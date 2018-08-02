namespace nico_database
{
    partial class Device_manager
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("area1");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("fab1", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("site1", new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DeviceListTree = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.DeviceCPType = new System.Windows.Forms.TextBox();
            this.DeviceCPdescription = new System.Windows.Forms.TextBox();
            this.DeviceCPip = new System.Windows.Forms.TextBox();
            this.DeviceCPName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DeviceCPApply = new System.Windows.Forms.Button();
            this.DeviceCPCancel = new System.Windows.Forms.Button();
            this.DeviceCPNVProportion_A = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DeviceCPNVproportional_f = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DeviceTreeRightMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewSiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewFabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.DeviceTreeRightMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DeviceListTree);
            this.groupBox1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox1.Location = new System.Drawing.Point(11, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(508, 621);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Device list";
            // 
            // DeviceListTree
            // 
            this.DeviceListTree.Location = new System.Drawing.Point(7, 24);
            this.DeviceListTree.Name = "DeviceListTree";
            treeNode1.Name = "area1";
            treeNode1.Text = "area1";
            treeNode2.Name = "fab1";
            treeNode2.Text = "fab1";
            treeNode3.Name = "site1";
            treeNode3.Text = "site1";
            this.DeviceListTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.DeviceListTree.ShowNodeToolTips = true;
            this.DeviceListTree.Size = new System.Drawing.Size(493, 590);
            this.DeviceListTree.TabIndex = 0;
            this.DeviceListTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.DeviceListTree_AfterSelect);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.DeviceCPType);
            this.groupBox2.Controls.Add(this.DeviceCPdescription);
            this.groupBox2.Controls.Add(this.DeviceCPip);
            this.groupBox2.Controls.Add(this.DeviceCPName);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.DeviceCPApply);
            this.groupBox2.Controls.Add(this.DeviceCPNVProportion_A);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.DeviceCPNVproportional_f);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox2.Location = new System.Drawing.Point(527, 11);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(442, 327);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Config property";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(444, 639);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 32;
            this.button1.Text = "apply";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(178, 210);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 17);
            this.label8.TabIndex = 31;
            this.label8.Text = "(default = 1)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(200, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 17);
            this.label7.TabIndex = 30;
            this.label7.Text = "(default = 3000)";
            // 
            // DeviceCPType
            // 
            this.DeviceCPType.Enabled = false;
            this.DeviceCPType.Location = new System.Drawing.Point(140, 141);
            this.DeviceCPType.Name = "DeviceCPType";
            this.DeviceCPType.ReadOnly = true;
            this.DeviceCPType.Size = new System.Drawing.Size(54, 24);
            this.DeviceCPType.TabIndex = 29;
            this.DeviceCPType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DeviceCPdescription
            // 
            this.DeviceCPdescription.Enabled = false;
            this.DeviceCPdescription.Location = new System.Drawing.Point(140, 108);
            this.DeviceCPdescription.Name = "DeviceCPdescription";
            this.DeviceCPdescription.Size = new System.Drawing.Size(235, 24);
            this.DeviceCPdescription.TabIndex = 28;
            // 
            // DeviceCPip
            // 
            this.DeviceCPip.Enabled = false;
            this.DeviceCPip.Location = new System.Drawing.Point(140, 75);
            this.DeviceCPip.Name = "DeviceCPip";
            this.DeviceCPip.Size = new System.Drawing.Size(118, 24);
            this.DeviceCPip.TabIndex = 27;
            // 
            // DeviceCPName
            // 
            this.DeviceCPName.Enabled = false;
            this.DeviceCPName.Location = new System.Drawing.Point(140, 42);
            this.DeviceCPName.Name = "DeviceCPName";
            this.DeviceCPName.Size = new System.Drawing.Size(159, 24);
            this.DeviceCPName.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(22, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 17);
            this.label6.TabIndex = 25;
            this.label6.Text = "device protocol :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(49, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 17);
            this.label5.TabIndex = 24;
            this.label5.Text = "description :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(52, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 17);
            this.label4.TabIndex = 23;
            this.label4.Text = "ip address :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(83, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "name :";
            // 
            // DeviceCPApply
            // 
            this.DeviceCPApply.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DeviceCPApply.Location = new System.Drawing.Point(319, 41);
            this.DeviceCPApply.Name = "DeviceCPApply";
            this.DeviceCPApply.Size = new System.Drawing.Size(56, 25);
            this.DeviceCPApply.TabIndex = 21;
            this.DeviceCPApply.Text = "edit";
            this.DeviceCPApply.UseVisualStyleBackColor = true;
            this.DeviceCPApply.Click += new System.EventHandler(this.DeviceCPApply_Click);
            // 
            // DeviceCPCancel
            // 
            this.DeviceCPCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DeviceCPCancel.Location = new System.Drawing.Point(363, 639);
            this.DeviceCPCancel.Name = "DeviceCPCancel";
            this.DeviceCPCancel.Size = new System.Drawing.Size(75, 25);
            this.DeviceCPCancel.TabIndex = 20;
            this.DeviceCPCancel.Text = "cancel";
            this.DeviceCPCancel.UseVisualStyleBackColor = true;
            this.DeviceCPCancel.Click += new System.EventHandler(this.DeviceCPCancel_Click);
            // 
            // DeviceCPNVProportion_A
            // 
            this.DeviceCPNVProportion_A.Enabled = false;
            this.DeviceCPNVProportion_A.Location = new System.Drawing.Point(140, 207);
            this.DeviceCPNVProportion_A.Name = "DeviceCPNVProportion_A";
            this.DeviceCPNVProportion_A.Size = new System.Drawing.Size(32, 24);
            this.DeviceCPNVProportion_A.TabIndex = 19;
            this.DeviceCPNVProportion_A.Text = "1";
            this.DeviceCPNVProportion_A.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(36, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Proportion_A :";
            // 
            // DeviceCPNVproportional_f
            // 
            this.DeviceCPNVproportional_f.Enabled = false;
            this.DeviceCPNVproportional_f.Location = new System.Drawing.Point(140, 174);
            this.DeviceCPNVproportional_f.Name = "DeviceCPNVproportional_f";
            this.DeviceCPNVproportional_f.Size = new System.Drawing.Size(54, 24);
            this.DeviceCPNVproportional_f.TabIndex = 17;
            this.DeviceCPNVproportional_f.Text = "3000";
            this.DeviceCPNVproportional_f.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(30, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "proportional_f :";
            // 
            // DeviceTreeRightMenu
            // 
            this.DeviceTreeRightMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewSiteToolStripMenuItem,
            this.addNewFabToolStripMenuItem,
            this.delToolStripMenuItem});
            this.DeviceTreeRightMenu.Name = "DeviceTreeRightMenu";
            this.DeviceTreeRightMenu.Size = new System.Drawing.Size(148, 70);
            // 
            // addNewSiteToolStripMenuItem
            // 
            this.addNewSiteToolStripMenuItem.Name = "addNewSiteToolStripMenuItem";
            this.addNewSiteToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.addNewSiteToolStripMenuItem.Text = "add new site";
            this.addNewSiteToolStripMenuItem.Click += new System.EventHandler(this.addNewSiteToolStripMenuItem_Click);
            // 
            // addNewFabToolStripMenuItem
            // 
            this.addNewFabToolStripMenuItem.Name = "addNewFabToolStripMenuItem";
            this.addNewFabToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.addNewFabToolStripMenuItem.Text = "add new fab";
            this.addNewFabToolStripMenuItem.Click += new System.EventHandler(this.addNewFabToolStripMenuItem_Click);
            // 
            // delToolStripMenuItem
            // 
            this.delToolStripMenuItem.Name = "delToolStripMenuItem";
            this.delToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.delToolStripMenuItem.Text = "del";
            this.delToolStripMenuItem.Click += new System.EventHandler(this.delToolStripMenuItem_Click);
            // 
            // Device_manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 672);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DeviceCPCancel);
            this.Font = new System.Drawing.Font("Arial", 11F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Device_manager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Device_manager";
            this.Load += new System.EventHandler(this.Device_manager_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.DeviceTreeRightMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox DeviceCPType;
        private System.Windows.Forms.TextBox DeviceCPdescription;
        private System.Windows.Forms.TextBox DeviceCPip;
        private System.Windows.Forms.TextBox DeviceCPName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button DeviceCPApply;
        private System.Windows.Forms.Button DeviceCPCancel;
        private System.Windows.Forms.TextBox DeviceCPNVProportion_A;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DeviceCPNVproportional_f;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip DeviceTreeRightMenu;
        private System.Windows.Forms.ToolStripMenuItem addNewSiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewFabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem delToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TreeView DeviceListTree;
    }
}