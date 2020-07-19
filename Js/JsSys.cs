using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ModbusSimJs.Js
{
    public class JsSys
    {
        public string Exec(string cmd, int waitMs = -1)
        {
            Process p = new Process();
            p.StartInfo.FileName = cmd;
            // p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;

            if (p.Start())
            {
                string output = p.StandardOutput.ReadToEnd();

                if (waitMs > 0)
                    p.WaitForExit(waitMs);
                else if (waitMs == 0)
                    p.WaitForExit();

                return output;
            }
            else
                return "";
        }

        public void Start()
        {

        }

    }
}
