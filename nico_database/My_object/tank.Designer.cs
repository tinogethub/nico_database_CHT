namespace nico_database.My_object
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
            this.animate = new System.Windows.Forms.PictureBox();
            this.axTank = new AxiProfessionalLibrary.AxiTankX();
            ((System.ComponentModel.ISupportInitialize)(this.animate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTank)).BeginInit();
            this.SuspendLayout();
            // 
            // animate
            // 
            this.animate.Image = ((System.Drawing.Image)(resources.GetObject("animate.Image")));
            this.animate.Location = new System.Drawing.Point(0, 102);
            this.animate.Name = "animate";
            this.animate.Size = new System.Drawing.Size(200, 20);
            this.animate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.animate.TabIndex = 0;
            this.animate.TabStop = false;
            // 
            // axTank
            // 
            this.axTank.Location = new System.Drawing.Point(70, 30);
            this.axTank.Name = "axTank";
            this.axTank.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTank.OcxState")));
            this.axTank.Size = new System.Drawing.Size(60, 120);
            this.axTank.TabIndex = 1;
            // 
            // tank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.axTank);
            this.Controls.Add(this.animate);
            this.Name = "tank";
            this.Size = new System.Drawing.Size(200, 178);
            ((System.ComponentModel.ISupportInitialize)(this.animate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTank)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox animate;
        private AxiProfessionalLibrary.AxiTankX axTank;
    }
}
