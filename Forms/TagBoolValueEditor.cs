using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModbusSimJs.Forms
{
    public partial class TagBoolValueEditor : Form
    {
        private readonly Tag tag;
        bool val;

        bool Val { 
            get => (bool)tag.Value;
            set {
                tag.Value = value;

                if (value)
                {
                    buttonTrue.BackColor = Color.Green;
                    buttonFalse.BackColor = Color.WhiteSmoke;
                }
                else
                {
                    buttonTrue.BackColor = Color.WhiteSmoke;
                    buttonFalse.BackColor = Color.Green;
                }
            }
        }

        public TagBoolValueEditor(Tag tag)
        {
            InitializeComponent();
            Text = tag.Name;
            Val = (bool)tag.Value;
        }
        private void KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();

            switch (e.KeyValue)
            {
                case 't':
                case 'y':
                case '1':
                    Val = true;
                    break;
                case 'f':
                case 'n':
                case '0':
                    Val = false;
                    break;
            }
        }
    }
}
