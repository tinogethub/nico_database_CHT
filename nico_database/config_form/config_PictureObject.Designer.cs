namespace nico_database
{
    partial class config_PictureObject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(config_PictureObject));
            this.openimage = new System.Windows.Forms.Button();
            this.imagePATH = new System.Windows.Forms.TextBox();
            this.preview = new System.Windows.Forms.PictureBox();
            this.cmdApply = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.textheight = new System.Windows.Forms.TextBox();
            this.textwidth = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textY = new System.Windows.Forms.TextBox();
            this.textX = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.preview)).BeginInit();
            this.SuspendLayout();
            // 
            // openimage
            // 
            this.openimage.Image = ((System.Drawing.Image)(resources.GetObject("openimage.Image")));
            this.openimage.Location = new System.Drawing.Point(407, 51);
            this.openimage.Name = "openimage";
            this.openimage.Size = new System.Drawing.Size(28, 36);
            this.openimage.TabIndex = 0;
            this.openimage.UseVisualStyleBackColor = true;
            this.openimage.Click += new System.EventHandler(this.openimage_Click);
            // 
            // imagePATH
            // 
            this.imagePATH.Location = new System.Drawing.Point(140, 7);
            this.imagePATH.Name = "imagePATH";
            this.imagePATH.Size = new System.Drawing.Size(354, 24);
            this.imagePATH.TabIndex = 1;
            // 
            // preview
            // 
            this.preview.Location = new System.Drawing.Point(6, 7);
            this.preview.Name = "preview";
            this.preview.Size = new System.Drawing.Size(128, 128);
            this.preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.preview.TabIndex = 2;
            this.preview.TabStop = false;
            // 
            // cmdApply
            // 
            this.cmdApply.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdApply.Location = new System.Drawing.Point(416, 109);
            this.cmdApply.Name = "cmdApply";
            this.cmdApply.Size = new System.Drawing.Size(78, 25);
            this.cmdApply.TabIndex = 31;
            this.cmdApply.Text = "apply";
            this.cmdApply.UseVisualStyleBackColor = true;
            this.cmdApply.Click += new System.EventHandler(this.cmdApply_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdCancel.Location = new System.Drawing.Point(333, 109);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(78, 25);
            this.cmdCancel.TabIndex = 30;
            this.cmdCancel.Text = "cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // textheight
            // 
            this.textheight.Location = new System.Drawing.Point(340, 73);
            this.textheight.Name = "textheight";
            this.textheight.Size = new System.Drawing.Size(45, 24);
            this.textheight.TabIndex = 67;
            this.textheight.Text = "0";
            // 
            // textwidth
            // 
            this.textwidth.Location = new System.Drawing.Point(340, 43);
            this.textwidth.Name = "textwidth";
            this.textwidth.Size = new System.Drawing.Size(45, 24);
            this.textwidth.TabIndex = 66;
            this.textwidth.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(279, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 17);
            this.label4.TabIndex = 65;
            this.label4.Text = "height :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(284, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 17);
            this.label5.TabIndex = 64;
            this.label5.Text = "width :";
            // 
            // textY
            // 
            this.textY.Location = new System.Drawing.Point(222, 73);
            this.textY.Name = "textY";
            this.textY.Size = new System.Drawing.Size(45, 24);
            this.textY.TabIndex = 63;
            this.textY.Text = "0";
            // 
            // textX
            // 
            this.textX.Location = new System.Drawing.Point(222, 43);
            this.textX.Name = "textX";
            this.textX.Size = new System.Drawing.Size(45, 24);
            this.textX.TabIndex = 62;
            this.textX.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(191, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 17);
            this.label3.TabIndex = 61;
            this.label3.Text = "Y :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(191, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 17);
            this.label1.TabIndex = 60;
            this.label1.Text = "X :";
            // 
            // config_PictureObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(499, 142);
            this.Controls.Add(this.textheight);
            this.Controls.Add(this.textwidth);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textY);
            this.Controls.Add(this.textX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdApply);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.preview);
            this.Controls.Add(this.imagePATH);
            this.Controls.Add(this.openimage);
            this.Font = new System.Drawing.Font("Arial", 11F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "config_PictureObject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "config_PictureObject";
            this.Load += new System.EventHandler(this.config_PictureObject_Load);
            ((System.ComponentModel.ISupportInitialize)(this.preview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openimage;
        private System.Windows.Forms.Button cmdApply;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.PictureBox preview;
        public System.Windows.Forms.TextBox imagePATH;
        public System.Windows.Forms.TextBox textheight;
        public System.Windows.Forms.TextBox textwidth;
        public System.Windows.Forms.TextBox textY;
        public System.Windows.Forms.TextBox textX;
    }
}