namespace ModbusSimJs
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.TabPanelVars = new System.Windows.Forms.TabControl();
            this.tabPageVarSrc = new System.Windows.Forms.TabPage();
            this.richTextBoxVar = new System.Windows.Forms.RichTextBox();
            this.tabPageVars = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItemNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStartStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonJsFileSelect = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRemoveJs = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRunLoop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonTcpConfog = new System.Windows.Forms.ToolStripButton();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.listViewConsole = new System.Windows.Forms.ListView();
            this.columnHeaderTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMsg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tagsView1 = new ModbusSimJs.Controls.TagsView();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.TabPanelVars.SuspendLayout();
            this.tabPageVarSrc.SuspendLayout();
            this.tabPageVars.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 364);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(561, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.TabPanelVars);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(561, 261);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(561, 286);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // TabPanelVars
            // 
            this.TabPanelVars.Controls.Add(this.tabPageVarSrc);
            this.TabPanelVars.Controls.Add(this.tabPageVars);
            this.TabPanelVars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabPanelVars.Location = new System.Drawing.Point(0, 0);
            this.TabPanelVars.Multiline = true;
            this.TabPanelVars.Name = "TabPanelVars";
            this.TabPanelVars.SelectedIndex = 0;
            this.TabPanelVars.Size = new System.Drawing.Size(561, 261);
            this.TabPanelVars.TabIndex = 4;
            this.TabPanelVars.SelectedIndexChanged += new System.EventHandler(this.TabPanelVars_SelectedIndexChanged);
            // 
            // tabPageVarSrc
            // 
            this.tabPageVarSrc.Controls.Add(this.richTextBoxVar);
            this.tabPageVarSrc.Location = new System.Drawing.Point(4, 22);
            this.tabPageVarSrc.Name = "tabPageVarSrc";
            this.tabPageVarSrc.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVarSrc.Size = new System.Drawing.Size(553, 235);
            this.tabPageVarSrc.TabIndex = 0;
            this.tabPageVarSrc.Text = "VarsSource";
            this.tabPageVarSrc.UseVisualStyleBackColor = true;
            // 
            // richTextBoxVar
            // 
            this.richTextBoxVar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxVar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxVar.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxVar.Name = "richTextBoxVar";
            this.richTextBoxVar.Size = new System.Drawing.Size(547, 229);
            this.richTextBoxVar.TabIndex = 3;
            this.richTextBoxVar.Text = resources.GetString("richTextBoxVar.Text");
            this.richTextBoxVar.WordWrap = false;
            // 
            // tabPageVars
            // 
            this.tabPageVars.Controls.Add(this.tagsView1);
            this.tabPageVars.Location = new System.Drawing.Point(4, 22);
            this.tabPageVars.Name = "tabPageVars";
            this.tabPageVars.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVars.Size = new System.Drawing.Size(553, 235);
            this.tabPageVars.TabIndex = 1;
            this.tabPageVars.Text = "VarsTable";
            this.tabPageVars.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton2,
            this.toolStripDropDownButton1,
            this.toolStripSeparator3,
            this.toolStripButton1,
            this.toolStripButtonStartStop,
            this.toolStripSeparator1,
            this.toolStripButtonJsFileSelect,
            this.toolStripButtonRemoveJs,
            this.toolStripButtonRunLoop,
            this.toolStripSeparator2,
            this.toolStripButtonTcpConfog});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(362, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemNew,
            this.toolStripMenuItemOpen});
            this.toolStripDropDownButton2.Image = global::ModbusSimJs.Properties.Resources.NewFile;
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton2.Text = "toolStripDropDownButton2";
            // 
            // toolStripMenuItemNew
            // 
            this.toolStripMenuItemNew.Name = "toolStripMenuItemNew";
            this.toolStripMenuItemNew.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemNew.Text = "New";
            // 
            // toolStripMenuItemOpen
            // 
            this.toolStripMenuItemOpen.Name = "toolStripMenuItemOpen";
            this.toolStripMenuItemOpen.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemOpen.Text = "Open";
            this.toolStripMenuItemOpen.Click += new System.EventHandler(this.toolStripMenuItemOpen_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemSave,
            this.toolStripMenuItemSaveAs});
            this.toolStripDropDownButton1.Image = global::ModbusSimJs.Properties.Resources.Save;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // toolStripMenuItemSave
            // 
            this.toolStripMenuItemSave.Name = "toolStripMenuItemSave";
            this.toolStripMenuItemSave.Size = new System.Drawing.Size(111, 22);
            this.toolStripMenuItemSave.Text = "Save";
            this.toolStripMenuItemSave.Click += new System.EventHandler(this.toolStripMenuItemSave_Click);
            // 
            // toolStripMenuItemSaveAs
            // 
            this.toolStripMenuItemSaveAs.Name = "toolStripMenuItemSaveAs";
            this.toolStripMenuItemSaveAs.Size = new System.Drawing.Size(111, 22);
            this.toolStripMenuItemSaveAs.Text = "SaveAs";
            this.toolStripMenuItemSaveAs.Click += new System.EventHandler(this.toolStripMenuItemSaveAs_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::ModbusSimJs.Properties.Resources.ImageCompile;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Compile";
            this.toolStripButton1.ToolTipText = "toolStripButtonCompile";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButtonStartStop
            // 
            this.toolStripButtonStartStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStartStop.ForeColor = System.Drawing.Color.DarkGreen;
            this.toolStripButtonStartStop.Image = global::ModbusSimJs.Properties.Resources.ImageStart;
            this.toolStripButtonStartStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStartStop.Name = "toolStripButtonStartStop";
            this.toolStripButtonStartStop.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonStartStop.Text = "Start";
            this.toolStripButtonStartStop.Click += new System.EventHandler(this.toolStripButtonStartStop_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonJsFileSelect
            // 
            this.toolStripButtonJsFileSelect.Image = global::ModbusSimJs.Properties.Resources.JsFile;
            this.toolStripButtonJsFileSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonJsFileSelect.Name = "toolStripButtonJsFileSelect";
            this.toolStripButtonJsFileSelect.Size = new System.Drawing.Size(54, 22);
            this.toolStripButtonJsFileSelect.Text = "JsFile";
            this.toolStripButtonJsFileSelect.Click += new System.EventHandler(this.toolStripButtonJsFileSelect_Click);
            // 
            // toolStripButtonRemoveJs
            // 
            this.toolStripButtonRemoveJs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonRemoveJs.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRemoveJs.Image")));
            this.toolStripButtonRemoveJs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRemoveJs.Name = "toolStripButtonRemoveJs";
            this.toolStripButtonRemoveJs.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRemoveJs.Text = "X";
            this.toolStripButtonRemoveJs.Click += new System.EventHandler(this.toolStripButtonRemoveJs_Click);
            // 
            // toolStripButtonRunLoop
            // 
            this.toolStripButtonRunLoop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonRunLoop.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRunLoop.Image")));
            this.toolStripButtonRunLoop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRunLoop.Name = "toolStripButtonRunLoop";
            this.toolStripButtonRunLoop.Size = new System.Drawing.Size(46, 22);
            this.toolStripButtonRunLoop.Text = "Loop()";
            this.toolStripButtonRunLoop.Click += new System.EventHandler(this.toolStripButtonRunLoop_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonTcpConfog
            // 
            this.toolStripButtonTcpConfog.Image = global::ModbusSimJs.Properties.Resources.Network;
            this.toolStripButtonTcpConfog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTcpConfog.Name = "toolStripButtonTcpConfog";
            this.toolStripButtonTcpConfog.Size = new System.Drawing.Size(105, 22);
            this.toolStripButtonTcpConfog.Text = "127.0.0.1:11502";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.toolStripContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.listViewConsole);
            this.splitContainer2.Size = new System.Drawing.Size(561, 364);
            this.splitContainer2.SplitterDistance = 286;
            this.splitContainer2.TabIndex = 6;
            // 
            // listViewConsole
            // 
            this.listViewConsole.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTime,
            this.columnHeaderCat,
            this.columnHeaderMsg});
            this.listViewConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewConsole.HideSelection = false;
            this.listViewConsole.Location = new System.Drawing.Point(0, 0);
            this.listViewConsole.Name = "listViewConsole";
            this.listViewConsole.Size = new System.Drawing.Size(561, 74);
            this.listViewConsole.TabIndex = 0;
            this.listViewConsole.UseCompatibleStateImageBehavior = false;
            this.listViewConsole.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderTime
            // 
            this.columnHeaderTime.Text = "Time";
            this.columnHeaderTime.Width = 50;
            // 
            // columnHeaderCat
            // 
            this.columnHeaderCat.Text = "Cat";
            this.columnHeaderCat.Width = 40;
            // 
            // columnHeaderMsg
            // 
            this.columnHeaderMsg.Text = "Message";
            this.columnHeaderMsg.Width = 400;
            // 
            // tagsView1
            // 
            this.tagsView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tagsView1.Location = new System.Drawing.Point(3, 3);
            this.tagsView1.Name = "tagsView1";
            this.tagsView1.Size = new System.Drawing.Size(547, 229);
            this.tagsView1.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 386);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FormMain";
            this.Text = "Симулятор modbus";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.TabPanelVars.ResumeLayout(false);
            this.tabPageVarSrc.ResumeLayout(false);
            this.tabPageVars.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonRunLoop;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView listViewConsole;
        private System.Windows.Forms.ColumnHeader columnHeaderTime;
        private System.Windows.Forms.ColumnHeader columnHeaderCat;
        private System.Windows.Forms.ColumnHeader columnHeaderMsg;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonStartStop;
        private System.Windows.Forms.RichTextBox richTextBoxVar;
        private System.Windows.Forms.ToolStripButton toolStripButtonJsFileSelect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonTcpConfog;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNew;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpen;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSave;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButtonRemoveJs;
        private System.Windows.Forms.TabControl TabPanelVars;
        private System.Windows.Forms.TabPage tabPageVarSrc;
        private System.Windows.Forms.TabPage tabPageVars;
        private Controls.TagsView tagsView1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}

