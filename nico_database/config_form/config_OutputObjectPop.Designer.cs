namespace nico_database
{
    partial class config_OutputObjectPop
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
            this.inputVal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CMDApply
            // 
            this.CMDApply.Location = new System.Drawing.Point(135, 52);
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
            this.CMDCancel.Location = new System.Drawing.Point(15, 52);
            this.CMDCancel.Margin = new System.Windows.Forms.Padding(4);
            this.CMDCancel.Name = "CMDCancel";
            this.CMDCancel.Size = new System.Drawing.Size(112, 28);
            this.CMDCancel.TabIndex = 9;
            this.CMDCancel.Text = "cancel";
            this.CMDCancel.UseVisualStyleBackColor = true;
            this.CMDCancel.Click += new System.EventHandler(this.CMDCancel_Click);
            // 
            // inputVal
            // 
            this.inputVal.Location = new System.Drawing.Point(65, 12);
            this.inputVal.Name = "inputVal";
            this.inputVal.Size = new System.Drawing.Size(182, 24);
            this.inputVal.TabIndex = 11;
            this.inputVal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputVal_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "input :";
            // 
            // config_OutputObjectPop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(256, 91);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputVal);
            this.Controls.Add(this.CMDApply);
            this.Controls.Add(this.CMDCancel);
            this.Font = new System.Drawing.Font("Arial", 11F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "config_OutputObjectPop";
            this.Text = "config_OutputObjectPop";
            this.Load += new System.EventHandler(this.config_OutputObjectPop_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CMDApply;
        private System.Windows.Forms.Button CMDCancel;
        private System.Windows.Forms.TextBox inputVal;
        private System.Windows.Forms.Label label1;
    }
}