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
    public partial class TagValueFloatEditor : UserControl
    {
        private readonly Tag tag;

        float tempVal;

        public TagValueFloatEditor(Tag tag)
        {
            InitializeComponent();
            this.tag = tag;
            tempVal = (float)tag.Value;
            textBox1.Text = tempVal.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            var text = textBox.Text;
            if(float.TryParse(text, out float newTmpVal))
            {
                tempVal = newTmpVal;
                textBox.BackColor = Color.White;
            }
            else
                textBox.BackColor = Color.Pink;
            
            
        }
    }
}
