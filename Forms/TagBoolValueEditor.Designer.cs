namespace ModbusSimJs.Forms
{
    partial class TagBoolValueEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonTrue = new System.Windows.Forms.Button();
            this.buttonFalse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonTrue
            // 
            this.buttonTrue.Location = new System.Drawing.Point(12, 12);
            this.buttonTrue.Name = "buttonTrue";
            this.buttonTrue.Size = new System.Drawing.Size(75, 23);
            this.buttonTrue.TabIndex = 0;
            this.buttonTrue.Text = "True";
            this.buttonTrue.UseVisualStyleBackColor = true;
            this.buttonTrue.Click += new System.EventHandler(this.buttonTrue_Click);
            // 
            // buttonFalse
            // 
            this.buttonFalse.Location = new System.Drawing.Point(96, 12);
            this.buttonFalse.Name = "buttonFalse";
            this.buttonFalse.Size = new System.Drawing.Size(75, 23);
            this.buttonFalse.TabIndex = 1;
            this.buttonFalse.Text = "False";
            this.buttonFalse.UseVisualStyleBackColor = true;
            this.buttonFalse.Click += new System.EventHandler(this.buttonFalse_Click);
            // 
            // TagBoolValueEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(183, 44);
            this.Controls.Add(this.buttonFalse);
            this.Controls.Add(this.buttonTrue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TagBoolValueEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "TagBoolValueEditor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonTrue;
        private System.Windows.Forms.Button buttonFalse;
    }
}