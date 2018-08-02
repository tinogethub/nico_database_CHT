namespace nico_database
{
    partial class input_name
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.CMDApply = new System.Windows.Forms.Button();
            this.CMDCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "input name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(98, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 24);
            this.textBox1.TabIndex = 1;
            // 
            // CMDApply
            // 
            this.CMDApply.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CMDApply.Location = new System.Drawing.Point(199, 49);
            this.CMDApply.Margin = new System.Windows.Forms.Padding(4);
            this.CMDApply.Name = "CMDApply";
            this.CMDApply.Size = new System.Drawing.Size(99, 27);
            this.CMDApply.TabIndex = 27;
            this.CMDApply.Text = "add";
            this.CMDApply.UseVisualStyleBackColor = true;
            // 
            // CMDCancel
            // 
            this.CMDCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CMDCancel.Location = new System.Drawing.Point(92, 49);
            this.CMDCancel.Margin = new System.Windows.Forms.Padding(4);
            this.CMDCancel.Name = "CMDCancel";
            this.CMDCancel.Size = new System.Drawing.Size(99, 27);
            this.CMDCancel.TabIndex = 26;
            this.CMDCancel.Text = "exit";
            this.CMDCancel.UseVisualStyleBackColor = true;
            // 
            // input_name
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(308, 83);
            this.Controls.Add(this.CMDApply);
            this.Controls.Add(this.CMDCancel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 11F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "input_name";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "input_name";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button CMDApply;
        private System.Windows.Forms.Button CMDCancel;
    }
}