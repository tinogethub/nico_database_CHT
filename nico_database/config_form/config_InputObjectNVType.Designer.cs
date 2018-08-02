namespace nico_database
{
    partial class config_InputObjectNVType
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
            this.CMDApply = new System.Windows.Forms.Button();
            this.CMDCancel = new System.Windows.Forms.Button();
            this.NVType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CMDApply
            // 
            this.CMDApply.Location = new System.Drawing.Point(137, 59);
            this.CMDApply.Margin = new System.Windows.Forms.Padding(4);
            this.CMDApply.Name = "CMDApply";
            this.CMDApply.Size = new System.Drawing.Size(112, 28);
            this.CMDApply.TabIndex = 14;
            this.CMDApply.Text = "apply";
            this.CMDApply.UseVisualStyleBackColor = true;
            this.CMDApply.Click += new System.EventHandler(this.CMDApply_Click);
            // 
            // CMDCancel
            // 
            this.CMDCancel.Location = new System.Drawing.Point(17, 59);
            this.CMDCancel.Margin = new System.Windows.Forms.Padding(4);
            this.CMDCancel.Name = "CMDCancel";
            this.CMDCancel.Size = new System.Drawing.Size(112, 28);
            this.CMDCancel.TabIndex = 13;
            this.CMDCancel.Text = "cancel";
            this.CMDCancel.UseVisualStyleBackColor = true;
            this.CMDCancel.Click += new System.EventHandler(this.CMDCancel_Click);
            // 
            // NVType
            // 
            this.NVType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NVType.FormattingEnabled = true;
            this.NVType.Location = new System.Drawing.Point(85, 15);
            this.NVType.Name = "NVType";
            this.NVType.Size = new System.Drawing.Size(164, 25);
            this.NVType.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "tag type :";
            // 
            // config_InputObjectNVType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(257, 94);
            this.Controls.Add(this.CMDApply);
            this.Controls.Add(this.CMDCancel);
            this.Controls.Add(this.NVType);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 11F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "config_InputObjectNVType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "config_InputObjectNVType";
            this.Load += new System.EventHandler(this.config_InputObjectNVType_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CMDApply;
        private System.Windows.Forms.Button CMDCancel;
        private System.Windows.Forms.ComboBox NVType;
        private System.Windows.Forms.Label label1;
    }
}