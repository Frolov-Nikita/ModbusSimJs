using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModbusSimJs.Controls
{
    public partial class TcpParams : UserControl
    {

        public int Port { 
            get => (int)numericUpDownPort.Value; 
            set => numericUpDownPort.Value = value; }

        public string Host { 
            get => textBoxHost.Text; 
            set => textBoxHost.Text = value; }

        public TcpParams()
        {
            InitializeComponent();
        }
    }
}
