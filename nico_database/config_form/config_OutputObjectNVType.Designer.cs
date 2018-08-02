namespace nico_database
{
    partial class config_OutputObjectNVType
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
            this.NVType = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.RadioButton();
            this.CMDApply = new System.Windows.Forms.Button();
            this.CMDCancel = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "tag type :";
            // 
            // NVType
            // 
            this.NVType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NVType.FormattingEnabled = true;
            this.NVType.Location = new System.Drawing.Point(85, 21);
            this.NVType.Name = "NVType";
            this.NVType.Size = new System.Drawing.Size(164, 25);
            this.NVType.TabIndex = 1;
            this.NVType.SelectedIndexChanged += new System.EventHandler(this.NVType_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Checked = true;
            this.button1.Location = new System.Drawing.Point(85, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 21);
            this.button1.TabIndex = 2;
            this.button1.TabStop = true;
            this.button1.Text = "input textbox";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.CheckedChanged += new System.EventHandler(this.button1_CheckedChanged);
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.Location = new System.Drawing.Point(85, 88);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(66, 21);
            this.button2.TabIndex = 2;
            this.button2.Text = "button";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.CheckedChanged += new System.EventHandler(this.button1_CheckedChanged);
            // 
            // CMDApply
            // 
            this.CMDApply.Location = new System.Drawing.Point(135, 148);
            this.CMDApply.Margin = new System.Windows.Forms.Padding(4);
            this.CMDApply.Name = "CMDApply";
            this.CMDApply.Size = new System.Drawing.Size(112, 28);
            this.CMDApply.TabIndex = 10;
            this.CMDApply.Text = "apply";
            this.CMDApply.UseVisualStyleBackColor = true;
            this.CMDApply.Click += new System.EventHandler(this.CMDApply_Click);
            // 
            // CMDCancel
            // 
            this.CMDCancel.Location = new System.Drawing.Point(15, 148);
            this.CMDCancel.Margin = new System.Windows.Forms.Padding(4);
            this.CMDCancel.Name = "CMDCancel";
            this.CMDCancel.Size = new System.Drawing.Size(112, 28);
            this.CMDCancel.TabIndex = 9;
            this.CMDCancel.Text = "cancel";
            this.CMDCancel.UseVisualStyleBackColor = true;
            this.CMDCancel.Click += new System.EventHandler(this.CMDCancel_Click);
            // 
            // button3
            // 
            this.button3.AutoSize = true;
            this.button3.Location = new System.Drawing.Point(85, 115);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(84, 21);
            this.button3.TabIndex = 11;
            this.button3.Text = "pop form";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.CheckedChanged += new System.EventHandler(this.button1_CheckedChanged);
            // 
            // config_OutputObjectNVType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(259, 184);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.CMDApply);
            this.Controls.Add(this.CMDCancel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.NVType);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 11F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "config_OutputObjectNVType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "config_OutputObjectNVType";
            this.Load += new System.EventHandler(this.config_OutputObjectNVType_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox NVType;
        private System.Windows.Forms.RadioButton button1;
        private System.Windows.Forms.RadioButton button2;
        private System.Windows.Forms.Button CMDApply;
        private System.Windows.Forms.Button CMDCancel;
        private System.Windows.Forms.RadioButton button3;
    }
}