namespace iocomp.MyObj
{
    partial class tank
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tank));
            this.axTank = new AxiProfessionalLibrary.AxiTankX();
            this.labName = new System.Windows.Forms.Label();
            this.labValue = new System.Windows.Forms.Label();
            this.pic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.axTank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // axTank
            // 
            this.axTank.Location = new System.Drawing.Point(70, 30);
            this.axTank.Name = "axTank";
            this.axTank.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTank.OcxState")));
            this.axTank.Size = new System.Drawing.Size(60, 120);
            this.axTank.TabIndex = 0;
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labName.Location = new System.Drawing.Point(81, 8);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(39, 19);
            this.labName.TabIndex = 1;
            this.labName.Text = "tank";
            this.labName.Paint += new System.Windows.Forms.PaintEventHandler(this.labName_Paint);
            // 
            // labValue
            // 
            this.labValue.AutoSize = true;
            this.labValue.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labValue.Location = new System.Drawing.Point(81, 153);
            this.labValue.Name = "labValue";
            this.labValue.Size = new System.Drawing.Size(49, 19);
            this.labValue.TabIndex = 2;
            this.labValue.Text = "100%";
            this.labValue.Paint += new System.Windows.Forms.PaintEventHandler(this.labValue_Paint);
            // 
            // pic
            // 
            this.pic.Image = ((System.Drawing.Image)(resources.GetObject("pic.Image")));
            this.pic.Location = new System.Drawing.Point(0, 102);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(200, 20);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic.TabIndex = 3;
            this.pic.TabStop = false;
            // 
            // tank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.axTank);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.labValue);
            this.Controls.Add(this.labName);
            this.Name = "tank";
            this.Size = new System.Drawing.Size(200, 178);
            ((System.ComponentModel.ISupportInitialize)(this.axTank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxiProfessionalLibrary.AxiTankX axTank;
        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.Label labValue;
        private System.Windows.Forms.PictureBox pic;
    }
}
