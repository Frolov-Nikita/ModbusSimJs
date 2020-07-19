using Microsoft.ClearScript;
using Microsoft.ClearScript.V8;
using NModbus;
using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModbusSimJs.Js;
using System.IO;
using System.Collections.Generic;

namespace ModbusSimJs
{
    public enum SvrState
    {
        Stopped,
        Starting,
        Runing,
        Stopping
    }

    public partial class FormMain : Form
    {
        JsFile jsFile = new JsFile();

        JsConsole jsConsole = new JsConsole();
        
        JsSys jsSys = new JsSys();

        SlaveStorage store = new SlaveStorage();

        readonly dynamic tags = new TagsList();

        int port = 11502;

        byte slaveId = 1;

        IPAddress address = new IPAddress(new byte[] { 127, 0, 0, 1 });

        TcpListener slaveTcpListener;

        IModbusFactory factory = new ModbusFactory();

        IModbusSlaveNetwork network;

        CancellationTokenSource cts;

        Task networkListenerTask;

        Task scriptLoopTask;

        SvrState state = SvrState.Stopped;

        long loopPeriodMs = 500;

        public FormMain()
        {
            InitializeComponent();
            jsConsole.ConsoleMessageEvent += JsConsole_ConsoleMessage;
            jsConsole.ConsoleClearEvent += JsConsole_ConsoleClear;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            loopPeriodMs = Properties.Settings.Default.LoopPeriodMs;
            LoadJsFile(Properties.Settings.Default.JsFile);
            LoadVarFile(Properties.Settings.Default.VarTxt);
        }

        void LoadJsFile(string fileName)
        {
            try
            {
                jsFile = new JsFile();
                if (string.IsNullOrEmpty(fileName))
                {
                    toolStripButtonJsFileSelect.Text = "...";
                    Properties.Settings.Default.JsFile = fileName;
                    Properties.Settings.Default.Save();
                    return;
                }

                var hosObjects = new Dictionary<string, object>
                {
                    {"Console", jsConsole },
                    {"Sys", jsSys },
                    {"Tags", tags },
                };

                jsFile.Load(fileName, hosObjects);
                toolStripButtonJsFileSelect.Text = fileName;
                Properties.Settings.Default.JsFile = fileName;
                Properties.Settings.Default.Save();
                toolStripButtonRunLoop.Enabled = true;
                toolStripButtonRemoveJs.Enabled = true;
            }
            catch (Exception ex)
            {
                jsConsole.error(ex);
                toolStripButtonJsFileSelect.Text = "...";
                toolStripButtonRunLoop.Enabled = false;
                toolStripButtonRemoveJs.Enabled = false;
            }
        }

        void LoadVarFile(string fileName)
        {
            try
            {
                richTextBoxVar.Text = File.ReadAllText(fileName);
                CompileTags(richTextBoxVar.Text);
                ColorizeTags();
            }            
            catch (Exception ex)
            {
                jsConsole.error(ex);
            }
        }

        private void ColorizeTags()
        {
            
        }

        private void JsConsole_ConsoleClear() 
        {
            listViewConsole.Items.Clear(); 
            listViewConsole.Refresh();
        }

        private void JsConsole_ConsoleMessage(consoleMessageType type, string msg)
        {
            var item = listViewConsole.Items.Add(DateTime.Now.ToString("HH:mm:ss"));
            var subItems = item.SubItems;
            subItems.Add(type.ToString());
            subItems.Add(msg);
            switch (type)
            {
                case consoleMessageType.log:
                    //item.BackColor = Color.White;
                    item.ForeColor = Color.Black;
                    break;
                case consoleMessageType.info:
                    //item.BackColor = Color.White;
                    item.ForeColor = Color.Blue;
                    break;
                case consoleMessageType.comment:
                    //item.BackColor = Color.White;
                    item.ForeColor = Color.DarkGray;
                    break;
                case consoleMessageType.warn:
                    //item.BackColor = Color.Yellow;
                    item.ForeColor = Color.DarkOrchid;
                    break;
                case consoleMessageType.error:
                    //item.BackColor = Color.Red;
                    item.ForeColor = Color.DarkRed;
                    break;
            }
            item.EnsureVisible();
        }

        private void CompileTags(string tagsList)
        {
            var lines = tagsList
                .Replace("\r\n", "\n")
                .Split('\n');

            tags.Clear();

            var descForNextLine = "";

            foreach (var line in lines)
            {
                if (line.Trim() == "") 
                {
                    descForNextLine = "";
                    continue;
                }

                if (line.Trim().StartsWith("//"))
                {
                    descForNextLine = descForNextLine == "" ? line : descForNextLine + "\r\n" + line;
                    continue;
                }

                if ((line.Length > 8) && TagInfo.TryParse(line, out TagInfo tagInfo)) 
                {
                    tagInfo.Description = tagInfo.Description == "" ? descForNextLine : descForNextLine + "\r\n" + tagInfo.Description;
                    tagInfo.Description = tagInfo.Description.Trim();
                    tags.Add(new Tag(tagInfo, store));
                }
                else
                {// Wrong tag definition
                    
                }

                descForNextLine = "";
            }


        }

        private async Task scriptLoop(CancellationToken token)
        {
            TimeSpan period = TimeSpan.FromMilliseconds(loopPeriodMs);
            TimeSpan dPeriod = TimeSpan.FromMilliseconds(10);
            TimeSpan sleepTime;
            DateTime nextTime;
            try
            {
                while(!token.IsCancellationRequested)
                {
                    nextTime = DateTime.Now + period;
                
                    jsFile.Loop();

                    sleepTime = nextTime - DateTime.Now;
                    if (sleepTime.TotalMilliseconds > 0)
                        await Task.Delay(sleepTime, token);
                    else
                    {
                        period = DateTime.Now - (nextTime - period) + dPeriod;
                        JsConsole_ConsoleMessage(consoleMessageType.warn, $"Loop() is too long. Period insceaced{period}");
                    }
                }
            }
            catch (TaskCanceledException)
            {
                JsConsole_ConsoleMessage(consoleMessageType.comment, $"Loop() stopped.");
            }
            catch (Exception ex)
            {
                JsConsole_ConsoleMessage(consoleMessageType.error, $"Error in Loop() {ex.Message}");
                Stop();
            }
        }

        private void Start()
        {
            try
            {
                CompileTags(richTextBoxVar.Text);

                tagsView1.Load(tags);

                state = SvrState.Starting;

                cts = new CancellationTokenSource();
                slaveTcpListener = new TcpListener(address, port);
                slaveTcpListener.Start();
                network = factory.CreateSlaveNetwork(slaveTcpListener);

                var slave1 = factory.CreateSlave(slaveId, store);

                network.AddSlave(slave1);

                networkListenerTask = network.ListenAsync(cts.Token);

                scriptLoopTask = scriptLoop(cts.Token);

                state = SvrState.Runing;
            }
            catch (Exception ex)
            {
                jsConsole.error(ex);
                state = SvrState.Stopped;
                cts?.Cancel();
                network.Dispose();
                slaveTcpListener?.Stop();
                scriptLoopTask.Wait(100);
                scriptLoopTask.Dispose();
            }
        }

        private void Stop()
        {
            state = SvrState.Stopping;
            cts.Cancel();
            network.Dispose();
            slaveTcpListener.Stop();
            scriptLoopTask.Wait(100);
            scriptLoopTask.Dispose();

            state = SvrState.Stopped;
        }

        private void toolStripButtonRunLoop_Click(object sender, EventArgs e)
        {
            try
            {
                jsFile.Loop();
            }
            catch (Exception ex)
            {
                JsConsole_ConsoleMessage(consoleMessageType.error, "error. \r\n" + ex.Message);
            }
        }

        private void toolStripButtonStartStop_Click(object sender, EventArgs e)
        {

            if(state == SvrState.Stopped)
            {
                JsConsole_ConsoleClear();

                Start();

                JsConsole_ConsoleMessage(consoleMessageType.info, $"Started at {address}:{port}. Tags {tags.Count}");
                toolStripButtonStartStop.Image = Properties.Resources.ImageStop;
                toolStripButtonStartStop.Text = "Stop";
                toolStripButtonStartStop.ForeColor = Color.DarkRed;
            }
            else
            {
                Stop();

                toolStripButtonStartStop.Image = Properties.Resources.ImageStart;
                toolStripButtonStartStop.Text = "Start";
                toolStripButtonStartStop.ForeColor = Color.DarkGreen;

                JsConsole_ConsoleMessage(consoleMessageType.info, $"Stopped");
            }

            Thread.Sleep(250);
        }

        private void toolStripButtonJsFileSelect_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "*.js|*.js";
            if(openFileDialog.ShowDialog() == DialogResult.OK)
                LoadJsFile(openFileDialog.FileName);
        }

        private void toolStripButtonRemoveJs_Click(object sender, EventArgs e)
        {
            LoadJsFile(null);
        }
    }
}

