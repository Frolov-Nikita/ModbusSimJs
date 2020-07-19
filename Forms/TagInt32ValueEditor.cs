﻿using System;
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
    public partial class TagInt32ValueEditor : Form
    {
        private readonly Tag tag;
        Int32 val;
        bool isValid = true;

        public TagInt32ValueEditor(Tag tag)
        {
            InitializeComponent();
            Text = tag.Name;
            val = (Int32)tag.Value;
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
            var text = textBox1.Text.Trim();

            if (Int32.TryParse(text, out Int32 tmp))
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
