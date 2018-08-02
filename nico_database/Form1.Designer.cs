namespace nico_database
{
    partial class Form1
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

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Mainmenu = new System.Windows.Forms.MenuStrip();
            this.fileTool = new System.Windows.Forms.ToolStripMenuItem();
            this.newProject = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.saveProject = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsProject = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.loadProject = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitProject = new System.Windows.Forms.ToolStripMenuItem();
            this.deviceTool = new System.Windows.Forms.ToolStripMenuItem();
            this.managaneTool = new System.Windows.Forms.ToolStripMenuItem();
            this.layerTool = new System.Windows.Forms.ToolStripMenuItem();
            this.layerEditTool = new System.Windows.Forms.ToolStripMenuItem();
            this.optionTool = new System.Windows.Forms.ToolStripMenuItem();
            this.emailTool = new System.Windows.Forms.ToolStripMenuItem();
            this.emailManaganeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Mainstatus = new System.Windows.Forms.StatusStrip();
            this.activeMode = new System.Windows.Forms.ToolStripStatusLabel();
            this.project_lab = new System.Windows.Forms.ToolStripStatusLabel();
            this.user_lab = new System.Windows.Forms.ToolStripStatusLabel();
            this.level_lab = new System.Windows.Forms.ToolStripStatusLabel();
            this.db_lab = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.Maintool = new System.Windows.Forms.ToolStrip();
            this.RunMode = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.LockObj = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.LayerListSelect = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.delSelectObj = new System.Windows.Forms.ToolStripButton();
            this.AddObjText = new System.Windows.Forms.ToolStripButton();
            this.AddObjButton = new System.Windows.Forms.ToolStripButton();
            this.AddObjPicture = new System.Windows.Forms.ToolStripButton();
            this.AddObjInput = new System.Windows.Forms.ToolStripButton();
            this.AddObjOutput = new System.Windows.Forms.ToolStripButton();
            this.AddObjTank = new System.Windows.Forms.ToolStripButton();
            this.AddObjAlarm = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.iconRightMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputTagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alarmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.configureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.duplicatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SystemTimer = new System.ComponentModel.BackgroundWorker();
            this.AlarmMonitor = new System.ComponentModel.BackgroundWorker();
            this.Alarm = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.NVMonitor = new System.ComponentModel.BackgroundWorker();
            this.ReadAllNV = new System.ComponentModel.BackgroundWorker();
            this.Mainmenu.SuspendLayout();
            this.Mainstatus.SuspendLayout();
            this.Maintool.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.iconRightMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Mainmenu
            // 
            this.Mainmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileTool,
            this.deviceTool,
            this.layerTool,
            this.optionTool});
            this.Mainmenu.Location = new System.Drawing.Point(0, 0);
            this.Mainmenu.Name = "Mainmenu";
            this.Mainmenu.Size = new System.Drawing.Size(1008, 24);
            this.Mainmenu.TabIndex = 0;
            this.Mainmenu.Text = "menuStrip1";
            this.Mainmenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Mainmenu_ItemClicked);
            // 
            // fileTool
            // 
            this.fileTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProject,
            this.toolStripSeparator5,
            this.saveProject,
            this.saveAsProject,
            this.toolStripSeparator4,
            this.loadProject,
            this.toolStripSeparator3,
            this.exitProject});
            this.fileTool.Name = "fileTool";
            this.fileTool.Size = new System.Drawing.Size(38, 20);
            this.fileTool.Text = "File";
            this.fileTool.Click += new System.EventHandler(this.fileTool_Click);
            // 
            // newProject
            // 
            this.newProject.Enabled = false;
            this.newProject.Name = "newProject";
            this.newProject.Size = new System.Drawing.Size(152, 22);
            this.newProject.Text = "new";
            this.newProject.Click += new System.EventHandler(this.newProject_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(149, 6);
            // 
            // saveProject
            // 
            this.saveProject.Enabled = false;
            this.saveProject.Name = "saveProject";
            this.saveProject.Size = new System.Drawing.Size(152, 22);
            this.saveProject.Text = "save";
            this.saveProject.Click += new System.EventHandler(this.saveProject_Click);
            // 
            // saveAsProject
            // 
            this.saveAsProject.Enabled = false;
            this.saveAsProject.Name = "saveAsProject";
            this.saveAsProject.Size = new System.Drawing.Size(152, 22);
            this.saveAsProject.Text = "save as";
            this.saveAsProject.Click += new System.EventHandler(this.saveAsProject_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(149, 6);
            // 
            // loadProject
            // 
            this.loadProject.Enabled = false;
            this.loadProject.Name = "loadProject";
            this.loadProject.Size = new System.Drawing.Size(152, 22);
            this.loadProject.Text = "load";
            this.loadProject.Click += new System.EventHandler(this.loadProject_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // exitProject
            // 
            this.exitProject.Name = "exitProject";
            this.exitProject.Size = new System.Drawing.Size(152, 22);
            this.exitProject.Text = "exit";
            this.exitProject.Click += new System.EventHandler(this.exitProject_Click);
            // 
            // deviceTool
            // 
            this.deviceTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.managaneTool});
            this.deviceTool.Enabled = false;
            this.deviceTool.Name = "deviceTool";
            this.deviceTool.Size = new System.Drawing.Size(57, 20);
            this.deviceTool.Text = "Device";
            // 
            // managaneTool
            // 
            this.managaneTool.Name = "managaneTool";
            this.managaneTool.Size = new System.Drawing.Size(165, 22);
            this.managaneTool.Text = "device manager";
            this.managaneTool.Click += new System.EventHandler(this.managaneTool_Click);
            // 
            // layerTool
            // 
            this.layerTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.layerEditTool});
            this.layerTool.Enabled = false;
            this.layerTool.Name = "layerTool";
            this.layerTool.Size = new System.Drawing.Size(49, 20);
            this.layerTool.Text = "Layer";
            // 
            // layerEditTool
            // 
            this.layerEditTool.Name = "layerEditTool";
            this.layerEditTool.Size = new System.Drawing.Size(158, 22);
            this.layerEditTool.Text = "Layer manager";
            this.layerEditTool.Click += new System.EventHandler(this.layerEditTool_Click);
            // 
            // optionTool
            // 
            this.optionTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emailTool,
            this.emailManaganeToolStripMenuItem,
            this.databaseSettingToolStripMenuItem,
            this.accountManagerToolStripMenuItem});
            this.optionTool.Enabled = false;
            this.optionTool.Name = "optionTool";
            this.optionTool.Size = new System.Drawing.Size(59, 20);
            this.optionTool.Text = "Option";
            // 
            // emailTool
            // 
            this.emailTool.Name = "emailTool";
            this.emailTool.Size = new System.Drawing.Size(173, 22);
            this.emailTool.Text = "SMTP setting";
            this.emailTool.Click += new System.EventHandler(this.emailTool_Click);
            // 
            // emailManaganeToolStripMenuItem
            // 
            this.emailManaganeToolStripMenuItem.Name = "emailManaganeToolStripMenuItem";
            this.emailManaganeToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.emailManaganeToolStripMenuItem.Text = "email manager";
            this.emailManaganeToolStripMenuItem.Click += new System.EventHandler(this.emailManaganeToolStripMenuItem_Click);
            // 
            // databaseSettingToolStripMenuItem
            // 
            this.databaseSettingToolStripMenuItem.Name = "databaseSettingToolStripMenuItem";
            this.databaseSettingToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.databaseSettingToolStripMenuItem.Text = "database setting";
            this.databaseSettingToolStripMenuItem.Click += new System.EventHandler(this.databaseSettingToolStripMenuItem_Click);
            // 
            // accountManagerToolStripMenuItem
            // 
            this.accountManagerToolStripMenuItem.Name = "accountManagerToolStripMenuItem";
            this.accountManagerToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.accountManagerToolStripMenuItem.Text = "account manager";
            this.accountManagerToolStripMenuItem.Click += new System.EventHandler(this.accountManagerToolStripMenuItem_Click);
            // 
            // Mainstatus
            // 
            this.Mainstatus.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.Mainstatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activeMode,
            this.project_lab,
            this.user_lab,
            this.level_lab,
            this.db_lab,
            this.toolStripStatusLabel2,
            this.StatusTime});
            this.Mainstatus.Location = new System.Drawing.Point(0, 704);
            this.Mainstatus.Name = "Mainstatus";
            this.Mainstatus.Size = new System.Drawing.Size(1008, 26);
            this.Mainstatus.TabIndex = 1;
            this.Mainstatus.Text = "statusStrip1";
            // 
            // activeMode
            // 
            this.activeMode.AutoSize = false;
            this.activeMode.Font = new System.Drawing.Font("Arial", 11F);
            this.activeMode.ForeColor = System.Drawing.Color.DarkRed;
            this.activeMode.Name = "activeMode";
            this.activeMode.Size = new System.Drawing.Size(120, 21);
            this.activeMode.Text = "edit mode...";
            // 
            // project_lab
            // 
            this.project_lab.AutoSize = false;
            this.project_lab.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.project_lab.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.project_lab.Font = new System.Drawing.Font("Arial", 11F);
            this.project_lab.Name = "project_lab";
            this.project_lab.Size = new System.Drawing.Size(200, 21);
            this.project_lab.Text = "project : none";
            this.project_lab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // user_lab
            // 
            this.user_lab.AutoSize = false;
            this.user_lab.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.user_lab.Font = new System.Drawing.Font("Arial", 11F);
            this.user_lab.Name = "user_lab";
            this.user_lab.Size = new System.Drawing.Size(140, 21);
            this.user_lab.Text = "user : none";
            this.user_lab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // level_lab
            // 
            this.level_lab.AutoSize = false;
            this.level_lab.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.level_lab.Font = new System.Drawing.Font("Arial", 11F);
            this.level_lab.Name = "level_lab";
            this.level_lab.Size = new System.Drawing.Size(140, 21);
            this.level_lab.Text = "level : none";
            this.level_lab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // db_lab
            // 
            this.db_lab.Name = "db_lab";
            this.db_lab.Size = new System.Drawing.Size(112, 21);
            this.db_lab.Text = "database ip : none";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.toolStripStatusLabel2.IsLink = true;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(214, 21);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // StatusTime
            // 
            this.StatusTime.AutoToolTip = true;
            this.StatusTime.Font = new System.Drawing.Font("Arial", 11F);
            this.StatusTime.Name = "StatusTime";
            this.StatusTime.Size = new System.Drawing.Size(36, 21);
            this.StatusTime.Text = "time";
            // 
            // Maintool
            // 
            this.Maintool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RunMode,
            this.toolStripSeparator1,
            this.LockObj,
            this.toolStripLabel1,
            this.LayerListSelect,
            this.toolStripSeparator2,
            this.delSelectObj,
            this.AddObjText,
            this.AddObjButton,
            this.AddObjPicture,
            this.AddObjInput,
            this.AddObjOutput,
            this.AddObjTank,
            this.AddObjAlarm,
            this.toolStripSeparator8,
            this.toolStripButton1});
            this.Maintool.Location = new System.Drawing.Point(0, 24);
            this.Maintool.Name = "Maintool";
            this.Maintool.Size = new System.Drawing.Size(1008, 25);
            this.Maintool.TabIndex = 2;
            this.Maintool.Text = "toolStrip1";
            // 
            // RunMode
            // 
            this.RunMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RunMode.Enabled = false;
            this.RunMode.Image = ((System.Drawing.Image)(resources.GetObject("RunMode.Image")));
            this.RunMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RunMode.Name = "RunMode";
            this.RunMode.Size = new System.Drawing.Size(23, 22);
            this.RunMode.Text = "toolStripButton1";
            this.RunMode.ToolTipText = "Run";
            this.RunMode.Click += new System.EventHandler(this.RunMode_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // LockObj
            // 
            this.LockObj.Checked = true;
            this.LockObj.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LockObj.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LockObj.Enabled = false;
            this.LockObj.Image = ((System.Drawing.Image)(resources.GetObject("LockObj.Image")));
            this.LockObj.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LockObj.Name = "LockObj";
            this.LockObj.Size = new System.Drawing.Size(23, 22);
            this.LockObj.Text = "toolStripButton1";
            this.LockObj.ToolTipText = "icon status : lock ";
            this.LockObj.Click += new System.EventHandler(this.LockObj_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(46, 22);
            this.toolStripLabel1.Text = " Layer :";
            // 
            // LayerListSelect
            // 
            this.LayerListSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LayerListSelect.Enabled = false;
            this.LayerListSelect.Items.AddRange(new object[] {
            "0"});
            this.LayerListSelect.Name = "LayerListSelect";
            this.LayerListSelect.Size = new System.Drawing.Size(200, 25);
            this.LayerListSelect.SelectedIndexChanged += new System.EventHandler(this.LayerListSelect_SelectedIndexChanged);
            this.LayerListSelect.Click += new System.EventHandler(this.LayerListSelect_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // delSelectObj
            // 
            this.delSelectObj.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.delSelectObj.Enabled = false;
            this.delSelectObj.Image = ((System.Drawing.Image)(resources.GetObject("delSelectObj.Image")));
            this.delSelectObj.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.delSelectObj.Name = "delSelectObj";
            this.delSelectObj.Size = new System.Drawing.Size(23, 22);
            this.delSelectObj.Text = "toolStripButton1";
            this.delSelectObj.ToolTipText = "delete object";
            this.delSelectObj.Click += new System.EventHandler(this.delSelectObj_Click);
            // 
            // AddObjText
            // 
            this.AddObjText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddObjText.Enabled = false;
            this.AddObjText.Image = ((System.Drawing.Image)(resources.GetObject("AddObjText.Image")));
            this.AddObjText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddObjText.Name = "AddObjText";
            this.AddObjText.Size = new System.Drawing.Size(23, 22);
            this.AddObjText.Text = "toolStripButton3";
            this.AddObjText.ToolTipText = "add new text object";
            this.AddObjText.Click += new System.EventHandler(this.AddObjText_Click);
            // 
            // AddObjButton
            // 
            this.AddObjButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddObjButton.Enabled = false;
            this.AddObjButton.Image = ((System.Drawing.Image)(resources.GetObject("AddObjButton.Image")));
            this.AddObjButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddObjButton.Name = "AddObjButton";
            this.AddObjButton.Size = new System.Drawing.Size(23, 22);
            this.AddObjButton.Text = "toolStripButton4";
            this.AddObjButton.ToolTipText = "add new button object";
            this.AddObjButton.Click += new System.EventHandler(this.AddObjButton_Click);
            // 
            // AddObjPicture
            // 
            this.AddObjPicture.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddObjPicture.Enabled = false;
            this.AddObjPicture.Image = ((System.Drawing.Image)(resources.GetObject("AddObjPicture.Image")));
            this.AddObjPicture.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddObjPicture.Name = "AddObjPicture";
            this.AddObjPicture.Size = new System.Drawing.Size(23, 22);
            this.AddObjPicture.Text = "picture icon";
            this.AddObjPicture.ToolTipText = "add new picture object";
            this.AddObjPicture.Click += new System.EventHandler(this.AddObjPicture_Click);
            // 
            // AddObjInput
            // 
            this.AddObjInput.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddObjInput.Enabled = false;
            this.AddObjInput.Image = ((System.Drawing.Image)(resources.GetObject("AddObjInput.Image")));
            this.AddObjInput.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddObjInput.Name = "AddObjInput";
            this.AddObjInput.Size = new System.Drawing.Size(23, 22);
            this.AddObjInput.Text = "toolStripButton1";
            this.AddObjInput.ToolTipText = "add new input tag object";
            this.AddObjInput.Click += new System.EventHandler(this.AddObjInput_Click);
            // 
            // AddObjOutput
            // 
            this.AddObjOutput.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddObjOutput.Enabled = false;
            this.AddObjOutput.Image = ((System.Drawing.Image)(resources.GetObject("AddObjOutput.Image")));
            this.AddObjOutput.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddObjOutput.Name = "AddObjOutput";
            this.AddObjOutput.Size = new System.Drawing.Size(23, 22);
            this.AddObjOutput.Text = "toolStripButton1";
            this.AddObjOutput.ToolTipText = "add new output tag object";
            this.AddObjOutput.Click += new System.EventHandler(this.AddObjOutput_Click);
            // 
            // AddObjTank
            // 
            this.AddObjTank.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddObjTank.Image = ((System.Drawing.Image)(resources.GetObject("AddObjTank.Image")));
            this.AddObjTank.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddObjTank.Name = "AddObjTank";
            this.AddObjTank.Size = new System.Drawing.Size(23, 22);
            this.AddObjTank.Text = "toolStripButton2";
            this.AddObjTank.ToolTipText = "add new tank tag object";
            this.AddObjTank.Click += new System.EventHandler(this.AddObjTank_Click);
            // 
            // AddObjAlarm
            // 
            this.AddObjAlarm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddObjAlarm.Enabled = false;
            this.AddObjAlarm.Image = ((System.Drawing.Image)(resources.GetObject("AddObjAlarm.Image")));
            this.AddObjAlarm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddObjAlarm.Name = "AddObjAlarm";
            this.AddObjAlarm.Size = new System.Drawing.Size(23, 22);
            this.AddObjAlarm.Text = "toolStripButton1";
            this.AddObjAlarm.ToolTipText = "add new alarm object";
            this.AddObjAlarm.Click += new System.EventHandler(this.AddObjAlarm_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "account login";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ContextMenuStrip = this.iconRightMenu;
            this.pictureBox1.Location = new System.Drawing.Point(0, 50);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1008, 657);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            // 
            // iconRightMenu
            // 
            this.iconRightMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addObjectToolStripMenuItem,
            this.deleteObjectToolStripMenuItem,
            this.toolStripSeparator6,
            this.configureToolStripMenuItem,
            this.toolStripSeparator7,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator9,
            this.duplicatToolStripMenuItem,
            this.toolStripSeparator10,
            this.searchToolStripMenuItem});
            this.iconRightMenu.Name = "iconRightMenu";
            this.iconRightMenu.Size = new System.Drawing.Size(152, 182);
            this.iconRightMenu.Opening += new System.ComponentModel.CancelEventHandler(this.iconRightMenu_Opening);
            // 
            // addObjectToolStripMenuItem
            // 
            this.addObjectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelToolStripMenuItem,
            this.buttonToolStripMenuItem,
            this.inputTagToolStripMenuItem,
            this.outputTextToolStripMenuItem,
            this.alarmToolStripMenuItem,
            this.imageToolStripMenuItem});
            this.addObjectToolStripMenuItem.Name = "addObjectToolStripMenuItem";
            this.addObjectToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.addObjectToolStripMenuItem.Text = "Add object";
            // 
            // labelToolStripMenuItem
            // 
            this.labelToolStripMenuItem.Name = "labelToolStripMenuItem";
            this.labelToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.labelToolStripMenuItem.Text = "Label";
            this.labelToolStripMenuItem.Click += new System.EventHandler(this.labelToolStripMenuItem_Click);
            // 
            // buttonToolStripMenuItem
            // 
            this.buttonToolStripMenuItem.Name = "buttonToolStripMenuItem";
            this.buttonToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.buttonToolStripMenuItem.Text = "Button";
            this.buttonToolStripMenuItem.Click += new System.EventHandler(this.buttonToolStripMenuItem_Click);
            // 
            // inputTagToolStripMenuItem
            // 
            this.inputTagToolStripMenuItem.Name = "inputTagToolStripMenuItem";
            this.inputTagToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.inputTagToolStripMenuItem.Text = "Input tag";
            this.inputTagToolStripMenuItem.Click += new System.EventHandler(this.inputTagToolStripMenuItem_Click);
            // 
            // outputTextToolStripMenuItem
            // 
            this.outputTextToolStripMenuItem.Name = "outputTextToolStripMenuItem";
            this.outputTextToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.outputTextToolStripMenuItem.Text = "Output object";
            this.outputTextToolStripMenuItem.Click += new System.EventHandler(this.outputTextToolStripMenuItem_Click);
            // 
            // alarmToolStripMenuItem
            // 
            this.alarmToolStripMenuItem.Name = "alarmToolStripMenuItem";
            this.alarmToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.alarmToolStripMenuItem.Text = "Alarm";
            this.alarmToolStripMenuItem.Click += new System.EventHandler(this.alarmToolStripMenuItem_Click);
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.imageToolStripMenuItem.Text = "Image";
            this.imageToolStripMenuItem.Click += new System.EventHandler(this.imageToolStripMenuItem_Click);
            // 
            // deleteObjectToolStripMenuItem
            // 
            this.deleteObjectToolStripMenuItem.Name = "deleteObjectToolStripMenuItem";
            this.deleteObjectToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.deleteObjectToolStripMenuItem.Text = "Delete object";
            this.deleteObjectToolStripMenuItem.Click += new System.EventHandler(this.deleteObjectToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(148, 6);
            // 
            // configureToolStripMenuItem
            // 
            this.configureToolStripMenuItem.Name = "configureToolStripMenuItem";
            this.configureToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.configureToolStripMenuItem.Text = "Configure";
            this.configureToolStripMenuItem.Click += new System.EventHandler(this.configureToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(148, 6);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(148, 6);
            // 
            // duplicatToolStripMenuItem
            // 
            this.duplicatToolStripMenuItem.Name = "duplicatToolStripMenuItem";
            this.duplicatToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.duplicatToolStripMenuItem.Text = "Duplicat layer";
            this.duplicatToolStripMenuItem.Click += new System.EventHandler(this.duplicatToolStripMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(148, 6);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.searchToolStripMenuItem.Text = "Search";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
            // 
            // SystemTimer
            // 
            this.SystemTimer.WorkerReportsProgress = true;
            this.SystemTimer.WorkerSupportsCancellation = true;
            this.SystemTimer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.SystemTimer_DoWork);
            this.SystemTimer.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.SystemTimer_RunWorkerCompleted);
            // 
            // AlarmMonitor
            // 
            this.AlarmMonitor.WorkerSupportsCancellation = true;
            this.AlarmMonitor.DoWork += new System.ComponentModel.DoWorkEventHandler(this.AlarmMonitor_DoWork);
            this.AlarmMonitor.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.AlarmMonitor_RunWorkerCompleted);
            // 
            // Alarm
            // 
            this.Alarm.WorkerSupportsCancellation = true;
            this.Alarm.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Alarm_DoWork);
            this.Alarm.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Alarm_RunWorkerCompleted);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(825, 310);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(825, 339);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // NVMonitor
            // 
            this.NVMonitor.WorkerReportsProgress = true;
            this.NVMonitor.WorkerSupportsCancellation = true;
            this.NVMonitor.DoWork += new System.ComponentModel.DoWorkEventHandler(this.NVMonitor_DoWork);
            this.NVMonitor.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.NVMonitor_ProgressChanged);
            this.NVMonitor.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.NVMonitor_RunWorkerCompleted);
            // 
            // ReadAllNV
            // 
            this.ReadAllNV.WorkerReportsProgress = true;
            this.ReadAllNV.WorkerSupportsCancellation = true;
            this.ReadAllNV.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ReadAllNV_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Maintool);
            this.Controls.Add(this.Mainstatus);
            this.Controls.Add(this.Mainmenu);
            this.Font = new System.Drawing.Font("Arial", 11F);
            this.MainMenuStrip = this.Mainmenu;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Form1";
            this.Text = "nico monitor application";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.Mainmenu.ResumeLayout(false);
            this.Mainmenu.PerformLayout();
            this.Mainstatus.ResumeLayout(false);
            this.Mainstatus.PerformLayout();
            this.Maintool.ResumeLayout(false);
            this.Maintool.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.iconRightMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Mainmenu;
        private System.Windows.Forms.ToolStripMenuItem fileTool;
        private System.Windows.Forms.ToolStripMenuItem managaneTool;
        private System.Windows.Forms.ToolStripMenuItem layerTool;
        private System.Windows.Forms.ToolStripMenuItem layerEditTool;
        private System.Windows.Forms.StatusStrip Mainstatus;
        private System.Windows.Forms.ToolStripStatusLabel activeMode;
        private System.Windows.Forms.ToolStrip Maintool;
        private System.Windows.Forms.ToolStripButton RunMode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox LayerListSelect;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton AddObjText;
        private System.Windows.Forms.ToolStripButton AddObjButton;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel StatusTime;
        private System.Windows.Forms.ToolStripButton delSelectObj;
        private System.Windows.Forms.ContextMenuStrip iconRightMenu;
        private System.Windows.Forms.ToolStripMenuItem addObjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteObjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton AddObjInput;
        private System.Windows.Forms.ToolStripButton AddObjAlarm;
        private System.Windows.Forms.ToolStripMenuItem labelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buttonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inputTagToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton LockObj;
        private System.Windows.Forms.ToolStripButton AddObjOutput;
        private System.Windows.Forms.ToolStripButton AddObjPicture;
        
        private System.Windows.Forms.ToolStripMenuItem saveProject;
        private System.Windows.Forms.ToolStripMenuItem saveAsProject;
        private System.Windows.Forms.ToolStripMenuItem loadProject;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exitProject;
        private System.Windows.Forms.ToolStripMenuItem newProject;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.ComponentModel.BackgroundWorker SystemTimer;
        private System.ComponentModel.BackgroundWorker AlarmMonitor;
        private System.ComponentModel.BackgroundWorker Alarm;
        private System.Windows.Forms.ToolStripMenuItem optionTool;
        private System.Windows.Forms.ToolStripMenuItem emailTool;
        private System.Windows.Forms.ToolStripMenuItem emailManaganeToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem databaseSettingToolStripMenuItem;
        public System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem outputTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alarmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configureToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem deviceTool;
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem duplicatToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel project_lab;
        private System.Windows.Forms.ToolStripStatusLabel user_lab;
        private System.Windows.Forms.ToolStripStatusLabel level_lab;
        private System.Windows.Forms.ToolStripStatusLabel db_lab;
        private System.ComponentModel.BackgroundWorker NVMonitor;
        private System.Windows.Forms.ToolStripButton AddObjTank;
        private System.ComponentModel.BackgroundWorker ReadAllNV;
    }
}

