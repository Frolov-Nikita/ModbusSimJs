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
    public partial class TagFloatValueEditor : Form
    {
        private readonly Tag tag;
        float val;
        bool isValid = true;

        public TagFloatValueEditor(Tag tag)
        {
            InitializeComponent();
            Text = tag.Name;
            val = (float)tag.Value;
            textBox1.Text = val.ToString();
            this.tag = tag;
            textBox1.Focus();
        }

        void WriteTag() 
        {
            tag.Value = val;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WriteTag();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var sep = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;

            var text = textBox1.Text.Trim()
                .Replace(".", sep)
                .Replace(",", sep);

            if (float.TryParse(text, out float tmp))
            {
                val = tmp;
                isValid = true;
                textBox1.BackColor = Color.White;
            }
            else
            {
                isValid = false;
                textBox1.BackColor = Color.Red;
            }
        }

        private void KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    WriteTag();
                    if (e.Modifiers == Keys.Control)
                        Close();
                    break;
                case Keys.Escape:
                    Close();
                    break;
            }
        }
    }
}
