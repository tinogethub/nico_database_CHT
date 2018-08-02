using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.InteropServices;
using System.Linq;
//using SmartServer;
using System.Threading;
using WMPLib;
using System.IO;
using ThreadingTimer = System.Threading.Timer;
using TimersTimer = System.Timers.Timer;
using System.Diagnostics;
using System.Web;
using System.Net.Mail;
using System.Net.Sockets;
using MySql.Data.MySqlClient;
using System.Data.Odbc;
using System.Security.Cryptography;
//using System.Text;


namespace nico_database
{
    public partial class Form1 : Form
    {
        string timeStr = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
        
        TimersTimer _TimersTimer = null;
        TimersTimer _TimersTimerMonitor = null;
        TimersTimer _TimersTimerReadAll = null;

        public TreeView DeviceNode = new TreeView();
        private System.Windows.Forms.Timer gifTime = new System.Windows.Forms.Timer(); 
        
        Boolean alarmPlay = false;
        public string saveProjectName = "";
        public string saveProjectNameTemp = "";
        public string saveAsProjectName = "";
        string SaveProjectDefaultPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\nico\Secret\";//default save file path
        string mySaveFullPath = "";  //user save file path
        string copyObjName = "";
        string copyObjType = "";
        ArrayList copyObjValue = new ArrayList();
        //ArrayList offlineiLON = new ArrayList();
         
        public string nvPart = "";
        public Boolean UseShowFalseValue = false;

        MailMessage email = new MailMessage();
        SmtpClient SMTP = new SmtpClient();
        
        int getRightMenuX = 0;
        int getRightMenuY = 0;

        public int nProcessID = Process.GetCurrentProcess().Id;

        /// <summary> auto msg
        /// ////////////////////////////////
        [DllImport("user32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Auto)]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int PostMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        public const int WM_CLOSE = 0x10;
        /// ////////////////////////////////
        /// </summary>

        public Form1()
        {
            InitializeComponent();
        }

        private ListBox reListbox; //接收Listbox config 的值
        public ListBox ReListbox
        {
            set
            {
                reListbox = value;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             

            Form.CheckForIllegalCrossThreadCalls = false; //關閉跨執行緒檢查
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;//表單最大化
            LayerListSelect.SelectedIndex = 0;
                    
            this.gifTime.Tick += new System.EventHandler(this.gifTime_Tick);
            //timer1.Enabled = true;
            Layerstruct addnew = new Layerstruct();
            addnew.name = "0";
            addnew.backColor = SystemColors.Control.ToArgb();
            addnew.backImage = "";
            addnew.sizeMode = "Normal";
            memoryData.LayerData.Add(addnew);

            //memoryData.GroupContact[0].groupindex = 0;
            //memoryData.GroupContact[0].groupname = "all contact";
            //Array.Resize(ref memoryData.GroupContact[0].groupmember, 1);
            
            ContactGroup2 gtar = new ContactGroup2();
            gtar.groupname = "all contact";
            gtar.groupmember = new ArrayList();
            memoryData.GroupContact2.Add(gtar);

            //memoryData.GroupContact.Add 

            //SystemTimer.RunWorkerAsync();

            

            //load database info && load mail info
            readSetting();

            UserLogin();

            //threading.timer
            this._TimersTimer = new TimersTimer();
            this._TimersTimer.Interval = 1000;
            this._TimersTimer.Elapsed += new System.Timers.ElapsedEventHandler(_TimersTimer_Elapsed);  //log value timer
            this._TimersTimer.Start();

            this._TimersTimerMonitor = new TimersTimer();
            this._TimersTimerMonitor.Interval = 1000;
            this._TimersTimerMonitor.Elapsed += new System.Timers.ElapsedEventHandler(_ThreadMonitorNVvalue);  //display update timer
            this._TimersTimerMonitor.Start();

            this._TimersTimerReadAll = new TimersTimer();
            this._TimersTimerReadAll.Interval = 1000;
            this._TimersTimerReadAll.Elapsed += new System.Timers.ElapsedEventHandler(_ThreadReadAllNVvalue); //soap get value timer
            this._TimersTimerReadAll.Start();

            ///////////////////////////////////////////////////////////////////////////////////
            //處裡記憶體堆疊[釋放垃圾記憶體]
            new System.Threading.Thread(() =>
            {
                while (true)
                {
                    System.Threading.Thread.Sleep(3600000);    //每小時執行一次
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }).Start();
            ///////////////////////////////////////////////////////////////////////////////////

        }

        void _TimersTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            
            if (RunMode.Checked == true)
            {
                if (memoryData.InputData.Count > 0)
                {
                    if (SystemTimer.IsBusy != true)
                    { 
                      SystemTimer.RunWorkerAsync();  //log value to SQL
                    }
                }

                if (memoryData.AlarmData.Count > 0)
                {
                    if (AlarmMonitor.IsBusy != true)
                    {
                        AlarmMonitor.RunWorkerAsync();
                    }

                    if (Alarm.IsBusy != true)
                    {
                        Alarm.RunWorkerAsync();
                    }
                }
                else
                {
                    Alarm.CancelAsync();
                    AlarmMonitor.CancelAsync();
                }

                
                

            }
            else
            {
                Alarm.CancelAsync();
                AlarmMonitor.CancelAsync();
            }

            
                //timeStr = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
                //Mainstatus.Items[StatusTime.Name].Text = timeStr;
            
            

        }

        private void _ThreadFunction()
        {
            timeStr = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
            this.BeginInvoke(new UpdateControl(_mUpdateControl), new object[] { this.Mainstatus, timeStr });
        }

        delegate void UpdateControl(Control Ctrl, string Msg);
        private object _objLock = new object();
        void _mUpdateControl(Control Ctrl, string Msg) //委任時間更新改變UI
        {
            lock (this._objLock)
            {
                if (Ctrl is StatusStrip)
                {
                    try
                    { ((StatusStrip)Ctrl).Items[2].Text = Msg; }
                    catch
                    {
                        //Mainstatus.Items[StatusTime.Name].Text = Msg;
                    }
                    
                }
            }
        }


        private void _ThreadMonitorNVvalue(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (RunMode.Checked == true)
            {
                if (NVMonitor .IsBusy != true )
                {
                    NVMonitor.RunWorkerAsync();
                }
                
            }
            else
            {
                if (NVMonitor.IsBusy)
                {
                    NVMonitor.CancelAsync();
                }

                //for (int i = 0; i < memoryData.InputData.Count; i++)
                //{
                //    InputObjectstruct edit = (InputObjectstruct)memoryData.InputData[i];
                //    edit.logtimecount = 0;
                //    edit.count = 0;
                //    memoryData.InputData[i] = edit;
                //}
            }
            
        }

        private void _ThreadReadAllNVvalue(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (RunMode.Checked == true)
            {
                if (ReadAllNV.IsBusy != true)
                {
                    ReadAllNV.RunWorkerAsync();
                }

            }
            else
            {
                if (ReadAllNV.IsBusy )
                {
                    ReadAllNV.CancelAsync();
                }
                    
            }

        }

        private void _ThreadGetFirstNVvalue()  //獲取初值
        {
            try
            {
                memoryData.ReadAllNV.Clear();
                //ReadNVvaluestruct tar = new ReadNVvaluestruct();
                //獲取VALUE
                SOAP20_DLL.SOAP ra = new SOAP20_DLL.SOAP();
                for (int i = 0; i < memoryData.SmartserverIP.Count; i++)
                {
                    string getIP = memoryData.SmartserverIP[i].ToString();
                    string Request = ra.request(getIP);
                    if (Request != null)
                    {
                        string device = "";
                        string function = "";
                        //string NV = "";

                        string[] d = Request.Split('※');
                        for (int di = 1; di < d.Length; di++)
                        {
                            string[] f = d[di].Split('$');
                            device = f[0]; // get device name
                            for (int fi = 1; fi < f.Length; fi++)
                            {
                                string[] n = f[fi].Split('@');
                                function = n[0]; // get function name
                                for (int ni = 1; ni < n.Length; ni++)
                                {
                                    ReadNVvaluestruct tar = new ReadNVvaluestruct();
                                    string[] NVinfo = n[ni].Split('^');
                                    tar.IP = getIP;
                                    tar.device = device;
                                    tar.function = function;
                                    tar.NV = NVinfo[0].ToString();
                                    tar.NVtype = NVinfo[1].ToString();
                                    tar.Value = NVinfo[2].ToString();
                                    tar.status = NVinfo[3].ToString();
                                    tar.preset = NVinfo[4].ToString();
                                    memoryData.ReadAllNV.Add(tar);
                                    
                                } // for nv 
                            } // for function
                        } // for device
                    }
                } // for SmartserverIP
                //獲取VALUE結束，取得所有NV到記憶體

                //顯示資料到工作區
                //掃描所有input nv點
                for (int inputCount = 0; inputCount < memoryData.InputData.Count; inputCount++)
                {
                    InputObjectstruct source = (InputObjectstruct)memoryData.InputData[inputCount];
                    for (int readCount = 0; readCount < memoryData.ReadAllNV.Count; readCount++)
                    {
                        ReadNVvaluestruct tag = (ReadNVvaluestruct)memoryData.ReadAllNV[readCount];
                        if (source.ip == tag.IP && source.device == tag.device && source.function == tag.function && source.NV == tag.NV )
                        {
                            source.value = tag.Value;
                            memoryData.InputData[inputCount] = source; //更新read回來的nv資料
                            break;
                        }
                    }

                } //掃描所有input nv點結束

            }
            catch
            {
            }
        }

        private void readSetting() // read database and smtp mail setting info
        {

            //↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓===== load contact menu =====↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
            string curFile = Application.StartupPath + @"\Resources\mailGroup.txt";
            Boolean findfile = File.Exists(curFile);

            if (findfile == true)
            {
                memoryData.GroupContact2.Clear();
                StreamReader rd = new StreamReader(Application.StartupPath + @"\Resources\mailGroup.txt");
                while (rd.EndOfStream == false)
                {
                    string[] getConfig = rd.ReadLine().Split('#');
                    if (getConfig[1] != "")
                    {
                        ContactGroup2 groupLoad = new ContactGroup2();
                        groupLoad.groupname = getConfig[1];
                        groupLoad.groupmember = new System.Collections.ArrayList();

                        Contactstruct addmember = new Contactstruct();
                        for (int i = 2; i < getConfig.Length; i++)
                        {
                            string[] member = getConfig[i].Split('$');
                            //Contactstruct addmember = new Contactstruct();
                            addmember.name = member[0];
                            addmember.mail = member[1];
                            addmember.phone = member[2];
                            addmember.description = member[3];
                            groupLoad.groupmember.Add(addmember);
                        }

                        memoryData.GroupContact2.Add(groupLoad);

                        if (getConfig[1] == "all contact")
                        {
                            ContactGroup2 tarGroup = (ContactGroup2)memoryData.GroupContact2[0];
                            if (tarGroup.groupmember != null)
                            {
                                for (int a = 0; a < tarGroup.groupmember.Count; a++)
                                {
                                    Contactstruct addMember = (Contactstruct)tarGroup.groupmember[a];
                                    memoryData.contact.Add(addMember);
                                }
                            }
                        }
                    }
                }
                rd.Dispose();
            }
            //↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
            ///////////////////////////////////////////////////////////////////////////////////////////
            
            //↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓===== load database info =====↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
            string curFiled = Application.StartupPath + @"\Resources\database.dat";
            Boolean findfiled = File.Exists(curFile);
            if (findfiled == true)
            {
                using (FileStream input = new FileStream(Application.StartupPath + @"\Resources\database.dat", FileMode.Open))
                {   // 讀取整數值
                    BinaryReader reader = new BinaryReader(input);
                    string data = reader.ReadString();
                    int numOfBytes = data.Length / 8;
                    byte[] bytes = new byte[numOfBytes];
                    for (int i = 0; i < numOfBytes; ++i)
                    {
                        bytes[i] = Convert.ToByte(data.Substring(8 * i, 8), 2);
                    }
                    //File.WriteAllBytes(fileName, bytes);
                    string val = GetString(bytes);
                    string[] SpStr = val.Split('$');
                    database edit = new database();
                    edit.ip = SpStr[1];
                    edit.user = SpStr[2];
                    edit.password = SpStr[3];
                    edit.port = SpStr[4];
                    edit.DBname = SpStr[5];

                    if (edit.ip != "" && edit.ip != null)
                    {
                        if (memoryData.database.Count != 0)
                        {
                            memoryData.database[0] = edit;
                        }
                        else
                        {
                            memoryData.database.Add(edit);
                        }
                    }
                    input.Dispose();
                }
            }

            //↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
            ///////////////////////////////////////////////////////////////////////////////////////////


            //↓↓↓↓↓↓↓↓↓↓↓↓===== check database table =====↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

            //檢查alarm_list , alarm_value


            //↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
            ///////////////////////////////////////////////////////////////////////////////////////////

        }

        private void managaneTool_Click(object sender, EventArgs e)
        {
            Device_manager Dm = new Device_manager();
            Dm.Owner = this;
            if (DeviceNode.Nodes.Count != 0)
            {
                Dm.DeviceListTree.Nodes.Clear();
                foreach (TreeNode node in DeviceNode.Nodes)
                {
                    Dm.DeviceListTree.Nodes.Add((TreeNode)node.Clone());
                }
                //Dm.DeviceListTree.CollapseAll();
            }
            Dm.ShowDialog();

            //刪除
            if (memoryData.iconDelTemp.Count > 0)
            {
                for (int i = pictureBox1.Controls.Count - 1; i >= 0; i--)
                {
                    int index = memoryData.iconDelTemp.IndexOf(pictureBox1.Controls[i].Name);
                    if (index != -1)
                    {
                        pictureBox1.Controls.RemoveAt(i);
                    }
                }
                memoryData.iconDelTemp.Clear();
            }
        }

        private void layerEditTool_Click(object sender, EventArgs e)
        {
            Layer_edit Le = new Layer_edit();
            Le.Owner = this;
            Le.layerListBox.SelectedIndex = 0;
            Le.ShowDialog();

            if (reListbox != null)
            {
                LayerListSelect.Items.Clear();
                for (int i = 0; i < reListbox.Items.Count; i++)
                {
                    LayerListSelect.Items.Add(reListbox.Items[i].ToString());
                }
                LayerListSelect.SelectedIndex = 0;
                Layerstruct tar = (Layerstruct)memoryData.LayerData [0];

                if (tar.backImage != null && tar.backImage != "")
                {
                    this.pictureBox1.BackgroundImage = Image.FromFile(tar.backImage);
                }
                
                reListbox = null;
            }

            //刪除
            if(memoryData.iconDelTemp.Count > 0)
            {
                for (int i = pictureBox1.Controls.Count - 1; i>=0 ; i--)
                {
                    int index = memoryData.iconDelTemp.IndexOf(pictureBox1.Controls[i].Name);
                    if (index !=-1)
                    {
                        pictureBox1.Controls.RemoveAt(i);
                    }
                }
                memoryData.iconDelTemp.Clear();
            }

        }

        private void AddObjTank_Click(object sender, EventArgs e)
        {
            LayerListSelect.Select();
            if (LayerListSelect.Text != null)
            {

                                

            }
        }
        

        private void AddObjText_Click(object sender, EventArgs e)
        {
            LayerListSelect.Select();
            if (LayerListSelect.Text != null)
            {
                LabelWithOptionalCopyTextOnDoubleClick lb = new LabelWithOptionalCopyTextOnDoubleClick();
                lb.Text = "new label";
                lb.Name = chkAddIconName("1");
                lb.Tag = "label@label";
                lb.Font =new Font ("Arial",12,FontStyle.Regular);
                lb.AutoSize = true;
                lb.Location = new Point(10, 10);
                lb.DoubleClick += new System.EventHandler(this.label_DoubleClick);
                lb.Click += new System.EventHandler(this.label_Click);
                lb.Paint += new System.Windows.Forms.PaintEventHandler(this.label_paint);
                lb.Leave += new System.EventHandler(this.label_Level);
                lb.Enter += new System.EventHandler(this.label_Enter);
                lb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_mouseMove);
                lb.MouseEnter += new System.EventHandler(this.label_mouseEnter);
                lb.MouseLeave += new System.EventHandler(this.label_mouseLevel);
                lb.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.label_KeyUp);
                //lb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Icon_MouseDown);
                pictureBox1.Controls.Add(lb);
    
                LabelObjstruct addnew = new LabelObjstruct();
                addnew.backcolor = lb.BackColor.ToArgb();
                addnew.color = lb.ForeColor.ToArgb();
                addnew.font = lb.Font;
                addnew.layer = LayerListSelect.Text;
                addnew.name = lb.Name;
                addnew.text = lb.Text;
                addnew.border = lb.BorderStyle;
                addnew.x = lb.Location.X;
                addnew.y = lb.Location.Y;
                addnew.tag = lb.Tag.ToString();
                memoryData.LabelData.Add(addnew);
                memoryData.iconTemp.Add(lb.Name);
            }
        }
        
        private Label relab; //接收label config 的值
        public Label Relab
        {
            set
            {
                relab = value;
            }
        }

        private string gettooltip; //接收 tooltip 的值
        public string Gettooltip
        {
            set
            {
                gettooltip = value;
            }
        }

        private string user; //接收 user 的值
        public string User
        {
            set
            {
                user = value;
            }
        }

        private string accLV; //接收 account level 的值
        public string AccLV
        {
            set
            {
                accLV = value;
            }
        }

        protected void label_mouseEnter(object sender, EventArgs e)
        {
            Label lbtn = (Label)sender;
            lbtn.Select();
            string[] gettype = lbtn.Tag.ToString().Split('@');
            if (gettype[0] == "label")
            {
                toolStripStatusLabel2.Text = "label object location(" + lbtn.Location.X + "," + lbtn.Location.Y + ")";
            }
            else if (gettype[0] == "input")
            {
                toolStripStatusLabel2.Text = "input object location(" + lbtn.Location.X + "," + lbtn.Location.Y + ")";
            }
            
            //lbtn.Focus();
        }

        protected void label_mouseLevel(object sender, System.EventArgs e)
        {
            toolStripStatusLabel2.Text = "";
        }
                
        protected void label_mouseMove(object sender, MouseEventArgs e)
        {
            if (RunMode.Checked == false && LockObj.Checked == false && e.Button == MouseButtons.Left && (ModifierKeys & Keys.Control) == Keys.Control)
            {
                //  Layeredit.mouseHold = false;
                if (this.ActiveControl != null)
                {
                    Label lbtn = (Label)sender;
                    string[] tmpStr = lbtn.Tag.ToString().Split('@');
                    string lbType = tmpStr[0];
                    if (lbType == "label")
                    {
                        int indextemp = 0;
                        LabelObjstruct editstr = new LabelObjstruct();
                        for (int i = 0; i < memoryData.LabelData.Count; i++)
                        {
                            LabelObjstruct getstr = (LabelObjstruct)memoryData.LabelData[i];
                            if (getstr.name == lbtn.Name)
                            {
                                indextemp = i;
                                editstr = getstr;
                                break;
                            }
                        }

                        if (this.ActiveControl.Name == lbtn.Name)
                        {
                            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                            {

                                //lbtn.Top = e.Y +lbtn.Location.Y;
                                //lbtn.Left = e.X +lbtn.Location.X;
                                lbtn.Top = e.Y + lbtn.Location.Y - (lbtn.Size.Height / 2);
                                lbtn.Left = e.X + lbtn.Location.X - (lbtn.Size.Width / 2);
                                editstr.x = lbtn.Left;
                                editstr.y = lbtn.Top;

                                toolStripStatusLabel2.Text = "label object location(" + lbtn.Left + "," + lbtn.Top + ")";
                                memoryData.LabelData[indextemp] = editstr;

                            }
                            // MessageBox.Show("move");
                        }
                    }
                    else if (lbType == "input")
                    {
                        int indextemp = 0;
                        InputObjectstruct editstr = new InputObjectstruct();
                        for (int i = 0; i < memoryData.InputData.Count; i++)
                        {
                            InputObjectstruct getstr = (InputObjectstruct)memoryData.InputData[i];
                            if (getstr.name == lbtn.Name)
                            {
                                indextemp = i;
                                editstr = getstr;
                                break;
                            }
                        }

                        if (this.ActiveControl.Name == lbtn.Name)
                        {
                            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                            {

                                //lbtn.Top = e.Y +lbtn.Location.Y;
                                //lbtn.Left = e.X +lbtn.Location.X;
                                lbtn.Top = e.Y + lbtn.Location.Y - (lbtn.Size.Height / 2);
                                lbtn.Left = e.X + lbtn.Location.X - (lbtn.Size.Width / 2);
                                editstr.x = lbtn.Left;
                                editstr.y = lbtn.Top;
                                toolStripStatusLabel2.Text = "input object location(" + lbtn.Left + "," + lbtn.Top + ")";
                                memoryData.InputData[indextemp] = editstr;

                            }
                            // MessageBox.Show("move");
                        }
                    }
                    
                }
            }
            
        }

        protected void label_KeyUp(object sender, PreviewKeyDownEventArgs e)
        {
            if (RunMode.Checked == false && LockObj.Checked == false)
            {
                Label tar = (Label)sender;
                int oldX = tar.Location.X;
                int oldY = tar.Location.Y;

                string[] tmpStr = tar.Tag.ToString().Split('@');
                string LabelType = tmpStr[0];

                if (e.KeyCode == Keys.Up)
                {
                    tar.Location = new Point(oldX, oldY - 1);
                }
                else if (e.KeyCode == Keys.Down)
                {
                    tar.Location = new Point(oldX, oldY + 1);
                }
                else if (e.KeyCode == Keys.Left)
                {
                    tar.Location = new Point(oldX - 1, oldY);
                }
                else if (e.KeyCode == Keys.Right)
                {
                    tar.Location = new Point(oldX + 1, oldY);
                }

                if (LabelType == "label")
                {
                    for (int i = 0; i < memoryData.LabelData.Count; i++)
                    {
                        LabelObjstruct edit = (LabelObjstruct)memoryData.LabelData[i];
                        if (edit.name == tar.Name)
                        {
                            edit.x = tar.Location.X;
                            edit.y = tar.Location.Y;
                            memoryData.LabelData[i] = edit;
                            toolStripStatusLabel2.Text = "label object location(" + tar.Left + "," + tar.Top + ")";
                            break;
                        }
                    }

                }
                else if (LabelType == "input")
                {
                    for (int i = 0; i < memoryData.InputData.Count; i++)
                    {
                        InputObjectstruct edit = (InputObjectstruct)memoryData.InputData[i];
                        if (edit.name == tar.Name)
                        {
                            edit.x = tar.Location.X;
                            edit.y = tar.Location.Y;
                            memoryData.InputData[i] = edit;
                            toolStripStatusLabel2.Text = "input object location(" + tar.Left + "," + tar.Top + ")";
                            break;
                        }
                    }

                }

                
            }

        }

        protected void label_Enter(object sender, EventArgs e)
        {
            Label lbtn = (Label)sender;
            //MessageBox.Show(lbtn.Name + " enter");
            lbtn.Refresh();
        }

        protected void label_Level(object sender, EventArgs e)
        {
            Label lbtn = (Label)sender;
            //MessageBox.Show(lbtn.Name + " level");
            
            lbtn.Refresh();
        }

        protected void label_Click(object sender, EventArgs e)
        {
            Label lbtn = (Label)sender;
            lbtn.Focus();
            
        }

        protected void label_paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

            try
            {
                Label lbtn = (Label)sender;
                if (this.ActiveControl.Name == lbtn.Name)
                {
                    ControlPaint.DrawBorder(e.Graphics, (sender as Control).DisplayRectangle, Color.Red, ButtonBorderStyle.Dashed);
                }
                else
                {
                    ControlPaint.DrawBorder(e.Graphics, (sender as Control).DisplayRectangle, Color.Red, ButtonBorderStyle.None);
                }

            }
            catch
            {

            }


        }

        protected void label_DoubleClick(object sender, EventArgs e) //建立LABEL CLICK事件
        {
            if (RunMode.Checked == false)
            {
                IDataObject iData = Clipboard.GetDataObject();

                //this.Text = (String)iData.GetData(DataFormats.Text);
                Label lbtn = (Label)sender;
                editLabelObj(sender,e);
            }

        }

        private void editLabelObj(object sender, EventArgs e) //開啟編輯LABEL
        {
            Label lbtn = (Label)sender;
            string[] tmpStr = lbtn.Tag.ToString().Split('@');
            string LabelType = tmpStr[0];
            if (LabelType == "label")
            {
                config_LabelObject lForm = new config_LabelObject();
                lForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
                lForm.Controls["Labtext"].Text = lbtn.Text;
                Label tar = (Label)lForm.Controls["groupBox1"].Controls[0];
                //lForm.Controls["groupBox1"].Controls[0].Font = lbtn.Font;
                tar.Font = lbtn.Font;
                tar.ForeColor = lbtn.ForeColor;
                tar.BackColor = lbtn.BackColor;
                tar.BorderStyle = lbtn.BorderStyle;
                lForm.Controls["textX"].Text = lbtn.Location.X.ToString();
                lForm.Controls["textY"].Text = lbtn.Location.Y.ToString();
                lForm.LabelName = lbtn.Name;
                lForm.ShowDialog();

                if (relab != null)
                {

                    lbtn.Text = relab.Text;
                    lbtn.Font = relab.Font;
                    lbtn.ForeColor = relab.ForeColor;
                    lbtn.BackColor = relab.BackColor;
                    lbtn.BorderStyle = relab.BorderStyle;
                    string NewXY = relab.Tag.ToString();
                    string[] splitXY = NewXY.Split('_');
                    int Nx = int.Parse(splitXY[0]);
                    int Ny = int.Parse(splitXY[1]);
                    lbtn.Location = new Point(Nx, Ny);

                    relab = null;

                }
            }
            else if (LabelType == "input")
            {
                
                if (DeviceNode.Nodes.Count != 0)
                {
                    config_InputTagObject lForm = new config_InputTagObject();
                    lForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
                    lForm.Controls["Labtext"].Text = lbtn.Text;
                    lForm.Controls["groupBox1"].Controls[0].Font = lbtn.Font;
                    lForm.Controls["groupBox1"].Controls[0].ForeColor = lbtn.ForeColor;
                    lForm.Controls["groupBox1"].Controls[0].BackColor = lbtn.BackColor;
                    lForm.Controls["textX"].Text = lbtn.Location.X.ToString();
                    lForm.Controls["textY"].Text = lbtn.Location.Y.ToString();
                    lForm.LabelName = lbtn.Name;
                    string[] tmpStr2 = lbtn.Tag.ToString().Split('@');
                    lForm.NVType = tmpStr2[1];

                    foreach (TreeNode node in DeviceNode.Nodes)
                        {
                            lForm.deviceList.Nodes.Add((TreeNode)node.Clone());
                        }
                   
                   // lForm.deviceList.ExpandAll();
                    
                    lForm.ShowDialog();

                    if (relab != null)
                    {
                        lbtn.Text = relab.Text;
                        lbtn.Font = relab.Font;
                        lbtn.ForeColor = relab.ForeColor;
                        lbtn.BackColor = relab.BackColor;
                        lbtn.BorderStyle = relab.BorderStyle;
                        string NewXY = relab.Tag.ToString();
                        string[] splitXY = NewXY.Split('_');
                        int Nx = int.Parse(splitXY[0]);
                        int Ny = int.Parse(splitXY[1]);
                        lbtn.Location = new Point(Nx, Ny);
                        toolTip1.SetToolTip(lbtn, gettooltip);

                        gettooltip = "";
                        relab = null;
                    }
                }
                else
                {

                    DialogResult ans = MessageBox.Show("goto device manager ?", "device list is null!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ans == DialogResult.Yes)
                    {
                        managaneTool.Select();
                        managaneTool_Click(sender, e);
                    }
                }
            }
            
        }

        private string chkAddIconName(string addname)
        {
            Boolean repeat = false;
        retry:
            for (int i = 0; i < pictureBox1.Controls.Count; i++)
            {
                if (pictureBox1.Controls[i].Name == addname)
                {
                    repeat = true;
                    break;
                }
            }

            for (int i = 0; i < memoryData.iconTemp.Count; i++)
            {
                string cname = memoryData.iconTemp[i].ToString();
                if (cname == addname)
                {
                    repeat = true;
                    break;
                }
            }
           

            if (repeat == true)
            {
                int na = int.Parse(addname);
                na += 1;
                addname = na.ToString();
                repeat = false;
                goto retry;
            }
            else
            { return addname; }

        }

        private void AddObjButton_Click(object sender, EventArgs e)
        {
            if (LayerListSelect.Text != null)
            {
                DoubleClickButton bt = new DoubleClickButton();
                bt.Text = "new button";
                bt.Name = chkAddIconName("1");
                bt.AutoSize = false;
                bt.Font = new Font("Arial", 12, FontStyle.Regular);
                bt.Size = new Size(100, 28);
                bt.Tag = "button";
                bt.Location = new Point(10, 10);
                bt.DoubleClick += new System.EventHandler(this.buttn_DoubleClick);
                bt.Click += new System.EventHandler(this.buttn_Click);
                bt.Paint += new System.Windows.Forms.PaintEventHandler(this.buttn_paint);
                bt.Leave += new System.EventHandler(this.buttn_Level);
                bt.Enter += new System.EventHandler(this.buttn_Enter);
                bt.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttn_mouseMove);
                bt.MouseEnter += new System.EventHandler(this.buttn_mouseEnter);
                bt.MouseLeave += new System.EventHandler(this.buttn_mouseLevel);
                bt.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.buttn_KeyUp);
                bt.BackgroundImage = null;
                bt.BackgroundImageLayout = ImageLayout.None;

                pictureBox1.Controls.Add(bt);

                ButtonObjstruct addnew = new ButtonObjstruct();
                addnew.AlignImage = bt.ImageAlign.ToString();
                addnew.AlignText = bt.TextAlign.ToString();
                addnew.backColor = bt.BackColor.ToArgb();
                addnew.backImage = null;
                addnew.command = LayerListSelect.Text;
                addnew.font = bt.Font;
                addnew.forecolor = bt.ForeColor.ToArgb();
                addnew.height = bt.Size.Height;
                addnew.layer = LayerListSelect.Text;
                addnew.name = bt.Name;
                addnew.text = bt.Text;
                addnew.width = bt.Size.Width;
                addnew.x = bt.Location.X;
                addnew.y = bt.Location.Y;
                addnew.tag = bt.Tag.ToString();

                memoryData.ButtonData.Add(addnew);
                memoryData.iconTemp.Add(bt.Name);
            }
        }

        private Button rebutton; //接收button config 的值
        private String rebuttonTarget; //接收button target 的值
        public Button Rebutton
        {
            set
            {
                rebutton = value;
            }
        }
        public string RebuttonTarget
        {
            set
            {
                rebuttonTarget = value;
            }
        }

        protected void buttn_mouseEnter(object sender, EventArgs e)
        {
            Button lbtn = (Button)sender;
            string[] gettype = lbtn.Tag.ToString().Split('@');
            if (gettype[0] == "pop")
            {
                toolStripStatusLabel2.Text = "pop output object location(" + lbtn.Location.X + "," + lbtn.Location.Y + ")";
            }
            else if (gettype[0] == "button")
            {
                toolStripStatusLabel2.Text = "button object location(" + lbtn.Location.X + "," + lbtn.Location.Y + ")";
            }
            
            lbtn.Select();
        }

        protected void buttn_mouseLevel(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "";
        }

        protected void buttn_mouseMove(object sender, MouseEventArgs e)
        {
            if (RunMode.Checked == false && LockObj.Checked == false && e.Button == MouseButtons.Left && (ModifierKeys & Keys.Control) == Keys.Control)
            {
                if (this.ActiveControl != null)
                {
                    int index = 0;
                    Button lbtn = (Button)sender;
                    string[] tar = lbtn.Tag.ToString().Split('@');
                    if(tar[0]=="button")
                    {
                        ButtonObjstruct editstr = new ButtonObjstruct();
                        for (int i = 0; i < memoryData.ButtonData.Count; i++)
                        {
                            ButtonObjstruct getstr = (ButtonObjstruct)memoryData.ButtonData[i];
                            if (getstr.name == lbtn.Name)
                            {
                                index = i;
                                editstr = getstr;
                            }
                        }

                        if (this.ActiveControl.Name == lbtn.Name)
                        {
                            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                            {
                                lbtn.Top = e.Y + lbtn.Location.Y - (lbtn.Size.Height / 2);
                                lbtn.Left = e.X + lbtn.Location.X - (lbtn.Size.Width / 2);
                                editstr.x = lbtn.Left;
                                editstr.y = lbtn.Top;
                                memoryData.ButtonData[index] = editstr;
                                toolStripStatusLabel2.Text = "button object location(" + lbtn.Location.X + "," + lbtn.Location.Y + ")";
                            }
                        }
                    }
                    else if (tar[0] == "pop")
                    {
                        OutputPopObjectstruct editstr = new OutputPopObjectstruct();
                        for (int i = 0; i < memoryData.OutputPopData.Count; i++)
                        {
                            OutputPopObjectstruct getstr = (OutputPopObjectstruct)memoryData.OutputPopData[i];
                            if (getstr.name == lbtn.Name)
                            {
                                index = i;
                                editstr = getstr;
                            }
                        }
                        if (this.ActiveControl.Name == lbtn.Name)
                        {
                            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                            {
                                lbtn.Top = e.Y + lbtn.Location.Y - (lbtn.Size.Height / 2);
                                lbtn.Left = e.X + lbtn.Location.X - (lbtn.Size.Width / 2);
                                editstr.x = lbtn.Left;
                                editstr.y = lbtn.Top;
                                memoryData.OutputPopData[index] = editstr;
                                toolStripStatusLabel2.Text = "pop output object location(" + lbtn.Location.X + "," + lbtn.Location.Y + ")";
                            }
                        }
                    }

                }
            }

        }

        private void buttn_KeyUp(object sender, PreviewKeyDownEventArgs e)
        {
            if (RunMode.Checked == false && LockObj.Checked == false)
            {
                Button tar = (Button)sender;
                int oldX = tar.Location.X;
                int oldY = tar.Location.Y;

                if (e.KeyCode == Keys.Up)
                {
                    tar.Location = new Point(oldX, oldY - 1);
                }
                else if (e.KeyCode == Keys.Down)
                {
                    tar.Location = new Point(oldX, oldY + 1);
                }
                else if (e.KeyCode == Keys.Left)
                {
                    tar.Location = new Point(oldX - 1, oldY);
                }
                else if (e.KeyCode == Keys.Right)
                {
                    tar.Location = new Point(oldX + 1, oldY);
                }

                string[] str = tar.Tag.ToString().Split('@');
                if (str[0] == "button")
                {
                    for (int i = 0; i < memoryData.ButtonData.Count; i++)
                    {
                        ButtonObjstruct edit = (ButtonObjstruct)memoryData.ButtonData[i];
                        if (edit.name == tar.Name)
                        {
                            edit.x = tar.Location.X;
                            edit.y = tar.Location.Y;
                            memoryData.ButtonData[i] = edit;
                            toolStripStatusLabel2.Text = "button object location(" + tar.Left + "," + tar.Top + ")";
                            break;
                        }
                    }
                }
                else if (str[0] == "pop")
                {
                    for (int i = 0; i < memoryData.OutputPopData.Count; i++)
                    {
                        OutputPopObjectstruct edit = (OutputPopObjectstruct)memoryData.OutputPopData[i];
                        if (edit.name == tar.Name)
                        {
                            edit.x = tar.Location.X;
                            edit.y = tar.Location.Y;
                            memoryData.OutputPopData[i] = edit;
                            toolStripStatusLabel2.Text = "pop object location(" + tar.Left + "," + tar.Top + ")";
                            break;
                        }
                    }
                }


                
            }

        }

        protected void buttn_Enter(object sender, EventArgs e)
        {
            Button lbtn = (Button)sender;
            lbtn.Refresh();
        }

        protected void buttn_Level(object sender, EventArgs e)
        {
            Button lbtn = (Button)sender;
            lbtn.Refresh();
        }

        protected void buttn_Click(object sender, EventArgs e)
        {
            Button lbtn = (Button)sender;
            string[] tar = lbtn.Tag.ToString().Split('@');
            lbtn.Focus();
            if (RunMode.Checked == true)
            {
                if (tar[0] == "button")
                {
                    for (int i = 0; i < memoryData.ButtonData.Count; i++)
                    {
                        ButtonObjstruct getval = (ButtonObjstruct)memoryData.ButtonData[i];
                        if (getval.name == lbtn.Name)
                        {
                            LayerListSelect.SelectedItem = getval.command;
                            break;
                        }
                    }
                }
                else if (tar[0] == "pop")
                {
                    for (int i = 0; i < memoryData.OutputPopData.Count; i++)
                    {
                        OutputPopObjectstruct getval = (OutputPopObjectstruct)memoryData.OutputPopData[i];
                        if (getval.name == lbtn.Name)
                        {
                            config_OutputObjectPop lform = new config_OutputObjectPop();
                            //lform.Owner = this;
                            lform.ip = getval.ip;
                            lform.target = getval.target;
                            string[] gettype = getval.tag.Split('@');
                            lform.NVtype = gettype[1];
                            lform.listIndex = i;
                            lform.StartPosition = FormStartPosition.CenterScreen;
                            lform.Show();
                            
                            //send NV value
                            break;
                        }
                    }
                }
                
            }
        }

        protected void buttn_paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            try
            {
                Button lbtn = (Button)sender;
                if (this.ActiveControl.Name == lbtn.Name)
                {
                    ControlPaint.DrawBorder(e.Graphics, (sender as Control).DisplayRectangle, Color.Red, ButtonBorderStyle.Dashed);
                }
                else
                {
                    ControlPaint.DrawBorder(e.Graphics, (sender as Control).DisplayRectangle, Color.Black, ButtonBorderStyle.None);
                }
            }
            catch
            {
                
            }
        }

        protected void buttn_DoubleClick(object sender, EventArgs e) //建立button CLICK事件
        {
            if (RunMode.Checked == false)
            {
                Button lbtn = (Button)sender;
                string[] tar = lbtn.Tag.ToString().Split('@');
                if (tar[0] == "button")
                {
                    editButtonObj(sender);
                }
                else if (tar[0] == "pop")
                {
                    editPopObj(sender,e);
                }
            }
        }
        private void editPopObj(object sender, EventArgs e) //開啟編輯pop button obj
        {
            if (DeviceNode.Nodes.Count != 0)
            {
                Button lbtn = (Button)sender;
                config_OutputObjectPopEdit lForm = new config_OutputObjectPopEdit();
                lForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
                lForm.popName = lbtn.Name;
                lForm.NVType2 = lbtn.Tag.ToString();
                lForm.Controls["buttonText"].Text = lbtn.Text;
                lForm.Controls["buttonWidth"].Text = lbtn.Size.Width.ToString();
                lForm.Controls["buttonHeight"].Text = lbtn.Size.Height.ToString();
                lForm.Controls["textX"].Text = lbtn.Location.X.ToString();
                lForm.Controls["textY"].Text = lbtn.Location.Y.ToString();

                Button target = (Button)lForm.Controls["groupBox1"].Controls[0];
                target.Text = lbtn.Text;
                target.Font = lbtn.Font;
                target.ForeColor = lbtn.ForeColor;
                target.Size = new Size(lbtn.Size.Width, lbtn.Size.Height);
                target.Image = lbtn.Image;
                target.TextAlign = lbtn.TextAlign;
                target.ImageAlign = lbtn.ImageAlign;
                Boolean findTarget = false;
                for (int i = 0; i < memoryData.OutputPopData.Count; i++)
                {
                    OutputPopObjectstruct getval = (OutputPopObjectstruct)memoryData.OutputPopData[i];
                    if (getval.name == lbtn.Name)
                    {
                        if (getval.backImage != null)
                        {
                            Button target2 = (Button)lForm.Controls["groupBox1"].Controls[0];
                            target2.Image = Image.FromFile(getval.backImage);
                            findTarget = true;
                            break;
                        }
                    }
                }

                if (findTarget != true)
                {
                    Button target2 = (Button)lForm.Controls["groupBox1"].Controls[0];
                    target2.Image = null;
                }

                foreach (TreeNode node in DeviceNode.Nodes)
                {
                    lForm.deviceList.Nodes.Add((TreeNode)node.Clone());
                }

                lForm.ShowDialog();

                if (rebutton != null)
                {
                    lbtn.Text = rebutton.Text;
                    lbtn.Font = rebutton.Font;
                    lbtn.ForeColor = rebutton.ForeColor;
                    lbtn.BackColor = rebutton.BackColor;
                    lbtn.Size = new Size(rebutton.Size.Width, rebutton.Size.Height);
                    lbtn.Image = rebutton.Image;
                    lbtn.TextAlign = rebutton.TextAlign;
                    lbtn.ImageAlign = rebutton.ImageAlign;
                    string NewXY = rebutton.Tag.ToString();
                    string[] splitXY = NewXY.Split('_');
                    int Nx = int.Parse(splitXY[0]);
                    int Ny = int.Parse(splitXY[1]);
                    lbtn.Location = new Point(Nx, Ny);

                    for (int i = 0; i < memoryData.OutputPopData.Count; i++)
                    {
                        OutputPopObjectstruct getval = (OutputPopObjectstruct)memoryData.OutputPopData[i];
                        if (getval.name == lbtn.Name)
                        {
                            getval.AlignIMG = lbtn.ImageAlign;
                            getval.AlignText = lbtn.TextAlign;
                            getval.backColor = lbtn.BackColor.ToArgb();

                            getval.font = lbtn.Font;
                            getval.forecolor = lbtn.ForeColor.ToArgb();
                            getval.height = lbtn.Size.Height;
                            getval.text = lbtn.Text;
                            getval.width = lbtn.Size.Width;
                            getval.x = lbtn.Location.X;
                            getval.y = lbtn.Location.Y;
                            memoryData.OutputPopData[i] = getval;
                            break;
                        }
                    }

                    toolTip1.SetToolTip(lbtn, gettooltip);

                    gettooltip = "";
                    rebutton = null;
                    rebuttonTarget = null;
                }
                //回傳目標 = rebuttonTarget
            }
            else
            {
                DialogResult ans = MessageBox.Show("goto device manager ?", "device list is null!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == DialogResult.Yes)
                {
                    managaneTool.Select();
                    managaneTool_Click(sender, e);
                }
            }
        }

        private void editButtonObj(object sender) //開啟編輯button
        {
            Button lbtn = (Button)sender;
            config_ButtonObject lForm = new config_ButtonObject();
            lForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
            lForm.buttonName = lbtn.Name;
            lForm.Controls["buttonText"].Text = lbtn.Text;
            //lForm.Controls["buttonWidth"].Text = lbtn.Size.Width.ToString();
            //lForm.Controls["buttonHeight"].Text = lbtn.Size.Height.ToString();
            lForm.Controls["textX"].Text = lbtn.Location.X.ToString();
            lForm.Controls["textY"].Text = lbtn.Location.Y.ToString();
            Button target = (Button)lForm.Controls["groupBox1"].Controls[0];
            target.Text = lbtn.Text;
            target.Font = lbtn.Font;
            target.ForeColor = lbtn.ForeColor;
            target.Size = new Size(lbtn.Size.Width, lbtn.Size.Height);
            target.Image = lbtn.Image;
            //lForm.Controls["groupBox1"].Controls[0].Text = lbtn.Text;
            //lForm.Controls["groupBox1"].Controls[0].Font = lbtn.Font;
            //lForm.Controls["groupBox1"].Controls[0].ForeColor = lbtn.ForeColor;
            //lForm.Controls["groupBox1"].Controls[0].Size = new Size(lbtn.Size.Width, lbtn.Size.Height);
            //lForm.Controls["groupBox1"].Controls[0].BackColor = lbtn.BackColor;
            
            Boolean findTarget = false;
            for (int i = 0; i < memoryData.ButtonData.Count; i++)
            {
                ButtonObjstruct getval = (ButtonObjstruct)memoryData.ButtonData[i];
                if (getval.name == lbtn.Name)
                {
                    if (getval.backImage != null)
                    {
                        Button target2 = (Button)lForm.Controls["groupBox1"].Controls[0];

                        if (getval.backImage != "")
                        {
                            target2.Image = Image.FromFile(getval.backImage);
                        }
                        
                        
                        //lForm.Controls["groupBox1"].Controls[0].BackgroundImage = Image.FromFile(getval.backImage);
                        findTarget = true;
                        break;
                    }
                }
            }

            if (findTarget != true)
            {
                Button target2 = (Button)lForm.Controls["groupBox1"].Controls[0];
                //lForm.Controls["groupBox1"].Controls[0].BackgroundImage = null; 
                target2.Image = null;
            }

            //取得現有layer
            ComboBox tempCombbox = new ComboBox();
            for (int i = 0; i < LayerListSelect.Items.Count; i++)
            {
                tempCombbox.Items.Add(LayerListSelect.Items[i].ToString());
            }

            lForm.getLayerItem = tempCombbox;

            Control[] cb1 = lForm.Controls.Find("textAlign", true);
            Control[] cb2 = lForm.Controls.Find("imageAlign", true);
            
            
            if (lbtn.TextAlign == ContentAlignment.BottomCenter) { ((ComboBox)cb1[0]).SelectedIndex = 0; }
            else if (lbtn.TextAlign == ContentAlignment.BottomLeft) { ((ComboBox)cb1[0]).SelectedIndex = 1; }
            else if (lbtn.TextAlign == ContentAlignment.BottomRight) { ((ComboBox)cb1[0]).SelectedIndex = 2; }
            else if (lbtn.TextAlign == ContentAlignment.MiddleCenter) { ((ComboBox)cb1[0]).SelectedIndex = 3; }
            else if (lbtn.TextAlign == ContentAlignment.MiddleLeft) { ((ComboBox)cb1[0]).SelectedIndex = 4; }
            else if (lbtn.TextAlign == ContentAlignment.MiddleRight) { ((ComboBox)cb1[0]).SelectedIndex = 5; }
            else if (lbtn.TextAlign == ContentAlignment.TopCenter) { ((ComboBox)cb1[0]).SelectedIndex = 6; }
            else if (lbtn.TextAlign == ContentAlignment.TopLeft) { ((ComboBox)cb1[0]).SelectedIndex = 7; }
            else if (lbtn.TextAlign == ContentAlignment.TopRight) { ((ComboBox)cb1[0]).SelectedIndex = 8; }

            if (lbtn.ImageAlign == ContentAlignment.BottomCenter) { ((ComboBox)cb2[0]).SelectedIndex = 0; }
            else if (lbtn.ImageAlign == ContentAlignment.BottomLeft) { ((ComboBox)cb2[0]).SelectedIndex = 1; }
            else if (lbtn.ImageAlign == ContentAlignment.BottomRight) { ((ComboBox)cb2[0]).SelectedIndex = 2; }
            else if (lbtn.ImageAlign == ContentAlignment.MiddleCenter) { ((ComboBox)cb2[0]).SelectedIndex = 3; }
            else if (lbtn.ImageAlign == ContentAlignment.MiddleLeft) { ((ComboBox)cb2[0]).SelectedIndex = 4; }
            else if (lbtn.ImageAlign == ContentAlignment.MiddleRight) { ((ComboBox)cb2[0]).SelectedIndex = 5; }
            else if (lbtn.ImageAlign == ContentAlignment.TopCenter) { ((ComboBox)cb2[0]).SelectedIndex = 6; }
            else if (lbtn.ImageAlign == ContentAlignment.TopLeft) { ((ComboBox)cb2[0]).SelectedIndex = 7; }
            else if (lbtn.ImageAlign == ContentAlignment.TopRight) { ((ComboBox)cb2[0]).SelectedIndex = 8; }

                lForm.ShowDialog();

            if (rebutton != null)
            {
                lbtn.Text = rebutton.Text;
                lbtn.Font = rebutton.Font;
                lbtn.ForeColor = rebutton.ForeColor;
                lbtn.BackColor = rebutton.BackColor;
                lbtn.Size = new Size(rebutton.Size.Width, rebutton.Size.Height);
                lbtn.Image = rebutton.Image ;
                lbtn.TextAlign = rebutton.TextAlign;
                lbtn.ImageAlign = rebutton.ImageAlign;
                string NewXY = rebutton.Tag.ToString();
                string[] splitXY = NewXY.Split('_');
                int Nx = int.Parse(splitXY[0]);
                int Ny = int.Parse(splitXY[1]);
                lbtn.Location = new Point(Nx, Ny);

                for (int i = 0; i < memoryData.ButtonData.Count; i++)
                {
                    ButtonObjstruct getval = (ButtonObjstruct)memoryData.ButtonData[i];
                    if (getval.name == lbtn.Name)
                    {
                        getval.AlignImage = lbtn.ImageAlign.ToString();
                        getval.AlignText = lbtn.TextAlign.ToString();
                        getval.backColor = lbtn.BackColor.ToArgb();
                        
                        
                        getval.command = rebuttonTarget;
                        getval.font = lbtn.Font;
                        getval.forecolor = lbtn.ForeColor.ToArgb();
                        getval.height = lbtn.Size.Height;
                        getval.text = lbtn.Text;
                        getval.width = lbtn.Size.Width;
                        getval.x = lbtn.Location.X;
                        getval.y = lbtn.Location.Y;
                        memoryData.ButtonData[i] = getval;
                        break;
                    }
                }

                rebutton = null;
                rebuttonTarget = null; 
            }
            //回傳目標 = rebuttonTarget
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //this.Select();
            //this.ActiveControl = null;
            //pictureBox1.Focus();
        }

        private void LayerListSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            //pictureBox1.Controls.Clear();
            for (int i = 0; i < memoryData.LayerData.Count; i++) //換底圖
            {
                Layerstruct getimg = (Layerstruct)memoryData.LayerData[i];
                if (getimg.name == LayerListSelect.Text)
                {
                    pictureBox1.BackColor = Color.FromArgb(getimg.backColor);
                    if (getimg.backImage != "")
                    {
                        if (System.IO.File.Exists(getimg.backImage))
                        {
                            //find
                            FileStream fs = File.OpenRead(getimg.backImage);
                            pictureBox1.BackgroundImage = (Bitmap)Image.FromStream(fs);
                            fs.Close();
                        }
                        else
                        {
                            //not found
                        }
                        
                    
                       if (getimg.sizeMode == "Zoom")
                       { pictureBox1.BackgroundImageLayout = ImageLayout.Zoom; }
                       else
                       { pictureBox1.BackgroundImageLayout = ImageLayout.Stretch; }
                    }
               
                else { pictureBox1.BackgroundImage = null; }
                    break;
                }
            }

            for (int i = 0; i < memoryData.LabelData.Count; i++)  //找LABEL
            {
                LabelObjstruct getval = (LabelObjstruct)memoryData.LabelData[i];
                Label tar = (Label)pictureBox1.Controls[getval.name];
                if (getval.layer == LayerListSelect.Text)
                {
                    tar.Visible = true;
                }
                else
                {
                    tar.Visible = false;
                }
            }

            for (int i = 0; i < memoryData.ButtonData.Count; i++)  //找BUTTON
            {
                ButtonObjstruct getval = (ButtonObjstruct)memoryData.ButtonData[i];
                DoubleClickButton tar = (DoubleClickButton)pictureBox1.Controls[getval.name];
                if (getval.layer == LayerListSelect.Text)
                {
                    tar.Visible = true;
                }
                else
                {
                    tar.Visible = false;
                }
            }

            for (int i = 0; i < memoryData.OutputPopData.Count; i++)  //pop form button
            {
                OutputPopObjectstruct getval = (OutputPopObjectstruct)memoryData.OutputPopData[i];
                DoubleClickButton tar = (DoubleClickButton)pictureBox1.Controls[getval.name];
                if (getval.layer == LayerListSelect.Text)
                {
                    tar.Visible = true;
                }
                else
                {
                    tar.Visible = false;
                }
            }

            for (int i = 0; i < memoryData.InputData.Count; i++)  //找INPUT
            {
                InputObjectstruct getval = (InputObjectstruct)memoryData.InputData[i];
                Label tar = (Label)pictureBox1.Controls[getval.name];
                if (getval.layer == LayerListSelect.Text)
                {
                    tar.Visible = true;
                    if (getval.unituse == true)
                    {
                        if (getval.showvalue != null)
                        {
                            tar.Text = getval.showvalue + " " + getval.unit;
                        }
                        else
                        {
                            tar.Text = "0 " + getval.unit;
                        }
                        
                    }
                    else
                    {
                        if (getval.showvalue != null)
                        {
                            tar.Text = getval.showvalue;
                        }
                        else
                        {
                            tar.Text = "0";
                        }
                    }
                    
                }
                else
                {
                    tar.Visible = false;
                }
            }

            for (int i = 0; i < memoryData.AlarmData.Count; i++)  //找ALARM
            {
                AlarmObjectstruct getval = (AlarmObjectstruct)memoryData.AlarmData[i];
                PictureBox tar = (PictureBox)pictureBox1.Controls[getval.name];
                if (getval.layer == LayerListSelect.Text)
                {
                    tar.Visible = true;
                }
                else
                {
                    tar.Visible = false;
                }
            }

            for (int i = 0; i < memoryData.PictureData.Count; i++)  //找picture
            {
                PictureboxObjectstruct getval = (PictureboxObjectstruct)memoryData.PictureData[i];
                PictureBox tar = (PictureBox)pictureBox1.Controls[getval.name];
                if (getval.layer == LayerListSelect.Text)
                {
                    tar.Visible = true;
                }
                else
                {
                    tar.Visible = false;
                }
            }

            for (int i = 0; i < memoryData.OutputTextData.Count; i++)  //找output textbox
            {
                OutputTextObjectstruct getval = (OutputTextObjectstruct)memoryData.OutputTextData[i];
                TextBox tar = (TextBox)pictureBox1.Controls[getval.name];
                if (getval.layer == LayerListSelect.Text)
                {
                    tar.Visible = true;
                }
                else
                {
                    tar.Visible = false;
                }
            }

            for (int i = 0; i < memoryData.OutputButtonData.Count; i++)  //找output switch
            {
                OutputButtonObjectstruct getval = (OutputButtonObjectstruct)memoryData.OutputButtonData[i];
                PictureBox tar = (PictureBox)pictureBox1.Controls[getval.name];
                if (getval.layer == LayerListSelect.Text)
                {
                    tar.Visible = true;
                }
                else
                {
                    tar.Visible = false;
                }
            }

            
        }

        private void RunMode_Click(object sender, EventArgs e)
        {
            if (RunMode.Checked == false)
            {
                RunMode.Image = Image.FromFile(Application.StartupPath + @"\Resources\image\config.png");
                RunMode.ToolTipText = "Edit mode";
                Mainmenu.Enabled = false;
                pictureBox1.ContextMenuStrip = null;
                LayerListSelect.SelectedIndex = 0;
                LayerListSelect.Enabled = false;
                AddObjText.Enabled = false;
                AddObjButton.Enabled = false;
                delSelectObj.Enabled = false;
                AddObjInput.Enabled = false;
                AddObjOutput.Enabled = false;
                AddObjAlarm.Enabled = false;
                AddObjPicture.Enabled = false;

                fileTool.Enabled = false; //file
                deviceTool.Enabled = false; //device
                layerTool.Enabled = false; //layer
                optionTool.Enabled = false; //option

                activeMode.Text = "Running";
                activeMode.TextAlign = ContentAlignment.MiddleLeft;
                activeMode.ForeColor = Color.RoyalBlue;
                RunMode.Checked = true;
                //timer1.Enabled = true;
                LockObj.Enabled = false;
                
                    //get first nv value
                    Thread getvalue = new Thread(_ThreadGetFirstNVvalue);
                getvalue.Start();
               
            }
            else
            {
                RunMode.Image = Image.FromFile(Application.StartupPath + @"\Resources\image\play.png");
                RunMode.ToolTipText = "Run mode";
                Mainmenu.Enabled = true ;
                pictureBox1.ContextMenuStrip = iconRightMenu;
                LayerListSelect.Enabled = true;
                AddObjText.Enabled = true;
                AddObjButton.Enabled = true;
                delSelectObj.Enabled = true;
                AddObjInput.Enabled = true;
                AddObjOutput.Enabled = true;
                AddObjAlarm.Enabled = true;
                AddObjPicture.Enabled = true;

                fileTool.Enabled = true; //file
                deviceTool.Enabled = true; //device
                layerTool.Enabled = true; //layer
                if(accLV == "admin")
                {
                    optionTool.Enabled = true; //option
                }
                

                activeMode.Text = "edit mode...";
                activeMode.TextAlign = ContentAlignment.MiddleCenter;
                //activeMode.ForeColor = SystemColors.ControlText;
                activeMode.ForeColor = Color.DarkRed;
                RunMode.Checked = false;
                
                LockObj.Enabled = true;
                //soundplay.Stop();

                for (int i = 0; i < memoryData.InputData.Count; i++)
                {
                    InputObjectstruct edit = (InputObjectstruct)memoryData.InputData[i];
                    edit.logtimecount = 0;
                    edit.count = 0;
                    memoryData.InputData[i] = edit;
                }

                for (int i = 0; i < memoryData.AlarmData.Count; i++)
                {
                    AlarmObjectstruct edit = (AlarmObjectstruct)memoryData.AlarmData[i];
                    edit.sampleRatecount = 0;
                    edit.timeOvercount = 0;
                    edit.AlarmFalseRun = true;
                    edit.AlarmTrueRun = true;
                    edit.AlarmStatus = false;
                    memoryData.AlarmData[i] = edit;
                }

                
                memoryData.AlarmAudioFalse.Clear();
                memoryData.AlarmAudioTrue.Clear();

                //for (int ac = 0; ac < memoryData.AlarmData.Count; ac++)
                //{
                //    AlarmObjectstruct tar = (AlarmObjectstruct)memoryData.AlarmData[ac];
                //    tar.AlarmFalseRun = false;
                //    tar.AlarmTrueRun = true;
                //    tar.AlarmStatus = false;
                //    memoryData.AlarmData[ac] = tar;
                //}

            }
        }

       

        private void Form1_Resize(object sender, EventArgs e)
        {
            int nw , nh ;
            nw = this.Size.Width;
            nh = this.Size.Height;
            nw = nw - 16;
            nh = nh - 111;
            pictureBox1.Size = new Size(nw, nh);
            pictureBox1.Location = new Point(0, 50);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            //pictureBox1.Select();
        }

        private void delSelectObj_Click(object sender, EventArgs e)
        {
            string[] tmpStr = this.ActiveControl.Tag.ToString().Split('@');
            string tar = tmpStr[0];

            switch (tar)// (this.ActiveControl.Tag.ToString())
            {
                case "label":
                    //Label lb = (Label)this.ActiveControl;
                    for (int i = 0; i < memoryData.LabelData.Count; i++)
                    {
                        LabelObjstruct edit = (LabelObjstruct)memoryData.LabelData[i];
                        if (edit.name == this.ActiveControl.Name)
                        {
                            memoryData.LabelData.RemoveAt(i);
                            memoryData.iconTemp.Remove(edit.name);
                            pictureBox1.Controls.Remove(pictureBox1.Controls[edit.name]);
                            break;
                        }
                    }
                    break;
                case "button":
                    //DoubleClickButton bt = (DoubleClickButton)this.ActiveControl;
                    for (int i = 0; i < memoryData.ButtonData.Count; i++)
                    {
                        ButtonObjstruct edit = (ButtonObjstruct)memoryData.ButtonData[i];
                        if (edit.name == this.ActiveControl.Name)
                        {
                            memoryData.ButtonData.RemoveAt(i);
                            memoryData.iconTemp.Remove(edit.name);
                            pictureBox1.Controls.Remove(pictureBox1.Controls[edit.name]);
                            break;
                        }
                    }
                    break;
                case "input":
                    //Label inlb = (Label)this.ActiveControl;
                    for (int i = 0; i < memoryData.InputData.Count; i++)
                    {
                        InputObjectstruct edit = (InputObjectstruct)memoryData.InputData[i];
                        if (edit.name == this.ActiveControl.Name)
                        {
                            string[] tt = edit.target.Split('@');

                            memoryData.InputData.RemoveAt(i);
                            memoryData.iconTemp.Remove(edit.name);
                            //if (tt[0] == "lon")
                            //{
                            //    if (memoryData.InputData.Count == 0)
                            //    {
                                    //LonTimer.Enabled = false;
                            //    }
                            //}
                            pictureBox1.Controls.Remove(pictureBox1.Controls[edit.name]);
                            break;
                        }
                    }
                    break;

                case "pop":
                    for (int i = 0; i < memoryData.OutputPopData.Count; i++)
                    {
                        OutputPopObjectstruct edit = (OutputPopObjectstruct)memoryData.OutputPopData[i];
                        if (edit.name == this.ActiveControl.Name)
                        {
                            memoryData.OutputPopData.RemoveAt(i);
                            memoryData.iconTemp.Remove(edit.name);
                            pictureBox1.Controls.Remove(pictureBox1.Controls[edit.name]);
                            break;
                        }
                    }
                    break;

                case "switch":
                    for (int i = 0; i < memoryData.OutputButtonData.Count; i++)
                    {
                        OutputButtonObjectstruct edit = (OutputButtonObjectstruct)memoryData.OutputButtonData[i];
                        if (edit.name == this.ActiveControl.Name)
                        {
                            memoryData.OutputButtonData.RemoveAt(i);
                            memoryData.iconTemp.Remove(edit.name);
                            pictureBox1.Controls.Remove(pictureBox1.Controls[edit.name]);
                            break;
                        }
                    }
                    break;

                case "outputText":
                    for (int i = 0; i < memoryData.OutputTextData.Count; i++)
                    {
                        OutputTextObjectstruct edit = (OutputTextObjectstruct)memoryData.OutputTextData[i];
                        if (edit.name == this.ActiveControl.Name)
                        {
                            memoryData.OutputTextData.RemoveAt(i);
                            memoryData.iconTemp.Remove(edit.name);
                            pictureBox1.Controls.Remove(pictureBox1.Controls[edit.name]);
                            break;
                        }
                    }
                    break;

                case "image":
                    for (int i = 0; i < memoryData.PictureData.Count; i++)
                    {
                        PictureboxObjectstruct edit = (PictureboxObjectstruct)memoryData.PictureData[i];
                        if (edit.name == this.ActiveControl.Name)
                        {
                            memoryData.PictureData.RemoveAt(i);
                            memoryData.iconTemp.Remove(edit.name);
                            pictureBox1.Controls.Remove(pictureBox1.Controls[edit.name]);
                            break;
                        }
                    }
                    break;

                case "alarm":
                    for (int i = 0; i < memoryData.AlarmData.Count; i++)
                    {
                        AlarmObjectstruct edit = (AlarmObjectstruct)memoryData.AlarmData[i];
                        if (edit.name == this.ActiveControl.Name)
                        {
                            memoryData.AlarmData.RemoveAt(i);
                            memoryData.iconTemp.Remove(edit.name);
                            pictureBox1.Controls.Remove(pictureBox1.Controls[edit.name]);
                            break;
                        }
                    }

                    for (int j = 0; j < memoryData.AlarmMonitorValue.Count; j++)
                    {
                        AlarmMoniTorNV edit = (AlarmMoniTorNV)memoryData.AlarmMonitorValue[j];
                        if (edit.name == this.ActiveControl.Name)
                        {
                            
                            memoryData.AlarmMonitorValue.RemoveAt(j);
                            break;
                        }
                    }

                    break;
            }
        }

     

        private void deleteObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            delSelectObj.Select();
            delSelectObj_Click(sender, e);
        }

        private string systemTimerStr = "";
       

        private void labelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddObjText.Select();
            AddObjText_Click(sender, e);
        }

        private void buttonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddObjButton.Select();
            AddObjButton_Click(sender, e);
        }

        private void AddObjInput_Click(object sender, EventArgs e)
        {
            config_InputObjectNVType NVForm = new config_InputObjectNVType();
            NVForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
            NVForm.ShowDialog();
            if (reoutputNV != null)
            {
                LayerListSelect.Select();
                if (LayerListSelect.Text != null)
                {
                    LabelWithOptionalCopyTextOnDoubleClick lb = new LabelWithOptionalCopyTextOnDoubleClick();
                    lb.Text = "new input tag";
                    lb.Name = chkAddIconName("1");
                    lb.Tag = "input@" + reoutputNV;
                    lb.Font = new Font("Arial", 12, FontStyle.Regular);
                    lb.AutoSize = true;
                    lb.Location = new Point(10, 10);
                    lb.DoubleClick += new System.EventHandler(this.label_DoubleClick);
                    lb.Click += new System.EventHandler(this.label_Click);
                    lb.Paint += new System.Windows.Forms.PaintEventHandler(this.label_paint);
                    lb.Leave += new System.EventHandler(this.label_Level);
                    lb.Enter += new System.EventHandler(this.label_Enter);
                    lb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_mouseMove);
                    lb.MouseEnter += new System.EventHandler(this.label_mouseEnter);
                    lb.MouseLeave += new System.EventHandler(this.label_mouseLevel);
                    lb.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.label_KeyUp);
                    //lb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Icon_MouseDown);
                    pictureBox1.Controls.Add(lb);

                    InputObjectstruct addnew = new InputObjectstruct();
                    addnew.backcolor = lb.BackColor.ToArgb();
                    addnew.forecolor = lb.ForeColor.ToArgb();
                    addnew.font = lb.Font;
                    addnew.layer = LayerListSelect.Text;
                    addnew.name = lb.Name;
                    //addnew.text = lb.Text;
                    addnew.x = lb.Location.X;
                    addnew.y = lb.Location.Y;
                    addnew.border = lb.BorderStyle;
                    addnew.count = 0;
                    addnew.logdata = false;
                    addnew.logtime = 0;
                    addnew.stringFormat = "";
                    addnew.target = "";
                    addnew.targetindex = "";
                    addnew.unit = "";
                    addnew.unituse = false;
                    addnew.value = "0";
                    addnew.lonPolltime = 600;
                    addnew.ip = "127.0.0.1";
                    addnew.tag = lb.Tag.ToString();

                    memoryData.InputData.Add(addnew);
                    memoryData.iconTemp.Add(lb.Name);
                }
            }

        }

               

        private void LockObj_Click(object sender, EventArgs e)
        {
            if (LockObj.Checked == false)
            {
                LockObj.Image = Image.FromFile(Application.StartupPath + @"\Resources\image\lock_16x16.png");
                LockObj.Checked = true;
                LockObj.ToolTipText = "icon status : lock";
            }
            else
            {
                LockObj.Image = Image.FromFile(Application.StartupPath + @"\Resources\image\unlock_16x16.png");
                LockObj.Checked = false;
                LockObj.ToolTipText = "icon status : unlock";
            }
        }
        ///  ///////////////////////////////////////////// animal start
        //private Timer gifTime = new Timer();
        //this.gifTime.Tick += new System.EventHandler(this.gifTime_Tick);
        private Bitmap animatedImage  ;
        private void Image_FrameChanged(object o, EventArgs e)
        {
            //Paintイベントハンドラを呼び出す
            pictureBox1.Invalidate();
        }
        //フォームのPaintイベントハンドラ
        private void gif_Paint(object sender, PaintEventArgs e)
        {
            //フレームを進める
            ImageAnimator.UpdateFrames(animatedImage);
            //画像の表示
            e.Graphics.DrawImage(animatedImage, 0, 0);
        }
        private void showGIF()//object sender, EventArgs e)
        {
                animatedImage = new Bitmap("C:\\switch_off.gif");
            
                //フォームのPaintイベントハンドラを追加
                pictureBox1.Paint += new PaintEventHandler(this.gif_Paint);
                //アニメ開始
                ImageAnimator.Animate(animatedImage, new EventHandler(this.Image_FrameChanged));
                this.gifTime.Interval = 2200;
                this.gifTime.Tick += new System.EventHandler(this.gifTime_Tick);
                this.gifTime.Enabled = true;
        }
        private void gifTime_Tick(object sender, System.EventArgs e)
        {
            //ImageAnimator.StopAnimate(animatedImage, new EventHandler(this.Image_FrameChanged));
            gifTime.Enabled = false;
            PictureBox pb = (PictureBox)pictureBox1.Controls[switchName];
            if (switchVal == "off")
            {
                pb.Image = Image.FromFile(Application.StartupPath + @"\Resources\image\switch_off_png.png");
            }
            else if (switchVal == "on")
            {
                pb.Image = Image.FromFile(Application.StartupPath + @"\Resources\image\switch_on_png.png");
            }
            Cursor.Current = Cursors.Default ;
            
        }
        ///  /////////////////////////////////////////////animal end
       
        private PictureBox repicturebox; //接收picturebox config 的值
        public PictureBox Repicturebox
        {
            set
            {
                repicturebox = value;
            }
        }

        
        protected void picswitch_mouseEnter(object sender, EventArgs e)
        {
            PictureBox lbtn = (PictureBox)sender;
            lbtn.Select();
            string[] gettype = lbtn.Tag.ToString().Split('@');
            if (gettype[0] == "image")
            {
                toolStripStatusLabel2.Text = "image object location(" + lbtn.Location.X + "," + lbtn.Location.Y + ")";
            }
            else if (gettype[0] == "switch")
            {
                toolStripStatusLabel2.Text = "switch output object location(" + lbtn.Location.X + "," + lbtn.Location.Y + ")";
            }
            else if (gettype[0] == "alarm")
            {
                toolStripStatusLabel2.Text = "alarm object location(" + lbtn.Location.X + "," + lbtn.Location.Y + ")";
            }
            
        }

        protected void picswitch_mouseLevel(object sender, System.EventArgs e)
        {
            toolStripStatusLabel2.Text = "";
        }

        protected void picswitch_mouseMove(object sender, MouseEventArgs e)
        {

            if (RunMode.Checked == false && LockObj.Checked == false && e.Button == MouseButtons.Left && (ModifierKeys & Keys.Control) == Keys.Control)
            {
                //  Layeredit.mouseHold = false;
                if (this.ActiveControl != null)
                {
                    int index = 0;
                    PictureBox lbtn = (PictureBox)sender;
                    string[] tag = lbtn.Tag.ToString().Split('@');
                    if (tag[0] == "switch")
                    {
                        OutputButtonObjectstruct editstr = new OutputButtonObjectstruct();
                        for (int i = 0; i < memoryData.OutputButtonData.Count; i++)
                        {
                            OutputButtonObjectstruct getstr = (OutputButtonObjectstruct)memoryData.OutputButtonData[i];
                            if (getstr.name == lbtn.Name)
                            {
                                index = i;
                                editstr = getstr;
                                break;
                            }
                        }
                        if (this.ActiveControl.Name == lbtn.Name)
                        {
                            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                            {
                                lbtn.Top = e.Y + lbtn.Location.Y - (lbtn.Size.Height / 2);
                                lbtn.Left = e.X + lbtn.Location.X - (lbtn.Size.Width / 2);
                                editstr.x = lbtn.Left;
                                editstr.y = lbtn.Top;
                                memoryData.OutputButtonData[index] = editstr;
                                toolStripStatusLabel2.Text = "switch output object location(" + lbtn.Location.X + "," + lbtn.Location.Y + ")";
                            }
                        }
                    }
                    else if (tag[0] == "image")
                    {
                        PictureboxObjectstruct editstr = new PictureboxObjectstruct();
                        for (int i = 0; i < memoryData.PictureData.Count; i++)
                        {
                            PictureboxObjectstruct getstr = (PictureboxObjectstruct)memoryData.PictureData[i];
                            if (getstr.name == lbtn.Name)
                            {
                                index = i;
                                editstr = getstr;
                                break;
                            }
                        }
                        if (this.ActiveControl.Name == lbtn.Name)
                        {
                            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                            {
                                lbtn.Top = e.Y + lbtn.Location.Y - (lbtn.Size.Height / 2);
                                lbtn.Left = e.X + lbtn.Location.X - (lbtn.Size.Width / 2);
                                editstr.x = lbtn.Left;
                                editstr.y = lbtn.Top;
                                memoryData.PictureData[index] = editstr;
                                toolStripStatusLabel2.Text = "image object location(" + lbtn.Location.X + "," + lbtn.Location.Y + ")";
                            }
                        }
                    }
                    else if (tag[0] == "alarm")
                    {
                        AlarmObjectstruct editstr = new AlarmObjectstruct();
                        for (int i = 0; i < memoryData.AlarmData.Count; i++)
                        {
                            AlarmObjectstruct getstr = (AlarmObjectstruct)memoryData.AlarmData[i];
                            if (getstr.name == lbtn.Name)
                            {
                                index = i;
                                editstr = getstr;
                                break;
                            }
                        }
                        if (this.ActiveControl.Name == lbtn.Name)
                        {
                            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                            {
                                lbtn.Top = e.Y + lbtn.Location.Y - (lbtn.Size.Height / 2);
                                lbtn.Left = e.X + lbtn.Location.X - (lbtn.Size.Width / 2);
                                editstr.LogicFalseX = lbtn.Left;
                                editstr.LogicTrueX = lbtn.Left;
                                editstr.LogicFalseY = lbtn.Top;
                                editstr.LogicTrueY = lbtn.Top;
                                memoryData.AlarmData[index] = editstr;
                                toolStripStatusLabel2.Text = "alarm object location(" + lbtn.Location.X + "," + lbtn.Location.Y + ")";
                            }
                        }
                    }
                }
            }
        }
        protected void picswitch_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            try
            {
                PictureBox lbtn = (PictureBox)sender;
                if (this.ActiveControl.Name == lbtn.Name)
                {
                    ControlPaint.DrawBorder(e.Graphics, (sender as Control).DisplayRectangle, Color.Red, ButtonBorderStyle.Dashed);
                }
                else
                {
                    ControlPaint.DrawBorder(e.Graphics, (sender as Control).DisplayRectangle, Color.Black, ButtonBorderStyle.None);
                }
            }
            catch
            {

            }
        }

        private void picswitch_KeyUp(object sender, PreviewKeyDownEventArgs e)
        {
            if (RunMode.Checked == false && LockObj.Checked == false)
            {
                PictureBox tar = (PictureBox)sender;
                int oldX = tar.Location.X;
                int oldY = tar.Location.Y;

                if (e.KeyCode == Keys.Up)
                {
                    tar.Location = new Point(oldX, oldY - 1);
                }
                else if (e.KeyCode == Keys.Down)
                {
                    tar.Location = new Point(oldX, oldY + 1);
                }
                else if (e.KeyCode == Keys.Left)
                {
                    tar.Location = new Point(oldX - 1, oldY);
                }
                else if (e.KeyCode == Keys.Right)
                {
                    tar.Location = new Point(oldX + 1, oldY);
                }

                string[] tag = tar.Tag.ToString().Split('@');
                if (tag[0] == "switch")
                {
                    for (int i = 0; i < memoryData.OutputButtonData.Count; i++)
                    {
                        OutputButtonObjectstruct edit = (OutputButtonObjectstruct)memoryData.OutputButtonData[i];
                        if (edit.name == tar.Name)
                        {
                            edit.x = tar.Location.X;
                            edit.y = tar.Location.Y;
                            memoryData.OutputButtonData[i] = edit;
                            toolStripStatusLabel2.Text = "switch output object location(" + tar.Left + "," + tar.Top + ")";
                            break;
                        }
                    }
                }
                else if (tag[0] == "image")
                {
                    for (int i = 0; i < memoryData.PictureData.Count; i++)
                    {
                        PictureboxObjectstruct edit = (PictureboxObjectstruct)memoryData.PictureData[i];
                        if (edit.name == tar.Name)
                        {
                            edit.x = tar.Location.X;
                            edit.y = tar.Location.Y;
                            memoryData.PictureData[i] = edit;
                            toolStripStatusLabel2.Text = "image object location(" + tar.Left + "," + tar.Top + ")";
                            break;
                        }
                    }
                }
                else if (tag[0] == "alarm")
                {
                    for (int i = 0; i < memoryData.AlarmData.Count; i++)
                    {
                        AlarmObjectstruct edit = (AlarmObjectstruct)memoryData.AlarmData[i];
                        if (edit.name == tar.Name)
                        {
                            edit.LogicFalseX = tar.Location.X;
                            edit.LogicFalseY = tar.Location.Y;
                            edit.LogicTrueX = tar.Location.X;
                            edit.LogicTrueY = tar.Location.Y;

                            memoryData.AlarmData[i] = edit;
                            toolStripStatusLabel2.Text = "alarm object location(" + tar.Left + "," + tar.Top + ")";
                            break;
                        }
                    }
                }

            }

        }

        protected void picswitch_Enter(object sender, EventArgs e)
        {
            PictureBox lbtn = (PictureBox)sender;
            lbtn.Refresh();
        }
        private void picswitch_mouseUP(object sender, MouseEventArgs e)
        {
            if (RunMode.Checked == true)
            {
                PictureBox lbtn = (PictureBox)sender;
                string[] tag = lbtn.Tag.ToString().Split('@');
                if (tag[0] == "switch")
                {
                    for (int i = 0; i < memoryData.OutputButtonData.Count; i++)
                    {
                        OutputButtonObjectstruct tar = (OutputButtonObjectstruct)memoryData.OutputButtonData[i];
                        if (tar.name == lbtn.Name)
                        {
                            if (tar.buttontype == "1")
                            {lbtn.Image = Image.FromFile(Application.StartupPath + @"\Resources\image\button1_up.png");}
                            else if (tar.buttontype == "2")
                            {lbtn.Image = Image.FromFile(Application.StartupPath + @"\Resources\image\button2_up.png");}
                        }
                    }
                }
            }
        }
        private void picswitch_mouseDOWN(object sender, MouseEventArgs e)
        {
            if (RunMode.Checked == true)
            {
                PictureBox lbtn = (PictureBox)sender;
                string[] tag = lbtn.Tag.ToString().Split('@');
                if (tag[0] == "switch")
                {
                    for (int i = 0; i < memoryData.OutputButtonData.Count; i++)
                    {
                        OutputButtonObjectstruct tar = (OutputButtonObjectstruct)memoryData.OutputButtonData[i];
                        if (tar.name == lbtn.Name)
                        {
                            if (tar.buttontype == "1")
                            {lbtn.Image = Image.FromFile(Application.StartupPath + @"\Resources\image\button1_down.png");}
                            else if (tar.buttontype == "2")
                            {lbtn.Image = Image.FromFile(Application.StartupPath + @"\Resources\image\button2_down.png");}
                        }
                    }
                }
            }
        }
        protected void picswitch_Level(object sender, EventArgs e)
        {
            PictureBox lbtn = (PictureBox)sender;
            lbtn.Refresh();
        }
        private string switchVal = "";
        private string switchName = "";
        protected void picswitch_Click(object sender, EventArgs e)
        {
            if (RunMode.Checked == true)
            {
                Cursor.Current = Cursors.WaitCursor;
                PictureBox lbtn = (PictureBox)sender;
                string[] tag = lbtn.Tag.ToString().Split('@');
                string cmdFB = "";
                string cmdTarget = "";

                string formatForMySqlDate = DateTime.Now.ToString("yyyy-MM-dd");
                string formatForMySqlTime = DateTime.Now.ToString("HH:mm:ss");
                string formatForMySqlDay = DateTime.Now.Day.ToString();
                string tableName = "value" + DateTime.Now.ToString("yyyyMM");

                //switchName = lbtn.Name;
                lbtn.Focus();
                if (tag[0] == "switch")
                {
                    for (int i = 0; i < memoryData.OutputButtonData.Count; i++)
                    {
                        OutputButtonObjectstruct tar = (OutputButtonObjectstruct)memoryData.OutputButtonData[i];
                        long LastID = 0;
                        if (tar.target != "")
                        {
                            cmdTarget = tar.target;
                            //SmartServer.SOAP rfb = new SmartServer.SOAP();
                            SOAP20_DLL.SOAP ws = new SOAP20_DLL.SOAP();
                            //string FB = "";
                            string sendCMD = "";
                            if (tar.name == lbtn.Name)
                            {
                                switch (tar.NVvalue)
                                {
                                    case "0.0 0":
                                        string[] tar2 = tar.target.Split('@');
                                        //rfb.writeNV(tar.ip, tar2[2], "0.0 0");
                                        string requestVal = ws.writeNV(tar.ip, tar2[2], "0.0 0");
                                        sendCMD = "0.0 0";
                                        //FB = rfb.readNV(tar.ip, tar2[2]);
                                        string[] fbval = requestVal.Split('=');
                                        //string[] spR = FB.Split('$');  //100.0 1
                                        //string[] SFB = spR[0].Split(' '); // 
                                        string[] SFB = fbval[1].Split(' '); // 

                                        cmdFB = fbval[0];
                                        if (SFB[2] == "0")
                                        {
                                            switchVal = "off";
                                            if (tar.buttontype == "0")
                                            {
                                                switchName = lbtn.Name;
                                                gifTime.Interval = 2000;
                                                lbtn.Image = Image.FromFile(Application.StartupPath + @"\Resources\image\switch_off.gif");
                                                //Application.DoEvents();
                                                //System.Threading.Thread.Sleep(1);
                                                gifTime.Enabled = true;
                                            }
                                            else if (tar.buttontype == "1")
                                            {
                                                lbtn.Image = Image.FromFile(Application.StartupPath + @"\Resources\image\button1_up.png");
                                            }
                                            else if (tar.buttontype == "2")
                                            {
                                                lbtn.Image = Image.FromFile(Application.StartupPath + @"\Resources\image\button2_up.png");
                                            }
                                            else if (tar.buttontype == "3")
                                            {
                                                lbtn.Image = Image.FromFile(Application.StartupPath + @"\Resources\image\buttonknob1-off.png");
                                            }
                                            else if (tar.buttontype == "4")
                                            {
                                                lbtn.Image = Image.FromFile(tar.userOffImagePath);
                                            }
                                        }


                                        break;
                                    case "100.0 1":
                                        string[] tar3 = tar.target.Split('@');
                                        //rfb.writeNV(tar.ip, tar3[2], "100.0 1");
                                        string  requestVal2 = ws.writeNV(tar.ip, tar3[2], "100.0 1");
                                        sendCMD = "100.0 1";
                                        string[] spR3 = requestVal2.Split('=');
                                        //FB = rfb.readNV(tar.ip, tar3[2]);
                                        //string[] spR3 = FB.Split('$');
                                        string[] SFB3 = spR3[1].Split(' ');
                                        cmdFB = spR3[1];
                                        if (SFB3[2] == "1")
                                        {
                                            switchVal = "on";
                                            if (tar.buttontype == "0")
                                            {
                                                switchName = lbtn.Name;
                                                gifTime.Interval = 2000;
                                                lbtn.Image = Image.FromFile(Application.StartupPath + @"\Resources\image\switch_on.gif");
                                                //Application.DoEvents();
                                                //System.Threading.Thread.Sleep(1);
                                                gifTime.Enabled = true;
                                            }
                                            else if (tar.buttontype == "1")
                                            {
                                                lbtn.Image = Image.FromFile(Application.StartupPath + @"\Resources\image\button1_down.png");
                                            }
                                            else if (tar.buttontype == "2")
                                            {
                                                lbtn.Image = Image.FromFile(Application.StartupPath + @"\Resources\image\button2_down.png");
                                            }
                                            else if (tar.buttontype == "3")
                                            {
                                                lbtn.Image = Image.FromFile(Application.StartupPath + @"\Resources\image\buttonknob1-on.png");
                                            }
                                            else if (tar.buttontype == "4")
                                            {
                                                lbtn.Image = Image.FromFile(tar.userOnImagePath);
                                            }
                                        }

                                        break;
                                    case "toggle":
                                        string[] tar4 = tar.target.Split('@');
                                        string getans = ws.readNV(tar.ip, tar4[2]); //("192.168.1.224", "Net/LON/iLON App/Digital Output 1/nvoClaValueFb_1");
                                        System.Threading.Thread.Sleep(10);
                                        string[] getval = getans.Split('$');
                                        if (getval[0] == "100.0 1")
                                        {
                                            //rfb.writeNV(tar.ip, tar4[2], "0.0 0");
                                            string requestVal3 = ws.writeNV(tar.ip, tar4[2], "0.0 0");
                                            sendCMD = "0.0 0";
                                            //FB = rfb.readNV(tar.ip, tar4[2]);
                                            string[] spR4 = requestVal3.Split('=');
                                            string[] SFB4 = spR4[1].Split(' ');
                                            cmdFB = spR4[1];
                                            if (SFB4[2] == "0")
                                            {
                                                if (tar.buttontype == "0")
                                                {
                                                    switchName = lbtn.Name;
                                                    gifTime.Interval = 2000;
                                                    lbtn.Image = Image.FromFile(Application.StartupPath + @"\Resources\image\switch_off.gif");
                                                    //Application.DoEvents();
                                                    //System.Threading.Thread.Sleep(1);
                                                    gifTime.Enabled = true;
                                                }
                                                else if (tar.buttontype == "3")
                                                {
                                                    switchName = lbtn.Name;
                                                    lbtn.Image = Image.FromFile(Application.StartupPath + @"\Resources\image\buttonknob1-off.png");
                                                }
                                                else if (tar.buttontype == "4")
                                                {
                                                    switchName = lbtn.Name;
                                                    lbtn.Image = Image.FromFile(tar.userOffImagePath);
                                                }

                                                switchVal = "off";
                                            }

                                        }
                                        else if (getval[0] == "0.0 0")
                                        {
                                            //rfb.writeNV(tar.ip, tar4[2], "100.0 1");
                                            string requestVal3 = ws.writeNV(tar.ip, tar4[2], "100.0 1");
                                            sendCMD = "100.0 1";
                                            //FB = rfb.readNV(tar.ip, tar4[2]);
                                            string[] spR5 = requestVal3.Split('=');
                                            string[] SFB5 = spR5[1].Split(' ');
                                            cmdFB = spR5[1];
                                            if (SFB5[2] == "1")
                                            {
                                                if (tar.buttontype == "0")
                                                {
                                                    switchName = lbtn.Name;
                                                    gifTime.Interval = 2000;
                                                    lbtn.Image = Image.FromFile(Application.StartupPath + @"\Resources\image\switch_on.gif");
                                                    //Application.DoEvents();
                                                    //System.Threading.Thread.Sleep(1);
                                                    gifTime.Enabled = true;
                                                }
                                                else if (tar.buttontype == "3")
                                                {
                                                    switchName = lbtn.Name;
                                                    lbtn.Image = Image.FromFile(Application.StartupPath + @"\Resources\image\buttonknob1-on.png");
                                                }
                                                else if (tar.buttontype == "4")
                                                {
                                                    switchName = lbtn.Name;
                                                    lbtn.Image = Image.FromFile(tar.userOnImagePath);
                                                }
                                                switchVal = "on";
                                            }


                                        }
                                        
                                        //SQL
                                        if (memoryData.database.Count != 0)
                                        {
                                            database SQLstr = (database)memoryData.database[0];
                                            //save to database
                                            //open database   ///////////////////////////////////////////////////////////////////////
                                            string connStr = "server=" + SQLstr.ip + ";port=" + SQLstr.port + ";uid=" + SQLstr.user + ";pwd=" + SQLstr.password + ";database=" + SQLstr.DBname;
                                            MySqlConnection conn = new MySqlConnection(connStr);
                                            MySqlCommand addList = conn.CreateCommand();
                                            //save to database
                                            try
                                            {
                                                conn.Open();  //開啟資料庫

                                                //查詢output_list表單是否存在
                                                try
                                                {
                                                    //表單查詢，若不存在則進入catch
                                                    string sqlStr = @"select count(*) from " + SQLstr.DBname + ".output_list";
                                                    MySqlCommand cmdCHK = new MySqlCommand(sqlStr, conn);
                                                    MySqlDataReader dataCHK = cmdCHK.ExecuteReader();
                                                    dataCHK.Close();

                                                    //表單存在
                                                    //搜尋資料
                                                    sqlStr = @"SELECT * FROM output_list WHERE site='" + tar.site + "' and fab='" + tar.fab + "' and area='" + tar.area
                                                                + "' and device='" + tar.device + "' and function='" + tar.function + "' and NVname='" + tar.NV + "' ";

                                                    MySqlCommand Getcmd = new MySqlCommand(sqlStr, conn);
                                                    MySqlDataReader GetRow = Getcmd.ExecuteReader();

                                                    if (GetRow.HasRows == true)
                                                    {
                                                        //資料存在 update description
                                                        GetRow.Read();
                                                        LastID = int.Parse(GetRow.GetString(0));
                                                        GetRow.Close();
                                                        addList.CommandText = @"update " + "nico_db" + ".output_list set description = '" + tar.description + "' where id = " + LastID;
                                                        addList.ExecuteNonQuery(); //更新input_list裡的description
                                                    }
                                                    else
                                                    {
                                                        //資料不存在 insert description
                                                        GetRow.Close();
                                                        addList.CommandText = @"Insert into output_list(site,fab,area,device,function,NVname,NVtype,description,ip) values('"
                                                                                                        + tar.site + "','" + tar.fab + "','" + tar.area + "','" + tar.device + "','" + tar.function + "','"
                                                                                                        + tar.NV + "','" + tar.NVtype + "','" + tar.description + "','" + tar.ip + "');";
                                                        addList.ExecuteNonQuery(); //新增input_list 
                                                        LastID = addList.LastInsertedId;
                                                    }
                                                    
                                                }
                                                catch (Exception ex)  //表單不存在
                                                {
                                                    //create 建立output_list表單
                                                    string addSqlstr = @"create table " + SQLstr.DBname + ".output_list(id SMALLINT auto_increment primary key,site char(32)not null"
                                                                + ",fab char(32)not null,area char(32)not null,device char(20)not null,function char(20)not null"
                                                                + ",NVname char(20)not null,NVtype char(20)not null,description char(32),ip char(15)not null)ENGINE = MYISAM  DEFAULT COLLATE utf8_general_ci;";

                                                    MySqlCommand SQLcmd = conn.CreateCommand();  //建立SQL命令
                                                    SQLcmd.CommandText = addSqlstr;
                                                    SQLcmd.ExecuteNonQuery();

                                                    //寫入資料 output_list
                                                    addSqlstr = @"Insert into output_list(site,fab,area,device,function,NVname,NVtype,description,ip) values('"
                                                                    + tar.site + "','" + tar.fab + "','" + tar.area + "','" + tar.device + "','" + tar.function + "','"
                                                                    + tar.NV + "','" + tar.NVtype + "','" + tar.description + "','" + tar.ip + "');";

                                                    SQLcmd.CommandText = addSqlstr;
                                                    SQLcmd.ExecuteNonQuery();
                                                    LastID = SQLcmd.LastInsertedId;
                                                    //throw;
                                                }  //查詢output_list表單結束

                                                //確認output_value表單是否存在
                                                try
                                                {
                                                    //表單查詢，若不存在則進入catch
                                                    string sqlStr = @"select count(*) from " + SQLstr.DBname + ".output_value" ;
                                                    MySqlCommand cmdCHK = new MySqlCommand(sqlStr, conn);
                                                    MySqlDataReader dataCHK = cmdCHK.ExecuteReader();
                                                    dataCHK.Close();
                                                    //form存在，寫入表單
                                                    //insert資料
                                                    MySqlCommand addValue = conn.CreateCommand();
                                                    addValue.CommandText = @"Insert into output_value(list_id,NVvalue_txt,date,time) values('" + LastID + "','"
                                                                          + sendCMD + "','" + formatForMySqlDate + "','" + formatForMySqlTime + "')";

                                                    addValue.ExecuteNonQuery();


                                                }
                                                catch (Exception) //找不到output_value表單
                                                {
                                                    //建立output_value表單
                                                    string addSqlstr = @"create table " + SQLstr.DBname + ".output_value(id integer auto_increment primary key,list_id SMALLINT not null"
                                                                + ",NVvalue_txt char(11)not null,date char(10)not null,time char(8)not null)ENGINE = MYISAM  DEFAULT COLLATE utf8_general_ci;";

                                                    MySqlCommand SQLcmd = conn.CreateCommand();  //建立SQL命令
                                                    SQLcmd.CommandText = addSqlstr;
                                                    SQLcmd.ExecuteNonQuery();  //建立表單

                                                    SQLcmd.CommandText = @"ALTER TABLE `output_value` ADD KEY `date` (`date`),ADD KEY `list_id` (`list_id`);";
                                                    SQLcmd.ExecuteNonQuery();  //建立索引

                                                    //寫入資料 output_value


                                                    SQLcmd.CommandText = @"Insert into output_value(list_id,NVvalue_txt,date,time) values('" + LastID + "','"
                                                                              + sendCMD + "','" + formatForMySqlDate + "','" + formatForMySqlTime + "')";

                                                    SQLcmd.ExecuteNonQuery();


                                                    //throw;
                                                }  //查詢output_value表單結束

                                            }
                                            catch (Exception ex)   //開啟資料庫失敗
                                            {

                                                //throw;
                                            }
                                            finally
                                            {
                                                conn.Close();  //關閉資料庫
                                            }
                                            //close database
                                        }


                                        //mail
                                        //send email
                                        if (tar.mail == true)
                                        {
                                            for (int m = 0; m < memoryData.GroupContact2.Count; m++)
                                            {
                                                ContactGroup2 mg = (ContactGroup2)memoryData.GroupContact2[m];
                                                if (tar.contactGroup == mg.groupname)
                                                {
                                                    using (FileStream input = new FileStream(Application.StartupPath + @"\Resources\SMTP.dat", FileMode.Open))
                                                    {   // 讀取整數值
                                                        BinaryReader reader = new BinaryReader(input);
                                                        string data = reader.ReadString();

                                                        int numOfBytes = data.Length / 8;
                                                        byte[] bytes = new byte[numOfBytes];
                                                        for (int ri = 0; ri < numOfBytes; ++ri)
                                                        {
                                                            bytes[ri] = Convert.ToByte(data.Substring(8 * ri, 8), 2);
                                                        }
                                                        //File.WriteAllBytes(fileName, bytes);
                                                        string val = GetString(bytes);
                                                        string[] SpStr = val.Split('$');
                                                        string SMTPhost = SpStr[1];
                                                        string SMTPport = SpStr[2];
                                                        Boolean SSL = Boolean.Parse(SpStr[3]);
                                                        string userName = SpStr[4];
                                                        string userPassword = SpStr[5];

                                                        string targetpath = tar.site + "/" + tar.fab + "/" + tar.area + "/" + tar.device + "/" + tar.function + "/" + tar.NV;


                                                        for (int sg = 0; sg < mg.groupmember.Count; sg++)
                                                        {
                                                            Contactstruct sgm = (Contactstruct)mg.groupmember[sg];
                                                            if (sgm.mail != null && sgm.mail != "")
                                                            {
                                                                email.From = new MailAddress(userName);  //寄件人
                                                                email.Subject = "IO trigger!  target : " + targetpath;  //標題
                                                                email.Body = "trigger time = " + formatForMySqlDate + " " + formatForMySqlTime + Environment.NewLine
                                                                             + "trigger value = " + sendCMD + Environment.NewLine + tar.description;  //內容
                                                                email.To.Add(sgm.mail);  //收件人
                                                                SMTP.EnableSsl = true;
                                                                SMTP.Port = int.Parse(SMTPport); //smtp port
                                                                SMTP.Host = SMTPhost;  //smtp host(主機ip)
                                                                SMTP.Credentials = new System.Net.NetworkCredential(userName, userPassword);  //寄件人,密碼
                                                                SMTP.Send(email);
                                                            }
                                                        }
                                                        input.Dispose();
                                                    }

                                                }
                                            }
                                        }

                                        break;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("no target!");
                        }

                    }
                }

                //將一樣的tag同步
                //cmdFB
                for (int i = 0; i < memoryData.OutputButtonData.Count; i++)
                {
                    OutputButtonObjectstruct tar = (OutputButtonObjectstruct)memoryData.OutputButtonData[i];
                    if (tar.target == cmdTarget && tar.layer == LayerListSelect.Text)
                    {
                        PictureBox edit = (PictureBox)pictureBox1.Controls[tar.name];
                        if (cmdFB == "0.0 0")
                        {
                            if (tar.buttontype == "0")
                            {
                                switchName = edit.Name;
                                gifTime.Interval = 2000;
                                edit.Image = Image.FromFile(Application.StartupPath + @"\Resources\image\switch_off.gif");
                                //Application.DoEvents();
                                //System.Threading.Thread.Sleep(1);
                                gifTime.Enabled = true;
                            }
                            else if (tar.buttontype == "1")
                            {
                                //edit.Image = Image.FromFile(Application.StartupPath + @"\Resources\image\button1_up.png");
                            }
                            else if (tar.buttontype == "2")
                            {
                                //edit.Image = Image.FromFile(Application.StartupPath + @"\Resources\image\button2_up.png");
                            }
                            else if (tar.buttontype == "3")
                            {
                                edit.Image = Image.FromFile(Application.StartupPath + @"\Resources\image\buttonknob1-off.png");
                            }
                            else if (tar.buttontype == "4")
                            {
                                edit.Image = Image.FromFile(tar.userOffImagePath);
                            }
                        }
                        else if (cmdFB == "100.0 1")
                        {
                            if (tar.buttontype == "0")
                            {
                                switchName = edit.Name;
                                gifTime.Interval = 2000;
                                edit.Image = Image.FromFile(Application.StartupPath + @"\Resources\image\switch_on.gif");
                                //Application.DoEvents();
                                //System.Threading.Thread.Sleep(1);
                                gifTime.Enabled = true;
                            }
                            else if (tar.buttontype == "1")
                            {
                                //edit.Image = Image.FromFile(Application.StartupPath + @"\Resources\image\button1_down.png");
                            }
                            else if (tar.buttontype == "2")
                            {
                                //edit.Image = Image.FromFile(Application.StartupPath + @"\Resources\image\button2_down.png");
                            }
                            else if (tar.buttontype == "3")
                            {
                                edit.Image = Image.FromFile(Application.StartupPath + @"\Resources\image\buttonknob1-on.png");
                            }
                            else if (tar.buttontype == "4")
                            {
                                edit.Image = Image.FromFile(tar.userOnImagePath);
                            }
                        }
                    }
                }

            }

        }
        protected void picswitch_DoubleClick(object sender, EventArgs e) //建立button CLICK事件
        {
                if (RunMode.Checked == false)
                {
                    PictureBox lbtn = (PictureBox)sender;
                    string[] tag = lbtn.Tag.ToString().Split('@');
                    if (tag[0] == "switch")
                    {
                        if (DeviceNode.Nodes.Count != 0)
                        {
                            config_OutputObjectButton lForm = new config_OutputObjectButton();
                            lForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
                            lForm.picboxName = lbtn.Name;
                            
                            lForm.NVType2 = lbtn.Tag.ToString();

                            foreach (TreeNode node in DeviceNode.Nodes)
                            {
                                lForm.deviceList.Nodes.Add((TreeNode)node.Clone());
                            }

                            lForm.ShowDialog();


                            if (repicturebox != null)
                            {
                                string tmp = repicturebox.Tag.ToString();
                                lbtn.Location = new Point(repicturebox.Location.X, repicturebox.Location.Y);
                                lbtn.Image = Image.FromFile(repicturebox.Tag.ToString());
                                lbtn.Size = new Size(repicturebox.Size.Width, repicturebox.Size.Height);

                                toolTip1.SetToolTip(lbtn, gettooltip);

                                gettooltip = "";
                                repicturebox = null;
                            }

                        }
                        else
                        {
                            DialogResult ans = MessageBox.Show("goto device manager ?", "device list is null!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (ans == DialogResult.Yes)
                            {
                                managaneTool.Select();
                                managaneTool_Click(sender, e);
                            }
                        }
                    }
                    else if (tag[0] == "image")
                    {
                        config_PictureObject lForm = new config_PictureObject();
                        lForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
                        lForm.preview.Image = lbtn.Image;
                        lForm.textX.Text = lbtn.Location.X.ToString();
                        lForm.textY.Text = lbtn.Location.Y.ToString();
                        lForm.textwidth.Text = lbtn.Size.Width.ToString();
                        lForm.textheight.Text = lbtn.Size.Height.ToString();
                        lForm.picName = lbtn.Name;
                        lForm.ShowDialog();

                        if (repicturebox != null)
                        {
                           FileStream fs = File.OpenRead(repicturebox.Tag.ToString());
                           lbtn.Image = (Bitmap)Image.FromStream(fs);
                           fs.Close();

                           //lbtn.Image = Image.FromFile(repicturebox.Tag.ToString());
                           lbtn.Location = repicturebox.Location;
                           lbtn.Size = repicturebox.Size;
                           repicturebox = null;
                        }
                    }
                    else if (tag[0] == "alarm")
                    {
                        if (DeviceNode.Nodes.Count != 0)
                        {
                            config_AlarmObject lForm = new config_AlarmObject();
                            lForm.Owner = this;
                            lForm.AlarmName = lbtn.Name;
                            lForm.NVType = tag[1];
                            lForm.deviceTree = DeviceNode;
                            foreach (TreeNode node in DeviceNode.Nodes)
                            {
                                lForm.deviceTreeLoad.Nodes.Add((TreeNode)node.Clone());
                            }

                            lForm.ShowDialog();

                            if (repicturebox != null)
                            {
                                lbtn.Size = repicturebox.Size;
                                lbtn.Location = repicturebox.Location;
                                if (repicturebox.Tag != null)
                                {
                                    lbtn.Image = Image.FromFile(repicturebox.Tag.ToString());
                                }

                                toolTip1.SetToolTip(lbtn, gettooltip);

                                gettooltip = "";
                                repicturebox = null;
                            }
                        }
                        else
                        {
                            DialogResult ans = MessageBox.Show("goto device manager ?", "device list is null!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (ans == DialogResult.Yes)
                            {
                                managaneTool.Select();
                                managaneTool_Click(sender, e);
                            }
                        }
                        
                    }
                }

             
        }

        private TextBox retextbox; //接收label config 的值
        public TextBox Retextbox
        {
            set
            {
                retextbox = value;
            }
        }
 
        protected void lonValue_keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (RunMode.Checked == true)
                {
                    Cursor.Current = Cursors.WaitCursor ;
                    TextBox tar = (TextBox)pictureBox1.Controls[lonIconName];
                    //string tmp = retextbox.Tag.ToString();
                    //string[] val = tmp.Split('@');

                    for (int i = 0; i < memoryData.OutputTextData.Count; i++)
                    {
                        OutputTextObjectstruct edit = (OutputTextObjectstruct)memoryData.OutputTextData[i];

                        if (edit.name == tar.Name)
                        {
                            
                            if (edit.target != "")
                            {
                                edit.NVvalue = tar.Text;
                                string[] nv = edit.target.Split('@');
                                //SmartServer.SOAP sw = new SmartServer.SOAP();
                                //sw.writeNV(edit.ip, nv[2], tar.Text);
                                SOAP20_DLL.SOAP ws = new SOAP20_DLL.SOAP();
                                string requestVal = ws.writeNV(edit.ip, nv[2], tar.Text);

                                //string ffb = sw.readNV(edit.ip, nv[2]);
                                //string[] FB = ffb.Split('$');



                                memoryData.OutputTextData[i] = edit;
                                //SQL
                                if (edit.log == true) //&& FB[0] == tar.Text)
                                {
                                    if (memoryData.database.Count != 0)
                                    {
                                        database SQLstr = (database)memoryData.database[0];

                                        //save to database
                                        //open database   ///////////////////////////////////////////////////////////////////////
                                        string connStr = "server=" + SQLstr.ip + ";port=" + SQLstr.port + ";uid=" + SQLstr.user + ";pwd=" + SQLstr.password + ";database=" + SQLstr.DBname;
                                        MySqlConnection conn = new MySqlConnection(connStr);
                                        MySqlCommand addList = conn.CreateCommand();
                                        conn.Open();

                                        string sql = @"SELECT * FROM output_list WHERE site='" + edit.site + "' and fab='" + edit.fab + "' and area='" + edit.area
                                                     + "' and device='" + edit.device + "' and function='" + edit.function + "' and NVname='" + edit.NV + "' ";

                                        MySqlCommand cmdCHK = new MySqlCommand(sql, conn);
                                        MySqlDataReader dataCHK = cmdCHK.ExecuteReader();
                                        int listid = 0;
                                        string formatForMySqlDate = DateTime.Now.ToString("yyyy-MM-dd");
                                        string formatForMySqlTime = DateTime.Now.ToString("HH:mm:ss");

                                        if (dataCHK.HasRows == true)
                                        {
                                            dataCHK.Read();
                                            //有查到資料
                                            listid = int.Parse(dataCHK.GetString(0));
                                            dataCHK.Close();

                                            addList.CommandText = @"update nico_db.output_list set description = '" + edit.description + "' where id = " + listid;
                                            addList.ExecuteNonQuery();

                                            MySqlCommand addValue = conn.CreateCommand();

                                            addValue.CommandText = @"Insert into output_value(list_id,NVvalue_txt,date,time) values('" + listid + "','"
                                                                      + tar.Text + "','" + formatForMySqlDate + "','" + formatForMySqlTime + "')";

                                            addValue.ExecuteNonQuery();

                                        }
                                        else
                                        {
                                            dataCHK.Close();
                                            // MySqlCommand addList = conn.CreateCommand();

                                            //沒有查到資料
                                            addList.CommandText = @"Insert into output_list(site,fab,area,device,function,NVname,NVtype,description,ip) values('"
                                                 + edit.site + "','" + edit.fab + "','" + edit.area + "','" + edit.device + "','" + edit.function + "','"
                                                 + edit.NV + "','" + edit.NVtype + "','" + edit.description + "','" + edit.ip + "');";

                                            addList.ExecuteNonQuery();
                                            //get list_id
                                            dataCHK = cmdCHK.ExecuteReader();
                                            dataCHK.Read();
                                            if (dataCHK.HasRows == true)
                                            {
                                                listid = int.Parse(dataCHK.GetString(0));
                                                dataCHK.Close();
                                            }

                                            //write to output_value
                                            MySqlCommand addValue = conn.CreateCommand();

                                            addValue.CommandText = @"Insert into output_value(list_id,NVvalue_txt,date,time) values('" + listid + "','"
                                                                      + tar.Text + "','" + formatForMySqlDate + "','" + formatForMySqlTime + "')";

                                            addValue.ExecuteNonQuery();
                                        }

                                        conn.Close();
                                        //close database    ////////////////////////////////////////////////////////////////////////
                                    }

                                }

                                //mail
                                if (edit.mail == true)
                                {
                                    for (int m = 0; m < memoryData.GroupContact2.Count; m++)
                                    {
                                        ContactGroup2 mg = (ContactGroup2)memoryData.GroupContact2[m];
                                        if (edit.contactGroup == mg.groupname)
                                        {
                                            using (FileStream input = new FileStream(Application.StartupPath + @"\Resources\SMTP.dat", FileMode.Open))
                                            {   // 讀取整數值
                                                BinaryReader reader = new BinaryReader(input);
                                                string data = reader.ReadString();

                                                int numOfBytes = data.Length / 8;
                                                byte[] bytes = new byte[numOfBytes];
                                                for (int ri = 0; ri < numOfBytes; ++ri)
                                                {
                                                    bytes[ri] = Convert.ToByte(data.Substring(8 * ri, 8), 2);
                                                }
                                                //File.WriteAllBytes(fileName, bytes);
                                                string val = GetString(bytes);
                                                string[] SpStr = val.Split('$');
                                                string SMTPhost = SpStr[1];
                                                string SMTPport = SpStr[2];
                                                Boolean SSL = Boolean.Parse(SpStr[3]);
                                                string userName = SpStr[4];
                                                string userPassword = SpStr[5];

                                                string path = edit.site + "/" + edit.fab + "/" + edit.area + "/" + edit.device + "/" + edit.function + "/" + edit.NV;
                                                string formatForMySqlDate = DateTime.Now.ToString("yyyy-MM-dd");
                                                string formatForMySqlTime = DateTime.Now.ToString("HH:mm:ss");

                                                for (int sg = 0; sg < mg.groupmember.Count; sg++)
                                                {
                                                    Contactstruct sgm = (Contactstruct)mg.groupmember[sg];
                                                    if (sgm.mail != null && sgm.mail != "")
                                                    {
                                                        email.From = new MailAddress(userName);  //寄件人
                                                        email.Subject = "IO trigger!  target : " + path;  //標題
                                                        email.Body = "trigger time = " + formatForMySqlDate + " " + formatForMySqlTime + Environment.NewLine
                                                                     + "trigger value = " + tar.Text + Environment.NewLine + edit.description;  //內容
                                                        email.To.Add(sgm.mail);  //收件人
                                                        SMTP.EnableSsl = true;
                                                        SMTP.Port = int.Parse(SMTPport); //smtp port
                                                        SMTP.Host = SMTPhost;  //smtp host(主機ip)
                                                        SMTP.Credentials = new System.Net.NetworkCredential(userName, userPassword);  //寄件人,密碼
                                                        SMTP.Send(email);
                                                    }

                                                }
                                                input.Dispose();
                                            }
                                        }
                                    }
                                }

                            }
                            else
                            {
                                MessageBox.Show("no target!");
                            }
                        }

                    }
                    Cursor.Current = Cursors.Default;
                }

            }
        }

        protected void lonValue_mouseLevel(object sender, System.EventArgs e)
        {
            TextBox lbtn = (TextBox)sender;
            lbtn.BorderStyle = BorderStyle.None ;
            lbtn.Refresh();
            toolStripStatusLabel2.Text = "";
        }

        private void lonValue_KeyUp(object sender, PreviewKeyDownEventArgs e)
        {
            if (RunMode.Checked == false && LockObj.Checked == false)
            {
                TextBox tar = (TextBox)sender;
                int oldX = tar.Location.X;
                int oldY = tar.Location.Y;

                if (e.KeyCode == Keys.Up)
                {
                    tar.Location = new Point(oldX, oldY - 1);
                }
                else if (e.KeyCode == Keys.Down)
                {
                    tar.Location = new Point(oldX, oldY + 1);
                }
                else if (e.KeyCode == Keys.Left)
                {
                    tar.Location = new Point(oldX - 1, oldY);
                }
                else if (e.KeyCode == Keys.Right)
                {
                    tar.Location = new Point(oldX + 1, oldY);
                }

                for (int i = 0; i < memoryData.OutputTextData.Count; i++)
                {
                    OutputTextObjectstruct edit = (OutputTextObjectstruct)memoryData.OutputTextData[i];
                    if (edit.name == tar.Name)
                    {
                        edit.x = tar.Location.X;
                        edit.y = tar.Location.Y;
                        memoryData.OutputTextData[i] = edit;
                        break;
                    }
                }
                toolStripStatusLabel2.Text = "textbox output object location(" + tar.Left + "," + tar.Top + ")";
            }

        }

        protected void lonValue_mouseEnter(object sender, EventArgs e)
        {
            TextBox lbtn = (TextBox)sender;
            lonIconName = lbtn.Name;
            lbtn.Select();
            toolStripStatusLabel2.Text = "textbox output object location(" + lbtn.Location.X + "," + lbtn.Location.Y + ")";

            try
            {
                Graphics pe = this.CreateGraphics();
                lbtn.BorderStyle = BorderStyle.Fixed3D;
                if (this.ActiveControl.Name == lbtn.Name)
                {
                    ControlPaint.DrawBorder(pe, (sender as Control).DisplayRectangle, Color.Red, ButtonBorderStyle.Dashed);
                }
                else
                {
                    ControlPaint.DrawBorder(pe, (sender as Control).DisplayRectangle, Color.Red, ButtonBorderStyle.None);
                }

            }
            catch
            {
            }
            lbtn.Refresh();
        }
        protected void lonValue_mouseMove(object sender, MouseEventArgs e)
        {
            if (RunMode.Checked == false && LockObj.Checked == false && e.Button == MouseButtons.Left && (ModifierKeys & Keys.Control) == Keys.Control)
            {
                if (this.ActiveControl != null)
                {
                    int index = 0;
                    OutputTextObjectstruct editstr = new OutputTextObjectstruct();
                    TextBox lbtn = (TextBox)sender;

                    for (int i = 0; i < memoryData.OutputTextData.Count; i++)
                    {
                        OutputTextObjectstruct getstr = (OutputTextObjectstruct)memoryData.OutputTextData[i];
                        if (getstr.name == lbtn.Name)
                        {
                            index = i;
                            editstr = getstr; 
                            break;
                        }
                    }

                    if (this.ActiveControl.Name == lbtn.Name)
                    {
                        if (e.Button == System.Windows.Forms.MouseButtons.Left)
                        {
                            lbtn.Top = e.Y + lbtn.Location.Y - (lbtn.Size.Height / 2);
                            lbtn.Left = e.X + lbtn.Location.X - (lbtn.Size.Width / 2);
                            editstr.x = lbtn.Left;
                            editstr.y = lbtn.Top;
                            memoryData.OutputTextData[index] = editstr;
                            toolStripStatusLabel2.Text = "textbox output object location(" + lbtn.Location.X + "," + lbtn.Location.Y + ")";
                        }
                    }
                }
            }
            
        }

        protected void lonValuePaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            try
            {
                TextBox lbtn = (TextBox)sender;
                if (this.ActiveControl.Name == lbtn.Name)
                {
                    ControlPaint.DrawBorder(e.Graphics, (sender as Control).DisplayRectangle, Color.Red, ButtonBorderStyle.Dashed);
                }
                else
                {
                    ControlPaint.DrawBorder(e.Graphics, (sender as Control).DisplayRectangle, Color.Red, ButtonBorderStyle.None);
                }

            }
            catch
            {

            }
        }

        protected void lonValue_Enter(object sender, EventArgs e)
        {
            //TextBox lbtn = (TextBox)sender;
            //lbtn.Refresh();
        }
        protected void lonValue_Level(object sender, EventArgs e)
        {
            //TextBox lbtn = (TextBox)sender;
            //lbtn.Refresh();
        }
        private string lonIconName = "";
        protected void lonValue_Click(object sender, EventArgs e)
        {
            if (RunMode.Checked == true)
            {
                Cursor.Current = Cursors.WaitCursor;
                TextBox lbtn = (TextBox)sender;
                lonIconName = lbtn.Name;
                lbtn.Focus();
               
            }

        }
        protected void lonValue_DoubleClick(object sender, EventArgs e) //建立button CLICK事件
        {
            if (RunMode.Checked == false)
            {
                TextBox lbtn = (TextBox)sender;
               // string LabelType = lbtn.Tag.ToString();

                    if (DeviceNode.Nodes.Count != 0)
                    {
                        config_OutputObjectText lForm = new config_OutputObjectText();
                        lForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  


                        foreach (TreeNode node in DeviceNode.Nodes)
                        {
                            lForm.deviceList.Nodes.Add((TreeNode)node.Clone());
                        }
                       
                        TextBox sX = (TextBox)lForm.Controls["edit"].Controls["textX"];
                        TextBox sY = (TextBox)lForm.Controls["edit"].Controls["textY"];
                        TextBox sW = (TextBox)lForm.Controls["edit"].Controls["textwidth"];
                        TextBox sH = (TextBox)lForm.Controls["edit"].Controls["textheight"];
                        sX.Text = lbtn.Location.X.ToString();
                        sY.Text = lbtn.Location.Y.ToString();
                        sW.Text = lbtn.Size.Width.ToString();
                        sH.Text = lbtn.Size.Height.ToString();
                        string[] tmpStr = lbtn.Tag.ToString().Split('@');
                        lForm.NVType2 = tmpStr[1];
                        lForm.textboxName = lbtn.Name;

                        lForm.ShowDialog();

                        if (retextbox != null)
                        {
                            string tmp = retextbox.Tag.ToString();
                            string[] val = tmp.Split('@');
                            lbtn.Location = new Point(int.Parse(val[0]), int.Parse(val[1]));
                            lbtn.Size = new Size(retextbox.Size.Width, retextbox.Size.Height);

                            toolTip1.SetToolTip(lbtn, gettooltip);

                            gettooltip = "";
                            retextbox = null;
                        }

                    }

                //editButtonObj(sender);
            
                    else
                    {
                     DialogResult ans = MessageBox.Show("goto device manager ?", "device list is null!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                       if (ans == DialogResult.Yes)
                       {
                         managaneTool.Select();
                         managaneTool_Click(sender, e);
                       }
                    }
            }
        }

        private string reoutputNV; //接收label config 的值
        public string ReoutputNV
        {
            set
            {
                reoutputNV = value;
            }
        }

        private void AddObjOutput_Click(object sender, EventArgs e)
        {
            config_OutputObjectNVType NVForm = new config_OutputObjectNVType();
            NVForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
            NVForm.ShowDialog();
            //if (NVForm.ShowDialog() == DialogResult.OK)
            //{
            if (reoutputNV != null)
            {
                LayerListSelect.Select();
                if (LayerListSelect.Text != null)
                {
                    string[] buttontype = reoutputNV.Split('@');
                    if (buttontype[0] == "outputText")
                    {
                        TextBox lb = new TextBox();
                        lb.Text = "100.0 1";
                        lb.Name = chkAddIconName("1");
                        lb.Tag = reoutputNV;
                        lb.Font = new Font("Arial", 12, FontStyle.Regular);
                        lb.Size = new Size(60, 24);
                        lb.Location = new Point(10, 10);
                        lb.ContextMenuStrip = iconRightMenu;
                        lb.DoubleClick += new System.EventHandler(this.lonValue_DoubleClick);
                        lb.Click += new System.EventHandler(this.lonValue_Click);
                        //lb.Leave += new System.EventHandler(this.lonValue_Level);
                        //lb.Enter += new System.EventHandler(this.lonValue_Enter);
                        lb.Paint += new System.Windows.Forms.PaintEventHandler(this.lonValuePaint);
                        lb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lonValue_keyDown);
                        lb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lonValue_mouseMove);
                        lb.MouseEnter += new System.EventHandler(this.lonValue_mouseEnter);
                        lb.MouseLeave += new System.EventHandler(this.lonValue_mouseLevel);
                        lb.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.lonValue_KeyUp);
                        lb.BorderStyle = BorderStyle.None;

                        pictureBox1.Controls.Add(lb);

                        OutputTextObjectstruct add = new OutputTextObjectstruct();
                        add.height = lb.Size.Height;
                        add.ip = "127.0.0.1";
                        add.layer = LayerListSelect.Text;
                        add.name = lb.Name;
                        add.NVtype = "lon";
                        add.NVvalue = "100.0 1";
                        add.target = "";
                        add.targetindex = "";
                        add.width = lb.Width;
                        add.x = lb.Location.X;
                        add.y = lb.Location.Y;
                        add.tag = lb.Tag.ToString();
                        memoryData.OutputTextData.Add(add);
                        memoryData.iconTemp.Add(lb.Name);
                    }
                    else if (buttontype[0] == "switch")
                    {
                        PictureBox pb = new PictureBox();
                        pb.Image = Image.FromFile(Application.StartupPath + @"\Resources\image\switch_on_png.png");
                        pb.Name = chkAddIconName("1");
                        pb.Size = new Size(53, 22);
                        pb.SizeMode = PictureBoxSizeMode.StretchImage;
                        pb.Tag = reoutputNV;
                        pb.Location = new Point(10, 10);
                        pb.DoubleClick += new System.EventHandler(this.picswitch_DoubleClick);
                        pb.Click += new System.EventHandler(this.picswitch_Click);
                        pb.Leave += new System.EventHandler(this.picswitch_Level);
                        pb.Enter += new System.EventHandler(this.picswitch_Enter);
                        pb.Paint += new System.Windows.Forms.PaintEventHandler(this.picswitch_Paint);
                        pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picswitch_mouseMove);
                        pb.MouseEnter += new System.EventHandler(this.picswitch_mouseEnter);
                        pb.MouseLeave += new System.EventHandler(this.picswitch_mouseLevel);
                        pb.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picswitch_mouseUP);
                        pb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picswitch_mouseDOWN);
                        pb.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.picswitch_KeyUp);
                        pictureBox1.Controls.Add(pb);

                        OutputButtonObjectstruct add = new OutputButtonObjectstruct();
                        add.height = pb.Size.Height;
                        add.ip = "127.0.0.1";
                        add.layer = LayerListSelect.Text;
                        add.name = pb.Name;
                        add.NVtype = "lon";
                        add.NVvalue = "toggle";
                        add.target = "";
                        add.targetindex = "";
                        add.width = pb.Width;
                        add.x = pb.Location.X;
                        add.y = pb.Location.Y;
                        add.buttontype = "0";
                        add.imagePath = "";
                        add.tag = pb.Tag.ToString();
                        memoryData.OutputButtonData.Add(add);
                        memoryData.iconTemp.Add(pb.Name);

                    }
                    else if (buttontype[0] == "pop")
                    {
                        DoubleClickButton bt = new DoubleClickButton();
                        bt.Text = "new pop";
                        bt.Name = chkAddIconName("1");
                        bt.AutoSize = false;
                        bt.Font = new Font("Arial", 12, FontStyle.Regular);
                        bt.Size = new Size(100, 28);
                        bt.Tag = reoutputNV;
                        bt.Location = new Point(10, 10);
                        bt.DoubleClick += new System.EventHandler(this.buttn_DoubleClick);
                        bt.Click += new System.EventHandler(this.buttn_Click);
                        bt.Paint += new System.Windows.Forms.PaintEventHandler(this.buttn_paint);
                        bt.Leave += new System.EventHandler(this.buttn_Level);
                        bt.Enter += new System.EventHandler(this.buttn_Enter);
                        bt.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttn_mouseMove);
                        bt.MouseEnter += new System.EventHandler(this.buttn_mouseEnter);
                        bt.MouseLeave += new System.EventHandler(this.buttn_mouseLevel);
                        bt.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.buttn_KeyUp);
                        bt.BackgroundImage = null;
                        bt.BackgroundImageLayout = ImageLayout.None;

                        pictureBox1.Controls.Add(bt);

                        OutputPopObjectstruct addnew = new OutputPopObjectstruct();
                        addnew.AlignIMG = bt.ImageAlign;
                        addnew.AlignText = bt.TextAlign;
                        addnew.backColor = bt.BackColor.ToArgb();
                        addnew.backImage = null;
                        addnew.font = bt.Font;
                        addnew.forecolor = bt.ForeColor.ToArgb();
                        addnew.height = bt.Size.Height;
                        addnew.ip = "127.0.0.1";
                        addnew.layer = LayerListSelect.Text;
                        addnew.log = false;
                        addnew.mail = false;
                        addnew.name = bt.Name;
                        addnew.NVtype = "lon";
                        //addnew.NVvalue = "0.0 0";
                        addnew.SMS = false;
                        addnew.target = "";
                        addnew.targetindex = "";
                        addnew.text = bt.Text;
                        addnew.width = bt.Size.Width;
                        addnew.x = bt.Location.X;
                        addnew.y = bt.Location.Y;
                        addnew.tag = bt.Tag.ToString();

                        memoryData.OutputPopData.Add(addnew);
                        memoryData.iconTemp.Add(bt.Name);
                    }
                }
                
                //  }
            }

        }

        private void AddObjAlarm_Click(object sender, EventArgs e)
        {
            config_AlarmObjectNVType lForm = new config_AlarmObjectNVType();
            lForm.Owner = this;
            lForm.ShowDialog();
            if (reoutputNV != null)
            {
                 LayerListSelect.Select();
                 if (LayerListSelect.Text != null)
                 {
                     PictureBox pb = new PictureBox();
                     pb.Image = Image.FromFile(Application.StartupPath + @"\Resources\image\Alarm-stop.png");
                     pb.Name = chkAddIconName("1");
                     pb.Size = new Size(28, 28);
                     pb.SizeMode = PictureBoxSizeMode.StretchImage;
                     pb.Tag = reoutputNV;
                     pb.Location = new Point(10, 10);
                     pb.DoubleClick += new System.EventHandler(this.picswitch_DoubleClick);
                     pb.Click += new System.EventHandler(this.picswitch_Click);
                     pb.Leave += new System.EventHandler(this.picswitch_Level);
                     pb.Enter += new System.EventHandler(this.picswitch_Enter);
                     pb.Paint += new System.Windows.Forms.PaintEventHandler(this.picswitch_Paint);
                     pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picswitch_mouseMove);
                     pb.MouseEnter += new System.EventHandler(this.picswitch_mouseEnter);
                     pb.MouseLeave += new System.EventHandler(this.picswitch_mouseLevel);
                     pb.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picswitch_mouseUP);
                     pb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picswitch_mouseDOWN);
                     pb.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.picswitch_KeyUp);
                     pictureBox1.Controls.Add(pb);

                     AlarmObjectstruct add = new AlarmObjectstruct();
                     //add.ip = "127.0.0.1";
                     add.TargetIP = "127.0.0.1";
                     add.SourceIP = "127.0.0.1";
                     add.layer = LayerListSelect.Text;
                     add.name = pb.Name;
                     add.LogicFalseHeight = pb.Size.Height;
                     add.LogicTrueHeight = pb.Size.Height;
                     add.LogicFalseWidth = pb.Width;
                     add.LogicTrueWidth = pb.Width;
                     add.LogicFalseX = pb.Location.X;
                     add.LogicTrueX = pb.Location.X;
                     add.LogicFalseY = pb.Location.Y;
                     add.LogicTrueY = pb.Location.Y;
                     add.tag = pb.Tag.ToString();

                     add.AlarmTrueRun = true;
                     add.AlarmFalseRun = false;
                     add.AlarmStatus = false;

                     add.CompareLogic = "==";
                     add.CompareMax = 0;
                     add.CompareMin = 0;
                     add.CompareType = "";
                     add.CompareValue = "";

                     string[] getNVtype = reoutputNV.Split('@');
                     add.NVType = getNVtype[1];
                     add.sampleRate = 600;
                     add.timeOver = 0;
                     add.sampleRatecount = 0;
                     add.timeOvercount = 0;
                     add.SourceNVName = "";
                     add.SourceNVindex = "";
                     add.TargetNVName = "";
                     add.TargetNVindex = "";

                     add.LogicFalseAudioPath = "";
                     add.LogicFalseAudioUse = false;
                     add.LogicFalseOutemail = false;
                     add.LogicFalseOutImagePath = Application.StartupPath + @"\Resources\image\Alarm-stop.png";
                     add.LogicFalseOutLog = false;
                     add.LogicFalseOutMSG = "";
                     add.LogicFalseOutNV = false;
                     add.LogicFalseOutNV1 ="";
                     add.LogicFalseOutNV2 ="";
                     add.LogicFalseOutNV3 ="";
                     add.LogicFalseOutNV4 ="";
                     add.LogicFalseOutNV5 ="";
                     add.LogicFalseOutNV6 = "";
                     add.LogicFalseOutNV7 = "";
                     add.LogicFalseOutNV8 = "";
                     add.LogicFalseOutNV1index = "";
                     add.LogicFalseOutNV2index = "";
                     add.LogicFalseOutNV3index = "";
                     add.LogicFalseOutNV4index = "";
                     add.LogicFalseOutNV5index = "";
                     add.LogicFalseOutNV6index = "";
                     add.LogicFalseOutNV7index = "";
                     add.LogicFalseOutNV8index = "";
                     add.LogicFalseOutNV1Value = "100.0 1";
                     add.LogicFalseOutNV2Value = "100.0 1";
                     add.LogicFalseOutNV3Value = "100.0 1";
                     add.LogicFalseOutNV4Value = "100.0 1";
                     add.LogicFalseOutNV5Value = "100.0 1";
                     add.LogicFalseOutNV6Value = "100.0 1";
                     add.LogicFalseOutNV7Value = "100.0 1";
                     add.LogicFalseOutNV8Value = "100.0 1";
                     add.LogicFalseOutSMS = false;

                     add.LogicTrueAudioPath = Application.StartupPath + @"\Resources\ALARM.wav";
                     add.LogicTrueAudioUse = false;
                     add.LogicTrueOutemail = false;
                     add.LogicTrueOutImagePath = Application.StartupPath + @"\Resources\image\Alarm-start.gif";
                     add.LogicTrueOutLog = false;
                     add.LogicTrueOutMSG = "";
                     add.LogicTrueOutNV = false;
                     add.LogicTrueOutNV1 = "";
                     add.LogicTrueOutNV2 = "";
                     add.LogicTrueOutNV3 = "";
                     add.LogicTrueOutNV4 = "";
                     add.LogicTrueOutNV5 = "";
                     add.LogicTrueOutNV6 = "";
                     add.LogicTrueOutNV7 = "";
                     add.LogicTrueOutNV8 = "";
                     add.LogicTrueOutNV1index = "";
                     add.LogicTrueOutNV2index = "";
                     add.LogicTrueOutNV3index = "";
                     add.LogicTrueOutNV4index = "";
                     add.LogicTrueOutNV5index = "";
                     add.LogicTrueOutNV6index = "";
                     add.LogicTrueOutNV7index = "";
                     add.LogicTrueOutNV8index = "";
                     add.LogicTrueOutNV1Value = "0.0 0";
                     add.LogicTrueOutNV2Value = "0.0 0";
                     add.LogicTrueOutNV3Value = "0.0 0";
                     add.LogicTrueOutNV4Value = "0.0 0";
                     add.LogicTrueOutNV5Value = "0.0 0";
                     add.LogicTrueOutNV6Value = "0.0 0";
                     add.LogicTrueOutNV7Value = "0.0 0";
                     add.LogicTrueOutNV8Value = "0.0 0";
                     add.LogicTrueOutSMS = false;

                     add.NVpart = nvPart;
                     
                     memoryData.AlarmData.Add(add);
                     memoryData.iconTemp.Add(pb.Name);

                     AlarmMoniTorNV add2 = new AlarmMoniTorNV();
                     add2.ip = add.SourceIP;
                     add2.name = add.name;
                     add2.NVpath = add.SourceNVName;
                     add2.NVtype = add.NVType;
                     add2.NVvalue = "";
                     add2.sampleRate = 1;
                     add2.sampleRatecount = 0;
                     memoryData.AlarmMonitorValue.Add(add2);
                 }
            }
        }

        private void AddObjPicture_Click(object sender, EventArgs e)
        {
            //config_PictureObject lForm = new config_PictureObject();
            //lForm.Owner = this;
            //lForm.ShowDialog();
            PictureBox pb = new PictureBox();
            FileStream fs = File.OpenRead(Application.StartupPath + @"\Resources\image\picture.png");
            Bitmap bmp1 = (Bitmap)Image.FromStream(fs);
            fs.Close();
            pb.Image = bmp1;
            pb.Name = chkAddIconName("1");
            pb.Size = new Size(48, 48);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Tag = "image@none";
            pb.Location = new Point(10, 10);
            pb.DoubleClick += new System.EventHandler(this.picswitch_DoubleClick);
            pb.Click += new System.EventHandler(this.picswitch_Click);
            pb.Leave += new System.EventHandler(this.picswitch_Level);
            pb.Enter += new System.EventHandler(this.picswitch_Enter);
            pb.Paint += new System.Windows.Forms.PaintEventHandler(this.picswitch_Paint);
            pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picswitch_mouseMove);
            pb.MouseEnter += new System.EventHandler(this.picswitch_mouseEnter);
            pb.MouseLeave += new System.EventHandler(this.picswitch_mouseLevel);
            pb.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picswitch_mouseUP);
            pb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picswitch_mouseDOWN);
            pb.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.picswitch_KeyUp);
            pictureBox1.Controls.Add(pb);

            PictureboxObjectstruct add = new PictureboxObjectstruct();
            add.height = pb.Size.Height;
            add.path = Application.StartupPath + @"\Resources\image\picture.png";
            add.layer = LayerListSelect.Text;
            add.name = pb.Name;
            add.width = pb.Width;
            add.x = pb.Location.X;
            add.y = pb.Location.Y;
            add.tag = pb.Tag.ToString();

            memoryData.PictureData.Add(add);
            memoryData.iconTemp.Add(pb.Name);

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.WindowsShutDown)
            {
                this.TopMost = true;
                //Me.Activate()
                if (MessageBox.Show("exit SCADA soft?", "Alarm", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    this.TopMost = false;
                    e.Cancel = true;
                }
                else
                {
                    System.Environment.Exit(System.Environment.ExitCode);

                }
            }
                
        }

        

        

        private void loadProject_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog myopen = new OpenFileDialog();
            myopen.Filter = "nico Files (*.np)|*.np;";
            myopen.InitialDirectory = SaveProjectDefaultPath;
            if (myopen.ShowDialog() == DialogResult.OK)
            {
                //clean memory temp data
                clearMemoryArrayData();
                LayerListSelect.Items.Clear();
                memoryData.LayerData.Clear();

                string loadPath = "";

                string[] getname = myopen.FileName.Split('\\');
                int itemcount = getname.Count()-1;
                string[] spname = getname[itemcount].Split('.');
                saveProjectNameTemp = spname[0];  //read project name from filename
                
                Mainstatus.Items[project_lab.Name].Text = "project : " + saveProjectNameTemp;

                for (int i = 0; i < getname.Count()-1; i++)
                {
                    loadPath = loadPath + getname[i] + "\\";
                }
                mySaveFullPath = loadPath;
            

            //load Lon monitor
           // StreamReader rd = new StreamReader(loadPath + "LONMonitor.txt");
           // while (rd.EndOfStream == false)
           // {
           //    string[] getConfig = rd.ReadLine().Split('#');
           //    MonitorNV add = new MonitorNV();

           //    add.count = int.Parse(getConfig[1]);
           //    add.ip = getConfig[2];
           //    add.name = getConfig[3];
           //    add.path = getConfig[4];
           //    add.time = int.Parse(getConfig[5]);
           //    add.unit = getConfig[6];
           //    memoryData.LonMonitor.Add(add);
           // }
            
            
            //load Layer data
            StreamReader rdLayer = new StreamReader(loadPath + "Layer.txt");
            while (rdLayer.EndOfStream == false)
            {
                string[] getConfig = rdLayer.ReadLine().Split('#');
                Layerstruct add = new Layerstruct();
                add.backColor = Int32.Parse(getConfig[1]);
                add.backImage = getConfig[2];
                add.name = getConfig[3];
                add.sizeMode = getConfig[4];
                memoryData.LayerData.Add(add);
                LayerListSelect.Items.Add(getConfig[3]);
            }
            rdLayer.Dispose();
            if (LayerListSelect.Items.Count != 0)
            {
                LayerListSelect.SelectedIndex = 0;
            }
            else
            {
                LayerListSelect.Items.Add("0");
                LayerListSelect.SelectedIndex = 0;
                
                Layerstruct addnew = new Layerstruct();
                addnew.name = "0";
                addnew.backColor = SystemColors.Control.ToArgb();
                addnew.backImage = "";
                addnew.sizeMode = "Normal";
                memoryData.LayerData.Add(addnew);
            }
            

            //load device list
            StreamReader rdDevicelist = new StreamReader(loadPath + "device.txt");
                memoryData.SmartserverIP.Clear();
                string site = "", fab = "", area = "", device = "", obj = "";//, nv = "";
            while (rdDevicelist.EndOfStream == false)
            {
                string[] getConfig = rdDevicelist.ReadLine().Split('#');
                switch (getConfig[1])
                {
                    case "site":
                        TreeNode addsite = new TreeNode();
                        addsite.Text = getConfig[2];
                        addsite.Name = getConfig[2];
                        DeviceNode.Nodes.Add(addsite);
                        site = addsite.Text;
                        break;
                    case "fab":
                        TreeNode addfab = new TreeNode();
                        addfab.Text = getConfig[2];
                        addfab.Name = getConfig[2];
                        DeviceNode.Nodes[site].Nodes.Add(addfab);
                        fab = addfab.Text;
                        break;
                    case "area":
                        TreeNode addarea = new TreeNode();
                        addarea.Text = getConfig[2];
                        addarea.Name = getConfig[2];
                        DeviceNode.Nodes[site].Nodes[fab].Nodes.Add(addarea);
                        area = addarea.Text;
                        break;
                    case "device":
                        TreeNode adddevice = new TreeNode();
                        adddevice.Text = getConfig[2];
                        adddevice.Name = getConfig[2];
                        adddevice.ForeColor = Color.DarkRed;
                        adddevice.Tag = getConfig[3];
                        adddevice.ToolTipText = getConfig[4];
                        DeviceNode.Nodes[site].Nodes[fab].Nodes[area].Nodes.Add(adddevice);
                        device = adddevice.Text;

                            int getindex = memoryData.SmartserverIP.IndexOf(getConfig[4].ToString());
                            if (getindex == -1)
                            {
                                memoryData.SmartserverIP.Add(getConfig[4].ToString());
                            }

                        break;
                    case "obj":
                        TreeNode addobj = new TreeNode();
                        addobj.Text = getConfig[2];
                        addobj.Name = getConfig[2];
                        addobj.ForeColor = Color.RoyalBlue;
                        DeviceNode.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes.Add(addobj);
                        obj = addobj.Text;
                        break;
                    case "nv":
                        TreeNode addnv = new TreeNode();
                        addnv.Text = getConfig[2];
                        addnv.Name = getConfig[2];
                        addnv.ForeColor = Color.Gray;
                        addnv.Tag = getConfig[3];
                        DeviceNode.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes[obj].Nodes.Add(addnv);
                        break;
                }
            }
            rdDevicelist.Dispose();
            
            //load Label data
            StreamReader rdLabel = new StreamReader(loadPath + "LabelObject.txt");
            while (rdLabel.EndOfStream == false)
            {
                string[] getConfig = rdLabel.ReadLine().Split('#');
                    LabelWithOptionalCopyTextOnDoubleClick add = new LabelWithOptionalCopyTextOnDoubleClick();

                add.BackColor = Color.FromArgb(int.Parse(getConfig[1]));
                if (getConfig[2].ToString() == "None")
                {
                    add.BorderStyle = BorderStyle.None;
                }
                else if (getConfig[2].ToString() == "Fixed3D")
                {
                    add.BorderStyle = BorderStyle.Fixed3D;
                }
                else if (getConfig[2].ToString() == "FixedSingle")
                {
                    add.BorderStyle = BorderStyle.FixedSingle;
                }

                add.ForeColor = Color.FromArgb(int.Parse(getConfig[3]));
                

                TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
                // Load an instance of Font from a string
                Font font = (Font)converter.ConvertFromString(getConfig[4]);
                add.Font = font;
                add.AutoSize = true;
                add.Name = getConfig[6];
                add.Text = getConfig[7];
                add.Location = new Point(int.Parse(getConfig[8]), int.Parse(getConfig[9]));
                add.Tag = getConfig[10];

                add.DoubleClick += new System.EventHandler(this.label_DoubleClick);
                add.Click += new System.EventHandler(this.label_Click);
                add.Paint += new System.Windows.Forms.PaintEventHandler(this.label_paint);
                add.Leave += new System.EventHandler(this.label_Level);
                add.Enter += new System.EventHandler(this.label_Enter);
                add.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_mouseMove);
                add.MouseEnter += new System.EventHandler(this.label_mouseEnter);
                add.MouseLeave += new System.EventHandler(this.label_mouseLevel);
                add.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.label_KeyUp);

                LabelObjstruct ma = new LabelObjstruct();
                ma.backcolor = add.BackColor.ToArgb();
                ma.border = add.BorderStyle;
                ma.color = add.ForeColor.ToArgb();
                ma.font = add.Font;
                ma.layer = getConfig[5];
                ma.name = add.Name;
                ma.text = add.Text;
                ma.x = add.Location.X;
                ma.y = add.Location.Y;
                ma.tag = getConfig[10];

                memoryData.LabelData.Add(ma);
                memoryData.iconTemp.Add(ma.name);

                if (ma.layer == LayerListSelect.Text)
                {
                    add.Visible = true;
                }
                else
                {
                    add.Visible = false;
                }
                pictureBox1.Controls.Add(add);

            }
            rdLabel.Dispose();

            //load button
            StreamReader rdButton = new StreamReader(loadPath + "ButtonObject.txt");
            while (rdButton.EndOfStream == false)
            {
                string[] getConfig = rdButton.ReadLine().Split('#');
                DoubleClickButton add = new DoubleClickButton();
                ButtonObjstruct tar = new ButtonObjstruct();

                if (getConfig[1] == "BottomCenter")
                {
                    add.ImageAlign = ContentAlignment.BottomCenter;
                }
                else if (getConfig[1] == "BottomLeft")
                {
                    add.ImageAlign = ContentAlignment.BottomLeft;
                }
                else if (getConfig[1] == "BottomRight")
                {
                    add.ImageAlign = ContentAlignment.BottomRight;
                }
                else if (getConfig[1] == "MiddleCenter")
                {
                    add.ImageAlign = ContentAlignment.MiddleCenter;
                }
                else if (getConfig[1] == "MiddleLeft")
                {
                    add.ImageAlign = ContentAlignment.MiddleLeft;
                }
                else if (getConfig[1] == "MiddleRight")
                {
                    add.ImageAlign = ContentAlignment.MiddleRight ;
                }
                else if (getConfig[1] == "TopCenter")
                {
                    add.ImageAlign = ContentAlignment.TopCenter;
                }
                else if (getConfig[1] == "TopLeft")
                {
                    add.ImageAlign = ContentAlignment.TopLeft;
                }
                else if (getConfig[1] == "TopRight")
                {
                    add.ImageAlign = ContentAlignment.TopRight;
                }

                if (getConfig[2] == "BottomCenter")
                {
                    add.TextAlign = ContentAlignment.BottomCenter;
                }
                else if (getConfig[2] == "BottomLeft")
                {
                    add.TextAlign = ContentAlignment.BottomLeft;
                }
                else if (getConfig[2] == "BottomRight")
                {
                    add.TextAlign = ContentAlignment.BottomRight;
                }
                else if (getConfig[2] == "MiddleCenter")
                {
                    add.TextAlign = ContentAlignment.MiddleCenter;
                }
                else if (getConfig[2] == "MiddleLeft")
                {
                    add.TextAlign = ContentAlignment.MiddleLeft;
                }
                else if (getConfig[2] == "MiddleRight")
                {
                    add.TextAlign = ContentAlignment.MiddleRight;
                }
                else if (getConfig[2] == "TopCenter")
                {
                    add.TextAlign = ContentAlignment.TopCenter;
                }
                else if (getConfig[2] == "TopLeft")
                {
                    add.TextAlign = ContentAlignment.TopLeft;
                }
                else if (getConfig[2] == "TopRight")
                {
                    add.TextAlign = ContentAlignment.TopRight;
                }

                add.BackColor = Color.FromArgb(int.Parse(getConfig[3]));

                if (getConfig[4] != "")
                {
                    add.Image = Image.FromFile(getConfig[4]);
                }
    
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
                // Load an instance of Font from a string
                Font font = (Font)converter.ConvertFromString(getConfig[6]);
                add.Font = font;

                add.ForeColor = Color.FromArgb(int.Parse(getConfig[7]));
                add.AutoSize = false;
                add.Size = new Size(int.Parse(getConfig[14]), int.Parse(getConfig[8]));
                add.Name = getConfig[10];
                add.Text = getConfig[11];
                add.Location = new Point(int.Parse(getConfig[15]), int.Parse(getConfig[16]));
                add.Tag =  getConfig[17];
                add.BackgroundImageLayout = ImageLayout.None;

                add.DoubleClick += new System.EventHandler(this.buttn_DoubleClick);
                add.Click += new System.EventHandler(this.buttn_Click);
                add.Paint += new System.Windows.Forms.PaintEventHandler(this.buttn_paint);
                add.Leave += new System.EventHandler(this.buttn_Level);
                add.Enter += new System.EventHandler(this.buttn_Enter);
                add.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttn_mouseMove);
                add.MouseEnter += new System.EventHandler(this.buttn_mouseEnter);
                add.MouseLeave += new System.EventHandler(this.buttn_mouseLevel);
                add.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.buttn_KeyUp);

                tar.AlignImage = add.ImageAlign.ToString();
                tar.AlignText = add.TextAlign.ToString();
                tar.backColor = add.BackColor.ToArgb();
                if (add.BackgroundImage != null)
                {
                    tar.backImage = getConfig[4];
                }
                else
                {
                    tar.backImage = null;
                }
                tar.tag = getConfig[17];
                tar.command = getConfig[5];
                tar.font = add.Font;
                tar.forecolor = add.ForeColor.ToArgb();
                tar.height = add.Size.Height;
                tar.layer = getConfig[9];
                tar.name = add.Name;
                tar.text = add.Text;
                tar.useBackColor = bool.Parse(getConfig[12]);
                tar.useBackIMG = bool.Parse(getConfig[13]);
                tar.width = add.Size.Width;
                tar.x = add.Location.X;
                tar.y = add.Location.Y;

                memoryData.ButtonData.Add(tar);
                memoryData.iconTemp.Add(tar.name);
                if (tar.layer == LayerListSelect.Text)
                {
                    add.Visible = true;
                }
                else
                {
                    add.Visible = false;
                }
                pictureBox1.Controls.Add(add);
                
            }
            rdButton.Dispose();

            //load input object
            StreamReader rdInput = new StreamReader(loadPath + "InputObject.txt");
            while (rdInput.EndOfStream == false)
            {
                string[] getConfig = rdInput.ReadLine().Split('#');
                    LabelWithOptionalCopyTextOnDoubleClick add = new LabelWithOptionalCopyTextOnDoubleClick();
                
                add.BackColor = Color.FromArgb(int.Parse(getConfig[1]));
                if (getConfig[2].ToString() == "None")
                {
                    add.BorderStyle = BorderStyle.None;
                }
                else if (getConfig[2].ToString() == "Fixed3D")
                {
                    add.BorderStyle = BorderStyle.Fixed3D;
                }
                else if (getConfig[2].ToString() == "FixedSingle")
                {
                    add.BorderStyle = BorderStyle.FixedSingle;
                }

                TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
                // Load an instance of Font from a string
                Font font = (Font)converter.ConvertFromString(getConfig[4]);
                add.Font = font;
                add.ForeColor = Color.FromArgb(int.Parse(getConfig[5]));
                add.Location = new Point(int.Parse(getConfig[18]), int.Parse(getConfig[19]));
                add.Tag = getConfig[20];
                add.Name = getConfig[11];
                add.Text = getConfig[17];
                add.AutoSize = true;

                add.DoubleClick += new System.EventHandler(this.label_DoubleClick);
                add.Click += new System.EventHandler(this.label_Click);
                add.Paint += new System.Windows.Forms.PaintEventHandler(this.label_paint);
                add.Leave += new System.EventHandler(this.label_Level);
                add.Enter += new System.EventHandler(this.label_Enter);
                add.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_mouseMove);
                add.MouseEnter += new System.EventHandler(this.label_mouseEnter);
                add.MouseLeave += new System.EventHandler(this.label_mouseLevel);
                add.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.label_KeyUp);

                InputObjectstruct tar = new InputObjectstruct();
                tar.backcolor = add.BackColor.ToArgb();
                tar.border = add.BorderStyle;
                tar.count = int.Parse(getConfig[3]);
                tar.font = add.Font;
                tar.forecolor = add.ForeColor.ToArgb();
                tar.ip = getConfig[6];
                tar.layer = getConfig[7];
                tar.logdata = Boolean.Parse(getConfig[8]);
                tar.logtime = int.Parse(getConfig[9]);
                tar.lonPolltime = int.Parse(getConfig[10]);
                tar.name = add.Name;
                tar.stringFormat = getConfig[12];
                tar.target = getConfig[13];
                tar.targetindex = getConfig[14];
                tar.unit = getConfig[15];
                tar.unituse = Boolean.Parse(getConfig[16]);
                tar.value = "0"; // getConfig[17];
                tar.showvalue = "0";
                tar.x = add.Location.X;
                tar.y = add.Location.Y;
                tar.tag = getConfig[20];
                tar.NVtype = getConfig[21];
                tar.potocol = getConfig[22];

                tar.area = getConfig[25];
                tar.fab = getConfig[24];
                tar.site = getConfig[23];
                tar.device = getConfig[26];
                tar.function = getConfig[27];
                tar.NV = getConfig[28];
                tar.description = getConfig[29];
                    
                memoryData.InputData.Add(tar);
                memoryData.iconTemp.Add(tar.name);
                if (tar.layer == LayerListSelect.Text)
                {
                    add.Visible = true;
                }
                else
                {
                    add.Visible = false;
                }
                toolTip1.SetToolTip(add, tar.description);
                pictureBox1.Controls.Add(add);
                
            }
            rdInput.Dispose();

            //load OutputButtonObject
            StreamReader rdOutputButton = new StreamReader(loadPath + "OutputButtonObject.txt");
            while (rdOutputButton.EndOfStream == false)
            {
                string[] getConfig = rdOutputButton.ReadLine().Split('#');
                PictureBox add = new PictureBox();
                OutputButtonObjectstruct tar = new OutputButtonObjectstruct();

                if (getConfig[3] != "")
                {
                    if (System.IO.File.Exists(getConfig[3]))
                    {
                        //檔案存在
                        add.Image = Image.FromFile(getConfig[3]); 
                    }
                    else
                    {
                        //檔案不存在
                        string appPath = System.IO.Directory.GetCurrentDirectory();
                        appPath = appPath + "\\Resources\\image\\error.png";
                        add.Image = Image.FromFile(appPath); 
                    }
                    
                }
                
                add.Name = getConfig[8];
                add.Size = new Size(int.Parse(getConfig[15]), int.Parse(getConfig[2]));
                add.Location = new Point(int.Parse(getConfig[16]), int.Parse(getConfig[17]));
                add.Tag = getConfig[18];
                add.SizeMode = PictureBoxSizeMode.StretchImage;

                add.DoubleClick += new System.EventHandler(this.picswitch_DoubleClick);
                add.Click += new System.EventHandler(this.picswitch_Click);
                add.Leave += new System.EventHandler(this.picswitch_Level);
                add.Enter += new System.EventHandler(this.picswitch_Enter);
                add.Paint += new System.Windows.Forms.PaintEventHandler(this.picswitch_Paint);
                add.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picswitch_mouseMove);
                add.MouseEnter += new System.EventHandler(this.picswitch_mouseEnter);
                add.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picswitch_mouseUP);
                add.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picswitch_mouseDOWN);
                add.MouseLeave += new System.EventHandler(this.picswitch_mouseLevel);
                add.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.picswitch_KeyUp);

                tar.buttontype = getConfig[1];
                tar.height = add.Size.Height;
                if (add.Image != null)
                {
                    tar.imagePath = getConfig[3];
                }
                else
                {
                    tar.imagePath = null;
                }
                
                tar.ip = getConfig[4];
                tar.layer = getConfig[5];
                tar.log = Boolean.Parse( getConfig[6]);
                tar.mail = Boolean.Parse(getConfig[7]);
                tar.name = getConfig[8];
                tar.NVtype = getConfig[9];
                tar.NVtypeF = getConfig[10];
                tar.NVvalue = getConfig[11];
                tar.SMS = Boolean.Parse(getConfig[12]);
                tar.target = getConfig[13];
                tar.targetindex = getConfig[14];
                tar.width = add.Size.Width;
                tar.x = add.Location.X;
                tar.y = add.Location.Y;
                tar.tag = getConfig[18];
                tar.site = getConfig[19];
                tar.fab = getConfig[20];
                tar.area = getConfig[21];
                tar.device = getConfig[22];
                tar.function = getConfig[23];
                tar.NV = getConfig[24];
                tar.description = getConfig[25];

                if (getConfig[26] != "")
                {
                    if (System.IO.File.Exists(getConfig[26]))
                    {
                        //檔案存在
                        tar.userOnImagePath = getConfig[26];
                    }
                    else
                    {
                        //檔案不存在
                        string appPath = System.IO.Directory.GetCurrentDirectory();
                        appPath = appPath + "\\Resources\\image\\error.png";
                        tar.userOnImagePath = appPath;
                    }
                }

                if (getConfig[27] != "")
                {
                    if (System.IO.File.Exists(getConfig[27]))
                    {
                        //檔案存在
                        tar.userOnImagePath = getConfig[27];
                    }
                    else
                    {
                        //檔案不存在
                        string appPath = System.IO.Directory.GetCurrentDirectory();
                        appPath = appPath + "\\Resources\\image\\error.png";
                        tar.userOffImagePath = appPath;
                    }
                }

                memoryData.OutputButtonData.Add(tar);
                memoryData.iconTemp.Add(tar.name);
                if (tar.layer == LayerListSelect.Text)
                {
                    add.Visible = true;
                }
                else
                {
                    add.Visible = false;
                }
                toolTip1.SetToolTip(add, tar.description);
                pictureBox1.Controls.Add(add);
                
            }
            rdOutputButton.Dispose();

            //load output text
            StreamReader rdOuttext = new StreamReader(loadPath + "OutputTextObject.txt");
            while (rdOuttext.EndOfStream == false)
            {
                string[] getConfig = rdOuttext.ReadLine().Split('#');
                TextBox add = new TextBox();
                OutputTextObjectstruct tar = new OutputTextObjectstruct();

                add.Size = new Size(int.Parse(getConfig[13]), int.Parse(getConfig[1]));
                add.Name = getConfig[6];
                add.Location = new Point(int.Parse(getConfig[14]), int.Parse(getConfig[15]));
                add.Tag = getConfig[16];
                add.ContextMenuStrip = iconRightMenu;
                add.Text = "100.0 1";
                add.BorderStyle = BorderStyle.None;

                add.DoubleClick += new System.EventHandler(this.lonValue_DoubleClick);
                add.Click += new System.EventHandler(this.lonValue_Click);
                add.Paint += new System.Windows.Forms.PaintEventHandler(this.lonValuePaint);
                add.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lonValue_keyDown);
                add.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lonValue_mouseMove);
                add.MouseEnter += new System.EventHandler(this.lonValue_mouseEnter);
                add.MouseLeave += new System.EventHandler(this.lonValue_mouseLevel);
                add.MouseLeave += new System.EventHandler(this.lonValue_mouseLevel);
                add.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.lonValue_KeyUp);

                tar.height = add.Size.Height;
                tar.ip = getConfig[2];
                tar.layer = getConfig[3];
                tar.log = Boolean.Parse(getConfig[4]);
                tar.mail = Boolean.Parse(getConfig[5]);
                tar.name = add.Name;
                tar.NVtype = getConfig[7];
                tar.NVtypeF = getConfig[8];
                tar.NVvalue = getConfig[9];
                tar.SMS = Boolean.Parse(getConfig[10]);
                tar.tag = getConfig[16];
                tar.target = getConfig[11];
                tar.targetindex = getConfig[12];
                tar.width = add.Size.Width;
                tar.x = add.Location.X;
                tar.y = add.Location.Y;
                tar.site = getConfig[17];
                tar.fab = getConfig[18];
                tar.area = getConfig[19];
                tar.device = getConfig[20];
                tar.function = getConfig[21];
                tar.NV = getConfig[22];
                tar.description = getConfig[23];

                memoryData.OutputTextData.Add(tar);
                memoryData.iconTemp.Add(tar.name);
                if (tar.layer == LayerListSelect.Text)
                {
                    add.Visible = true;
                }
                else
                {
                    add.Visible = false;
                }
                toolTip1.SetToolTip(add, tar.description);
                pictureBox1.Controls.Add(add);
                
            }
            rdOuttext.Dispose();

            //load output pop form
            StreamReader rdOutPoP = new StreamReader(loadPath + "OutputPoPObject.txt");
            while (rdOutPoP.EndOfStream == false)
            {
                string[] getConfig = rdOutPoP.ReadLine().Split('#');
                DoubleClickButton add = new DoubleClickButton();
                OutputPopObjectstruct tar = new OutputPopObjectstruct();

                if (getConfig[1] == "BottomCenter")
                {
                    add.ImageAlign = ContentAlignment.BottomCenter;
                }
                else if (getConfig[1] == "BottomLeft")
                {
                    add.ImageAlign = ContentAlignment.BottomLeft;
                }
                else if (getConfig[1] == "BottomRight")
                {
                    add.ImageAlign = ContentAlignment.BottomRight;
                }
                else if (getConfig[1] == "MiddleCenter")
                {
                    add.ImageAlign = ContentAlignment.MiddleCenter;
                }
                else if (getConfig[1] == "MiddleLeft")
                {
                    add.ImageAlign = ContentAlignment.MiddleLeft;
                }
                else if (getConfig[1] == "MiddleRight")
                {
                    add.ImageAlign = ContentAlignment.MiddleRight;
                }
                else if (getConfig[1] == "TopCenter")
                {
                    add.ImageAlign = ContentAlignment.TopCenter;
                }
                else if (getConfig[1] == "TopLeft")
                {
                    add.ImageAlign = ContentAlignment.TopLeft;
                }
                else if (getConfig[1] == "TopRight")
                {
                    add.ImageAlign = ContentAlignment.TopRight;
                }

                if (getConfig[2] == "BottomCenter")
                {
                    add.TextAlign = ContentAlignment.BottomCenter;
                }
                else if (getConfig[2] == "BottomLeft")
                {
                    add.TextAlign = ContentAlignment.BottomLeft;
                }
                else if (getConfig[2] == "BottomRight")
                {
                    add.TextAlign = ContentAlignment.BottomRight;
                }
                else if (getConfig[2] == "MiddleCenter")
                {
                    add.TextAlign = ContentAlignment.MiddleCenter;
                }
                else if (getConfig[2] == "MiddleLeft")
                {
                    add.TextAlign = ContentAlignment.MiddleLeft;
                }
                else if (getConfig[2] == "MiddleRight")
                {
                    add.TextAlign = ContentAlignment.MiddleRight;
                }
                else if (getConfig[2] == "TopCenter")
                {
                    add.TextAlign = ContentAlignment.TopCenter;
                }
                else if (getConfig[2] == "TopLeft")
                {
                    add.TextAlign = ContentAlignment.TopLeft;
                }
                else if (getConfig[2] == "TopRight")
                {
                    add.TextAlign = ContentAlignment.TopRight;
                }

                add.BackColor = Color.FromArgb(int.Parse( getConfig[3]));
                if (getConfig[4] != "")
                {
                    add.BackgroundImage = Image.FromFile(getConfig[4]);
                }

                TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
                // Load an instance of Font from a string
                Font font = (Font)converter.ConvertFromString(getConfig[5]);
                add.Font = font;

                add.ForeColor = Color.FromArgb(int.Parse(getConfig[6]));
                add.Size = new Size(int.Parse(getConfig[20]), int.Parse(getConfig[7]));
                add.Name = getConfig[12];
                add.Text = getConfig[17];
                add.Location = new Point(int.Parse(getConfig[21]), int.Parse(getConfig[22]));
                add.Tag = getConfig[23];
                add.AutoSize = false;
                add.BackgroundImageLayout = ImageLayout.None;

                add.DoubleClick += new System.EventHandler(this.buttn_DoubleClick);
                add.Click += new System.EventHandler(this.buttn_Click);
                add.Paint += new System.Windows.Forms.PaintEventHandler(this.buttn_paint);
                add.Leave += new System.EventHandler(this.buttn_Level);
                add.Enter += new System.EventHandler(this.buttn_Enter);
                add.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttn_mouseMove);
                add.MouseEnter += new System.EventHandler(this.buttn_mouseEnter);
                add.MouseLeave += new System.EventHandler(this.buttn_mouseLevel);
                add.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.buttn_KeyUp);

                tar.AlignIMG = add.ImageAlign;
                tar.AlignText = add.TextAlign;
                tar.backColor = add.BackColor.ToArgb();
                if (add.Image != null)
                {
                    tar.backImage = getConfig[4];
                }
                else
                {
                    tar.backImage = null;
                }

                tar.font = add.Font;
                tar.forecolor = add.ForeColor.ToArgb();
                tar.height = add.Size.Height;
                tar.ip = getConfig[8];
                tar.layer = getConfig[9];
                tar.log = Boolean.Parse(getConfig[10]);
                tar.mail = Boolean.Parse(getConfig[11]);
                tar.name = getConfig[12];
                tar.NVtype = getConfig[13];
                tar.SMS = Boolean.Parse(getConfig[14]);
                tar.tag = getConfig[23];
                tar.target = getConfig[15];
                tar.targetindex = getConfig[16];
                tar.text = add.Text;
                tar.useBackColor = Boolean.Parse(getConfig[18]);
                tar.useBackIMG = Boolean.Parse(getConfig[19]);
                tar.width = add.Size.Width;
                tar.x = add.Location.X;
                tar.y = add.Location.Y;

                tar.site = getConfig[24];
                tar.fab = getConfig[25];
                tar.area = getConfig[26];
                tar.device = getConfig[27];
                tar.function = getConfig[28];
                tar.NV = getConfig[29];
                tar.description = getConfig[30];

                memoryData.OutputPopData.Add(tar);
                memoryData.iconTemp.Add(tar.name);
                if (tar.layer == LayerListSelect.Text)
                {
                    add.Visible = true;
                }
                else
                {
                    add.Visible = false;
                }
                toolTip1.SetToolTip(add, tar.description);
                pictureBox1.Controls.Add(add);
                
            }
            rdOutPoP.Dispose();

            //load picturebox object
            StreamReader rdPicture = new StreamReader(loadPath + "PictureObject.txt");
            while (rdPicture.EndOfStream == false)
            {
                string[] getConfig = rdPicture.ReadLine().Split('#');
               PictureBox add = new PictureBox();
               PictureboxObjectstruct tar = new PictureboxObjectstruct();

               add.Size = new Size(int.Parse(getConfig[5]), int.Parse(getConfig[1]));
               add.Name = getConfig[3];
               add.SizeMode = PictureBoxSizeMode.StretchImage;
               add.Location = new Point(int.Parse(getConfig[6]), int.Parse(getConfig[7]));
               add.Tag = getConfig[8];
               if (getConfig[4] != "")
               {
                   add.Image = Image.FromFile(getConfig[4]);
               }

               add.DoubleClick += new System.EventHandler(this.picswitch_DoubleClick);
               add.Click += new System.EventHandler(this.picswitch_Click);
               add.Leave += new System.EventHandler(this.picswitch_Level);
               add.Enter += new System.EventHandler(this.picswitch_Enter);
               add.Paint += new System.Windows.Forms.PaintEventHandler(this.picswitch_Paint);
               add.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picswitch_mouseMove);
               add.MouseEnter += new System.EventHandler(this.picswitch_mouseEnter);
               add.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picswitch_mouseUP);
               add.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picswitch_mouseDOWN);
               add.MouseLeave += new System.EventHandler(this.picswitch_mouseLevel);
               add.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.picswitch_KeyUp);

               tar.height = add.Size.Height;
               tar.layer = getConfig[2];
               tar.name = add.Name;
               tar.path = getConfig[4];
               tar.tag = getConfig[8];
               tar.width = add.Size.Width;
               tar.x = add.Location.X;
               tar.y = add.Location.Y;

               memoryData.PictureData.Add(tar);
               memoryData.iconTemp.Add(tar.name);
               if (tar.layer == LayerListSelect.Text)
               {
                   add.Visible = true;
               }
               else
               {
                   add.Visible = false;
               }
               pictureBox1.Controls.Add(add);

            }
            rdPicture.Dispose();

            //load alarm object
            StreamReader rdAlarm = new StreamReader(loadPath + "AlarmObject.txt");
            while (rdAlarm.EndOfStream == false)
            {
                string[] getConfig = rdAlarm.ReadLine().Split('#');
                PictureBox add = new PictureBox();
                AlarmObjectstruct tar = new AlarmObjectstruct();
                AlarmMoniTorNV moni = new AlarmMoniTorNV();
                add.SizeMode = PictureBoxSizeMode.StretchImage;
                add.Name = getConfig[82];
                moni.name = getConfig[82];
                add.Size = new Size(int.Parse(getConfig[43]), int.Parse(getConfig[12]));
                add.Location = new Point(int.Parse(getConfig[44]), int.Parse(getConfig[45]));
                add.Tag = getConfig[94];
                if (getConfig[14] != "")
                {
                   // add.Image = Image.FromFile(getConfig[14]);
                }

                add.DoubleClick += new System.EventHandler(this.picswitch_DoubleClick);
                add.Click += new System.EventHandler(this.picswitch_Click);
                add.Leave += new System.EventHandler(this.picswitch_Level);
                add.Enter += new System.EventHandler(this.picswitch_Enter);
                add.Paint += new System.Windows.Forms.PaintEventHandler(this.picswitch_Paint);
                add.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picswitch_mouseMove);
                add.MouseEnter += new System.EventHandler(this.picswitch_mouseEnter);
                add.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picswitch_mouseUP);
                add.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picswitch_mouseDOWN);
                add.MouseLeave += new System.EventHandler(this.picswitch_mouseLevel);
                add.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.picswitch_KeyUp);

                tar.AlarmFalseRun = false; //Boolean.Parse(getConfig[1]);
                tar.AlarmStatus = Boolean.Parse(getConfig[2]);
                tar.AlarmTrueRun = true; //Boolean.Parse(getConfig[3]);
                tar.CompareLogic = getConfig[4];
                tar.CompareMax = float.Parse(getConfig[5]);
                tar.CompareMin = float.Parse(getConfig[6]);
                tar.CompareType = getConfig[7];
                tar.CompareValue = getConfig[8];
                tar.layer = getConfig[9];
                tar.LogicFalseAudioPath = getConfig[10];

                tar.LogicFalseAudioUse = Boolean.Parse(getConfig[11]);
                tar.LogicFalseHeight = int.Parse(getConfig[12]);
                tar.LogicFalseOutemail = Boolean.Parse(getConfig[13]);
                
                if (System.IO.File.Exists(getConfig[14]))
                {
                    //檔案存在
                    tar.LogicFalseOutImagePath = getConfig[14];
                    add.Image = Image.FromFile(getConfig[14]);
                }
                else
                {
                    //檔案不存在
                    //string[] spOld = getConfig[14].Split('\\');
                    string appPath = System.IO.Directory.GetCurrentDirectory();
                    appPath = appPath + "\\Resources\\image\\Alarm-start.gif";
                    add.Image = Image.FromFile(appPath);
                    tar.LogicFalseOutImagePath = appPath;
                }
                
                tar.LogicFalseOutLog = Boolean.Parse(getConfig[15]);
                tar.LogicFalseOutMSG = getConfig[16];
                tar.LogicFalseOutNV = Boolean.Parse(getConfig[17]);
                tar.LogicFalseOutNV1 = getConfig[18];
                tar.LogicFalseOutNV1index = getConfig[19];
                
                tar.LogicFalseOutNV1Value = getConfig[20];
                tar.LogicFalseOutNV2 = getConfig[21];
                tar.LogicFalseOutNV2index = getConfig[22];
                tar.LogicFalseOutNV2Value = getConfig[23];
                tar.LogicFalseOutNV3 = getConfig[24];
                tar.LogicFalseOutNV3index = getConfig[25];
                tar.LogicFalseOutNV3Value = getConfig[26];
                tar.LogicFalseOutNV4 = getConfig[27];
                tar.LogicFalseOutNV4index = getConfig[28];
                tar.LogicFalseOutNV4Value = getConfig[29];

                tar.LogicFalseOutNV5 = getConfig[30];
                tar.LogicFalseOutNV5index = getConfig[31];
                tar.LogicFalseOutNV5Value = getConfig[32];
                tar.LogicFalseOutNV6 = getConfig[33];
                tar.LogicFalseOutNV6index = getConfig[34];
                tar.LogicFalseOutNV6Value = getConfig[35];
                tar.LogicFalseOutNV7 = getConfig[36];
                tar.LogicFalseOutNV7index = getConfig[37];
                tar.LogicFalseOutNV7Value = getConfig[38];
                tar.LogicFalseOutNV8 = getConfig[39];

                tar.LogicFalseOutNV8index = getConfig[40];
                tar.LogicFalseOutNV8Value = getConfig[41];
                tar.LogicFalseOutSMS = Boolean.Parse(getConfig[42]);
                tar.LogicFalseWidth = int.Parse(getConfig[43]);
                tar.LogicFalseX = int.Parse(getConfig[44]);
                tar.LogicFalseY = int.Parse(getConfig[45]);
                tar.LogicTrueAudioPath = getConfig[46];
                tar.LogicTrueAudioUse = Boolean.Parse(getConfig[47]);
                tar.LogicTrueHeight = int.Parse(getConfig[48]);
                tar.LogicTrueOutemail = Boolean.Parse(getConfig[49]);

                if (System.IO.File.Exists(getConfig[50]))
                {
                    tar.LogicTrueOutImagePath = getConfig[50];
                }
                else
                {
                    string[] spOld = getConfig[50].Split('\\');
                    string appPath = System.IO.Directory.GetCurrentDirectory();
                    appPath = appPath + "\\Resources\\image\\Alarm-stop.png";
                    add.Image = Image.FromFile(appPath);
                    tar.LogicTrueOutImagePath = appPath;
                }
                

                tar.LogicTrueOutLog = Boolean.Parse(getConfig[51]);
                tar.LogicTrueOutMSG = getConfig[52];
                tar.LogicTrueOutNV = Boolean.Parse(getConfig[53]);
                tar.LogicTrueOutNV1 = getConfig[54];
                tar.LogicTrueOutNV1index = getConfig[55];
                tar.LogicTrueOutNV1Value = getConfig[56];
                tar.LogicTrueOutNV2 = getConfig[57];
                tar.LogicTrueOutNV2index = getConfig[58];
                tar.LogicTrueOutNV2Value = getConfig[59];

                tar.LogicTrueOutNV3 = getConfig[60];
                tar.LogicTrueOutNV3index = getConfig[61];
                tar.LogicTrueOutNV3Value = getConfig[62];
                tar.LogicTrueOutNV4 = getConfig[63];
                tar.LogicTrueOutNV4index = getConfig[64];
                tar.LogicTrueOutNV4Value = getConfig[65];
                tar.LogicTrueOutNV5 = getConfig[66];
                tar.LogicTrueOutNV5index = getConfig[67];
                tar.LogicTrueOutNV5Value = getConfig[68];
                tar.LogicTrueOutNV6 = getConfig[69];

                tar.LogicTrueOutNV6index = getConfig[70];
                tar.LogicTrueOutNV6Value = getConfig[71];
                tar.LogicTrueOutNV7 = getConfig[72];
                tar.LogicTrueOutNV7index = getConfig[73];
                tar.LogicTrueOutNV7Value = getConfig[74];
                tar.LogicTrueOutNV8 = getConfig[75];
                tar.LogicTrueOutNV8index = getConfig[76];
                tar.LogicTrueOutNV8Value = getConfig[77];

                tar.LogicTrueOutSMS = Boolean.Parse(getConfig[78]);
                tar.LogicTrueWidth = int.Parse(getConfig[79]);

                tar.LogicTrueX = int.Parse(getConfig[80]);
                tar.LogicTrueY = int.Parse(getConfig[81]);
                tar.name = add.Name;
                tar.NVType = getConfig[83];
                moni.NVtype = getConfig[83];
                tar.sampleRate = int.Parse(getConfig[84]);
                moni.sampleRate = tar.sampleRate;
                tar.sampleRatecount = 0; // int.Parse(getConfig[85]);
                moni.sampleRatecount = 0;
                tar.SourceIP = getConfig[86];
                moni.ip = getConfig[86];
                tar.SourceNVindex = getConfig[87];
                tar.SourceNVName = getConfig[88];
                moni.NVpath = getConfig[88];
                tar.TargetIP = getConfig[89];
                tar.TargetNVindex = getConfig[90];
                tar.TargetNVName = getConfig[91];
                tar.timeOver = int.Parse(getConfig[92]);
                tar.timeOvercount = int.Parse(getConfig[93]);
                tar.tag = getConfig[94];
                tar.AlarmTrueMailgroup = getConfig[95];
                tar.AlarmFalseMailgroup = getConfig[96];
                tar.description = getConfig[97];
                tar.site = getConfig[98];
                tar.fab = getConfig[99];
                tar.area = getConfig[100];
                tar.device = getConfig[101];
                moni.device = getConfig[101];
                tar.function = getConfig[102];
                moni.function = getConfig[102];
                tar.NV = getConfig[103];
                moni.NV = getConfig[103];
                tar.NVtype = getConfig[104];
                tar.NVpart = getConfig[105];

                TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
                // Load an instance of Font from a string
                Font font = (Font)converter.ConvertFromString(getConfig[106]);
                tar.LogicTrueOutFont = font;
                font = (Font)converter.ConvertFromString(getConfig[107]);
                tar.LogicFalseOutFont = font;

                tar.LogicTrueforecolor = int.Parse(getConfig[108]);
                tar.LogicFalseforecolor = int.Parse(getConfig[109]);

                tar.userTrueValue = Boolean.Parse(getConfig[110]);
                tar.userFalseValue = Boolean.Parse(getConfig[111]);

                memoryData.AlarmData.Add(tar);
                memoryData.iconTemp.Add(tar.name);
                memoryData.AlarmMonitorValue.Add(moni);
                if (tar.layer == LayerListSelect.Text)
                {
                    add.Visible = true;
                }
                else
                {
                    add.Visible = false;
                }
                toolTip1.SetToolTip(add, tar.description);
                pictureBox1.Controls.Add(add);
                
            }
            rdAlarm.Dispose();


            //load database
            try
            {
                //using (FileStream input = new FileStream(Application.StartupPath + @"\Resources\SMTP.dat", FileMode.Open))
                //{   // 讀取整數值
                //    BinaryReader reader = new BinaryReader(input);
                //    string data = reader.ReadString();
                //    string[] spStr = data.Split('$');
                //    SMTPhost.Text = spStr[1];
                //    SMTPport.Text = spStr[2];
                //    SSL.Checked = Boolean.Parse(spStr[3]);
                //    userName.Text = spStr[4];
                //    userPassword.Text = spStr[5];
                //}
                //////////////////////////////////////////////
                using (FileStream input = new FileStream(Application.StartupPath + @"\Resources\database.dat", FileMode.Open))
                {   // 讀取整數值
                    BinaryReader reader = new BinaryReader(input);
                    string data = reader.ReadString();

                    int numOfBytes = data.Length / 8;
                    byte[] bytes = new byte[numOfBytes];
                    for (int i = 0; i < numOfBytes; ++i)
                    {
                        bytes[i] = Convert.ToByte(data.Substring(8 * i, 8), 2);
                    }
                    //File.WriteAllBytes(fileName, bytes);
                    string val = GetString(bytes);
                    string[] SpStr = val.Split('$');
                    database edit = new database();
                    edit.ip = SpStr[1];
                    edit.user = SpStr[2];
                    edit.password = SpStr[3];
                    edit.port = SpStr[4];
                    edit.DBname = SpStr[5];

                    if (edit.ip != "" && edit.ip != null)
                    {
                        if (memoryData.database.Count != 0)
                        {
                            memoryData.database[0] = edit;
                        }
                        else
                        {
                            memoryData.database.Add(edit);
                        }
                    }
                    input.Dispose();
                }

            }
            catch   // (Exception ex)
            {

            }



            //load sample
            /////////////////////////////////////////////////////////////////////////////////////
            //StreamReader rd = new StreamReader(loadPath + "LabelObj.txt");
            //while (rd.EndOfStream == false)
            //{
            //   string[] getConfig = rd.ReadLine().Split('#');
            //}
        }
        }

        private void newProject_Click(object sender, EventArgs e)
        {
            //clean memory temp data
            clearMemoryArrayData();
        }

        private void clearMemoryArrayData()   // reset all
        {
            RunMode.Checked = false;
            memoryData.AlarmAudioFalse.Clear();
            memoryData.AlarmAudioTrue.Clear();
            memoryData.AlarmData.Clear();
            memoryData.AlarmMonitorValue.Clear();
            memoryData.ButtonData.Clear();
            memoryData.iconTemp.Clear();
            memoryData.InputData.Clear();
            memoryData.LabelData.Clear();
            memoryData.LayerData.Clear();
            memoryData.LonDeviceTemp.Clear();
            memoryData.SmartserverIP.Clear();
            memoryData.OutputButtonData.Clear();
            memoryData.OutputPopData.Clear();
            memoryData.OutputTextData.Clear();
            memoryData.PictureData.Clear();
            this.pictureBox1.Controls.Clear();
            this.pictureBox1.BackgroundImage = null; ;
            LayerListSelect.Items.Clear();
            LayerListSelect.Items.Add("0");
            LayerListSelect.SelectedIndex = 0;
            Layerstruct addnew = new Layerstruct();
            addnew.name = "0";
            addnew.backColor = SystemColors.Control.ToArgb();
            addnew.backImage = "";
            addnew.sizeMode = "Normal";
            memoryData.LayerData.Add(addnew);
            DeviceNode.Nodes.Clear();
            alarmPlay = false;
            reListbox = null;
            relab = null;
            rebutton = null;
            rebuttonTarget = null;
            repicturebox = null;
            reoutputNV = null;
            retextbox = null;
            saveProjectName = "";
            saveProjectNameTemp = "";


            toolTip1.RemoveAll();
            mySaveFullPath = "";

            Mainstatus.Items[project_lab.Name].Text = "priject : new file";

        }

        private void exitProject_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void saveProject_Click(object sender, EventArgs e)
        {
            if (saveProjectNameTemp == "")
            {
                //save first
                saveProjectForm lForm = new saveProjectForm();
                lForm.Owner = this;
                lForm.saveAs = false;
                lForm.ShowDialog();
                if (saveProjectName != "")
                {
                    //save first
                    saveProjectNameTemp = saveProjectName;
                    Mainstatus.Items[project_lab.Name].Text = "priject : " + saveProjectName;
                }
            }

            SaveProjectSub(saveProjectNameTemp);
        }

        private void saveAsProject_Click(object sender, EventArgs e)
        {
            saveProjectForm lForm = new saveProjectForm();
            lForm.Owner = this;
            lForm.saveAs = true;
            lForm.ShowDialog();

            if (saveAsProjectName != "")
            {
                //save new 
                saveProjectNameTemp = saveAsProjectName;
                Mainstatus.Items[project_lab.Name].Text = "priject : " + saveAsProjectName;
            }
            SaveProjectSub(saveProjectNameTemp);
        }
        
        private void SaveProjectSub(string editName) //存檔
        {
            if (Directory.Exists(SaveProjectDefaultPath + @"\" + editName + @"\") != true)
            {
                //資料夾不存在，新增資料夾
                Directory.CreateDirectory(SaveProjectDefaultPath + @"\" + editName + @"\");
                File.WriteAllText(SaveProjectDefaultPath + @"\" + editName + @"\" + editName + ".np", editName);
                mySaveFullPath = SaveProjectDefaultPath + @"\" + editName + @"\";
            }
            
            //save device tree list
            saveDeviceNode(mySaveFullPath);
            //save Layer
            saveLayerinfo(mySaveFullPath);
            //save label obj
            saveLabelObj(mySaveFullPath);
            //save button obj
            saveButtonObj(mySaveFullPath);
            //save input obj
            saveInputDataObj(mySaveFullPath);
            //save output button obj
            saveOutputButtonDataObj(mySaveFullPath);
            //save output text obj
            saveOutputTextDataObj(mySaveFullPath);
            //save output pop obj
            saveOutputPoPDataObj(mySaveFullPath);
            //save picture obj
            savePictureDataObj(mySaveFullPath);
            //save alarm obj
            saveAlarmDataObj(mySaveFullPath);
            //save Lon Monitor
            saveContactList(mySaveFullPath);
            //save contactlist

        }

        private void saveDeviceNode(string savePath)  //device node list save
        {
            StringBuilder buffer = new StringBuilder();
            foreach (TreeNode rootNode in DeviceNode.Nodes)
            {
                // buffer.AppendLine(rootNode.Name);
                BuildTreeString(rootNode, buffer);
            }

            File.WriteAllText(savePath + @"\" + "device.txt", buffer.ToString());
        }

        private void BuildTreeString(TreeNode rootNode, StringBuilder buffer)
        {
            switch (rootNode.Level)
            {
                case 0:
                    buffer.Append("#site");
                    buffer.Append("#" + rootNode.Name);
                    buffer.Append(Environment.NewLine);
                    break;
                case 1:
                    buffer.Append("#fab");
                    buffer.Append("#" + rootNode.Name);
                    buffer.Append(Environment.NewLine);
                    break;
                case 2:
                    buffer.Append("#area");
                    buffer.Append("#" + rootNode.Name);
                    buffer.Append(Environment.NewLine);
                    break;
                case 3:
                    buffer.Append("#device");
                    buffer.Append("#" + rootNode.Name);
                    buffer.Append("#" + rootNode.Tag.ToString());
                    buffer.Append("#" + rootNode.ToolTipText);
                    buffer.Append(Environment.NewLine);
                    break;
                case 4:
                    buffer.Append("#obj");
                    buffer.Append("#" + rootNode.Name);
                    buffer.Append(Environment.NewLine);
                    break;
                case 5:
                    buffer.Append("#nv");
                    buffer.Append("#" + rootNode.Name);
                    buffer.Append("#" + rootNode.Tag.ToString());
                    buffer.Append(Environment.NewLine);
                    break;
            }

            foreach (TreeNode childNode in rootNode.Nodes)
            {
                BuildTreeString(childNode, buffer);
            }
        }

        private void saveLayerinfo(string savePath)
        {
            StringBuilder buffer = new StringBuilder();
            if (memoryData.LayerData.Count > 0)
            {
                for (int i = 0; i < memoryData.LayerData.Count; i++)
                {
                    Layerstruct tar = (Layerstruct)memoryData.LayerData[i];
                    buffer.Append("#" + tar.backColor);
                    buffer.Append("#" + tar.backImage);
                    buffer.Append("#" + tar.name);
                    buffer.Append("#" + tar.sizeMode);
                    buffer.Append(Environment.NewLine);
                }
            }

            File.WriteAllText(savePath + @"\" + "Layer.txt", buffer.ToString());
        }

        private void saveLabelObj(string savePath)
        {
            //LabelObjstruct
            StringBuilder buffer = new StringBuilder();
            if (memoryData.LabelData.Count > 0)
            {
                for (int i = 0; i < memoryData.LabelData.Count; i++)
                {
                    LabelObjstruct tar = (LabelObjstruct)memoryData.LabelData[i];
                    buffer.Append("#" + tar.backcolor);
                    buffer.Append("#" + tar.border);
                    buffer.Append("#" + tar.color);
                    TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
                    // Saving Font object as a string
                    string fontString = converter.ConvertToString(tar.font);
                    buffer.Append("#" + fontString);
                    buffer.Append("#" + tar.layer);
                    buffer.Append("#" + tar.name);
                    buffer.Append("#" + tar.text);
                    buffer.Append("#" + tar.x);
                    buffer.Append("#" + tar.y);
                    buffer.Append("#" + tar.tag);
                    buffer.Append(Environment.NewLine);
                }
            }
            File.WriteAllText(savePath + @"\" + "LabelObject.txt", buffer.ToString());
        }

        private void saveButtonObj(string savePath)
        {
            //ButtonObjstruct
            StringBuilder buffer = new StringBuilder();
            if (memoryData.ButtonData.Count > 0)
            {
                for (int i = 0; i < memoryData.ButtonData.Count; i++)
                {
                    ButtonObjstruct tar = (ButtonObjstruct)memoryData.ButtonData[i];
                    buffer.Append("#" + tar.AlignImage);
                    buffer.Append("#" + tar.AlignText);
                    buffer.Append("#" + tar.backColor);
                    buffer.Append("#" + tar.backImage);
                    buffer.Append("#" + tar.command);
                    TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
                    // Saving Font object as a string
                    string fontString = converter.ConvertToString(tar.font);
                    buffer.Append("#" + fontString);
                    buffer.Append("#" + tar.forecolor);
                    buffer.Append("#" + tar.height);
                    buffer.Append("#" + tar.layer);
                    buffer.Append("#" + tar.name);
                    buffer.Append("#" + tar.text);
                    buffer.Append("#" + tar.useBackColor);
                    buffer.Append("#" + tar.useBackIMG);
                    buffer.Append("#" + tar.width);
                    buffer.Append("#" + tar.x);
                    buffer.Append("#" + tar.y);
                    buffer.Append("#" + tar.tag);
                    buffer.Append(Environment.NewLine);
                }
            }
            File.WriteAllText(savePath + @"\" + "ButtonObject.txt", buffer.ToString());
        }

        private void saveInputDataObj(string savePath)
        {
            //InputObjectstruct
            StringBuilder buffer = new StringBuilder();
            if (memoryData.InputData.Count > 0)
            {
                for (int i = 0; i < memoryData.InputData.Count; i++)
                {
                    InputObjectstruct tar = (InputObjectstruct)memoryData.InputData[i];
                    buffer.Append("#" + tar.backcolor);
                    buffer.Append("#" + tar.border);
                    //buffer.Append("#" + tar.count);
                    buffer.Append("#0");
                    TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
                    // Saving Font object as a string
                    string fontString = converter.ConvertToString(tar.font);
                    buffer.Append("#" + fontString);
                    buffer.Append("#" + tar.forecolor);
                    buffer.Append("#" + tar.ip);
                    buffer.Append("#" + tar.layer);
                    buffer.Append("#" + tar.logdata);
                    buffer.Append("#" + tar.logtime);
                    buffer.Append("#" + tar.lonPolltime);
                    buffer.Append("#" + tar.name);
                    buffer.Append("#" + tar.stringFormat);
                    buffer.Append("#" + tar.target);
                    buffer.Append("#" + tar.targetindex);
                    buffer.Append("#" + tar.unit);
                    buffer.Append("#" + tar.unituse);
                    buffer.Append("#0"); // + tar.value);
                    buffer.Append("#" + tar.x);
                    buffer.Append("#" + tar.y);
                    buffer.Append("#" + tar.tag);
                    buffer.Append("#" + tar.NVtype);
                    buffer.Append("#" + tar.potocol);
                    buffer.Append("#" + tar.site);
                    buffer.Append("#" + tar.fab);
                    buffer.Append("#" + tar.area);
                    buffer.Append("#" + tar.device);
                    buffer.Append("#" + tar.function);
                    buffer.Append("#" + tar.NV);
                    buffer.Append("#" + tar.description);
                    buffer.Append(Environment.NewLine);
                }
            }
            File.WriteAllText(savePath + @"\" + "InputObject.txt", buffer.ToString());
        }

        private void saveOutputButtonDataObj(string savePath)
        {
            //OutputButtonObjectstruct
            StringBuilder buffer = new StringBuilder();
            if (memoryData.OutputButtonData.Count > 0)
            {
                for (int i = 0; i < memoryData.OutputButtonData.Count; i++)
                {
                    OutputButtonObjectstruct tar = (OutputButtonObjectstruct)memoryData.OutputButtonData[i];
                    buffer.Append("#" + tar.buttontype);
                    buffer.Append("#" + tar.height);
                    buffer.Append("#" + tar.imagePath);
                    buffer.Append("#" + tar.ip);
                    buffer.Append("#" + tar.layer);
                    buffer.Append("#" + tar.log);
                    buffer.Append("#" + tar.mail);
                    buffer.Append("#" + tar.name);
                    buffer.Append("#" + tar.NVtype);
                    buffer.Append("#" + tar.NVtypeF);
                    buffer.Append("#" + tar.NVvalue);
                    buffer.Append("#" + tar.SMS);
                    buffer.Append("#" + tar.target);
                    buffer.Append("#" + tar.targetindex);
                    buffer.Append("#" + tar.width);
                    buffer.Append("#" + tar.x);
                    buffer.Append("#" + tar.y);
                    buffer.Append("#" + tar.tag);
                    buffer.Append("#" + tar.site);
                    buffer.Append("#" + tar.fab);
                    buffer.Append("#" + tar.area);
                    buffer.Append("#" + tar.device);
                    buffer.Append("#" + tar.function);
                    buffer.Append("#" + tar.NV);
                    buffer.Append("#" + tar.description);
                    buffer.Append("#" + tar.userOnImagePath);
                    buffer.Append("#" + tar.userOffImagePath);
                    buffer.Append(Environment.NewLine);
                }
            }
            File.WriteAllText(savePath + @"\" + "OutputButtonObject.txt", buffer.ToString());
        }

        private void saveOutputTextDataObj(string savePath)
        {
            //OutputTextObjectstruct
            StringBuilder buffer = new StringBuilder();
            if (memoryData.OutputTextData.Count > 0)
            {
                for (int i = 0; i < memoryData.OutputTextData.Count; i++)
                {
                    OutputTextObjectstruct tar = (OutputTextObjectstruct)memoryData.OutputTextData[i];
                    buffer.Append("#" + tar.height);
                    buffer.Append("#" + tar.ip);
                    buffer.Append("#" + tar.layer);
                    buffer.Append("#" + tar.log);
                    buffer.Append("#" + tar.mail);
                    buffer.Append("#" + tar.name);
                    buffer.Append("#" + tar.NVtype);
                    buffer.Append("#" + tar.NVtypeF);
                    buffer.Append("#" + tar.NVvalue);
                    buffer.Append("#" + tar.SMS);
                    buffer.Append("#" + tar.target);
                    buffer.Append("#" + tar.targetindex);
                    buffer.Append("#" + tar.width);
                    buffer.Append("#" + tar.x);
                    buffer.Append("#" + tar.y);
                    buffer.Append("#" + tar.tag);
                    buffer.Append("#" + tar.site);
                    buffer.Append("#" + tar.fab);
                    buffer.Append("#" + tar.area);
                    buffer.Append("#" + tar.device);
                    buffer.Append("#" + tar.function);
                    buffer.Append("#" + tar.NV);
                    buffer.Append("#" + tar.description);
                    buffer.Append(Environment.NewLine);
                }
            }
            File.WriteAllText(savePath + @"\" + "OutputTextObject.txt", buffer.ToString());
        }

        private void saveOutputPoPDataObj(string savePath)
        {
            //OutputPopObjectstruct
            StringBuilder buffer = new StringBuilder();
            if (memoryData.OutputPopData.Count > 0)
            {
                for (int i = 0; i < memoryData.OutputPopData.Count; i++)
                {
                    OutputPopObjectstruct tar = (OutputPopObjectstruct)memoryData.OutputPopData[i];
                    buffer.Append("#" + tar.AlignIMG);
                    buffer.Append("#" + tar.AlignText);
                    buffer.Append("#" + tar.backColor);
                    buffer.Append("#" + tar.backImage);
                    TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
                    // Saving Font object as a string
                    string fontString = converter.ConvertToString(tar.font);
                    buffer.Append("#" + fontString);
                    buffer.Append("#" + tar.forecolor);
                    buffer.Append("#" + tar.height);
                    buffer.Append("#" + tar.ip);
                    buffer.Append("#" + tar.layer);
                    buffer.Append("#" + tar.log);
                    buffer.Append("#" + tar.mail);
                    buffer.Append("#" + tar.name);
                    buffer.Append("#" + tar.NVtype);
                    buffer.Append("#" + tar.SMS);
                    buffer.Append("#" + tar.target);
                    buffer.Append("#" + tar.targetindex);
                    buffer.Append("#" + tar.text);
                    buffer.Append("#" + tar.useBackColor);
                    buffer.Append("#" + tar.useBackIMG);
                    buffer.Append("#" + tar.width);
                    buffer.Append("#" + tar.x);
                    buffer.Append("#" + tar.y);
                    buffer.Append("#" + tar.tag);
                    buffer.Append("#" + tar.site);
                    buffer.Append("#" + tar.fab);
                    buffer.Append("#" + tar.area);
                    buffer.Append("#" + tar.device);
                    buffer.Append("#" + tar.function);
                    buffer.Append("#" + tar.NV);
                    buffer.Append("#" + tar.description);
                    buffer.Append(Environment.NewLine);
                }
            }
            File.WriteAllText(savePath + @"\" + "OutputPoPObject.txt", buffer.ToString());
        }

        private void savePictureDataObj(string savePath)
        {
            //PictureboxObjectstruct
            StringBuilder buffer = new StringBuilder();
            if (memoryData.PictureData.Count > 0)
            {
                for (int i = 0; i < memoryData.PictureData.Count; i++)
                {
                    PictureboxObjectstruct tar = (PictureboxObjectstruct)memoryData.PictureData[i];
                    buffer.Append("#" + tar.height);
                    buffer.Append("#" + tar.layer);
                    buffer.Append("#" + tar.name);
                    buffer.Append("#" + tar.path);
                    buffer.Append("#" + tar.width);
                    buffer.Append("#" + tar.x);
                    buffer.Append("#" + tar.y);
                    buffer.Append("#" + tar.tag);
                    buffer.Append(Environment.NewLine);
                }
            }
            File.WriteAllText(savePath + @"\" + "PictureObject.txt", buffer.ToString());
        }

        private void saveAlarmDataObj(string savePath)
        {
            //AlarmObjectstruct
            StringBuilder buffer = new StringBuilder();
            if (memoryData.AlarmData.Count > 0)
            {
                for (int i = 0; i < memoryData.AlarmData.Count; i++)
                {
                    AlarmObjectstruct tar = (AlarmObjectstruct)memoryData.AlarmData[i];
                    buffer.Append("#" + tar.AlarmFalseRun);
                    buffer.Append("#" + tar.AlarmStatus);
                    buffer.Append("#" + tar.AlarmTrueRun);
                    buffer.Append("#" + tar.CompareLogic);
                    buffer.Append("#" + tar.CompareMax);
                    buffer.Append("#" + tar.CompareMin);
                    buffer.Append("#" + tar.CompareType);
                    buffer.Append("#" + tar.CompareValue);
                    buffer.Append("#" + tar.layer);
                    buffer.Append("#" + tar.LogicFalseAudioPath);
                    buffer.Append("#" + tar.LogicFalseAudioUse);
                    buffer.Append("#" + tar.LogicFalseHeight);
                    buffer.Append("#" + tar.LogicFalseOutemail);
                    buffer.Append("#" + tar.LogicFalseOutImagePath);
                    buffer.Append("#" + tar.LogicFalseOutLog);
                    buffer.Append("#" + tar.LogicFalseOutMSG);
                    buffer.Append("#" + tar.LogicFalseOutNV);
                    buffer.Append("#" + tar.LogicFalseOutNV1);
                    buffer.Append("#" + tar.LogicFalseOutNV1index);
                    buffer.Append("#" + tar.LogicFalseOutNV1Value);
                    buffer.Append("#" + tar.LogicFalseOutNV2);
                    buffer.Append("#" + tar.LogicFalseOutNV2index);
                    buffer.Append("#" + tar.LogicFalseOutNV2Value);
                    buffer.Append("#" + tar.LogicFalseOutNV3);
                    buffer.Append("#" + tar.LogicFalseOutNV3index);
                    buffer.Append("#" + tar.LogicFalseOutNV3Value);
                    buffer.Append("#" + tar.LogicFalseOutNV4);
                    buffer.Append("#" + tar.LogicFalseOutNV4index);
                    buffer.Append("#" + tar.LogicFalseOutNV4Value);
                    buffer.Append("#" + tar.LogicFalseOutNV5);
                    buffer.Append("#" + tar.LogicFalseOutNV5index);
                    buffer.Append("#" + tar.LogicFalseOutNV5Value);
                    buffer.Append("#" + tar.LogicFalseOutNV6);
                    buffer.Append("#" + tar.LogicFalseOutNV6index);
                    buffer.Append("#" + tar.LogicFalseOutNV6Value);
                    buffer.Append("#" + tar.LogicFalseOutNV7);
                    buffer.Append("#" + tar.LogicFalseOutNV7index);
                    buffer.Append("#" + tar.LogicFalseOutNV7Value);
                    buffer.Append("#" + tar.LogicFalseOutNV8);
                    buffer.Append("#" + tar.LogicFalseOutNV8index);
                    buffer.Append("#" + tar.LogicFalseOutNV8Value);
                    buffer.Append("#" + tar.LogicFalseOutSMS);
                    buffer.Append("#" + tar.LogicFalseWidth);
                    buffer.Append("#" + tar.LogicFalseX);
                    buffer.Append("#" + tar.LogicFalseY);
                    buffer.Append("#" + tar.LogicTrueAudioPath);
                    buffer.Append("#" + tar.LogicTrueAudioUse);
                    buffer.Append("#" + tar.LogicTrueHeight);
                    buffer.Append("#" + tar.LogicTrueOutemail);
                    buffer.Append("#" + tar.LogicTrueOutImagePath);
                    buffer.Append("#" + tar.LogicTrueOutLog);
                    buffer.Append("#" + tar.LogicTrueOutMSG);
                    buffer.Append("#" + tar.LogicTrueOutNV);
                    buffer.Append("#" + tar.LogicTrueOutNV1);
                    buffer.Append("#" + tar.LogicTrueOutNV1index);
                    buffer.Append("#" + tar.LogicTrueOutNV1Value);
                    buffer.Append("#" + tar.LogicTrueOutNV2);
                    buffer.Append("#" + tar.LogicTrueOutNV2index);
                    buffer.Append("#" + tar.LogicTrueOutNV2Value);
                    buffer.Append("#" + tar.LogicTrueOutNV3);
                    buffer.Append("#" + tar.LogicTrueOutNV3index);
                    buffer.Append("#" + tar.LogicTrueOutNV3Value);
                    buffer.Append("#" + tar.LogicTrueOutNV4);
                    buffer.Append("#" + tar.LogicTrueOutNV4index);
                    buffer.Append("#" + tar.LogicTrueOutNV4Value);
                    buffer.Append("#" + tar.LogicTrueOutNV5);
                    buffer.Append("#" + tar.LogicTrueOutNV5index);
                    buffer.Append("#" + tar.LogicTrueOutNV5Value);
                    buffer.Append("#" + tar.LogicTrueOutNV6);
                    buffer.Append("#" + tar.LogicTrueOutNV6index);
                    buffer.Append("#" + tar.LogicTrueOutNV6Value);
                    buffer.Append("#" + tar.LogicTrueOutNV7);
                    buffer.Append("#" + tar.LogicTrueOutNV7index);
                    buffer.Append("#" + tar.LogicTrueOutNV7Value);
                    buffer.Append("#" + tar.LogicTrueOutNV8);
                    buffer.Append("#" + tar.LogicTrueOutNV8index);
                    buffer.Append("#" + tar.LogicTrueOutNV8Value);
                    buffer.Append("#" + tar.LogicTrueOutSMS);
                    buffer.Append("#" + tar.LogicTrueWidth);
                    buffer.Append("#" + tar.LogicTrueX);
                    buffer.Append("#" + tar.LogicTrueY);
                    buffer.Append("#" + tar.name);
                    buffer.Append("#" + tar.NVType);
                    buffer.Append("#" + tar.sampleRate);
                    buffer.Append("#" + tar.sampleRatecount);
                    buffer.Append("#" + tar.SourceIP);
                    buffer.Append("#" + tar.SourceNVindex);
                    buffer.Append("#" + tar.SourceNVName);
                    buffer.Append("#" + tar.TargetIP);
                    buffer.Append("#" + tar.TargetNVindex);
                    buffer.Append("#" + tar.TargetNVName);
                    buffer.Append("#" + tar.timeOver);
                    buffer.Append("#" + tar.timeOvercount);
                    buffer.Append("#" + tar.tag);
                    buffer.Append("#" + tar.AlarmTrueMailgroup);
                    buffer.Append("#" + tar.AlarmFalseMailgroup );
                    buffer.Append("#" + tar.description);
                    buffer.Append("#" + tar.site);
                    buffer.Append("#" + tar.fab);
                    buffer.Append("#" + tar.area);
                    buffer.Append("#" + tar.device);
                    buffer.Append("#" + tar.function);
                    buffer.Append("#" + tar.NV);
                    buffer.Append("#" + tar.NVtype);
                    buffer.Append("#" + tar.NVpart);
                    TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
                    // Saving Font object as a string
                    string fontString = converter.ConvertToString(tar.LogicTrueOutFont);
                    buffer.Append("#" + fontString);
                    fontString = converter.ConvertToString(tar.LogicFalseOutFont);
                    buffer.Append("#" + fontString);
                    buffer.Append("#" + tar.LogicTrueforecolor);
                    buffer.Append("#" + tar.LogicFalseforecolor);
                    buffer.Append("#" + tar.userTrueValue);
                    buffer.Append("#" + tar.userFalseValue);
                    buffer.Append(Environment.NewLine);
                }
            }
            File.WriteAllText(savePath + @"\" + "AlarmObject.txt", buffer.ToString());
        }

        private void saveLonMonitor(string savePath)
        {
            //LonMonitorstruct
            StringBuilder buffer = new StringBuilder();
            if (memoryData.PictureData.Count > 0)
            {
               // for (int i = 0; i < memoryData.LonMonitor.Count; i++)
              //  {
              //      MonitorNV tar = (MonitorNV)memoryData.LonMonitor[i];
                    
              //      buffer.Append("#" + tar.count);
              //      buffer.Append("#" + tar.ip);
              //      buffer.Append("#" + tar.name);
              //      buffer.Append("#" + tar.path);
              //      buffer.Append("#" + tar.time);
              //      buffer.Append("#" + tar.unit);
              //      buffer.Append(Environment.NewLine);
              //  }
            }
          //  File.WriteAllText(savePath + @"\" + "LONMonitor.txt", buffer.ToString());
        }

        private void saveContactList(string savePath)
        {
            //LonMonitorstruct
            StringBuilder buffer = new StringBuilder();
            if (memoryData.contact.Count > 0)
            {
                // for (int i = 0; i < memoryData.LonMonitor.Count; i++)
                //  {
                //      MonitorNV tar = (MonitorNV)memoryData.LonMonitor[i];

                //      buffer.Append("#" + tar.count);
                //      buffer.Append("#" + tar.ip);
                //      buffer.Append("#" + tar.name);
                //      buffer.Append("#" + tar.path);
                //      buffer.Append("#" + tar.time);
                //      buffer.Append("#" + tar.unit);
                //      buffer.Append(Environment.NewLine);
                //  }
            }
            //  File.WriteAllText(savePath + @"\" + "LONMonitor.txt", buffer.ToString());
        }

        private void SystemTimer_DoWork(object sender, DoWorkEventArgs e)   //log data
        {
            string formatForMySqlDate = DateTime.Now.ToString("yyyy-MM-dd");
            string formatForMySqlTime = DateTime.Now.ToString("HH:mm:ss");
            string formatForMySqlDay = DateTime.Now.Day.ToString();
            string tableName = "value_" + DateTime.Now.ToString("yyyy_MM");

            for (int i = 0; i < memoryData.InputData.Count; i++) //逐條搜尋
            {
                long LastID = 0;
                InputObjectstruct inputTag = (InputObjectstruct)memoryData.InputData[i];
                if (inputTag.logdata == true)
                {
                    if (inputTag.logtime == inputTag.logtimecount && inputTag.logtime != 0)
                    {
                        //log時間到
                        if (memoryData.database.Count != 0)
                        {
                            database SQLstr = (database)memoryData.database[0];
                            //open database   ///////////////////////////////////////////////////////////////////////
                            string connStr = "server=" + SQLstr.ip + ";port=" + SQLstr.port + ";uid=" + SQLstr.user + ";pwd=" + SQLstr.password + ";database=" + SQLstr.DBname + ";CharSet=utf8";
                            MySqlConnection conn = new MySqlConnection(connStr);
                            MySqlCommand addList = conn.CreateCommand();

                            try  //資料庫連線
                            {
                                conn.Open(); //開啟資料庫

                                //確認input_list表單是否存在
                                try
                                {
                                    //表單查詢，若不存在則進入catch
                                    string sqlStr = @"select count(*) from " + SQLstr.DBname + ".input_list";
                                    MySqlCommand cmdCHK = new MySqlCommand(sqlStr, conn);
                                    MySqlDataReader dataCHK = cmdCHK.ExecuteReader();
                                    dataCHK.Close();

                                    //form存在，寫入表單
                                    //尋找資料
                                    sqlStr = @"SELECT * FROM input_list WHERE site='" + inputTag.site + "' and fab='" + inputTag.fab + "' and area='" + inputTag.area
                                         + "' and device='" + inputTag.device + "' and function='" + inputTag.function + "' and NVname='" + inputTag.NV + "' ";

                                    MySqlCommand Getcmd = new MySqlCommand(sqlStr, conn);
                                    MySqlDataReader GetRow = Getcmd.ExecuteReader();

                                    if (GetRow.HasRows == true)
                                    {
                                        GetRow.Read();
                                        LastID = int.Parse(GetRow.GetString(0));
                                        GetRow.Close();
                                        //資料已存在→覆寫 update
                                        addList.CommandText = @"update " + "nico_db" + ".input_list set description = '" + inputTag.description + "' where id = " + LastID;
                                        addList.ExecuteNonQuery(); //更新input_list裡的description
                                    }
                                    else
                                    {
                                        //資料不存在→新增 insert
                                        //dataCHK.Close();
                                        GetRow.Close();
                                        addList.CommandText = @"Insert into input_list(site,fab,area,device,function,NVname,NVtype,description,ip) values('"
                                                                                        + inputTag.site + "','" + inputTag.fab + "','" + inputTag.area + "','" + inputTag.device + "','" + inputTag.function + "','"
                                                                                        + inputTag.NV + "','" + inputTag.NVtype + "','" + inputTag.description + "','" + inputTag.ip + "');";
                                        addList.ExecuteNonQuery(); //新增input_list 
                                        LastID = addList.LastInsertedId;

                                    }

                                }
                                catch (Exception outmsg)  //表單查詢，不存在
                                {
                                    //form不存在，建立表單
                                    //建立input_list表單
                                    string addSqlstr = @"create table " + SQLstr.DBname + ".input_list(id SMALLINT auto_increment primary key,site char(32)not null"
                                                                + ",fab char(32)not null,area char(32)not null,device char(20)not null,function char(20)not null"
                                                                + ",NVname char(20)not null,NVtype char(20)not null,description char(32),ip char(15)not null)ENGINE = MYISAM DEFAULT COLLATE utf8_general_ci;";

                                    MySqlCommand SQLcmd = conn.CreateCommand();  //建立SQL命令
                                    SQLcmd.CommandText = addSqlstr;
                                    SQLcmd.ExecuteNonQuery();

                                    //寫入資料 input_list
                                    addSqlstr = @"Insert into input_list(site,fab,area,device,function,NVname,NVtype,description,ip) values('"
                                                    + inputTag.site + "','" + inputTag.fab + "','" + inputTag.area + "','" + inputTag.device + "','" + inputTag.function + "','"
                                                    + inputTag.NV + "','" + inputTag.NVtype + "','" + inputTag.description + "','" + inputTag.ip + "');";

                                    SQLcmd.CommandText = addSqlstr;
                                    SQLcmd.ExecuteNonQuery();
                                    LastID = SQLcmd.LastInsertedId;
                                }  //確認input_list結束

                                //確認value表單是否存在
                                try
                                {
                                    //表單查詢，若不存在則進入catch
                                    string sqlStr = @"select count(*) from " + SQLstr.DBname + "." + tableName;
                                    MySqlCommand cmdCHK = new MySqlCommand(sqlStr, conn);
                                    MySqlDataReader dataCHK = cmdCHK.ExecuteReader();
                                    dataCHK.Close();
                                    //form存在，寫入表單
                                    //insert資料
                                    MySqlCommand addValue = conn.CreateCommand();

                                    if (inputTag.NVtype == "SNVT_switch" || inputTag.NVtype == "SNVT_occupancy")
                                    {
                                        addValue.CommandText = @"Insert into " + tableName + "(list_id,NVvalue_txt,NVvalue_real,date,time) values('" + LastID + "','"
                                                          + inputTag.showvalue + "','" + float.Parse("0") + "','" + formatForMySqlDate + "','" + formatForMySqlTime + "')";
                                    }
                                    else
                                    {
                                        addValue.CommandText = @"Insert into " + tableName + "(list_id,NVvalue_txt,NVvalue_real,date,time) values('" + LastID + "','"
                                                          + inputTag.showvalue + "','" + float.Parse(inputTag.value) + "','" + formatForMySqlDate + "','" + formatForMySqlTime + "')";
                                    }
                                    addValue.ExecuteNonQuery(); //執行insert input_value

                                }
                                catch (Exception outmsg)  //表單查詢，不存在
                                {
                                    //form不存在，建立表單
                                    //建立input_Value表單
                                    string addSqlstr = @"create table " + SQLstr.DBname + "." + tableName + "(id integer auto_increment primary key,list_id SMALLINT not null"
                                                                + ",NVvalue_txt char(11)not null,NVvalue_real float not null,date char(10)not null,time char(8)not null)ENGINE = MYISAM  DEFAULT COLLATE utf8_general_ci;";

                                    MySqlCommand SQLcmd = conn.CreateCommand();  //建立SQL命令
                                    SQLcmd.CommandText = addSqlstr;
                                    SQLcmd.ExecuteNonQuery();

                                    SQLcmd.CommandText = @"ALTER TABLE `" + tableName + "` ADD KEY `date` (`date`),ADD KEY `list_id` (`list_id`);";
                                    SQLcmd.ExecuteNonQuery();

                                    //寫入第一筆資料 value
                                    if (inputTag.NVtype == "SNVT_switch" || inputTag.NVtype == "SNVT_occupancy")
                                    {
                                        addSqlstr = @"Insert into " + tableName + "(list_id,NVvalue_txt,NVvalue_real,date,time) values('" + LastID + "','"
                                                              + inputTag.showvalue + "','" + float.Parse("0") + "','" + formatForMySqlDate + "','" + formatForMySqlTime + "')";
                                    }
                                    else
                                    {
                                        addSqlstr = @"Insert into " + tableName + "(list_id,NVvalue_txt,NVvalue_real,date,time) values('" + LastID + "','"
                                                              + inputTag.showvalue + "','" + inputTag.value + "','" + formatForMySqlDate + "','" + formatForMySqlTime + "')";
                                    }
                                    SQLcmd.CommandText = addSqlstr;
                                    SQLcmd.ExecuteNonQuery();

                                    //throw;
                                }

                            }
                            catch (Exception ex)  //資料庫連線失敗
                            {
                                //MessageBox.Show(ex.Message.ToString());
                                throw ex;
                            }
                            finally
                            {
                                conn.Close();
                            }
                        }
                        //log完成，計時器歸零
                        inputTag.logtimecount = 0;
                        memoryData.InputData[i] = inputTag;
                    }
                    else
                    {
                        //log時間未到，計時器累加
                        inputTag.logtimecount += 1;
                        memoryData.InputData[i] = inputTag;
                    }
                }
            }
        }

        private void SystemTimer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }

        private void fileTool_Click(object sender, EventArgs e)
        {

        }

       

        private void AlarmMonitor_DoWork(object sender, DoWorkEventArgs e)
        {
            string ip = "";

            try
            {
                //update monitor alarm nv value
                if (memoryData.AlarmMonitorValue.Count != 0)
                {
                    for (int i = 0; i < memoryData.AlarmMonitorValue.Count; i++)
                    {
                        AlarmMoniTorNV tar = (AlarmMoniTorNV)memoryData.AlarmMonitorValue[i];
                        if (tar.NVpath != "")
                        {
                            if (tar.sampleRate == tar.sampleRatecount)
                            {
                                string temp = "";
                                for (int RACount = 0; RACount < memoryData.ReadAllNV.Count; RACount++)
                                {
                                    ReadNVvaluestruct fra = (ReadNVvaluestruct)memoryData.ReadAllNV[RACount];
                                    if (tar.ip == fra.IP && tar.device == fra.device && tar.function == fra.function && tar.NV == fra.NV)
                                    {
                                        temp = fra.Value + "$" + fra.status + "$" + fra.NVtype + "$" + fra.preset;
                                        break;
                                    }
                                }

                                if (tar.NVtype == "device")  // get device alarm
                                {

                                    if (temp != null)
                                    {
                                        string[] getval = temp.Split('$');

                                        if (getval[1] == "AL_NO_CONDITION")
                                        {
                                            tar.NVvalue = "AL_NO_CONDITION"; //device online
                                            tar.states = "AL_NO_CONDITION";
                                        }
                                        else if (getval[1] == "AL_OFFLINE")
                                        {
                                            tar.NVvalue = "AL_OFFLINE"; //device offline
                                            tar.states = "AL_OFFLINE";
                                        }
                                    }
                                    else
                                    {
                                        //smartserver offline
                                    }
                                }
                                else  // get NV alarm
                                {
                                    if (temp != null)
                                    {
                                        string[] getval = temp.Split('$');
                                        tar.NVvalue = getval[0]; //get nv value
                                        tar.states = getval[1];
                                        tar.preset = getval[3];
                                    }
                                    else
                                    {
                                        //smartserver offline
                                    }
                                }

                                tar.sampleRatecount = 0;   //reset count
                                memoryData.AlarmMonitorValue[i] = tar;
                            }
                            else
                            {
                                tar.sampleRatecount += 1;  //count ++
                                memoryData.AlarmMonitorValue[i] = tar;
                            }
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                var w32ex = ex as Win32Exception;
                if (w32ex == null)
                {
                    w32ex = ex.InnerException as Win32Exception;
                }
            }

        }  // AlarmMonitor DoWork end

        private void AlarmMonitor_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }

        private void Alarm_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                // alarm monitor
                if (memoryData.AlarmData.Count > 0)  // read alarm info
                {
                    //SmartServer.SOAP rs = new SmartServer.SOAP();
                    SOAP20_DLL.SOAP ws = new SOAP20_DLL.SOAP();
                    string moniVal = "";
                    string states = "";
                    string valueFB = "";
                    string readVal = "";
                    string getReadAllString = "";


                    //Boolean createAlarm = false;
                    for (int i = 0; i < memoryData.AlarmData.Count; i++)
                    {
                        AlarmObjectstruct tar = (AlarmObjectstruct)memoryData.AlarmData[i];
                        PictureBox tarIMG = (PictureBox)this.pictureBox1.Controls[tar.name];
                        //get alarm monitor NV value
                        for (int n = 0; n < memoryData.AlarmMonitorValue.Count; n++)
                        {
                            AlarmMoniTorNV gv = (AlarmMoniTorNV)memoryData.AlarmMonitorValue[n];
                            if (gv.name == tar.name)
                            {
                                moniVal = gv.NVvalue;
                                states = gv.states;
                                valueFB = gv.NVvalue + "$" + gv.states + "$" + gv.NVtype + "$" + gv.preset;
                                getReadAllString = gv.NVvalue + "$" + gv.states + "$" + gv.NVtype + "$" + gv.preset;
                                break;
                            }
                        }

                        //compare value
                        if (tar.NVType == "device") //check Device status (online || offline)
                        {
                            //for (int RAcount= 0;RAcount < memoryData.ReadAllNV.Count;RAcount ++)
                            //{
                            //    ReadNVvaluestruct tag = (ReadNVvaluestruct)memoryData.ReadAllNV[RAcount];
                            //    string[] tarNV = tar.SourceNVName.Split('@');

                            //    if (tag.device == tar.device && tag.IP == tar.SourceIP)
                            //    {
                            //        valueFB = tag.Value + "$" + tag.status + "$" + tag.NVtype + "$" + tag.preset;
                            //        getReadAllString = tag.Value + "$" + tag.status + "$" + tag.NVtype + "$" + tag.preset;
                            //        break;
                            //    }
                            //}

                            //ReadNVvaluestruct

                            //===========================================================
                            //原來的資料取得方式
                            //string[] tarNV = tar.SourceNVName.Split('@');
                            //valueFB = ws.readNV(tar.SourceIP, tarNV[2] + "/NodeObject/nviRequest");
                            //System.Threading.Thread.Sleep(10);
                            //===========================================================


                            string[] rq = valueFB.Split('$');

                            if (moniVal == "AL_OFFLINE") // device offline  if (rq[1] == "AL_OFFLINE") // device offline
                            {
                                //ALARM 成立
                                tar.AlarmStatus = true;
                            }
                            else if (moniVal == "AL_NO_CONDITION") // device online
                            {
                                tar.AlarmStatus = false;
                                tar.timeOvercount = 0;
                            }
                            else if (moniVal == "")
                            {
                                moniVal = "AL_NO_CONDITION";
                                tar.AlarmStatus = false;
                                tar.timeOvercount = 0;
                            }
                        }
                        else  //check NV value
                        {
                            if (tar.CompareType == "value") //compare value
                            {

                                //for (int RAcount = 0 ; RAcount < memoryData.ReadAllNV.Count; RAcount++)
                                //{
                                //        break;
                                //    ReadNVvaluestruct tag = (ReadNVvaluestruct)memoryData.ReadAllNV[RAcount];
                                //    if (tag.device == tar.device && tag.function == tar.function && tag.NV == tar.NV && tag.IP == tar.SourceIP)
                                //    {
                                //        valueFB = tag.Value + "$" + tag.status + "$" + tag.NVtype + "$" + tag.preset;
                                //        getReadAllString = tag.Value + "$" + tag.status + "$" + tag.NVtype + "$" + tag.preset;
                                //    }
                                //}

                                //===========================================================
                                //原來的資料取得方式
                                //string[] nvpath = tar.SourceNVName.Split('@');
                                //valueFB = ws.readNV(tar.SourceIP, nvpath[2]);  // get source NV value
                                //System.Threading.Thread.Sleep(10);
                                //===========================================================

                                if (valueFB != null)
                                {
                                    string[] rq = valueFB.Split('$');
                                    string[] reval = rq[0].Split(' ');
                                    if (tar.NVType == "SNVT_occupancy") // || tar.NVType == "SNVT_switch")
                                    {
                                        //string sourceNVval = reval[0];
                                        string sourceNVval = reval[0];
                                        readVal = reval[0];
                                        switch (tar.CompareLogic)
                                        {
                                            case "==":
                                                if (sourceNVval == tar.CompareValue)
                                                {
                                                    tar.AlarmStatus = true;
                                                }
                                                else
                                                {
                                                    tar.AlarmStatus = false;
                                                    tar.timeOvercount = 0;
                                                }
                                                break;
                                            case "!=":
                                                if (sourceNVval != tar.CompareValue)
                                                {
                                                    tar.AlarmStatus = true;
                                                }
                                                else
                                                {
                                                    tar.AlarmStatus = false;
                                                    tar.timeOvercount = 0;
                                                }
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        float sourceNVval = 0;
                                        float settingNalue = 0;
                                        readVal = reval[0];
                                        if (tar.NVType == "SNVT_switch")
                                        {
                                            if (tar.NVpart == "value")
                                            {
                                                sourceNVval = float.Parse(reval[0]);
                                            }
                                            else if (tar.NVpart == "status")
                                            {
                                                sourceNVval = float.Parse(reval[1]);
                                            }

                                        }
                                        else
                                        {
                                            sourceNVval = float.Parse(reval[0]);
                                        }

                                        settingNalue = float.Parse(tar.CompareValue);

                                        switch (tar.CompareLogic)
                                        {
                                            case "<":
                                                if (sourceNVval < settingNalue)
                                                { tar.AlarmStatus = true; }
                                                else
                                                {
                                                    tar.AlarmStatus = false;
                                                    tar.timeOvercount = 0;
                                                }
                                                break;
                                            case "<=":
                                                if (sourceNVval <= settingNalue)
                                                { tar.AlarmStatus = true; }
                                                else
                                                {
                                                    tar.AlarmStatus = false;
                                                    tar.timeOvercount = 0;
                                                }
                                                break;
                                            case "==":
                                                if (sourceNVval == settingNalue)
                                                { tar.AlarmStatus = true; }
                                                else
                                                {
                                                    tar.AlarmStatus = false;
                                                    tar.timeOvercount = 0;
                                                }
                                                break;
                                            case "!=":
                                                if (sourceNVval != settingNalue)
                                                { tar.AlarmStatus = true; }
                                                else
                                                {
                                                    tar.AlarmStatus = false;
                                                    tar.timeOvercount = 0;
                                                }
                                                break;
                                            case ">=":
                                                if (sourceNVval >= settingNalue)
                                                { tar.AlarmStatus = true; }
                                                else
                                                {
                                                    tar.AlarmStatus = false;
                                                    tar.timeOvercount = 0;
                                                }
                                                break;
                                            case ">":
                                                if (sourceNVval > settingNalue)
                                                { tar.AlarmStatus = true; }
                                                else
                                                {
                                                    tar.AlarmStatus = false;
                                                    tar.timeOvercount = 0;
                                                }
                                                break;
                                            case "~":
                                                if (sourceNVval >= (float)tar.CompareMin && (float)sourceNVval <= tar.CompareMax)
                                                { tar.AlarmStatus = true; }
                                                else
                                                {
                                                    tar.AlarmStatus = false;
                                                    tar.timeOvercount = 0;
                                                }
                                                break;
                                        }
                                    }
                                }
                            }
                            else if (tar.CompareType == "tag")   //compare another nv
                            {
                                //for (int RAcount = 0; RAcount < memoryData.ReadAllNV.Count; RAcount++)
                                //{
                                //    ReadNVvaluestruct tag = (ReadNVvaluestruct)memoryData.ReadAllNV[RAcount];
                                //    if (tag.device == tar.device && tag.function == tar.function && tag.NV == tar.NV && tag.IP == tar.SourceIP)
                                //    {
                                //        valueFB = tag.Value + "$" + tag.status + "$" + tag.NVtype + "$" + tag.preset;
                                //        getReadAllString = tag.Value + "$" + tag.status + "$" + tag.NVtype + "$" + tag.preset;
                                //        break;
                                //    }
                                //}

                                //===========================================================
                                //原來的資料取得方式
                                //string[] nvpath = tar.SourceNVName.Split('@');
                                //valueFB = ws.readNV(tar.SourceIP, nvpath[2]);  // get source NV value
                                //System.Threading.Thread.Sleep(10);
                                //===========================================================

                                string[] tarNV = tar.TargetNVName.Split('@');
                                string[] getTemp = tarNV[2].Split('/');

                                string compareIP = tarNV[1];
                                string compareDevice = getTemp[2];
                                string compareFunction = getTemp[3];
                                string compareNV = getTemp[4];


                                if (valueFB != null)
                                {

                                    if (tar.NVType == "SNVT_occupancy") // || tar.NVType == "SNVT_switch")
                                    {
                                        string temp2 = "";
                                        for (int item = 0; item < memoryData.ReadAllNV.Count; item++)
                                        {
                                            ReadNVvaluestruct tag = (ReadNVvaluestruct)memoryData.ReadAllNV[item];
                                            if (tag.device == compareDevice && tag.function == compareFunction && tag.NV == compareNV && tag.IP == compareIP)
                                            {
                                                temp2 = tag.Value + "$" + tag.status + "$" + tag.NVtype + "$" + tag.preset;
                                                break;
                                            }
                                        }

                                        //===========================================================
                                        //原來的資料取得方式
                                        //string temp2 = ws.readNV(tar.TargetIP, tarNV[2]);  // get target NV value
                                        //System.Threading.Thread.Sleep(10);
                                        //===========================================================

                                        string[] sVal = valueFB.Split('$');
                                        string[] tVal = temp2.Split('$');
                                        string[] ssval = sVal[0].Split(' ');
                                        string[] ttval = tVal[0].Split(' ');
                                        string sourceGet = ssval[0];
                                        string targetGet = ttval[0];

                                        switch (tar.CompareLogic)
                                        {

                                            case "==":
                                                if (sourceGet == targetGet)
                                                { tar.AlarmStatus = true; }
                                                else
                                                {
                                                    tar.AlarmStatus = false;
                                                    tar.timeOvercount = 0;
                                                }
                                                break;
                                            case "!=":
                                                if (sourceGet != targetGet)
                                                { tar.AlarmStatus = true; }
                                                else
                                                {
                                                    tar.AlarmStatus = false;
                                                    tar.timeOvercount = 0;
                                                }
                                                break;

                                        }
                                    }
                                    else   //other type
                                    {
                                        string temp2 = "";
                                        for (int item = 0; item < memoryData.ReadAllNV.Count; item++)
                                        {
                                            ReadNVvaluestruct tag = (ReadNVvaluestruct)memoryData.ReadAllNV[item];
                                            if (tag.device == compareDevice && tag.function == compareFunction && tag.NV == compareNV && tag.IP == compareIP)
                                            {
                                                temp2 = tag.Value + "$" + tag.status + "$" + tag.NVtype + "$" + tag.preset;
                                                break;
                                            }
                                        }

                                        //===========================================================
                                        //原來的資料取得方式
                                        //string temp2 = ws.readNV(tar.TargetIP, tarNV[2]);  // get target NV value
                                        //System.Threading.Thread.Sleep(10);
                                        //===========================================================

                                        string[] sVal = valueFB.Split('$');
                                        string[] tVal = temp2.Split('$');
                                        string[] ssval = sVal[0].Split(' ');
                                        string[] ttval = tVal[0].Split(' ');

                                        float sourceGet = 0; // =float.Parse(ssval[0]);
                                        float targetGet = 0; // =float.Parse(ttval[0]);

                                        if (tar.NVType == "SNVT_switch")
                                        {
                                            if (tar.NVpart == "value")
                                            {
                                                sourceGet = float.Parse(ssval[0]);
                                                targetGet = float.Parse(ttval[0]);
                                            }
                                            else if (tar.NVpart == "status")
                                            {
                                                sourceGet = float.Parse(ssval[1]);
                                                targetGet = float.Parse(ttval[1]);
                                            }

                                        }
                                        else
                                        {
                                            sourceGet = float.Parse(ssval[0]);
                                            targetGet = float.Parse(ttval[0]);
                                        }



                                        switch (tar.CompareLogic)
                                        {
                                            case "<":
                                                if (sourceGet < targetGet)
                                                { tar.AlarmStatus = true; }
                                                else
                                                {
                                                    tar.AlarmStatus = false;
                                                    tar.timeOvercount = 0;
                                                }
                                                break;
                                            case "<=":
                                                if (sourceGet <= targetGet)
                                                { tar.AlarmStatus = true; }
                                                else
                                                {
                                                    tar.AlarmStatus = false;
                                                    tar.timeOvercount = 0;
                                                }
                                                break;
                                            case "==":
                                                if (sourceGet == targetGet)
                                                { tar.AlarmStatus = true; }
                                                else
                                                {
                                                    tar.AlarmStatus = false;
                                                    tar.timeOvercount = 0;
                                                }
                                                break;
                                            case "!=":
                                                if (sourceGet != targetGet)
                                                { tar.AlarmStatus = true; }
                                                else
                                                {
                                                    tar.AlarmStatus = false;
                                                    tar.timeOvercount = 0;
                                                }
                                                break;
                                            case ">=":
                                                if (sourceGet >= targetGet)
                                                { tar.AlarmStatus = true; }
                                                else
                                                {
                                                    tar.AlarmStatus = false;
                                                    tar.timeOvercount = 0;
                                                }
                                                break;
                                            case ">":
                                                if (sourceGet > targetGet)
                                                { tar.AlarmStatus = true; }
                                                else
                                                {
                                                    tar.AlarmStatus = false;
                                                    tar.timeOvercount = 0;
                                                }
                                                break;
                                        }
                                    }


                                }

                            }

                        }
                        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //alarm action
                        if (tar.AlarmStatus == true) // alarm 條件達成
                        {
                            if (tar.timeOver == tar.timeOvercount) //時間到.執行動作
                            {
                                //alarm發生時執行一次
                                //tar.LogicTrueOutImagePath (第一次發生時執行)
                                if (tar.AlarmTrueRun == true)
                                {
                                    tar.AlarmStatus = true;
                                    alarmPlay = true;
                                    if (tar.LogicTrueOutImagePath != "")
                                    {
                                        //showValue or image
                                        if (tar.userTrueValue == true)
                                        {

                                        }
                                        else
                                        {
                                            //use image
                                            if (tarIMG != null)
                                            {
                                                if (System.IO.File.Exists(tar.LogicTrueOutImagePath))
                                                {
                                                    //find
                                                    FileStream fs = File.OpenRead(tar.LogicTrueOutImagePath);
                                                    tarIMG.Image = Image.FromStream(fs);
                                                    //fs.Close();
                                                }
                                                else
                                                {
                                                    //not found
                                                }

                                                tarIMG.Size = new Size(tar.LogicTrueWidth, tar.LogicTrueHeight);
                                                tarIMG.SizeMode = PictureBoxSizeMode.StretchImage;
                                            }
                                        }

                                    }

                                    if (tar.LogicTrueAudioUse == true && tar.LogicTrueAudioPath != "")
                                    {
                                        AlarmAudiostruct add = new AlarmAudiostruct();
                                        add.name = tar.name;
                                        add.path = tar.LogicTrueAudioPath;
                                        memoryData.AlarmAudioTrue.Add(add);
                                    }

                                    tar.AlarmTrueRun = false;

                                    //output nv
                                    if (tar.LogicTrueOutNV == true)
                                    {
                                        if (tar.LogicTrueOutNV1 != "")  //output nv1
                                        {
                                            string[] nv = tar.LogicTrueOutNV1.Split('@');
                                            //rs.writeNV(nv[1], nv[2], tar.LogicTrueOutNV1Value);
                                            string fb = ws.writeNV(nv[1], nv[2], tar.LogicTrueOutNV1Value);
                                        }

                                        if (tar.LogicTrueOutNV2 != "")  //output nv2
                                        {
                                            string[] nv = tar.LogicTrueOutNV2.Split('@');
                                            //rs.writeNV(nv[1], nv[2], tar.LogicTrueOutNV2Value);
                                            string fb = ws.writeNV(nv[1], nv[2], tar.LogicTrueOutNV2Value);
                                        }

                                        if (tar.LogicTrueOutNV3 != "")  //output nv3
                                        {
                                            string[] nv = tar.LogicTrueOutNV3.Split('@');
                                            //rs.writeNV(nv[1], nv[2], tar.LogicTrueOutNV3Value);
                                            string fb = ws.writeNV(nv[1], nv[2], tar.LogicTrueOutNV3Value);
                                        }

                                        if (tar.LogicTrueOutNV4 != "")  //output nv4
                                        {
                                            string[] nv = tar.LogicTrueOutNV4.Split('@');
                                            //rs.writeNV(nv[1], nv[2], tar.LogicTrueOutNV4Value);
                                            string fb = ws.writeNV(nv[1], nv[2], tar.LogicTrueOutNV4Value);
                                        }

                                        if (tar.LogicTrueOutNV5 != "")  //output nv5
                                        {
                                            string[] nv = tar.LogicTrueOutNV5.Split('@');
                                            //rs.writeNV(nv[1], nv[2], tar.LogicTrueOutNV5Value);
                                            string fb = ws.writeNV(nv[1], nv[2], tar.LogicTrueOutNV5Value);
                                        }

                                        if (tar.LogicTrueOutNV6 != "")  //output nv6
                                        {
                                            string[] nv = tar.LogicTrueOutNV6.Split('@');
                                            //rs.writeNV(nv[1], nv[2], tar.LogicTrueOutNV6Value);
                                            string fb = ws.writeNV(nv[1], nv[2], tar.LogicTrueOutNV6Value);
                                        }

                                        if (tar.LogicTrueOutNV7 != "")  //output nv7
                                        {
                                            string[] nv = tar.LogicTrueOutNV7.Split('@');
                                            //rs.writeNV(nv[1], nv[2], tar.LogicTrueOutNV7Value);
                                            string fb = ws.writeNV(nv[1], nv[2], tar.LogicTrueOutNV7Value);
                                        }

                                        if (tar.LogicTrueOutNV8 != "")  //output nv8
                                        {
                                            string[] nv = tar.LogicTrueOutNV8.Split('@');
                                            //rs.writeNV(nv[1], nv[2], tar.LogicTrueOutNV8Value);
                                            string fb = ws.writeNV(nv[1], nv[2], tar.LogicTrueOutNV8Value);
                                        }
                                    }

                                    //send mail
                                    if (tar.LogicTrueOutemail == true)
                                    {
                                        for (int m = 0; m < memoryData.GroupContact2.Count; m++)
                                        {
                                            ContactGroup2 mg = (ContactGroup2)memoryData.GroupContact2[m];
                                            if (tar.AlarmTrueMailgroup == mg.groupname)
                                            {
                                                using (FileStream input = new FileStream(Application.StartupPath + @"\Resources\SMTP.dat", FileMode.Open))
                                                {   // 讀取整數值
                                                    BinaryReader reader = new BinaryReader(input);
                                                    string data = reader.ReadString();
                                                    reader.Dispose();
                                                    int numOfBytes = data.Length / 8;
                                                    byte[] bytes = new byte[numOfBytes];
                                                    for (int ri = 0; ri < numOfBytes; ++ri)
                                                    {
                                                        bytes[ri] = Convert.ToByte(data.Substring(8 * ri, 8), 2);
                                                    }
                                                    //File.WriteAllBytes(fileName, bytes);
                                                    string val = GetString(bytes);
                                                    string[] SpStr = val.Split('$');
                                                    string SMTPhost = SpStr[1];
                                                    string SMTPport = SpStr[2];
                                                    Boolean SSL = Boolean.Parse(SpStr[3]);
                                                    string userName = SpStr[4];
                                                    string userPassword = SpStr[5];

                                                    for (int sg = 0; sg < mg.groupmember.Count; sg++)
                                                    {
                                                        Contactstruct sgm = (Contactstruct)mg.groupmember[sg];

                                                        if (sgm.mail != null && sgm.mail != null)
                                                        {
                                                            string formatForMySqlDate = DateTime.Now.ToString("yyyy-MM-dd");
                                                            string formatForMySqlTime = DateTime.Now.ToString("HH:mm:ss");

                                                            email.From = new MailAddress(userName);  //寄件人
                                                            email.Subject = "alarm active!";  //標題
                                                            email.Body = "trigger time = " + formatForMySqlDate + " " + formatForMySqlTime + Environment.NewLine
                                                                         + "trigger value = " + readVal + Environment.NewLine + "descript : " + tar.description
                                                                         + Environment.NewLine + "message : " + tar.LogicTrueOutMSG;  //內容
                                                            email.To.Add(sgm.mail);  //收件人
                                                            SMTP.EnableSsl = true;
                                                            SMTP.Port = int.Parse(SMTPport); //smtp port
                                                            SMTP.Host = SMTPhost;  //smtp host(主機ip)
                                                            SMTP.Credentials = new System.Net.NetworkCredential(userName, userPassword);  //寄件人,密碼
                                                            SMTP.Send(email);
                                                        }

                                                    }
                                                    input.Dispose();
                                                }
                                            }
                                        }
                                    }
                                    //send SMS
                                    if (tar.LogicTrueOutSMS == true)
                                    {
                                    }
                                    //log data to SQL
                                    if (tar.LogicTrueOutLog == true)
                                    {
                                        //save to database
                                        if (memoryData.database.Count != 0)
                                        {
                                            database SQLstr = (database)memoryData.database[0];

                                            //open database
                                            string connStr = "server=" + SQLstr.ip + ";port=" + SQLstr.port + ";uid=" + SQLstr.user + ";pwd=" + SQLstr.password + ";database=" + SQLstr.DBname;
                                            MySqlConnection conn = new MySqlConnection(connStr);
                                            //MySqlCommand command = conn.CreateCommand();
                                            MySqlCommand addList = conn.CreateCommand();
                                            conn.Open();

                                            string sql = @"SELECT * FROM alarm_list WHERE site='" + tar.site + "' and fab='" + tar.fab + "' and area='" + tar.area
                                                               + "' and device='" + tar.device + "' and function='" + tar.function + "' and NVname='" + tar.NV + "' ";

                                            MySqlCommand cmdCHK = new MySqlCommand(sql, conn);
                                            MySqlDataReader dataCHK = cmdCHK.ExecuteReader();
                                            int listid = 0;

                                            string formatForMySqlDate = DateTime.Now.ToString("yyyy-MM-dd");
                                            string formatForMySqlTime = DateTime.Now.ToString("HH:mm:ss");

                                            string alarm_value = "";
                                            string NVvalue_txt = "";
                                            float NVvalue_real = 0;

                                            if (tar.LogicTrueOutLog == true)
                                            {
                                                //get type
                                                string alarmType = "";
                                                if (tar.NVType == "device")
                                                {
                                                    alarmType = "device";
                                                }
                                                else
                                                {
                                                    alarmType = "tag";
                                                }

                                                if (tar.NVType == "SNVT_occupancy")
                                                {
                                                    alarm_value = tar.CompareValue;
                                                    NVvalue_txt = readVal;
                                                    NVvalue_real = 0;
                                                }
                                                else if (tar.NVType == "device")  // type = device
                                                {
                                                    alarm_value = "offline";
                                                    NVvalue_txt = "offline";
                                                    NVvalue_real = 0;
                                                }
                                                else  // type = NV
                                                {
                                                    if (moniVal == "" || moniVal == null)
                                                    {
                                                        moniVal = "0";
                                                    }

                                                    if (tar.NVType == "SNVT_switch" || tar.NVtype == "SNVT_occupancy")
                                                    {
                                                        //===========================================================
                                                        //原來的資料取得方式
                                                        //string[] gettar = tar.SourceNVName.Split('@');
                                                        //string[] getnewValue = ws.readNV(gettar[1], gettar[2]).Split('$');
                                                        //System.Threading.Thread.Sleep(10);
                                                        //===========================================================

                                                        string[] getnewValue = getReadAllString.Split('$');

                                                        string[] sppart = getnewValue[0].Split(' ');
                                                        if (tar.NVpart == "value")
                                                        {
                                                            NVvalue_txt = sppart[0];
                                                            NVvalue_real = float.Parse(sppart[0]);
                                                        }
                                                        else if (tar.NVpart == "status")
                                                        {
                                                            NVvalue_txt = sppart[1];
                                                            NVvalue_real = float.Parse(sppart[1]);
                                                        }

                                                        alarm_value = tar.CompareValue;

                                                    }
                                                    else
                                                    {
                                                        alarm_value = tar.CompareValue;
                                                        NVvalue_txt = readVal;
                                                        NVvalue_real = float.Parse(readVal);
                                                    }
                                                }


                                                if (dataCHK.HasRows == true)
                                                {
                                                    //有查到資料
                                                    dataCHK.Read();
                                                    listid = int.Parse(dataCHK.GetString(0));
                                                    dataCHK.Close();

                                                    addList.CommandText = @"update nico_db.alarm_list set description = '" + tar.description + "',message = '"
                                                                           + tar.LogicTrueOutMSG + "' where id = " + listid;
                                                    addList.ExecuteNonQuery();

                                                    MySqlCommand addValue = conn.CreateCommand();

                                                    addValue.CommandText = @"Insert into alarm_value(list_id,NVvalue_txt,NVvalue_real,alarm_event,date,time) values('"
                                                                              + listid + "','" + NVvalue_txt + "','" + NVvalue_real + "','active','"
                                                                              + formatForMySqlDate + "','" + formatForMySqlTime + "')";

                                                    addValue.ExecuteNonQuery();

                                                }
                                                else
                                                {
                                                    dataCHK.Close();
                                                    //沒有查到資料


                                                    addList.CommandText = @"Insert into alarm_list(site,fab,area,device,function,NVname,NVtype,alarm_setting,alarm_type,"
                                                                          + "alarm_value,message,description,ip) values('" + tar.site + "','" + tar.fab + "','" + tar.area
                                                                          + "','" + tar.device + "','" + tar.function + "','" + tar.NV + "','" + tar.NVType
                                                                          + "','" + tar.CompareLogic + "','" + alarmType + "','" + alarm_value + "','" + tar.LogicTrueOutMSG
                                                                          + "','" + tar.description + "','" + tar.SourceIP + "')";

                                                    addList.ExecuteNonQuery();

                                                    //get list_id
                                                    dataCHK = cmdCHK.ExecuteReader();
                                                    dataCHK.Read();
                                                    if (dataCHK.HasRows == true)
                                                    {
                                                        listid = int.Parse(dataCHK.GetString(0));
                                                        dataCHK.Close();
                                                    }

                                                    //write to output_value
                                                    MySqlCommand addValue = conn.CreateCommand();

                                                    addValue.CommandText = @"Insert into alarm_value(list_id,NVvalue_txt,NVvalue_real,alarm_event,date,time) values('"
                                                                              + listid + "','" + NVvalue_txt + "','" + NVvalue_real + "','active','"
                                                                              + formatForMySqlDate + "','" + formatForMySqlTime + "')";

                                                    addValue.ExecuteNonQuery();

                                                }

                                                conn.Close();
                                                // old  /////////////////↑↑↑↑↑↑↑↑↑↑↑↑

                                            }
                                        }
                                    }

                                }

                                //時間到持續更新SHOW VALUE(ALARM已發生仍要繼續更新畫面)
                                if (tar.userTrueValue == true)
                                {

                                    //use value
                                    //要顯示的文字
                                    string s = ""; //moniVal;  // "show alarm value";
                                    string[] spSTR = valueFB.Split('$');
                                    if (tar.NVType == "SNVT_switch")
                                    {
                                        string[] NV = spSTR[0].Split(' ');
                                        if (tar.NVpart == "value")
                                        {
                                            s = NV[0];
                                        }
                                        else if (tar.NVpart == "status")
                                        {
                                            s = NV[1];
                                        }
                                    }
                                    else if (tar.NVType == "device")
                                    {
                                        if (moniVal == "AL_NO_CONDITION")
                                        {
                                            s = "online";
                                        }
                                        else
                                        {
                                            s = "offline";
                                        }
                                    }
                                    else //if (tar.NVtype == "SNVT_occupancy")
                                    {
                                        if (spSTR[0] == "")
                                        {
                                            s = "null";
                                        }
                                        else
                                        {
                                            s = spSTR[0];
                                        }

                                    }


                                    //先建立底圖預測文字大小使用
                                    Bitmap canvas = new Bitmap(40, 28);
                                    //建立繪圖物件
                                    Graphics g = Graphics.FromImage(canvas);


                                    // 设置字体的样式

                                    Font f = new Font("Arial", 12);  //tar.LogicTrueOutFont; //new Font("新細明體", 12);

                                    //計算文字大小
                                    SizeF stringSize = g.MeasureString(s, tar.LogicTrueOutFont, 1000);
                                    //SizeF stringSize = g.MeasureString(s, f, 1000);
                                    g.Dispose();
                                    int setX = Convert.ToInt32(stringSize.Width);
                                    int setY = Convert.ToInt32(stringSize.Height);
                                    //canvas.Dispose();
                                    //g.Dispose();
                                    Bitmap canvasShow = new Bitmap(setX, setY);
                                    Graphics show = Graphics.FromImage(canvasShow);

                                    // 实例化一个实心画刷，颜色是红色
                                    SolidBrush brush = new SolidBrush(Color.FromArgb(tar.LogicTrueforecolor)); //new SolidBrush(Color.Red);
                                                                                                               // 与左上角坐标的距离
                                    PointF point = new PointF(0, 0);
                                    // 开始绘制
                                    show.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                                    show.DrawString(s, f, brush, point);
                                    //f.Dispose();
                                    //show.Dispose();
                                    tarIMG.Image = canvasShow;
                                    tarIMG.SizeMode = PictureBoxSizeMode.AutoSize;

                                    f.Dispose();
                                    show.Dispose();

                                }


                                tar.AlarmFalseRun = true;
                                tar.timeOvercount = 0;
                                memoryData.AlarmData[i] = tar;


                            }
                            else //count ++
                            {
                                tar.timeOvercount += 1;
                                memoryData.AlarmData[i] = tar;

                            }
                        }
                        else if (tar.AlarmStatus == false) // alarm 條件未達成
                        {
                            //alarm解除時第一次執行的動作
                            if (tar.AlarmFalseRun == true) // (第一次發生時執行)
                            {
                                tar.AlarmStatus = false;
                                alarmPlay = true;

                                if (tar.userFalseValue == true)
                                {

                                }
                                else
                                {
                                    if (tarIMG != null)
                                    {
                                        if (System.IO.File.Exists(tar.LogicFalseOutImagePath))
                                        {
                                            //find
                                            FileStream fs = File.OpenRead(tar.LogicFalseOutImagePath);
                                            tarIMG.Image = Image.FromStream(fs);
                                            //fs.Close();
                                        }
                                        else
                                        {
                                            //not found
                                        }


                                        tarIMG.Size = new Size(tar.LogicFalseWidth, tar.LogicFalseHeight);
                                        tarIMG.SizeMode = PictureBoxSizeMode.StretchImage;
                                    }
                                }

                                tar.AlarmFalseRun = false;
                                tar.AlarmTrueRun = true;

                                int position = -1;
                                AlarmAudiostruct scan = new AlarmAudiostruct();
                                scan.name = tar.name;
                                scan.path = tar.LogicTrueAudioPath;
                                position = memoryData.AlarmAudioTrue.IndexOf(scan);
                                if (position != -1)
                                {
                                    memoryData.AlarmAudioTrue.RemoveAt(position);
                                }

                                if (tar.LogicFalseAudioUse == true)
                                {
                                    if (tar.LogicFalseAudioPath != "")
                                    {
                                        AlarmAudiostruct add = new AlarmAudiostruct();
                                        add.name = tar.name;
                                        add.path = tar.LogicFalseAudioPath;
                                        memoryData.AlarmAudioFalse.Add(add);


                                    }
                                }

                                //output nv
                                if (tar.LogicFalseOutNV == true)
                                {
                                    if (tar.LogicFalseOutNV1 != "")  // output nv1
                                    {
                                        string[] nv = tar.LogicFalseOutNV1.Split('@');
                                        //rs.writeNV(nv[1], nv[2], tar.LogicFalseOutNV1Value);
                                        string fb = ws.writeNV(nv[1], nv[2], tar.LogicFalseOutNV1Value);
                                    }

                                    if (tar.LogicFalseOutNV2 != "")  // output nv2
                                    {
                                        string[] nv = tar.LogicFalseOutNV2.Split('@');
                                        //rs.writeNV(nv[1], nv[2], tar.LogicFalseOutNV2Value);
                                        string fb = ws.writeNV(nv[1], nv[2], tar.LogicFalseOutNV2Value);
                                    }

                                    if (tar.LogicFalseOutNV3 != "")  // output nv3
                                    {
                                        string[] nv = tar.LogicFalseOutNV3.Split('@');
                                        //rs.writeNV(nv[1], nv[2], tar.LogicFalseOutNV3Value);
                                        string fb = ws.writeNV(nv[1], nv[2], tar.LogicFalseOutNV3Value);
                                    }

                                    if (tar.LogicFalseOutNV4 != "")  // output nv4
                                    {
                                        string[] nv = tar.LogicFalseOutNV4.Split('@');
                                        //rs.writeNV(nv[1], nv[2], tar.LogicFalseOutNV4Value);
                                        string fb = ws.writeNV(nv[1], nv[2], tar.LogicFalseOutNV4Value);
                                    }

                                    if (tar.LogicFalseOutNV5 != "")  // output nv5
                                    {
                                        string[] nv = tar.LogicFalseOutNV5.Split('@');
                                        //rs.writeNV(nv[1], nv[2], tar.LogicFalseOutNV5Value);
                                        string fb = ws.writeNV(nv[1], nv[2], tar.LogicFalseOutNV5Value);
                                    }

                                    if (tar.LogicFalseOutNV6 != "")  // output nv6
                                    {
                                        string[] nv = tar.LogicFalseOutNV6.Split('@');
                                        //rs.writeNV(nv[1], nv[2], tar.LogicFalseOutNV6Value);
                                        string fb = ws.writeNV(nv[1], nv[2], tar.LogicFalseOutNV6Value);
                                    }

                                    if (tar.LogicFalseOutNV7 != "")  // output nv7
                                    {
                                        string[] nv = tar.LogicFalseOutNV7.Split('@');
                                        //rs.writeNV(nv[1], nv[2], tar.LogicFalseOutNV7Value);
                                        string fb = ws.writeNV(nv[1], nv[2], tar.LogicFalseOutNV7Value);
                                    }

                                    if (tar.LogicFalseOutNV8 != "")  // output nv8
                                    {
                                        string[] nv = tar.LogicFalseOutNV8.Split('@');
                                        //rs.writeNV(nv[1], nv[2], tar.LogicFalseOutNV8Value);
                                        string fb = ws.writeNV(nv[1], nv[2], tar.LogicFalseOutNV8Value);
                                    }
                                }

                                //send mail
                                if (tar.LogicFalseOutemail == true)
                                {
                                    //send mail
                                    if (tar.LogicFalseOutemail == true)
                                    {
                                        for (int m = 0; m < memoryData.GroupContact2.Count; m++)
                                        {
                                            ContactGroup2 mg = (ContactGroup2)memoryData.GroupContact2[m];
                                            if (tar.AlarmFalseMailgroup == mg.groupname)
                                            {
                                                using (FileStream input = new FileStream(Application.StartupPath + @"\Resources\SMTP.dat", FileMode.Open))
                                                {   // 讀取整數值
                                                    BinaryReader reader = new BinaryReader(input);
                                                    string data = reader.ReadString();

                                                    int numOfBytes = data.Length / 8;
                                                    byte[] bytes = new byte[numOfBytes];
                                                    for (int ri = 0; ri < numOfBytes; ++ri)
                                                    {
                                                        bytes[ri] = Convert.ToByte(data.Substring(8 * ri, 8), 2);
                                                    }
                                                    //File.WriteAllBytes(fileName, bytes);
                                                    string val = GetString(bytes);
                                                    string[] SpStr = val.Split('$');
                                                    string SMTPhost = SpStr[1];
                                                    string SMTPport = SpStr[2];
                                                    Boolean SSL = Boolean.Parse(SpStr[3]);
                                                    string userName = SpStr[4];
                                                    string userPassword = SpStr[5];

                                                    for (int sg = 0; sg < mg.groupmember.Count; sg++)
                                                    {
                                                        Contactstruct sgm = (Contactstruct)mg.groupmember[sg];
                                                        if (sgm.mail != null & sgm.mail != "")
                                                        {
                                                            string formatForMySqlDate = DateTime.Now.ToString("yyyy-MM-dd");
                                                            string formatForMySqlTime = DateTime.Now.ToString("HH:mm:ss");

                                                            email.From = new MailAddress(userName);  //寄件人
                                                            email.Subject = "alarm inactive!";  //標題
                                                            email.Body = "trigger time = " + formatForMySqlDate + " " + formatForMySqlTime + Environment.NewLine
                                                                         + "trigger value = " + readVal + Environment.NewLine + "descript : " + tar.description
                                                                         + Environment.NewLine + "message : " + tar.LogicFalseOutMSG;  //內容
                                                            email.To.Add(sgm.mail);  //收件人
                                                            SMTP.EnableSsl = true;
                                                            SMTP.Port = int.Parse(SMTPport); //smtp port
                                                            SMTP.Host = SMTPhost;  //smtp host(主機ip)
                                                            SMTP.Credentials = new System.Net.NetworkCredential(userName, userPassword);  //寄件人,密碼
                                                            SMTP.Send(email);
                                                        }

                                                    }
                                                    input.Dispose();
                                                }
                                            }
                                        }
                                    }
                                }
                                //send SMS
                                if (tar.LogicFalseOutSMS == true)
                                {
                                }
                                //log data to SQL
                                if (tar.LogicFalseOutLog == true)
                                {
                                    //save to database
                                    if (memoryData.database.Count != 0)
                                    {
                                        database SQLstr = (database)memoryData.database[0];

                                        //open database
                                        string connStr = "server=" + SQLstr.ip + ";port=" + SQLstr.port + ";uid=" + SQLstr.user + ";pwd=" + SQLstr.password + ";database=" + SQLstr.DBname;
                                        MySqlConnection conn = new MySqlConnection(connStr);
                                        //MySqlCommand command = conn.CreateCommand();
                                        MySqlCommand addList = conn.CreateCommand();
                                        conn.Open();

                                        string sql = @"SELECT * FROM alarm_list WHERE site='" + tar.site + "' and fab='" + tar.fab + "' and area='" + tar.area
                                                           + "' and device='" + tar.device + "' and function='" + tar.function + "' and NVname='" + tar.NV + "' ";

                                        MySqlCommand cmdCHK = new MySqlCommand(sql, conn);
                                        MySqlDataReader dataCHK = cmdCHK.ExecuteReader();
                                        int listid = 0;

                                        string formatForMySqlDate = DateTime.Now.ToString("yyyy-MM-dd");
                                        string formatForMySqlTime = DateTime.Now.ToString("HH:mm:ss");

                                        string alarm_value = "";
                                        string NVvalue_txt = "";
                                        float NVvalue_real = 0;

                                        if (tar.LogicFalseOutLog == true)
                                        {
                                            //get type
                                            string alarmType = "";
                                            if (tar.NVType == "device")
                                            {
                                                alarmType = "device";
                                            }
                                            else
                                            {
                                                alarmType = "tag";
                                            }

                                            if (tar.NVType == "SNVT_occupancy")
                                            {
                                                alarm_value = tar.CompareValue;
                                                NVvalue_txt = moniVal;
                                                NVvalue_real = 0;
                                            }
                                            else if (tar.NVType == "device")  // type = device
                                            {
                                                alarm_value = "online";
                                                NVvalue_txt = "online";
                                                NVvalue_real = 0;
                                            }
                                            else  // type = NV
                                            {
                                                if (moniVal == "" || moniVal == null)
                                                {
                                                    moniVal = "0";
                                                }

                                                if (tar.NVType == "SNVT_switch")
                                                {
                                                    //===========================================================
                                                    //原來的資料取得方式
                                                    //string[] gettar = tar.SourceNVName.Split('@');
                                                    //string[] getnewValue = ws.readNV(gettar[1], gettar[2]).Split('$');
                                                    //System.Threading.Thread.Sleep(10);
                                                    //===========================================================
                                                    string[] getnewValue = getReadAllString.Split('$');
                                                    string[] sppart = getnewValue[0].Split(' ');
                                                    if (tar.NVpart == "value")
                                                    {
                                                        NVvalue_txt = sppart[0];
                                                        NVvalue_real = float.Parse(sppart[0]);
                                                    }
                                                    else if (tar.NVpart == "status")
                                                    {
                                                        NVvalue_txt = sppart[1];
                                                        NVvalue_real = float.Parse(sppart[1]);
                                                    }

                                                    alarm_value = tar.CompareValue;

                                                }
                                                else
                                                {
                                                    alarm_value = tar.CompareValue;
                                                    NVvalue_txt = readVal;
                                                    NVvalue_real = float.Parse(readVal);
                                                }
                                            }


                                            if (dataCHK.HasRows == true)
                                            {
                                                //有查到資料
                                                dataCHK.Read();
                                                listid = int.Parse(dataCHK.GetString(0));
                                                dataCHK.Close();

                                                addList.CommandText = @"update nico_db.alarm_list set description = '" + tar.description + "',message = '"
                                                                       + tar.LogicFalseOutMSG + "' where id = " + listid;
                                                addList.ExecuteNonQuery();

                                                MySqlCommand addValue = conn.CreateCommand();

                                                addValue.CommandText = @"Insert into alarm_value(list_id,NVvalue_txt,NVvalue_real,alarm_event,date,time) values('"
                                                                          + listid + "','" + NVvalue_txt + "','" + NVvalue_real + "','inactive','"
                                                                          + formatForMySqlDate + "','" + formatForMySqlTime + "')";

                                                addValue.ExecuteNonQuery();

                                            }
                                            else
                                            {
                                                dataCHK.Close();
                                                //沒有查到資料


                                                addList.CommandText = @"Insert into alarm_list(site,fab,area,device,function,NVname,NVtype,alarm_setting,alarm_type,"
                                                                      + "alarm_value,message,description,ip) values('" + tar.site + "','" + tar.fab + "','" + tar.area
                                                                      + "','" + tar.device + "','" + tar.function + "','" + tar.NV + "','" + tar.NVType
                                                                      + "','" + tar.CompareLogic + "','" + alarmType + "','" + alarm_value + "','" + tar.LogicFalseOutMSG
                                                                      + "','" + tar.description + "','" + tar.SourceIP + "')";

                                                addList.ExecuteNonQuery();

                                                //get list_id
                                                dataCHK = cmdCHK.ExecuteReader();
                                                dataCHK.Read();
                                                if (dataCHK.HasRows == true)
                                                {
                                                    listid = int.Parse(dataCHK.GetString(0));
                                                    dataCHK.Close();
                                                }

                                                //write to output_value
                                                MySqlCommand addValue = conn.CreateCommand();

                                                addValue.CommandText = @"Insert into alarm_value(list_id,NVvalue_txt,NVvalue_real,alarm_event,date,time) values('"
                                                                          + listid + "','" + NVvalue_txt + "','" + NVvalue_real + "','inactive','"
                                                                          + formatForMySqlDate + "','" + formatForMySqlTime + "')";

                                                addValue.ExecuteNonQuery();

                                            }

                                            conn.Close();
                                            // old  /////////////////↑↑↑↑↑↑↑↑↑↑↑↑

                                        }
                                    }

                                }

                            }
                            tar.sampleRatecount = 0;
                            memoryData.AlarmData[i] = tar;

                            if (tar.userFalseValue == true)
                            {

                                //use value
                                //要顯示的文字
                                string s = ""; //moniVal;  // "show alarm value";
                                string[] spSTR = valueFB.Split('$');
                                if (tar.NVType == "SNVT_switch")
                                {
                                    string[] NV = spSTR[0].Split(' ');
                                    if (tar.NVpart == "value")
                                    {
                                        s = NV[0];
                                    }
                                    else if (tar.NVpart == "status")
                                    {
                                        s = NV[1];
                                    }
                                }
                                else if (tar.NVType == "device")
                                {
                                    if (moniVal == "AL_NO_CONDITION")
                                    {
                                        s = "online";
                                    }
                                    else
                                    {
                                        s = "offline";
                                    }
                                }
                                else //if (tar.NVtype == "SNVT_occupancy")
                                {
                                    if (spSTR[0] == "")
                                    {
                                        s = "null";
                                    }
                                    else
                                    {
                                        s = spSTR[0];
                                    }

                                }


                                //先建立底圖預測文字大小使用
                                Bitmap canvas = new Bitmap(40, 28);
                                //建立繪圖物件
                                Graphics g = Graphics.FromImage(canvas);

                                // 设置字体的样式

                                Font f = new Font("Arial", 12);  //tar.LogicTrueOutFont; //new Font("新細明體", 12);

                                //計算文字大小
                                SizeF stringSize = g.MeasureString(s, tar.LogicFalseOutFont, 1000);
                                //SizeF stringSize = g.MeasureString(s, f, 1000);
                                g.Dispose();
                                int setX = Convert.ToInt32(stringSize.Width);
                                int setY = Convert.ToInt32(stringSize.Height);
                                //canvas.Dispose();
                                //g.Dispose();
                                Bitmap canvasShow = new Bitmap(setX, setY);
                                Graphics show = Graphics.FromImage(canvasShow);

                                // 实例化一个实心画刷，颜色是红色
                                SolidBrush brush = new SolidBrush(Color.FromArgb(tar.LogicFalseforecolor)); //new SolidBrush(Color.Red);
                                                                                                            // 与左上角坐标的距离
                                PointF point = new PointF(0, 0);
                                // 开始绘制
                                show.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                                show.DrawString(s, f, brush, point);
                                //f.Dispose();
                                //show.Dispose();
                                tarIMG.Image = canvasShow;
                                tarIMG.SizeMode = PictureBoxSizeMode.AutoSize;

                                f.Dispose();
                                show.Dispose();

                            }

                        }



                    }
                }
                // GC.Collect();
            }
            catch (Exception ex)
            {
                //throw;
            }
            finally
            {

            }

        }

        //↓↓↓↓↓↓↓↓↓↓ string to binary using  ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }

        //Formats a byte[] into a binary string (010010010010100101010)
        public string Format(byte[] data)
        {
            //storage for the resulting string
            string result = string.Empty;
            //iterate through the byte[]
            foreach (byte value in data)
            {
                //storage for the individual byte
                string binarybyte = Convert.ToString(value, 2);
                //if the binarybyte is not 8 characters long, its not a proper result
                while (binarybyte.Length < 8)
                {
                    //prepend the value with a 0
                    binarybyte = "0" + binarybyte;
                }
                //append the binarybyte to the result
                result += binarybyte;
            }
            //return the result
            return result;
        }
        //↑↑↑↑↑↑↑↑↑↑ string to binary using  ↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

        private void Alarm_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void emailTool_Click(object sender, EventArgs e)
        {
            option_mail Le = new option_mail();
            Le.Show();
        }

        private void emailManaganeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            option_contact Le = new option_contact();
            Le.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            timeStr = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
            Mainstatus.Items[StatusTime.Name].Text = timeStr;

            

            if (activeMode.Text == "Running") { activeMode.Text = "Running ▷"; }
            else if (activeMode.Text == "Running ▷") { activeMode.Text = "Running ▷▷"; }  //▷▶➵✈ ➻ ➼♞∼✈ ∽☁☼
            else if (activeMode.Text == "Running ▷▷") { activeMode.Text = "Running ▷▷▷"; }
            else if (activeMode.Text == "Running ▷▷▷") { activeMode.Text = "Running ▷▷▷▷"; }
            else if (activeMode.Text == "Running ▷▷▷▷") { activeMode.Text = "Running ▷▷▷▷▷"; }
            else if (activeMode.Text == "Running ▷▷▷▷▷") { activeMode.Text = "Running"; }

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            
            if(memoryData.errorIp.Count !=0)
            {
                IntPtr ptr = FindWindow(null, "offline smartserver");
                if (ptr == IntPtr.Zero)
                {
                    errorIP showIP = new errorIP();
                    showIP.Show();
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // alarm monitor
                if (memoryData.AlarmData.Count > 0)  // read alarm info
                {
                    //SmartServer.SOAP rs = new SmartServer.SOAP();
                    SOAP20_DLL.SOAP ws = new SOAP20_DLL.SOAP();
                    string moniVal = "";
                    string states = "";
                    string valueFB = "";
                    string readVal = "";
                    string getReadAllString = "";
                    

                    //Boolean createAlarm = false;
                    for (int i = 0; i < memoryData.AlarmData.Count; i++)
                    {
                        AlarmObjectstruct tar = (AlarmObjectstruct)memoryData.AlarmData[i];
                        PictureBox tarIMG = (PictureBox)this.pictureBox1.Controls[tar.name];
                        //get alarm monitor NV value
                        for (int n = 0; n < memoryData.AlarmMonitorValue.Count; n++)
                        {
                            AlarmMoniTorNV gv = (AlarmMoniTorNV)memoryData.AlarmMonitorValue[n];
                            if (gv.name == tar.name)
                            {
                                moniVal = gv.NVvalue;
                                states = gv.states;
                                valueFB = gv.NVvalue + "$" + gv.states + "$" + gv.NVtype + "$" + gv.preset;
                                getReadAllString = gv.NVvalue + "$" + gv.states + "$" + gv.NVtype + "$" + gv.preset;
                                break;
                            }
                        }

                        //compare value
                        if (tar.NVType == "device") //check Device status (online || offline)
                        {
                            //for (int RAcount= 0;RAcount < memoryData.ReadAllNV.Count;RAcount ++)
                            //{
                            //    ReadNVvaluestruct tag = (ReadNVvaluestruct)memoryData.ReadAllNV[RAcount];
                            //    string[] tarNV = tar.SourceNVName.Split('@');

                            //    if (tag.device == tar.device && tag.IP == tar.SourceIP)
                            //    {
                            //        valueFB = tag.Value + "$" + tag.status + "$" + tag.NVtype + "$" + tag.preset;
                            //        getReadAllString = tag.Value + "$" + tag.status + "$" + tag.NVtype + "$" + tag.preset;
                            //        break;
                            //    }
                            //}

                            //ReadNVvaluestruct

                            //===========================================================
                            //原來的資料取得方式
                            //string[] tarNV = tar.SourceNVName.Split('@');
                            //valueFB = ws.readNV(tar.SourceIP, tarNV[2] + "/NodeObject/nviRequest");
                            //System.Threading.Thread.Sleep(10);
                            //===========================================================


                            string[] rq = valueFB.Split('$');

                            if (moniVal == "AL_OFFLINE") // device offline  if (rq[1] == "AL_OFFLINE") // device offline
                            {
                                //ALARM 成立
                                tar.AlarmStatus = true;
                            }
                            else if (moniVal == "AL_NO_CONDITION") // device online
                            {
                                tar.AlarmStatus = false;
                                tar.timeOvercount = 0;
                            }
                            else if (moniVal == "")
                            {
                                moniVal = "AL_NO_CONDITION";
                                tar.AlarmStatus = false;
                                tar.timeOvercount = 0;
                            }
                        }
                        else  //check NV value
                        {
                            if (tar.CompareType == "value") //compare value
                            {
                                
                                //for (int RAcount = 0 ; RAcount < memoryData.ReadAllNV.Count; RAcount++)
                                //{
                                //        break;
                                //    ReadNVvaluestruct tag = (ReadNVvaluestruct)memoryData.ReadAllNV[RAcount];
                                //    if (tag.device == tar.device && tag.function == tar.function && tag.NV == tar.NV && tag.IP == tar.SourceIP)
                                //    {
                                //        valueFB = tag.Value + "$" + tag.status + "$" + tag.NVtype + "$" + tag.preset;
                                //        getReadAllString = tag.Value + "$" + tag.status + "$" + tag.NVtype + "$" + tag.preset;
                                //    }
                                //}

                                //===========================================================
                                //原來的資料取得方式
                                //string[] nvpath = tar.SourceNVName.Split('@');
                                //valueFB = ws.readNV(tar.SourceIP, nvpath[2]);  // get source NV value
                                //System.Threading.Thread.Sleep(10);
                                //===========================================================

                                if (valueFB != null)
                                {
                                    string[] rq = valueFB.Split('$');
                                    string[] reval = rq[0].Split(' ');
                                    if (tar.NVType == "SNVT_occupancy") // || tar.NVType == "SNVT_switch")
                                    {
                                        //string sourceNVval = reval[0];
                                        string sourceNVval = reval[0];
                                        readVal = reval[0];
                                        switch (tar.CompareLogic)
                                        {
                                            case "==":
                                                if (sourceNVval == tar.CompareValue)
                                                {
                                                    tar.AlarmStatus = true;
                                                }
                                                else
                                                {
                                                    tar.AlarmStatus = false;
                                                    tar.timeOvercount = 0;
                                                }
                                                break;
                                            case "!=":
                                                if (sourceNVval != tar.CompareValue)
                                                {
                                                    tar.AlarmStatus = true;
                                                }
                                                else
                                                {
                                                    tar.AlarmStatus = false;
                                                    tar.timeOvercount = 0;
                                                }
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        float sourceNVval = 0;
                                        float settingNalue = 0;
                                        readVal = reval[0];
                                        if (tar.NVType == "SNVT_switch")
                                        {
                                            if (tar.NVpart == "value")
                                            {
                                                sourceNVval = float.Parse(reval[0]);
                                            }
                                            else if (tar.NVpart == "status")
                                            {
                                                sourceNVval = float.Parse(reval[1]);
                                            }

                                        }
                                        else
                                        {
                                            sourceNVval = float.Parse(reval[0]);
                                        }

                                        settingNalue = float.Parse(tar.CompareValue);

                                        switch (tar.CompareLogic)
                                        {
                                            case "<":
                                                if (sourceNVval < settingNalue)
                                                { tar.AlarmStatus = true; }
                                                else
                                                {
                                                    tar.AlarmStatus = false;
                                                    tar.timeOvercount = 0;
                                                }
                                                break;
                                            case "<=":
                                                if (sourceNVval <= settingNalue)
                                                { tar.AlarmStatus = true; }
                                                else
                                                {
                                                    tar.AlarmStatus = false;
                                                    tar.timeOvercount = 0;
                                                }
                                                break;
                                            case "==":
                                                if (sourceNVval == settingNalue)
                                                { tar.AlarmStatus = true; }
                                                else
                                                {
                                                    tar.AlarmStatus = false;
                                                    tar.timeOvercount = 0;
                                                }
                                                break;
                                            case "!=":
                                                if (sourceNVval != settingNalue)
                                                { tar.AlarmStatus = true; }
                                                else
                                                {
                                                    tar.AlarmStatus = false;
                                                    tar.timeOvercount = 0;
                                                }
                                                break;
                                            case ">=":
                                                if (sourceNVval >= settingNalue)
                                                { tar.AlarmStatus = true; }
                                                else
                                                {
                                                    tar.AlarmStatus = false;
                                                    tar.timeOvercount = 0;
                                                }
                                                break;
                                            case ">":
                                                if (sourceNVval > settingNalue)
                                                { tar.AlarmStatus = true; }
                                                else
                                                {
                                                    tar.AlarmStatus = false;
                                                    tar.timeOvercount = 0;
                                                }
                                                break;
                                            case "~":
                                                if (sourceNVval >= (float)tar.CompareMin && (float)sourceNVval <= tar.CompareMax)
                                                { tar.AlarmStatus = true; }
                                                else
                                                {
                                                    tar.AlarmStatus = false;
                                                    tar.timeOvercount = 0;
                                                }
                                                break;
                                        }
                                    }
                                }
                            }
                            else if (tar.CompareType == "tag")   //compare another nv
                            {
                                //for (int RAcount = 0; RAcount < memoryData.ReadAllNV.Count; RAcount++)
                                //{
                                //    ReadNVvaluestruct tag = (ReadNVvaluestruct)memoryData.ReadAllNV[RAcount];
                                //    if (tag.device == tar.device && tag.function == tar.function && tag.NV == tar.NV && tag.IP == tar.SourceIP)
                                //    {
                                //        valueFB = tag.Value + "$" + tag.status + "$" + tag.NVtype + "$" + tag.preset;
                                //        getReadAllString = tag.Value + "$" + tag.status + "$" + tag.NVtype + "$" + tag.preset;
                                //        break;
                                //    }
                                //}

                                //===========================================================
                                //原來的資料取得方式
                                //string[] nvpath = tar.SourceNVName.Split('@');
                                //valueFB = ws.readNV(tar.SourceIP, nvpath[2]);  // get source NV value
                                //System.Threading.Thread.Sleep(10);
                                //===========================================================
                                
                                string[] tarNV = tar.TargetNVName.Split('@');
                                string[] getTemp = tarNV[2].Split('/');

                                string compareIP = tarNV[1];
                                string compareDevice = getTemp[2];
                                string compareFunction = getTemp[3];
                                string compareNV = getTemp[4];
                                                                

                                if (valueFB != null)
                                {
                                    
                                    if (tar.NVType == "SNVT_occupancy") // || tar.NVType == "SNVT_switch")
                                    {
                                        string temp2 = "";
                                        for (int item = 0; item <  memoryData.ReadAllNV.Count; item ++)
                                        {
                                            ReadNVvaluestruct tag = (ReadNVvaluestruct)memoryData.ReadAllNV[item];
                                            if (tag.device == compareDevice && tag.function == compareFunction && tag.NV == compareNV && tag.IP == compareIP)
                                            {
                                                temp2 = tag.Value + "$" + tag.status + "$" + tag.NVtype + "$" + tag.preset;
                                                break;
                                            }
                                        }

                                        //===========================================================
                                        //原來的資料取得方式
                                        //string temp2 = ws.readNV(tar.TargetIP, tarNV[2]);  // get target NV value
                                        //System.Threading.Thread.Sleep(10);
                                        //===========================================================

                                        string[] sVal = valueFB.Split('$');
                                        string[] tVal = temp2.Split('$');
                                        string[] ssval = sVal[0].Split(' ');
                                        string[] ttval = tVal[0].Split(' ');
                                        string sourceGet = ssval[0];
                                        string targetGet = ttval[0];

                                        switch (tar.CompareLogic)
                                        {

                                            case "==":
                                                if (sourceGet == targetGet)
                                                { tar.AlarmStatus = true; }
                                                else
                                                {
                                                    tar.AlarmStatus = false;
                                                    tar.timeOvercount = 0;
                                                }
                                                break;
                                            case "!=":
                                                if (sourceGet != targetGet)
                                                { tar.AlarmStatus = true; }
                                                else
                                                {
                                                    tar.AlarmStatus = false;
                                                    tar.timeOvercount = 0;
                                                }
                                                break;

                                        }
                                    }
                                    else   //other type
                                    {
                                        string temp2 = "";
                                        for (int item = 0; item  < memoryData.ReadAllNV.Count; item++)
                                        {
                                            ReadNVvaluestruct tag = (ReadNVvaluestruct)memoryData.ReadAllNV[item];
                                            if (tag.device == compareDevice && tag.function == compareFunction && tag.NV == compareNV && tag.IP == compareIP)
                                            {
                                                temp2 = tag.Value + "$" + tag.status + "$" + tag.NVtype + "$" + tag.preset;
                                                break;
                                            }
                                        }

                                        //===========================================================
                                        //原來的資料取得方式
                                        //string temp2 = ws.readNV(tar.TargetIP, tarNV[2]);  // get target NV value
                                        //System.Threading.Thread.Sleep(10);
                                        //===========================================================

                                        string[] sVal = valueFB.Split('$');
                                        string[] tVal = temp2.Split('$');
                                        string[] ssval = sVal[0].Split(' ');
                                        string[] ttval = tVal[0].Split(' ');

                                        float sourceGet = 0; // =float.Parse(ssval[0]);
                                        float targetGet = 0; // =float.Parse(ttval[0]);

                                        if (tar.NVType == "SNVT_switch")
                                        {
                                            if (tar.NVpart == "value")
                                            {
                                                sourceGet = float.Parse(ssval[0]);
                                                targetGet = float.Parse(ttval[0]);
                                            }
                                            else if (tar.NVpart == "status")
                                            {
                                                sourceGet = float.Parse(ssval[1]);
                                                targetGet = float.Parse(ttval[1]);
                                            }

                                        }
                                        else
                                        {
                                            sourceGet = float.Parse(ssval[0]);
                                            targetGet = float.Parse(ttval[0]);
                                        }



                                        switch (tar.CompareLogic)
                                        {
                                            case "<":
                                                if (sourceGet < targetGet)
                                                { tar.AlarmStatus = true; }
                                                else
                                                {
                                                    tar.AlarmStatus = false;
                                                    tar.timeOvercount = 0;
                                                }
                                                break;
                                            case "<=":
                                                if (sourceGet <= targetGet)
                                                { tar.AlarmStatus = true; }
                                                else
                                                {
                                                    tar.AlarmStatus = false;
                                                    tar.timeOvercount = 0;
                                                }
                                                break;
                                            case "==":
                                                if (sourceGet == targetGet)
                                                { tar.AlarmStatus = true; }
                                                else
                                                {
                                                    tar.AlarmStatus = false;
                                                    tar.timeOvercount = 0;
                                                }
                                                break;
                                            case "!=":
                                                if (sourceGet != targetGet)
                                                { tar.AlarmStatus = true; }
                                                else
                                                {
                                                    tar.AlarmStatus = false;
                                                    tar.timeOvercount = 0;
                                                }
                                                break;
                                            case ">=":
                                                if (sourceGet >= targetGet)
                                                { tar.AlarmStatus = true; }
                                                else
                                                {
                                                    tar.AlarmStatus = false;
                                                    tar.timeOvercount = 0;
                                                }
                                                break;
                                            case ">":
                                                if (sourceGet > targetGet)
                                                { tar.AlarmStatus = true; }
                                                else
                                                {
                                                    tar.AlarmStatus = false;
                                                    tar.timeOvercount = 0;
                                                }
                                                break;
                                        }
                                    }


                                }

                            }

                        } // 資料比對結束

                        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //alarm action
                        if (tar.AlarmStatus == true) // alarm 條件達成
                        {
                            if (tar.timeOver == tar.timeOvercount) //時間到.執行動作
                            {
                                //alarm發生時執行一次
                                //tar.LogicTrueOutImagePath (第一次發生時執行)
                                if (tar.AlarmTrueRun == true)
                                {
                                    tar.AlarmStatus = true;
                                    alarmPlay = true;
                                    if (tar.LogicTrueOutImagePath != "")
                                    {
                                        //showValue or image
                                        if (tar.userTrueValue == true)
                                        {

                                        }
                                        else
                                        {
                                            //use image
                                            if (tarIMG != null)
                                            {
                                                if (System.IO.File.Exists(tar.LogicTrueOutImagePath))
                                                {
                                                    //find
                                                    FileStream fs = File.OpenRead(tar.LogicTrueOutImagePath);
                                                    tarIMG.Image = Image.FromStream(fs);
                                                    //fs.Close();
                                                }
                                                else
                                                {
                                                    //not found
                                                }

                                                tarIMG.Size = new Size(tar.LogicTrueWidth, tar.LogicTrueHeight);
                                                tarIMG.SizeMode = PictureBoxSizeMode.StretchImage;
                                            }
                                        }

                                    }

                                    if (tar.LogicTrueAudioUse == true && tar.LogicTrueAudioPath != "")
                                    {
                                        AlarmAudiostruct add = new AlarmAudiostruct();
                                        add.name = tar.name;
                                        add.path = tar.LogicTrueAudioPath;
                                        memoryData.AlarmAudioTrue.Add(add);
                                    }

                                    tar.AlarmTrueRun = false;

                                    //output nv
                                    if (tar.LogicTrueOutNV == true)
                                    {
                                        if (tar.LogicTrueOutNV1 != "")  //output nv1
                                        {
                                            string[] nv = tar.LogicTrueOutNV1.Split('@');
                                            //rs.writeNV(nv[1], nv[2], tar.LogicTrueOutNV1Value);
                                            string fb = ws.writeNV(nv[1], nv[2], tar.LogicTrueOutNV1Value);
                                        }

                                        if (tar.LogicTrueOutNV2 != "")  //output nv2
                                        {
                                            string[] nv = tar.LogicTrueOutNV2.Split('@');
                                            //rs.writeNV(nv[1], nv[2], tar.LogicTrueOutNV2Value);
                                            string fb = ws.writeNV(nv[1], nv[2], tar.LogicTrueOutNV2Value);
                                        }

                                        if (tar.LogicTrueOutNV3 != "")  //output nv3
                                        {
                                            string[] nv = tar.LogicTrueOutNV3.Split('@');
                                            //rs.writeNV(nv[1], nv[2], tar.LogicTrueOutNV3Value);
                                            string fb = ws.writeNV(nv[1], nv[2], tar.LogicTrueOutNV3Value);
                                        }

                                        if (tar.LogicTrueOutNV4 != "")  //output nv4
                                        {
                                            string[] nv = tar.LogicTrueOutNV4.Split('@');
                                            //rs.writeNV(nv[1], nv[2], tar.LogicTrueOutNV4Value);
                                            string fb = ws.writeNV(nv[1], nv[2], tar.LogicTrueOutNV4Value);
                                        }

                                        if (tar.LogicTrueOutNV5 != "")  //output nv5
                                        {
                                            string[] nv = tar.LogicTrueOutNV5.Split('@');
                                            //rs.writeNV(nv[1], nv[2], tar.LogicTrueOutNV5Value);
                                            string fb = ws.writeNV(nv[1], nv[2], tar.LogicTrueOutNV5Value);
                                        }

                                        if (tar.LogicTrueOutNV6 != "")  //output nv6
                                        {
                                            string[] nv = tar.LogicTrueOutNV6.Split('@');
                                            //rs.writeNV(nv[1], nv[2], tar.LogicTrueOutNV6Value);
                                            string fb = ws.writeNV(nv[1], nv[2], tar.LogicTrueOutNV6Value);
                                        }

                                        if (tar.LogicTrueOutNV7 != "")  //output nv7
                                        {
                                            string[] nv = tar.LogicTrueOutNV7.Split('@');
                                            //rs.writeNV(nv[1], nv[2], tar.LogicTrueOutNV7Value);
                                            string fb = ws.writeNV(nv[1], nv[2], tar.LogicTrueOutNV7Value);
                                        }

                                        if (tar.LogicTrueOutNV8 != "")  //output nv8
                                        {
                                            string[] nv = tar.LogicTrueOutNV8.Split('@');
                                            //rs.writeNV(nv[1], nv[2], tar.LogicTrueOutNV8Value);
                                            string fb = ws.writeNV(nv[1], nv[2], tar.LogicTrueOutNV8Value);
                                        }
                                    }

                                    //send mail
                                    if (tar.LogicTrueOutemail == true)
                                    {
                                        for (int m = 0; m < memoryData.GroupContact2.Count; m++)
                                        {
                                            ContactGroup2 mg = (ContactGroup2)memoryData.GroupContact2[m];
                                            if (tar.AlarmTrueMailgroup == mg.groupname)
                                            {
                                                using (FileStream input = new FileStream(Application.StartupPath + @"\Resources\SMTP.dat", FileMode.Open))
                                                {   // 讀取整數值
                                                    BinaryReader reader = new BinaryReader(input);
                                                    string data = reader.ReadString();
                                                    reader.Dispose();
                                                    int numOfBytes = data.Length / 8;
                                                    byte[] bytes = new byte[numOfBytes];
                                                    for (int ri = 0; ri < numOfBytes; ++ri)
                                                    {
                                                        bytes[ri] = Convert.ToByte(data.Substring(8 * ri, 8), 2);
                                                    }
                                                    //File.WriteAllBytes(fileName, bytes);
                                                    string val = GetString(bytes);
                                                    string[] SpStr = val.Split('$');
                                                    string SMTPhost = SpStr[1];
                                                    string SMTPport = SpStr[2];
                                                    Boolean SSL = Boolean.Parse(SpStr[3]);
                                                    string userName = SpStr[4];
                                                    string userPassword = SpStr[5];

                                                    for (int sg = 0; sg < mg.groupmember.Count; sg++)
                                                    {
                                                        Contactstruct sgm = (Contactstruct)mg.groupmember[sg];

                                                        if (sgm.mail != null && sgm.mail != null)
                                                        {
                                                            string formatForMySqlDate = DateTime.Now.ToString("yyyy-MM-dd");
                                                            string formatForMySqlTime = DateTime.Now.ToString("HH:mm:ss");

                                                            email.From = new MailAddress(userName);  //寄件人
                                                            email.Subject = "alarm active!";  //標題
                                                            email.Body = "trigger time = " + formatForMySqlDate + " " + formatForMySqlTime + Environment.NewLine
                                                                         + "trigger value = " + readVal + Environment.NewLine + "descript : " + tar.description
                                                                         + Environment.NewLine + "message : " + tar.LogicTrueOutMSG;  //內容
                                                            email.To.Add(sgm.mail);  //收件人
                                                            SMTP.EnableSsl = true;
                                                            SMTP.Port = int.Parse(SMTPport); //smtp port
                                                            SMTP.Host = SMTPhost;  //smtp host(主機ip)
                                                            SMTP.Credentials = new System.Net.NetworkCredential(userName, userPassword);  //寄件人,密碼
                                                            SMTP.Send(email);
                                                        }

                                                    }
                                                    input.Dispose();
                                                }
                                            }
                                        }
                                    }
                                    //send SMS
                                    if (tar.LogicTrueOutSMS == true)
                                    {
                                    }
                                    //log data to SQL
                                    if (tar.LogicTrueOutLog == true)
                                    {
                                        //save to database
                                        if (memoryData.database.Count != 0)
                                        {
                                            database SQLstr = (database)memoryData.database[0];

                                            //open database
                                            string connStr = "server=" + SQLstr.ip + ";port=" + SQLstr.port + ";uid=" + SQLstr.user + ";pwd=" + SQLstr.password + ";database=" + SQLstr.DBname;
                                            MySqlConnection conn = new MySqlConnection(connStr);
                                            //MySqlCommand command = conn.CreateCommand();
                                            MySqlCommand addList = conn.CreateCommand();
                                            conn.Open();

                                            string sql = @"SELECT * FROM alarm_list WHERE site='" + tar.site + "' and fab='" + tar.fab + "' and area='" + tar.area
                                                               + "' and device='" + tar.device + "' and function='" + tar.function + "' and NVname='" + tar.NV + "' ";

                                            MySqlCommand cmdCHK = new MySqlCommand(sql, conn);
                                            MySqlDataReader dataCHK = cmdCHK.ExecuteReader();
                                            int listid = 0;

                                            string formatForMySqlDate = DateTime.Now.ToString("yyyy-MM-dd");
                                            string formatForMySqlTime = DateTime.Now.ToString("HH:mm:ss");

                                            string alarm_value = "";
                                            string NVvalue_txt = "";
                                            float NVvalue_real = 0;

                                            if (tar.LogicTrueOutLog == true)
                                            {
                                                //get type
                                                string alarmType = "";
                                                if (tar.NVType == "device")
                                                {
                                                    alarmType = "device";
                                                }
                                                else
                                                {
                                                    alarmType = "tag";
                                                }

                                                if (tar.NVType == "SNVT_occupancy")
                                                {
                                                    alarm_value = tar.CompareValue;
                                                    NVvalue_txt = readVal;
                                                    NVvalue_real = 0;
                                                }
                                                else if (tar.NVType == "device")  // type = device
                                                {
                                                    alarm_value = "offline";
                                                    NVvalue_txt = "offline";
                                                    NVvalue_real = 0;
                                                }
                                                else  // type = NV
                                                {
                                                    if (moniVal == "" || moniVal == null)
                                                    {
                                                        moniVal = "0";
                                                    }

                                                    if (tar.NVType == "SNVT_switch" || tar.NVtype == "SNVT_occupancy")
                                                    {
                                                        //===========================================================
                                                        //原來的資料取得方式
                                                        //string[] gettar = tar.SourceNVName.Split('@');
                                                        //string[] getnewValue = ws.readNV(gettar[1], gettar[2]).Split('$');
                                                        //System.Threading.Thread.Sleep(10);
                                                        //===========================================================

                                                        string[] getnewValue = getReadAllString.Split('$');
                                                        
                                                        string[] sppart = getnewValue[0].Split(' ');
                                                        if (tar.NVpart == "value")
                                                        {
                                                            NVvalue_txt = sppart[0];
                                                            NVvalue_real = float.Parse(sppart[0]);
                                                        }
                                                        else if (tar.NVpart == "status")
                                                        {
                                                            NVvalue_txt = sppart[1];
                                                            NVvalue_real = float.Parse(sppart[1]);
                                                        }

                                                        alarm_value = tar.CompareValue;

                                                    }
                                                    else
                                                    {
                                                        alarm_value = tar.CompareValue;
                                                        NVvalue_txt = readVal;
                                                        NVvalue_real = float.Parse(readVal);
                                                    }
                                                }


                                                if (dataCHK.HasRows == true)
                                                {
                                                    //有查到資料
                                                    dataCHK.Read();
                                                    listid = int.Parse(dataCHK.GetString(0));
                                                    dataCHK.Close();

                                                    addList.CommandText = @"update nico_db.alarm_list set description = '" + tar.description + "',message = '"
                                                                           + tar.LogicTrueOutMSG + "' where id = " + listid;
                                                    addList.ExecuteNonQuery();

                                                    MySqlCommand addValue = conn.CreateCommand();

                                                    addValue.CommandText = @"Insert into alarm_value(list_id,NVvalue_txt,NVvalue_real,alarm_event,date,time) values('"
                                                                              + listid + "','" + NVvalue_txt + "','" + NVvalue_real + "','active','"
                                                                              + formatForMySqlDate + "','" + formatForMySqlTime + "')";

                                                    addValue.ExecuteNonQuery();

                                                }
                                                else
                                                {
                                                    dataCHK.Close();
                                                    //沒有查到資料


                                                    addList.CommandText = @"Insert into alarm_list(site,fab,area,device,function,NVname,NVtype,alarm_setting,alarm_type,"
                                                                          + "alarm_value,message,description,ip) values('" + tar.site + "','" + tar.fab + "','" + tar.area
                                                                          + "','" + tar.device + "','" + tar.function + "','" + tar.NV + "','" + tar.NVType
                                                                          + "','" + tar.CompareLogic + "','" + alarmType + "','" + alarm_value + "','" + tar.LogicTrueOutMSG
                                                                          + "','" + tar.description + "','" + tar.SourceIP + "')";

                                                    addList.ExecuteNonQuery();

                                                    //get list_id
                                                    dataCHK = cmdCHK.ExecuteReader();
                                                    dataCHK.Read();
                                                    if (dataCHK.HasRows == true)
                                                    {
                                                        listid = int.Parse(dataCHK.GetString(0));
                                                        dataCHK.Close();
                                                    }

                                                    //write to output_value
                                                    MySqlCommand addValue = conn.CreateCommand();

                                                    addValue.CommandText = @"Insert into alarm_value(list_id,NVvalue_txt,NVvalue_real,alarm_event,date,time) values('"
                                                                              + listid + "','" + NVvalue_txt + "','" + NVvalue_real + "','active','"
                                                                              + formatForMySqlDate + "','" + formatForMySqlTime + "')";

                                                    addValue.ExecuteNonQuery();

                                                }

                                                conn.Close();
                                                // old  /////////////////↑↑↑↑↑↑↑↑↑↑↑↑

                                            }
                                        }
                                    }

                                }

                                //時間到持續更新SHOW VALUE(ALARM已發生仍要繼續更新畫面)
                                if (tar.userTrueValue == true)
                                {

                                    //use value
                                    //要顯示的文字
                                    string s = ""; //moniVal;  // "show alarm value";
                                    string[] spSTR = valueFB.Split('$');
                                    if (tar.NVType == "SNVT_switch")
                                    {
                                        string[] NV = spSTR[0].Split(' ');
                                        if (tar.NVpart == "value")
                                        {
                                            s = NV[0];
                                        }
                                        else if (tar.NVpart == "status")
                                        {
                                            s = NV[1];
                                        }
                                    }
                                    else if (tar.NVType == "device")
                                    {
                                        if (moniVal == "AL_NO_CONDITION")
                                        {
                                            s = "online";
                                        }
                                        else
                                        {
                                            s = "offline";
                                        }
                                    }
                                    else //if (tar.NVtype == "SNVT_occupancy")
                                    {
                                        if (spSTR[0] == "")
                                        {
                                            s = "null";
                                        }
                                        else
                                        {
                                            s = spSTR[0];
                                        }

                                    }


                                    //先建立底圖預測文字大小使用
                                    Bitmap canvas = new Bitmap(40, 28);
                                    //建立繪圖物件
                                    Graphics g = Graphics.FromImage(canvas);


                                    // 设置字体的样式

                                    Font f = new Font("Arial", 12);  //tar.LogicTrueOutFont; //new Font("新細明體", 12);

                                    //計算文字大小
                                    SizeF stringSize = g.MeasureString(s, tar.LogicTrueOutFont, 1000);
                                    //SizeF stringSize = g.MeasureString(s, f, 1000);
                                    g.Dispose();
                                    int setX = Convert.ToInt32(stringSize.Width);
                                    int setY = Convert.ToInt32(stringSize.Height);
                                    //canvas.Dispose();
                                    //g.Dispose();
                                    Bitmap canvasShow = new Bitmap(setX, setY);
                                    Graphics show = Graphics.FromImage(canvasShow);

                                    // 实例化一个实心画刷，颜色是红色
                                    SolidBrush brush = new SolidBrush(Color.FromArgb(tar.LogicTrueforecolor)); //new SolidBrush(Color.Red);
                                                                                                               // 与左上角坐标的距离
                                    PointF point = new PointF(0, 0);
                                    // 开始绘制
                                    show.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                                    show.DrawString(s, f, brush, point);
                                    //f.Dispose();
                                    //show.Dispose();
                                    tarIMG.Image = canvasShow;
                                    tarIMG.SizeMode = PictureBoxSizeMode.AutoSize;

                                    f.Dispose();
                                    show.Dispose();

                                }


                                tar.AlarmFalseRun = true;
                                tar.timeOvercount = 0;
                                memoryData.AlarmData[i] = tar;


                            }
                            else //count ++
                            {
                                tar.timeOvercount += 1;
                                memoryData.AlarmData[i] = tar;

                            }
                        }
                        else if (tar.AlarmStatus == false) // alarm 條件未達成
                        {
                            //alarm解除時第一次執行的動作
                            if (tar.AlarmFalseRun == true) // (第一次發生時執行)
                            {
                                tar.AlarmStatus = false;
                                alarmPlay = true;

                                if (tar.userFalseValue == true)
                                {

                                }
                                else
                                {
                                    if (tarIMG != null)
                                    {
                                        if (System.IO.File.Exists(tar.LogicFalseOutImagePath))
                                        {
                                            //find
                                            FileStream fs = File.OpenRead(tar.LogicFalseOutImagePath);
                                            tarIMG.Image = Image.FromStream(fs);
                                            //fs.Close();
                                        }
                                        else
                                        {
                                            //not found
                                        }


                                        tarIMG.Size = new Size(tar.LogicFalseWidth, tar.LogicFalseHeight);
                                        tarIMG.SizeMode = PictureBoxSizeMode.StretchImage;
                                    }
                                }

                                tar.AlarmFalseRun = false;
                                tar.AlarmTrueRun = true;

                                int position = -1;
                                AlarmAudiostruct scan = new AlarmAudiostruct();
                                scan.name = tar.name;
                                scan.path = tar.LogicTrueAudioPath;
                                position = memoryData.AlarmAudioTrue.IndexOf(scan);
                                if (position != -1)
                                {
                                    memoryData.AlarmAudioTrue.RemoveAt(position);
                                }

                                if (tar.LogicFalseAudioUse == true)
                                {
                                    if (tar.LogicFalseAudioPath != "")
                                    {
                                        AlarmAudiostruct add = new AlarmAudiostruct();
                                        add.name = tar.name;
                                        add.path = tar.LogicFalseAudioPath;
                                        memoryData.AlarmAudioFalse.Add(add);


                                    }
                                }

                                //output nv
                                if (tar.LogicFalseOutNV == true)
                                {
                                    if (tar.LogicFalseOutNV1 != "")  // output nv1
                                    {
                                        string[] nv = tar.LogicFalseOutNV1.Split('@');
                                        //rs.writeNV(nv[1], nv[2], tar.LogicFalseOutNV1Value);
                                        string fb = ws.writeNV(nv[1], nv[2], tar.LogicFalseOutNV1Value);
                                    }

                                    if (tar.LogicFalseOutNV2 != "")  // output nv2
                                    {
                                        string[] nv = tar.LogicFalseOutNV2.Split('@');
                                        //rs.writeNV(nv[1], nv[2], tar.LogicFalseOutNV2Value);
                                        string fb = ws.writeNV(nv[1], nv[2], tar.LogicFalseOutNV2Value);
                                    }

                                    if (tar.LogicFalseOutNV3 != "")  // output nv3
                                    {
                                        string[] nv = tar.LogicFalseOutNV3.Split('@');
                                        //rs.writeNV(nv[1], nv[2], tar.LogicFalseOutNV3Value);
                                        string fb = ws.writeNV(nv[1], nv[2], tar.LogicFalseOutNV3Value);
                                    }

                                    if (tar.LogicFalseOutNV4 != "")  // output nv4
                                    {
                                        string[] nv = tar.LogicFalseOutNV4.Split('@');
                                        //rs.writeNV(nv[1], nv[2], tar.LogicFalseOutNV4Value);
                                        string fb = ws.writeNV(nv[1], nv[2], tar.LogicFalseOutNV4Value);
                                    }

                                    if (tar.LogicFalseOutNV5 != "")  // output nv5
                                    {
                                        string[] nv = tar.LogicFalseOutNV5.Split('@');
                                        //rs.writeNV(nv[1], nv[2], tar.LogicFalseOutNV5Value);
                                        string fb = ws.writeNV(nv[1], nv[2], tar.LogicFalseOutNV5Value);
                                    }

                                    if (tar.LogicFalseOutNV6 != "")  // output nv6
                                    {
                                        string[] nv = tar.LogicFalseOutNV6.Split('@');
                                        //rs.writeNV(nv[1], nv[2], tar.LogicFalseOutNV6Value);
                                        string fb = ws.writeNV(nv[1], nv[2], tar.LogicFalseOutNV6Value);
                                    }

                                    if (tar.LogicFalseOutNV7 != "")  // output nv7
                                    {
                                        string[] nv = tar.LogicFalseOutNV7.Split('@');
                                        //rs.writeNV(nv[1], nv[2], tar.LogicFalseOutNV7Value);
                                        string fb = ws.writeNV(nv[1], nv[2], tar.LogicFalseOutNV7Value);
                                    }

                                    if (tar.LogicFalseOutNV8 != "")  // output nv8
                                    {
                                        string[] nv = tar.LogicFalseOutNV8.Split('@');
                                        //rs.writeNV(nv[1], nv[2], tar.LogicFalseOutNV8Value);
                                        string fb = ws.writeNV(nv[1], nv[2], tar.LogicFalseOutNV8Value);
                                    }
                                }

                                //send mail
                                if (tar.LogicFalseOutemail == true)
                                {
                                    //send mail
                                    if (tar.LogicFalseOutemail == true)
                                    {
                                        for (int m = 0; m < memoryData.GroupContact2.Count; m++)
                                        {
                                            ContactGroup2 mg = (ContactGroup2)memoryData.GroupContact2[m];
                                            if (tar.AlarmFalseMailgroup == mg.groupname)
                                            {
                                                using (FileStream input = new FileStream(Application.StartupPath + @"\Resources\SMTP.dat", FileMode.Open))
                                                {   // 讀取整數值
                                                    BinaryReader reader = new BinaryReader(input);
                                                    string data = reader.ReadString();

                                                    int numOfBytes = data.Length / 8;
                                                    byte[] bytes = new byte[numOfBytes];
                                                    for (int ri = 0; ri < numOfBytes; ++ri)
                                                    {
                                                        bytes[ri] = Convert.ToByte(data.Substring(8 * ri, 8), 2);
                                                    }
                                                    //File.WriteAllBytes(fileName, bytes);
                                                    string val = GetString(bytes);
                                                    string[] SpStr = val.Split('$');
                                                    string SMTPhost = SpStr[1];
                                                    string SMTPport = SpStr[2];
                                                    Boolean SSL = Boolean.Parse(SpStr[3]);
                                                    string userName = SpStr[4];
                                                    string userPassword = SpStr[5];

                                                    for (int sg = 0; sg < mg.groupmember.Count; sg++)
                                                    {
                                                        Contactstruct sgm = (Contactstruct)mg.groupmember[sg];
                                                        if (sgm.mail != null & sgm.mail != "")
                                                        {
                                                            string formatForMySqlDate = DateTime.Now.ToString("yyyy-MM-dd");
                                                            string formatForMySqlTime = DateTime.Now.ToString("HH:mm:ss");

                                                            email.From = new MailAddress(userName);  //寄件人
                                                            email.Subject = "alarm inactive!";  //標題
                                                            email.Body = "trigger time = " + formatForMySqlDate + " " + formatForMySqlTime + Environment.NewLine
                                                                         + "trigger value = " + readVal + Environment.NewLine + "descript : " + tar.description
                                                                         + Environment.NewLine + "message : " + tar.LogicFalseOutMSG;  //內容
                                                            email.To.Add(sgm.mail);  //收件人
                                                            SMTP.EnableSsl = true;
                                                            SMTP.Port = int.Parse(SMTPport); //smtp port
                                                            SMTP.Host = SMTPhost;  //smtp host(主機ip)
                                                            SMTP.Credentials = new System.Net.NetworkCredential(userName, userPassword);  //寄件人,密碼
                                                            SMTP.Send(email);
                                                        }

                                                    }
                                                    input.Dispose();
                                                }
                                            }
                                        }
                                    }
                                }
                                //send SMS
                                if (tar.LogicFalseOutSMS == true)
                                {
                                }
                                //log data to SQL
                                if (tar.LogicFalseOutLog == true)
                                {
                                    //save to database
                                    if (memoryData.database.Count != 0)
                                    {
                                        database SQLstr = (database)memoryData.database[0];

                                        //open database
                                        string connStr = "server=" + SQLstr.ip + ";port=" + SQLstr.port + ";uid=" + SQLstr.user + ";pwd=" + SQLstr.password + ";database=" + SQLstr.DBname;
                                        MySqlConnection conn = new MySqlConnection(connStr);
                                        //MySqlCommand command = conn.CreateCommand();
                                        MySqlCommand addList = conn.CreateCommand();
                                        conn.Open();

                                        string sql = @"SELECT * FROM alarm_list WHERE site='" + tar.site + "' and fab='" + tar.fab + "' and area='" + tar.area
                                                           + "' and device='" + tar.device + "' and function='" + tar.function + "' and NVname='" + tar.NV + "' ";

                                        MySqlCommand cmdCHK = new MySqlCommand(sql, conn);
                                        MySqlDataReader dataCHK = cmdCHK.ExecuteReader();
                                        int listid = 0;

                                        string formatForMySqlDate = DateTime.Now.ToString("yyyy-MM-dd");
                                        string formatForMySqlTime = DateTime.Now.ToString("HH:mm:ss");

                                        string alarm_value = "";
                                        string NVvalue_txt = "";
                                        float NVvalue_real = 0;

                                        if (tar.LogicFalseOutLog == true)
                                        {
                                            //get type
                                            string alarmType = "";
                                            if (tar.NVType == "device")
                                            {
                                                alarmType = "device";
                                            }
                                            else
                                            {
                                                alarmType = "tag";
                                            }

                                            if (tar.NVType == "SNVT_occupancy")
                                            {
                                                alarm_value = tar.CompareValue;
                                                NVvalue_txt = moniVal;
                                                NVvalue_real = 0;
                                            }
                                            else if (tar.NVType == "device")  // type = device
                                            {
                                                alarm_value = "online";
                                                NVvalue_txt = "online";
                                                NVvalue_real = 0;
                                            }
                                            else  // type = NV
                                            {
                                                if (moniVal == "" || moniVal == null)
                                                {
                                                    moniVal = "0";
                                                }

                                                if (tar.NVType == "SNVT_switch")
                                                {
                                                    //===========================================================
                                                    //原來的資料取得方式
                                                    //string[] gettar = tar.SourceNVName.Split('@');
                                                    //string[] getnewValue = ws.readNV(gettar[1], gettar[2]).Split('$');
                                                    //System.Threading.Thread.Sleep(10);
                                                    //===========================================================
                                                    string[] getnewValue = getReadAllString.Split('$');
                                                    string[] sppart = getnewValue[0].Split(' ');
                                                    if (tar.NVpart == "value")
                                                    {
                                                        NVvalue_txt = sppart[0];
                                                        NVvalue_real = float.Parse(sppart[0]);
                                                    }
                                                    else if (tar.NVpart == "status")
                                                    {
                                                        NVvalue_txt = sppart[1];
                                                        NVvalue_real = float.Parse(sppart[1]);
                                                    }

                                                    alarm_value = tar.CompareValue;

                                                }
                                                else
                                                {
                                                    alarm_value = tar.CompareValue;
                                                    NVvalue_txt = readVal;
                                                    NVvalue_real = float.Parse(readVal);
                                                }
                                            }


                                            if (dataCHK.HasRows == true)
                                            {
                                                //有查到資料
                                                dataCHK.Read();
                                                listid = int.Parse(dataCHK.GetString(0));
                                                dataCHK.Close();

                                                addList.CommandText = @"update nico_db.alarm_list set description = '" + tar.description + "',message = '"
                                                                       + tar.LogicFalseOutMSG + "' where id = " + listid;
                                                addList.ExecuteNonQuery();

                                                MySqlCommand addValue = conn.CreateCommand();

                                                addValue.CommandText = @"Insert into alarm_value(list_id,NVvalue_txt,NVvalue_real,alarm_event,date,time) values('"
                                                                          + listid + "','" + NVvalue_txt + "','" + NVvalue_real + "','inactive','"
                                                                          + formatForMySqlDate + "','" + formatForMySqlTime + "')";

                                                addValue.ExecuteNonQuery();

                                            }
                                            else
                                            {
                                                dataCHK.Close();
                                                //沒有查到資料


                                                addList.CommandText = @"Insert into alarm_list(site,fab,area,device,function,NVname,NVtype,alarm_setting,alarm_type,"
                                                                      + "alarm_value,message,description,ip) values('" + tar.site + "','" + tar.fab + "','" + tar.area
                                                                      + "','" + tar.device + "','" + tar.function + "','" + tar.NV + "','" + tar.NVType
                                                                      + "','" + tar.CompareLogic + "','" + alarmType + "','" + alarm_value + "','" + tar.LogicFalseOutMSG
                                                                      + "','" + tar.description + "','" + tar.SourceIP + "')";

                                                addList.ExecuteNonQuery();

                                                //get list_id
                                                dataCHK = cmdCHK.ExecuteReader();
                                                dataCHK.Read();
                                                if (dataCHK.HasRows == true)
                                                {
                                                    listid = int.Parse(dataCHK.GetString(0));
                                                    dataCHK.Close();
                                                }

                                                //write to output_value
                                                MySqlCommand addValue = conn.CreateCommand();

                                                addValue.CommandText = @"Insert into alarm_value(list_id,NVvalue_txt,NVvalue_real,alarm_event,date,time) values('"
                                                                          + listid + "','" + NVvalue_txt + "','" + NVvalue_real + "','inactive','"
                                                                          + formatForMySqlDate + "','" + formatForMySqlTime + "')";

                                                addValue.ExecuteNonQuery();

                                            }

                                            conn.Close();
                                            // old  /////////////////↑↑↑↑↑↑↑↑↑↑↑↑

                                        }
                                    }

                                }

                            }
                            tar.sampleRatecount = 0;
                            memoryData.AlarmData[i] = tar;

                            if (tar.userFalseValue == true)
                            {

                                //use value
                                //要顯示的文字
                                string s = ""; //moniVal;  // "show alarm value";
                                string[] spSTR = valueFB.Split('$');
                                if (tar.NVType == "SNVT_switch")
                                {
                                    string[] NV = spSTR[0].Split(' ');
                                    if (tar.NVpart == "value")
                                    {
                                        s = NV[0];
                                    }
                                    else if (tar.NVpart == "status")
                                    {
                                        s = NV[1];
                                    }
                                }
                                else if (tar.NVType == "device")
                                {
                                    if (moniVal == "AL_NO_CONDITION")
                                    {
                                        s = "online";
                                    }
                                    else
                                    {
                                        s = "offline";
                                    }
                                }
                                else //if (tar.NVtype == "SNVT_occupancy")
                                {
                                    if (spSTR[0] == "")
                                    {
                                        s = "null";
                                    }
                                    else
                                    {
                                        s = spSTR[0];
                                    }

                                }


                                //先建立底圖預測文字大小使用
                                Bitmap canvas = new Bitmap(40, 28);
                                //建立繪圖物件
                                Graphics g = Graphics.FromImage(canvas);

                                // 设置字体的样式

                                Font f = new Font("Arial", 12);  //tar.LogicTrueOutFont; //new Font("新細明體", 12);

                                //計算文字大小
                                SizeF stringSize = g.MeasureString(s, tar.LogicFalseOutFont, 1000);
                                //SizeF stringSize = g.MeasureString(s, f, 1000);
                                g.Dispose();
                                int setX = Convert.ToInt32(stringSize.Width);
                                int setY = Convert.ToInt32(stringSize.Height);
                                //canvas.Dispose();
                                //g.Dispose();
                                Bitmap canvasShow = new Bitmap(setX, setY);
                                Graphics show = Graphics.FromImage(canvasShow);

                                // 实例化一个实心画刷，颜色是红色
                                SolidBrush brush = new SolidBrush(Color.FromArgb(tar.LogicFalseforecolor)); //new SolidBrush(Color.Red);
                                                                                                            // 与左上角坐标的距离
                                PointF point = new PointF(0, 0);
                                // 开始绘制
                                show.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                                show.DrawString(s, f, brush, point);
                                //f.Dispose();
                                //show.Dispose();
                                tarIMG.Image = canvasShow;
                                tarIMG.SizeMode = PictureBoxSizeMode.AutoSize;

                                f.Dispose();
                                show.Dispose();

                            }

                        }



                    }
                }
                // GC.Collect();
            }
            catch (Exception ex)
            {
                //throw;
            }
            finally
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void databaseSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            option_database Le = new option_database();
            Le.Show();
        }

        private void Mainmenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void LayerListSelect_Click(object sender, EventArgs e)
        {

        }

        private void inputTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddObjInput.Select();
            AddObjInput_Click(sender, e);
        }

        private void alarmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddObjAlarm.Select();
            AddObjAlarm_Click(sender, e);
        }

        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddObjPicture.Select();
            AddObjPicture_Click(sender, e);
        }

        private void outputTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddObjOutput.Select();
            AddObjOutput_Click(sender, e);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] tmpStr = this.ActiveControl.Tag.ToString().Split('@');
            string tar = tmpStr[0];
            switch (tar)// (this.ActiveControl.Tag.ToString())
            {
                case "label":
                    //Label lb = (Label)this.ActiveControl;
                    for (int i = 0; i < memoryData.LabelData.Count; i++)
                    {
                        LabelObjstruct edit = (LabelObjstruct)memoryData.LabelData[i];
                        if (edit.name == this.ActiveControl.Name)
                        {
                            copyObjValue.Clear();
                            copyObjValue.Add(edit);
                            copyObjType = "label";
                            copyObjName = edit.name;
                            break;
                        }
                    }
                    break;
                case "button":
                    //DoubleClickButton bt = (DoubleClickButton)this.ActiveControl;
                    for (int i = 0; i < memoryData.ButtonData.Count; i++)
                    {
                        ButtonObjstruct edit = (ButtonObjstruct)memoryData.ButtonData[i];
                        if (edit.name == this.ActiveControl.Name)
                        {
                            copyObjValue.Clear();
                            copyObjValue.Add(edit);
                            copyObjType = "button";
                            copyObjName = edit.name;
                            break;
                        }
                    }
                    break;
                case "input":
                    //Label inlb = (Label)this.ActiveControl;
                    for (int i = 0; i < memoryData.InputData.Count; i++)
                    {
                        InputObjectstruct edit = (InputObjectstruct)memoryData.InputData[i];
                        if (edit.name == this.ActiveControl.Name)
                        {
                            copyObjValue.Clear();
                            copyObjValue.Add(edit);
                            copyObjType = "input";
                            copyObjName = edit.name;
                            break;
                        }
                    }
                    break;

                case "pop":
                    for (int i = 0; i < memoryData.OutputPopData.Count; i++)
                    {
                        OutputPopObjectstruct edit = (OutputPopObjectstruct)memoryData.OutputPopData[i];
                        if (edit.name == this.ActiveControl.Name)
                        {
                            copyObjValue.Clear();
                            copyObjValue.Add(edit);
                            copyObjType = "pop";
                            copyObjName = edit.name;
                            break;
                        }
                    }
                    break;

                case "switch":
                    for (int i = 0; i < memoryData.OutputButtonData.Count; i++)
                    {
                        OutputButtonObjectstruct edit = (OutputButtonObjectstruct)memoryData.OutputButtonData[i];
                        if (edit.name == this.ActiveControl.Name)
                        {
                            copyObjValue.Clear();
                            copyObjValue.Add(edit);
                            copyObjType = "switch";
                            copyObjName = edit.name;
                            break;
                        }
                    }
                    break;

                case "outputText":
                    for (int i = 0; i < memoryData.OutputTextData.Count; i++)
                    {
                        OutputTextObjectstruct edit = (OutputTextObjectstruct)memoryData.OutputTextData[i];
                        if (edit.name == this.ActiveControl.Name)
                        {
                            copyObjValue.Clear();
                            copyObjValue.Add(edit);
                            copyObjType = "outputText";
                            copyObjName = edit.name;
                            break;
                        }
                    }
                    break;

                case "image":
                    for (int i = 0; i < memoryData.PictureData.Count; i++)
                    {
                        PictureboxObjectstruct edit = (PictureboxObjectstruct)memoryData.PictureData[i];
                        if (edit.name == this.ActiveControl.Name)
                        {
                            copyObjValue.Clear();
                            copyObjValue.Add(edit);
                            copyObjType = "image";
                            copyObjName = edit.name;
                            break;
                        }
                    }
                    break;

                case "alarm":
                    for (int i = 0; i < memoryData.AlarmData.Count; i++)
                    {
                        AlarmObjectstruct edit = (AlarmObjectstruct)memoryData.AlarmData[i];
                        if (edit.name == this.ActiveControl.Name)
                        {
                            copyObjValue.Clear();
                            copyObjValue.Add(edit);
                            break;
                        }
                    }

                    for (int j = 0; j < memoryData.AlarmMonitorValue.Count; j++)
                    {
                        AlarmMoniTorNV edit = (AlarmMoniTorNV)memoryData.AlarmMonitorValue[j];
                        if (edit.name == this.ActiveControl.Name)
                        {
                            copyObjType = "alarm";
                            copyObjName = edit.name;
                            copyObjValue.Add(edit);
                            break;
                        }
                    }

                    break;
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (copyObjType)// (this.ActiveControl.Tag.ToString())
            {
                case "label":
                    LabelObjstruct copy = (LabelObjstruct)copyObjValue[0];
                    copy.name = chkAddIconName("1");
                    //copy.x = System.Windows.Forms.Cursor.Position.X;
                    //copy.y = System.Windows.Forms.Cursor.Position.Y -80;
                    copy.x = getRightMenuX;
                    copy.y = getRightMenuY-80;
                    copy.layer = LayerListSelect.Text;
                    memoryData.LabelData.Add(copy);

                    Label act = (Label)this.pictureBox1.Controls[copyObjName];
                    LabelWithOptionalCopyTextOnDoubleClick lb = new LabelWithOptionalCopyTextOnDoubleClick();

                    lb.Text = copy.text;
                    lb.Name = copy.name;
                    lb.Tag = "label@label";
                    lb.Font =act.Font;
                    lb.ForeColor = act.ForeColor;
                    lb.BackColor = act.BackColor;
                    lb.BorderStyle = copy.border;
                    lb.AutoSize = true;
                    lb.Location = new Point(copy.x, copy.y);
                    lb.DoubleClick += new System.EventHandler(this.label_DoubleClick);
                    lb.Click += new System.EventHandler(this.label_Click);
                    lb.Paint += new System.Windows.Forms.PaintEventHandler(this.label_paint);
                    lb.Leave += new System.EventHandler(this.label_Level);
                    lb.Enter += new System.EventHandler(this.label_Enter);
                    lb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_mouseMove);
                    lb.MouseEnter += new System.EventHandler(this.label_mouseEnter);
                    lb.MouseLeave += new System.EventHandler(this.label_mouseLevel);
                    lb.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.label_KeyUp);
                
                    pictureBox1.Controls.Add(lb);
                    break;
                case "button":
                    ButtonObjstruct copy1 = (ButtonObjstruct)copyObjValue[0];
                    copy1.name = chkAddIconName("1");
                    //copy1.x = System.Windows.Forms.Cursor.Position.X;
                    //copy1.y = System.Windows.Forms.Cursor.Position.Y -70;
                    copy1.x = getRightMenuX;
                    copy1.y = getRightMenuY-80;
                    copy1.layer = LayerListSelect.Text;
                    memoryData.ButtonData.Add(copy1);

                    DoubleClickButton act1 = (DoubleClickButton)this.pictureBox1.Controls[copyObjName];
                    DoubleClickButton bt = new DoubleClickButton();
                    bt.AutoSize = false;
                    bt.Text = copy1.text;
                    bt.Name = copy1.name;
                    bt.Tag = copy1.tag;
                    bt.Location = new Point(copy1.x, copy1.y);
                    bt.Size = new Size(copy1.width, copy1.height);

                    bt.Font = act1.Font;
                    bt.ForeColor = act1.ForeColor;
                    bt.BackColor = act1.BackColor;
                    bt.TextAlign = act1.TextAlign;
                    bt.ImageAlign = act1.ImageAlign;
                    if (copy1.backImage != null && copy1.backImage != "")
                    {
                        bt.Image = Image.FromFile(copy1.backImage);
                    }
                                        

                    bt.DoubleClick += new System.EventHandler(this.buttn_DoubleClick);
                    bt.Click += new System.EventHandler(this.buttn_Click);
                    bt.Paint += new System.Windows.Forms.PaintEventHandler(this.buttn_paint);
                    bt.Leave += new System.EventHandler(this.buttn_Level);
                    bt.Enter += new System.EventHandler(this.buttn_Enter);
                    bt.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttn_mouseMove);
                    bt.MouseEnter += new System.EventHandler(this.buttn_mouseEnter);
                    bt.MouseLeave += new System.EventHandler(this.buttn_mouseLevel);
                    bt.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.buttn_KeyUp);
                    bt.BackgroundImage = null;
                    bt.BackgroundImageLayout = ImageLayout.None;

                    pictureBox1.Controls.Add(bt);
                    break;
                case "input":
                    InputObjectstruct copy2 = (InputObjectstruct)copyObjValue[0];
                    copy2.name = chkAddIconName("1");
                    //copy2.x = System.Windows.Forms.Cursor.Position.X;
                    //copy2.y = System.Windows.Forms.Cursor.Position.Y -70;
                    copy2.x = getRightMenuX;
                    copy2.y = getRightMenuY-80;
                    copy2.layer = LayerListSelect.Text;
                    memoryData.InputData.Add(copy2);

                    Label act2 = (Label)this.pictureBox1.Controls[copyObjName];
                    LabelWithOptionalCopyTextOnDoubleClick lbi = new LabelWithOptionalCopyTextOnDoubleClick();

                    lbi.AutoSize = true;
                    lbi.Text = act2.Text;
                    lbi.Name = copy2.name;
                    lbi.Tag = copy2.tag;
                    lbi.Location = new Point(copy2.x, copy2.y);

                    lbi.Font = act2.Font;
                    lbi.ForeColor = act2.ForeColor;
                    lbi.BackColor = act2.BackColor;
                    lbi.BorderStyle = act2.BorderStyle;
                    
                    lbi.DoubleClick += new System.EventHandler(this.label_DoubleClick);
                    lbi.Click += new System.EventHandler(this.label_Click);
                    lbi.Paint += new System.Windows.Forms.PaintEventHandler(this.label_paint);
                    lbi.Leave += new System.EventHandler(this.label_Level);
                    lbi.Enter += new System.EventHandler(this.label_Enter);
                    lbi.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_mouseMove);
                    lbi.MouseEnter += new System.EventHandler(this.label_mouseEnter);
                    lbi.MouseLeave += new System.EventHandler(this.label_mouseLevel);
                    lbi.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.label_KeyUp);
                    //lb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Icon_MouseDown);
                    pictureBox1.Controls.Add(lbi);
                    toolTip1.SetToolTip(lbi, copy2.description);
                    memoryData.iconTemp.Add(lbi.Name);
                    break;

                case "pop":
                    OutputPopObjectstruct copy3 = (OutputPopObjectstruct)copyObjValue[0];
                    copy3.name = chkAddIconName("1");
                    //copy3.x = System.Windows.Forms.Cursor.Position.X;
                    //copy3.y = System.Windows.Forms.Cursor.Position.Y -70;
                    copy3.x = getRightMenuX;
                    copy3.y = getRightMenuY-80;
                    copy3.layer = LayerListSelect.Text;
                    memoryData.OutputPopData.Add(copy3);

                    DoubleClickButton act3 = (DoubleClickButton)this.pictureBox1.Controls[copyObjName];
                    DoubleClickButton btp = new DoubleClickButton();

                    btp.AutoSize = false;
                    btp.Text = copy3.text;
                    btp.Name = copy3.name;
                    btp.Location = new Point(copy3.x, copy3.y);

                    btp.ImageAlign = act3.ImageAlign;
                    btp.TextAlign = act3.TextAlign;
                    btp.BackColor = act3.BackColor;
                    btp.Font = act3.Font;
                    btp.ForeColor = act3.ForeColor;
                    btp.Size = act3.Size;
                    if (copy3.backImage != null && copy3.backImage != "")
                    {
                        btp.BackgroundImage = Image.FromFile(copy3.backImage);
                    }
                    


                    btp.DoubleClick += new System.EventHandler(this.buttn_DoubleClick);
                    btp.Click += new System.EventHandler(this.buttn_Click);
                    btp.Paint += new System.Windows.Forms.PaintEventHandler(this.buttn_paint);
                    btp.Leave += new System.EventHandler(this.buttn_Level);
                    btp.Enter += new System.EventHandler(this.buttn_Enter);
                    btp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttn_mouseMove);
                    btp.MouseEnter += new System.EventHandler(this.buttn_mouseEnter);
                    btp.MouseLeave += new System.EventHandler(this.buttn_mouseLevel);
                    btp.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.buttn_KeyUp);
                    btp.BackgroundImage = null;
                    btp.BackgroundImageLayout = ImageLayout.None;

                    pictureBox1.Controls.Add(btp);
                    toolTip1.SetToolTip(btp, copy3.description);
                    break;

                case "switch":
                    OutputButtonObjectstruct copy4 = (OutputButtonObjectstruct)copyObjValue[0];
                    copy4.name = chkAddIconName("1");
                    //copy4.x = System.Windows.Forms.Cursor.Position.X;
                    //copy4.y = System.Windows.Forms.Cursor.Position.Y -70;
                    copy4.x = getRightMenuX;
                    copy4.y = getRightMenuY-80;
                    copy4.layer = LayerListSelect.Text;
                    memoryData.OutputButtonData.Add(copy4);

                    PictureBox act4 = (PictureBox)this.pictureBox1.Controls[copyObjName];
                    PictureBox pbs = new PictureBox();
                    

                    pbs.Name = copy4.name;
                    pbs.Location = new Point(copy4.x, copy4.y);
                    pbs.SizeMode = PictureBoxSizeMode.StretchImage;

                    pbs.Tag = copy4.tag;
                    pbs.Size = act4.Size;

                    if (copy4.imagePath != null && copy4.imagePath != "")
                    {
                        pbs.Image = Image.FromFile(copy4.imagePath);
                    }


                    
                    pbs.DoubleClick += new System.EventHandler(this.picswitch_DoubleClick);
                    pbs.Click += new System.EventHandler(this.picswitch_Click);
                    pbs.Leave += new System.EventHandler(this.picswitch_Level);
                    pbs.Enter += new System.EventHandler(this.picswitch_Enter);
                    pbs.Paint += new System.Windows.Forms.PaintEventHandler(this.picswitch_Paint);
                    pbs.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picswitch_mouseMove);
                    pbs.MouseEnter += new System.EventHandler(this.picswitch_mouseEnter);
                    pbs.MouseLeave += new System.EventHandler(this.picswitch_mouseLevel);
                    pbs.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picswitch_mouseUP);
                    pbs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picswitch_mouseDOWN);
                    pbs.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.picswitch_KeyUp);
                    pictureBox1.Controls.Add(pbs);
                    toolTip1.SetToolTip(pbs, copy4.description);
                    break;

                case "outputText":
                    OutputTextObjectstruct copy5 = (OutputTextObjectstruct)copyObjValue[0];
                    copy5.name = chkAddIconName("1");
                    //copy5.x = System.Windows.Forms.Cursor.Position.X;
                    //copy5.y = System.Windows.Forms.Cursor.Position.Y -70;
                    copy5.x = getRightMenuX;
                    copy5.y = getRightMenuY-80;
                    copy5.layer = LayerListSelect.Text;
                    memoryData.OutputTextData.Add(copy5);

                    TextBox act5 = (TextBox)this.pictureBox1.Controls[copyObjName];
                    TextBox lbt = new TextBox();

                    lbt.Name = copy5.name;
                    lbt.Location = new Point(copy5.x, copy5.y);
                    lbt.Size = act5.Size;
                    lbt.Tag = copy5.tag;

                    lbt.DoubleClick += new System.EventHandler(this.lonValue_DoubleClick);
                    lbt.Click += new System.EventHandler(this.lonValue_Click);
                    lbt.Paint += new System.Windows.Forms.PaintEventHandler(this.lonValuePaint);
                    lbt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lonValue_keyDown);
                    lbt.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lonValue_mouseMove);
                    lbt.MouseEnter += new System.EventHandler(this.lonValue_mouseEnter);
                    lbt.MouseLeave += new System.EventHandler(this.lonValue_mouseLevel);
                    lbt.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.lonValue_KeyUp);
                    lbt.BorderStyle = BorderStyle.None;

                    pictureBox1.Controls.Add(lbt);
                    toolTip1.SetToolTip(lbt, copy5.description);
                    break;

                case "image":
                    PictureboxObjectstruct copy6 = (PictureboxObjectstruct)copyObjValue[0];
                    copy6.name = chkAddIconName("1");
                    //copy6.x = System.Windows.Forms.Cursor.Position.X;
                    //copy6.y = System.Windows.Forms.Cursor.Position.Y -70;
                    copy6.x = getRightMenuX;
                    copy6.y = getRightMenuY-80;
                    copy6.layer = LayerListSelect.Text;
                    memoryData.PictureData.Add(copy6);

                    PictureBox act6 = (PictureBox)this.pictureBox1.Controls[copyObjName];
                    PictureBox pic = new PictureBox();

                    pic.Name = copy6.name;
                    pic.Tag = copy6.tag;
                    pic.Location = new Point(copy6.x, copy6.y);
                    pic.Size = act6.Size;
                    pic.SizeMode = act6.SizeMode;
                    if (copy6.path != null && copy6.path != "")
                    {
                        pic.Image = Image.FromFile(copy6.path);
                    }

                    pic.DoubleClick += new System.EventHandler(this.picswitch_DoubleClick);
                    pic.Click += new System.EventHandler(this.picswitch_Click);
                    pic.Leave += new System.EventHandler(this.picswitch_Level);
                    pic.Enter += new System.EventHandler(this.picswitch_Enter);
                    pic.Paint += new System.Windows.Forms.PaintEventHandler(this.picswitch_Paint);
                    pic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picswitch_mouseMove);
                    pic.MouseEnter += new System.EventHandler(this.picswitch_mouseEnter);
                    pic.MouseLeave += new System.EventHandler(this.picswitch_mouseLevel);
                    pic.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picswitch_mouseUP);
                    pic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picswitch_mouseDOWN);
                    pic.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.picswitch_KeyUp);

                    pictureBox1.Controls.Add(pic);
                    
                    break;

                case "alarm":
                    //AlarmObjectstruct
                    AlarmObjectstruct copyAL = (AlarmObjectstruct)copyObjValue[0];
                    //AlarmMoniTorNV
                    AlarmMoniTorNV copyAM = (AlarmMoniTorNV)copyObjValue[1];

                    string newName=chkAddIconName("1");
                    int nx = getRightMenuX;
                    int ny = getRightMenuY;

                    copyAM.name = newName;
                    memoryData.AlarmMonitorValue.Add(copyAM);

                    PictureBox actAL = (PictureBox)this.pictureBox1.Controls[copyObjName];

                    copyAL.name = newName;
                    copyAL.LogicFalseX = getRightMenuX;
                    copyAL.LogicFalseY = getRightMenuY - 80;
                    copyAL.LogicTrueX = getRightMenuX;
                    copyAL.LogicTrueY = getRightMenuY - 80;
                    copyAL.layer = LayerListSelect.Text;

                    memoryData.AlarmData.Add(copyAL);
                    PictureBox al = new PictureBox();

                    al.Name = newName;
                    al.Tag = copyAL.tag;
                    al.Location = new Point(copyAL.LogicFalseX, copyAL.LogicFalseY);
                    al.Size = actAL.Size;
                    al.SizeMode = actAL.SizeMode;

                    if (copyAL.LogicFalseOutImagePath != null && copyAL.LogicFalseOutImagePath != "")
                    {
                        al.Image = Image.FromFile(copyAL.LogicFalseOutImagePath);
                    }

                    al.DoubleClick += new System.EventHandler(this.picswitch_DoubleClick);
                    al.Click += new System.EventHandler(this.picswitch_Click);
                    al.Leave += new System.EventHandler(this.picswitch_Level);
                    al.Enter += new System.EventHandler(this.picswitch_Enter);
                    al.Paint += new System.Windows.Forms.PaintEventHandler(this.picswitch_Paint);
                    al.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picswitch_mouseMove);
                    al.MouseEnter += new System.EventHandler(this.picswitch_mouseEnter);
                    al.MouseLeave += new System.EventHandler(this.picswitch_mouseLevel);
                    al.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picswitch_mouseUP);
                    al.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picswitch_mouseDOWN);
                    al.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.picswitch_KeyUp);

                    pictureBox1.Controls.Add(al);
                    toolTip1.SetToolTip(al, copyAL.description);

                    break;
            }
        }

        private void iconRightMenu_Opening(object sender, CancelEventArgs e)
        {
            //MessageBox.Show("open");
            getRightMenuX = System.Windows.Forms.Cursor.Position.X;
            getRightMenuY = System.Windows.Forms.Cursor.Position.Y;
        }

        private void accountManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //option_account Le = new option_account();
            //Le.Show();

            user_check2 le = new user_check2();
            le.Show();
        }

        private void configureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] tmpStr = this.ActiveControl.Tag.ToString().Split('@');
            string tar = tmpStr[0];
            switch (tar)// (this.ActiveControl.Tag.ToString())
            {
                case "label":
                case "input":
                    editLabelObj(this.ActiveControl, e);
                    break;
                
                case "button":
                case "pop":
                    buttn_DoubleClick(this.ActiveControl, e);
                    break;

                case "outputText":
                    lonValue_DoubleClick(this.ActiveControl, e);
                    break;

                case "image":
                case "alarm":
                case "switch":
                    picswitch_DoubleClick(this.ActiveControl, e);
                    break;

            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            UserLogin();
        }

        private void UserLogin()
        {
            user_check lForm = new user_check();
            lForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
            lForm.ShowDialog();

            database DBstr = (database)memoryData.database[0];


            Mainstatus.Items[user_lab.Name].Text = "admin : " + user;
            Mainstatus.Items[level_lab.Name].Text = "level : " + accLV;
            Mainstatus.Items[db_lab.Name].Text = "database ip : " + DBstr.ip;
            if (accLV == "admin")
            {
                if (RunMode.Checked == true)
                {
                    fileTool.Enabled = false;
                    //newProject.Enabled = true;  //file — new
                    //saveProject.Enabled = true;  //file — save
                    //saveAsProject.Enabled = true;  //file — save as
                    //loadProject.Enabled = true;  //file — load
                    deviceTool.Enabled = false;  //device
                    layerTool.Enabled = false;  //layer
                    optionTool.Enabled = false;  //option
                    RunMode.Enabled = true;  //Run button
                    LockObj.Enabled = false;  //lock icon
                    LayerListSelect.Enabled = false;  //layer select
                    delSelectObj.Enabled = false;  //delect icon
                    AddObjText.Enabled = false;  //add Label icon
                    AddObjButton.Enabled = false;  //add Button icon
                    AddObjPicture.Enabled = false;  //add image icon
                    AddObjInput.Enabled = false;  //add input icon
                    AddObjOutput.Enabled = false;  //add output icon
                    AddObjAlarm.Enabled = false;  //add alarm icon
                }
                else
                {
                    fileTool.Enabled = true;
                    newProject.Enabled = true;  //file — new
                    saveProject.Enabled = true;  //file — save
                    saveAsProject.Enabled = true;  //file — save as
                    loadProject.Enabled = true;  //file — load
                    deviceTool.Enabled = true;  //device
                    layerTool.Enabled = true;  //layer
                    optionTool.Enabled = true;  //option
                    RunMode.Enabled = true;  //Run button
                    LockObj.Enabled = true;  //lock icon
                    LayerListSelect.Enabled = true;  //layer select
                    delSelectObj.Enabled = true;  //delect icon
                    AddObjText.Enabled = true;  //add Label icon
                    AddObjButton.Enabled = true;  //add Button icon
                    AddObjPicture.Enabled = true;  //add image icon
                    AddObjInput.Enabled = true;  //add input icon
                    AddObjOutput.Enabled = true;  //add output icon
                    AddObjAlarm.Enabled = true;  //add alarm icon
                }

            }
            else if (accLV == "design")
            {
                if (RunMode.Checked == true)
                {
                    fileTool.Enabled = false;
                    //newProject.Enabled = true;  //file — new
                    //saveProject.Enabled = true;  //file — save
                    //saveAsProject.Enabled = true;  //file — save as
                    //loadProject.Enabled = true;  //file — load
                    deviceTool.Enabled = false;  //device
                    layerTool.Enabled = false;  //layer
                    optionTool.Enabled = false;  //option
                    RunMode.Enabled = true;  //Run button
                    LockObj.Enabled = false;  //lock icon
                    LayerListSelect.Enabled = false;  //layer select
                    delSelectObj.Enabled = false;  //delect icon
                    AddObjText.Enabled = false;  //add Label icon
                    AddObjButton.Enabled = false;  //add Button icon
                    AddObjPicture.Enabled = false;  //add image icon
                    AddObjInput.Enabled = false;  //add input icon
                    AddObjOutput.Enabled = false;  //add output icon
                    AddObjAlarm.Enabled = false;  //add alarm icon
                }
                else
                {
                    fileTool.Enabled = true;
                    newProject.Enabled = true;  //file — new
                    saveProject.Enabled = true;  //file — save
                    saveAsProject.Enabled = true;  //file — save as
                    loadProject.Enabled = true;  //file — load
                    deviceTool.Enabled = true;  //device
                    layerTool.Enabled = true;  //layer
                    optionTool.Enabled = false;  //option
                    RunMode.Enabled = true;  //Run button
                    LockObj.Enabled = true;  //lock icon
                    LayerListSelect.Enabled = true;  //layer select
                    delSelectObj.Enabled = true;  //delect icon
                    AddObjText.Enabled = true;  //add Label icon
                    AddObjButton.Enabled = true;  //add Button icon
                    AddObjPicture.Enabled = true;  //add image icon
                    AddObjInput.Enabled = true;  //add input icon
                    AddObjOutput.Enabled = true;  //add output icon
                    AddObjAlarm.Enabled = true;  //add alarm icon
                }

            }
            else if (accLV == "view")
            {
                newProject.Enabled = false;  //file — new
                saveProject.Enabled = false;  //file — save
                saveAsProject.Enabled = false;  //file — save as
                loadProject.Enabled = false;  //file — load
                deviceTool.Enabled = false;  //device
                layerTool.Enabled = false;  //layer
                optionTool.Enabled = false;  //option
                RunMode.Enabled = false;  //Run button
                LockObj.Enabled = false;  //lock icon
                LayerListSelect.Enabled = false;  //layer select
                delSelectObj.Enabled = false;  //delect icon
                AddObjText.Enabled = false;  //add Label icon
                AddObjButton.Enabled = false;  //add Button icon
                AddObjPicture.Enabled = false;  //add image icon
                AddObjInput.Enabled = false;  //add input icon
                AddObjOutput.Enabled = false;  //add output icon
                AddObjAlarm.Enabled = false;  //add alarm icon
            }
            else
            {
                newProject.Enabled = false;  //file — new
                saveProject.Enabled = false;  //file — save
                saveAsProject.Enabled = false;  //file — save as
                loadProject.Enabled = false;  //file — load
                deviceTool.Enabled = false;  //device
                layerTool.Enabled = false;  //layer
                optionTool.Enabled = false;  //option
                RunMode.Enabled = false;  //Run button
                LockObj.Enabled = false;  //lock icon
                LayerListSelect.Enabled = false;  //layer select
                delSelectObj.Enabled = false;  //delect icon
                AddObjText.Enabled = false;  //add Label icon
                AddObjButton.Enabled = false;  //add Button icon
                AddObjPicture.Enabled = false;  //add image icon
                AddObjInput.Enabled = false;  //add input icon
                AddObjOutput.Enabled = false;  //add output icon
                AddObjAlarm.Enabled = false;  //add alarm icon
            }
            //user = "";
            //accLV = "";
        }

        private Boolean layerNameRepeatChk(string inputName)
        {
            Boolean Repeat = false;
            for (int i = 0; i < LayerListSelect.Items.Count; i++)
            {
                if (LayerListSelect.FindString(inputName) != -1)
                {
                    Repeat = true;
                }
            }

            return Repeat;
        }

        private void duplicatToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string message = "copy target : " + LayerListSelect.Text;
            string caption = "duplicate layer";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                string tarName = LayerListSelect.Text; 
                string addname = tarName + "_";
                int addindex = 1;

            Chk:
                if (layerNameRepeatChk(addname + addindex) == false)
                {
                    //copy layer
                    Layerstruct addLayer = new Layerstruct();
                    for(int la=0;la<memoryData.LayerData.Count;la++)
                    {
                        Layerstruct tar = (Layerstruct)memoryData.LayerData[la];
                        if(tar.name == tarName)
                        {
                            addLayer = tar;
                            addLayer.name = addname + addindex;
                            memoryData.LayerData.Add(addLayer);
                        }
                    }

                    //copy label
                    LabelObjstruct addLabel = new LabelObjstruct();
                    for (int lb = 0; lb < memoryData.LabelData.Count; lb++)
                    {
                        LabelObjstruct tar = (LabelObjstruct)memoryData.LabelData[lb];
                        if (tar.layer == tarName)
                        {
                            addLabel = tar;
                            addLabel.layer = addname + addindex;
                            addLabel.name = chkAddIconName("1");
                            memoryData.LabelData.Add(addLabel);

                            LabelWithOptionalCopyTextOnDoubleClick lba = new LabelWithOptionalCopyTextOnDoubleClick();
                            lba.Text = tar.text;
                            lba.Name = addLabel.name;
                            lba.Tag = addLabel.tag;
                            lba.Font = addLabel.font;
                            lba.AutoSize = true;
                            lba.Location = new Point(addLabel.x, addLabel.y);
                            lba.Visible = false;
                            lba.DoubleClick += new System.EventHandler(this.label_DoubleClick);
                            lba.Click += new System.EventHandler(this.label_Click);
                            lba.Paint += new System.Windows.Forms.PaintEventHandler(this.label_paint);
                            lba.Leave += new System.EventHandler(this.label_Level);
                            lba.Enter += new System.EventHandler(this.label_Enter);
                            lba.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_mouseMove);
                            lba.MouseEnter += new System.EventHandler(this.label_mouseEnter);
                            lba.MouseLeave += new System.EventHandler(this.label_mouseLevel);
                            lba.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.label_KeyUp);
                            
                            pictureBox1.Controls.Add(lba);
                            memoryData.iconTemp.Add(addLabel.name);
                        }
                    }

                    //copy button
                    ButtonObjstruct addButton = new ButtonObjstruct();
                    for (int btn = 0; btn < memoryData.ButtonData.Count; btn++)
                    {
                        ButtonObjstruct tar = (ButtonObjstruct)memoryData.ButtonData[btn];
                        if (tar.layer == tarName)
                        {
                            addButton = tar;
                            addButton.layer = addname + addindex;
                            addButton.name = chkAddIconName("1");
                            memoryData.ButtonData.Add(addButton);

                            DoubleClickButton bt = new DoubleClickButton();
                            bt.Text = addButton.text;
                            bt.Name = addButton.name;
                            bt.AutoSize = false;
                            bt.Font = addButton.font;
                            bt.Size = new Size(addButton.width, addButton.height);
                            bt.Tag = addButton.tag;
                            bt.Location = new Point(addButton.x, addButton.y);
                            bt.Visible = false;
                            bt.DoubleClick += new System.EventHandler(this.buttn_DoubleClick);
                            bt.Click += new System.EventHandler(this.buttn_Click);
                            bt.Paint += new System.Windows.Forms.PaintEventHandler(this.buttn_paint);
                            bt.Leave += new System.EventHandler(this.buttn_Level);
                            bt.Enter += new System.EventHandler(this.buttn_Enter);
                            bt.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttn_mouseMove);
                            bt.MouseEnter += new System.EventHandler(this.buttn_mouseEnter);
                            bt.MouseLeave += new System.EventHandler(this.buttn_mouseLevel);
                            bt.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.buttn_KeyUp);
                            bt.BackgroundImage = null;
                            bt.BackgroundImageLayout = ImageLayout.None;

                            pictureBox1.Controls.Add(bt);
                            memoryData.iconTemp.Add(addButton.name);
                        }
                    }

                    //copy input
                    InputObjectstruct addInput = new InputObjectstruct();
                    for (int inp = 0; inp < memoryData.InputData.Count; inp++)
                    {
                        InputObjectstruct tar = (InputObjectstruct)memoryData.InputData[inp];
                        if (tar.layer == tarName)
                        {
                            addInput = tar;
                            addInput.layer = addname + addindex;
                            addInput.name = chkAddIconName("1");
                            memoryData.InputData.Add(addInput);

                            LabelWithOptionalCopyTextOnDoubleClick lb = new LabelWithOptionalCopyTextOnDoubleClick();
                            lb.Text = addInput.value;
                            lb.Name = addInput.name;
                            lb.Tag = addInput.tag;
                            lb.Font = addInput.font;
                            lb.AutoSize = true;
                            lb.Location = new Point(addInput.x, addInput.y);
                            lb.Visible = false;
                            lb.DoubleClick += new System.EventHandler(this.label_DoubleClick);
                            lb.Click += new System.EventHandler(this.label_Click);
                            lb.Paint += new System.Windows.Forms.PaintEventHandler(this.label_paint);
                            lb.Leave += new System.EventHandler(this.label_Level);
                            lb.Enter += new System.EventHandler(this.label_Enter);
                            lb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_mouseMove);
                            lb.MouseEnter += new System.EventHandler(this.label_mouseEnter);
                            lb.MouseLeave += new System.EventHandler(this.label_mouseLevel);
                            lb.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.label_KeyUp);

                            memoryData.iconTemp.Add(addInput.name);
                            pictureBox1.Controls.Add(lb);

                        }
                    }

                    //copy outputbutton
                    OutputButtonObjectstruct addOutBut = new OutputButtonObjectstruct();
                    for (int opb = 0; opb < memoryData.OutputButtonData.Count; opb++)
                    {
                        OutputButtonObjectstruct tar = (OutputButtonObjectstruct)memoryData.OutputButtonData[opb];
                        if (tar.layer == tarName)
                        {
                            addOutBut = tar;
                            addOutBut.layer = addname + addindex;
                            addOutBut.name = chkAddIconName("1");
                            memoryData.OutputButtonData.Add(addOutBut);

                            PictureBox pb = new PictureBox();
                            if (addOutBut.imagePath != null && addOutBut.imagePath != "")
                            {
                                pb.Image = Image.FromFile(addOutBut.imagePath);
                            }
                            else
                            {
                                pb.Image = Image.FromFile(Application.StartupPath + @"\Resources\image\switch_on_png.png");
                            }
                            
                            pb.Name = addOutBut.name;
                            pb.Size = new Size(addOutBut.width, addOutBut.height);
                            pb.SizeMode = PictureBoxSizeMode.StretchImage;
                            pb.Tag = addOutBut.tag;
                            pb.Location = new Point(addOutBut.x, addOutBut.y);
                            pb.Visible = false;
                            pb.DoubleClick += new System.EventHandler(this.picswitch_DoubleClick);
                            pb.Click += new System.EventHandler(this.picswitch_Click);
                            pb.Leave += new System.EventHandler(this.picswitch_Level);
                            pb.Enter += new System.EventHandler(this.picswitch_Enter);
                            pb.Paint += new System.Windows.Forms.PaintEventHandler(this.picswitch_Paint);
                            pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picswitch_mouseMove);
                            pb.MouseEnter += new System.EventHandler(this.picswitch_mouseEnter);
                            pb.MouseLeave += new System.EventHandler(this.picswitch_mouseLevel);
                            pb.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picswitch_mouseUP);
                            pb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picswitch_mouseDOWN);
                            pb.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.picswitch_KeyUp);

                            memoryData.iconTemp.Add(addOutBut.name);
                            pictureBox1.Controls.Add(pb);
                        }
                    }

                    //copy outputText
                    OutputTextObjectstruct addOutText = new OutputTextObjectstruct();
                    for (int opt = 0; opt < memoryData.OutputTextData.Count; opt++)
                    {
                        OutputTextObjectstruct tar = (OutputTextObjectstruct)memoryData.OutputTextData[opt];
                        if (tar.layer == tarName)
                        {
                            addOutText = tar;
                            addOutText.layer = addname + addindex;
                            addOutText.name = chkAddIconName("1");
                            memoryData.OutputTextData.Add(addOutText);

                            TextBox outT = new TextBox();
                            outT.Text = addOutText.NVvalue;
                            outT.Name = addOutText.name;
                            outT.Tag = addOutText.tag;
                            outT.Font = new Font("Arial", 12, FontStyle.Regular);
                            outT.Size = new Size(addOutText.width, addOutText.height);
                            outT.Location = new Point(addOutText.x, addOutText.y);
                            outT.ContextMenuStrip = iconRightMenu;
                            outT.Visible = false;
                            outT.DoubleClick += new System.EventHandler(this.lonValue_DoubleClick);
                            outT.Click += new System.EventHandler(this.lonValue_Click);
                            outT.Paint += new System.Windows.Forms.PaintEventHandler(this.lonValuePaint);
                            outT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lonValue_keyDown);
                            outT.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lonValue_mouseMove);
                            outT.MouseEnter += new System.EventHandler(this.lonValue_mouseEnter);
                            outT.MouseLeave += new System.EventHandler(this.lonValue_mouseLevel);
                            outT.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.lonValue_KeyUp);
                            outT.BorderStyle = BorderStyle.None;

                            memoryData.iconTemp.Add(addOutText.name);
                            pictureBox1.Controls.Add(outT);
                        }
                    }

                    //copy outputPop
                    OutputPopObjectstruct addOutPop = new OutputPopObjectstruct();
                    for (int opp = 0; opp < memoryData.OutputPopData.Count; opp++)
                    {
                        OutputPopObjectstruct tar = (OutputPopObjectstruct)memoryData.OutputPopData[opp];

                        if (tar.layer == tarName)
                        {
                            addOutPop = tar;
                            addOutPop.layer = addname + addindex;
                            addOutPop.name = chkAddIconName("1");
                            memoryData.OutputPopData.Add(addOutPop);

                            DoubleClickButton bt = new DoubleClickButton();
                            bt.Text = addOutPop.text;
                            bt.Name = addOutPop.name;
                            bt.AutoSize = false;
                            bt.Font = addOutPop.font;
                            bt.Size = new Size(addOutPop.width, addOutPop.height);
                            bt.Tag = addOutPop.tag;
                            bt.Location = new Point(addOutPop.x, addOutPop.y);
                            bt.Visible = false;
                            bt.DoubleClick += new System.EventHandler(this.buttn_DoubleClick);
                            bt.Click += new System.EventHandler(this.buttn_Click);
                            bt.Paint += new System.Windows.Forms.PaintEventHandler(this.buttn_paint);
                            bt.Leave += new System.EventHandler(this.buttn_Level);
                            bt.Enter += new System.EventHandler(this.buttn_Enter);
                            bt.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttn_mouseMove);
                            bt.MouseEnter += new System.EventHandler(this.buttn_mouseEnter);
                            bt.MouseLeave += new System.EventHandler(this.buttn_mouseLevel);
                            bt.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.buttn_KeyUp);
                            bt.BackgroundImage = null;
                            bt.BackgroundImageLayout = ImageLayout.None;

                            memoryData.iconTemp.Add(addOutPop.name);
                            pictureBox1.Controls.Add(bt);
                        }

                    }

                    //copy picture
                    PictureboxObjectstruct addImage = new PictureboxObjectstruct();
                    for (int pic = 0; pic < memoryData.PictureData.Count; pic++)
                    {
                        PictureboxObjectstruct tar = (PictureboxObjectstruct)memoryData.PictureData[pic];
                        if (tar.layer == tarName)
                        {
                            addImage = tar;
                            addImage.layer = addname + addindex;
                            addImage.name = chkAddIconName("1");
                            memoryData.PictureData.Add(addImage);

                            PictureBox pb = new PictureBox();
                            pb.Image = Image.FromFile(addImage.path);
                            pb.Name = addImage.name;
                            pb.Size = new Size(addImage.width, addImage.height);
                            pb.SizeMode = PictureBoxSizeMode.StretchImage;
                            pb.Tag = addImage.tag;
                            pb.Location = new Point(addImage.x, addImage.y);
                            pb.Visible = false;
                            pb.DoubleClick += new System.EventHandler(this.picswitch_DoubleClick);
                            pb.Click += new System.EventHandler(this.picswitch_Click);
                            pb.Leave += new System.EventHandler(this.picswitch_Level);
                            pb.Enter += new System.EventHandler(this.picswitch_Enter);
                            pb.Paint += new System.Windows.Forms.PaintEventHandler(this.picswitch_Paint);
                            pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picswitch_mouseMove);
                            pb.MouseEnter += new System.EventHandler(this.picswitch_mouseEnter);
                            pb.MouseLeave += new System.EventHandler(this.picswitch_mouseLevel);
                            pb.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picswitch_mouseUP);
                            pb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picswitch_mouseDOWN);
                            pb.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.picswitch_KeyUp);

                            pictureBox1.Controls.Add(pb);
                            memoryData.iconTemp.Add(addImage.name);
                        }
                        
                    }

                    //copy alarm
                    AlarmObjectstruct addAlarm = new AlarmObjectstruct();
                    for (int al = 0; al < memoryData.AlarmData.Count; al++)
                    {
                        AlarmObjectstruct tar = (AlarmObjectstruct)memoryData.AlarmData[al];
                        if (tar.layer == tarName)
                        {
                            addAlarm = tar;
                            addAlarm.layer = addname + addindex;
                            addAlarm.name = chkAddIconName("1");
                            memoryData.AlarmData.Add(addAlarm);

                            PictureBox pb = new PictureBox();
                            pb.Image = Image.FromFile(addAlarm.LogicFalseOutImagePath);
                            pb.Name = addAlarm.name;
                            pb.Size = new Size(addAlarm.LogicFalseWidth, addAlarm.LogicFalseHeight);
                            pb.SizeMode = PictureBoxSizeMode.StretchImage;
                            pb.Tag = addAlarm.tag;
                            pb.Location = new Point(addAlarm.LogicFalseX, addAlarm.LogicFalseY);
                            pb.Visible = false;
                            pb.DoubleClick += new System.EventHandler(this.picswitch_DoubleClick);
                            pb.Click += new System.EventHandler(this.picswitch_Click);
                            pb.Leave += new System.EventHandler(this.picswitch_Level);
                            pb.Enter += new System.EventHandler(this.picswitch_Enter);
                            pb.Paint += new System.Windows.Forms.PaintEventHandler(this.picswitch_Paint);
                            pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picswitch_mouseMove);
                            pb.MouseEnter += new System.EventHandler(this.picswitch_mouseEnter);
                            pb.MouseLeave += new System.EventHandler(this.picswitch_mouseLevel);
                            pb.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picswitch_mouseUP);
                            pb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picswitch_mouseDOWN);
                            pb.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.picswitch_KeyUp);

                            memoryData.iconTemp.Add(addAlarm.name);
                            pictureBox1.Controls.Add(pb);
                        }
                        
                    }

                    //layerListBox.Items.Add(addname + addindex);
                    LayerListSelect.Items.Add(addname + addindex);
                }
                else
                {
                    addindex += 1;
                    goto Chk;
                }
            }
        }


        //////////////////////////////////
        private void StartKiller()
        {
            System.Windows.Forms.Timer timerMSG = new System.Windows.Forms.Timer();
            timerMSG.Interval = 3000; //3秒啓動
            timerMSG.Tick += new EventHandler(TimerMSG_Tick);
            timerMSG.Start();
        }

        private void TimerMSG_Tick(object sender, EventArgs e)
        {
            KillMessageBox();
            //停止Timer
            ((System.Windows.Forms.Timer)sender).Stop();
        }

        private void KillMessageBox()
        {
            //依MessageBox的標題,找出MessageBox的視窗
            
            IntPtr ptr = FindWindow(null, "SmartServer offline");
            if (ptr != IntPtr.Zero)
            {
                //找到則關閉MessageBox視窗
                PostMessage(ptr, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                
            }

            
        }
        
        //////////////////////////////////

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private String MD5code(String str)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
            Byte[] data = md5Hasher.ComputeHash((new System.Text.ASCIIEncoding()).GetBytes(str));
            System.Text.StringBuilder sBuilder = new System.Text.StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] tmpStr = this.ActiveControl.Tag.ToString().Split('@');
            string tar = tmpStr[0];
            string IconTarget = "";
            string getNVpath = "";
            switch (tar)// (this.ActiveControl.Tag.ToString())
            {
                //case "label":
                case "input":
                    IconTarget = "input";
                    break;

                //case "button":
                case "pop":
                    IconTarget = "outpop";
                    break;

                case "outputText":
                    IconTarget = "outtextbox";
                    break;

                case "image":
                    IconTarget = "image";
                    break;

                //case "alarm":

                case "switch":
                    IconTarget = "outButton";
                    break;
            }
            
            if(IconTarget == "input")
            {
                Label tarLabel = (Label)this.ActiveControl;
                //InputObjectstruct 
                for (int a=0;a < memoryData.InputData.Count;a++)
                {
                    InputObjectstruct chkData = (InputObjectstruct)memoryData.InputData[a];
                    if(tarLabel.Name == chkData.name)
                    {
                        getNVpath = chkData.site + "/" + chkData.fab + "/" + chkData.area + "/" + chkData.device + "/"
                                    + chkData.function + "/" + chkData.NV + "/" + chkData.NVtype + "/"
                                    + chkData.description + "/" + chkData.ip;

                        search_tagData newform = new search_tagData();
                        newform.TargetPath = getNVpath;
                        newform.Show();
                    }
                }
            }
            else if (IconTarget == "outpop")
            {
                Button tarPop = (Button)this.ActiveControl;
                //OutputPopObjectstruct
                
            }
            else if (IconTarget == "outtextbox")
            {
                TextBox tarTextbox = (TextBox )this.ActiveControl;
                //OutputTextObjectstruct
                
            }
            else if (IconTarget == "image")
            {
                PictureBox tarIMG = (PictureBox)this.ActiveControl;
                //PictureboxObjectstruct
                
            }
            else if (IconTarget == "outButton")
            {
                Button tarSwitch = (Button)this.ActiveControl;
                //PictureboxObjectstruct
                
            }
            
        }

        private void NVMonitor_DoWork(object sender, DoWorkEventArgs e)
        {

            try
            {//NV monitor
                if (memoryData.InputData.Count > 0)
                {
                    
                    //SOAP20_DLL.SOAP rs = new SOAP20_DLL.SOAP();

                    for (int i = 0; i < memoryData.InputData.Count; i++)
                    {
                        InputObjectstruct tar = (InputObjectstruct)memoryData.InputData[i];

                        if (tar.target != "")
                        {
                            string[] path = tar.target.Split('@');

                            if (tar.count == tar.lonPolltime)
                            {

                                if (tar.potocol == "lon")
                                {

                                    //string temp = rs.readNV(path[1], path[2]);
                                    //System.Threading.Thread.Sleep(10);
                                    string temp = "";
                                    for (int RACount = 0; RACount < memoryData.ReadAllNV.Count; RACount++)
                                    {
                                        ReadNVvaluestruct fra = (ReadNVvaluestruct)memoryData.ReadAllNV[RACount];
                                        if (tar.ip == fra.IP && tar.device == fra.device && tar.function == fra.function && tar.NV == fra.NV)
                                        {
                                            temp = fra.Value + "$" + fra.status + "$" + fra.NVtype + "$" + fra.preset;
                                            break;
                                        }
                                    }

                                    
                                    string[] getval = temp.Split('$');

                                    if (temp != null)
                                    {
                                        if (getval[1] == "AL_NO_CONDITION")
                                        {
                                            if (tar.NVtype == "SNVT_occupancy")
                                            {
                                                tar.showvalue = getval[0];
                                                tar.value = "0";
                                            }
                                            else if (tar.NVtype == "SNVT_switch")
                                            {
                                                tar.showvalue = getval[0];
                                                tar.value = "0";
                                            }
                                            else
                                            {
                                                float covStr = float.Parse(getval[0]);

                                                switch (tar.stringFormat)
                                                {
                                                    case "G":
                                                        tar.showvalue = covStr.ToString("G");
                                                        tar.value = covStr.ToString();
                                                        break;
                                                    case "0":
                                                        tar.showvalue = covStr.ToString("0");
                                                        tar.value = covStr.ToString();
                                                        break;
                                                    case "0.00":
                                                        tar.showvalue = covStr.ToString("0.00");
                                                        tar.value = covStr.ToString();
                                                        break;
                                                    case "#,##0":
                                                        tar.showvalue = covStr.ToString("#,##0");
                                                        tar.value = covStr.ToString();
                                                        break;
                                                    case "#,##0.00":
                                                        tar.showvalue = covStr.ToString("#,##0.00");
                                                        tar.value = covStr.ToString();
                                                        break;
                                                    default:
                                                        string cf = tar.stringFormat;
                                                        if (cf != "")
                                                        {
                                                            tar.showvalue = covStr.ToString(cf);
                                                            tar.value = covStr.ToString();
                                                        }
                                                        else
                                                        {
                                                            tar.showvalue = covStr.ToString("G");
                                                            tar.value = covStr.ToString() + " " + cf;
                                                        }
                                                        break;
                                                }
                                                memoryData.InputData[i] = tar;
                                            }
                                        }
                                        else if (getval[1] == "AL_OFFLINE")
                                        {
                                            if (tar.NVtype == "SNVT_occupancy")
                                            {
                                                tar.showvalue = "???";
                                                tar.value = "0";
                                            }
                                            else if (tar.NVtype == "SNVT_switch")
                                            {
                                                tar.showvalue = "???";
                                                tar.value = "0";
                                            }
                                            else
                                            {
                                                float covStr = float.Parse(getval[0]);

                                                switch (tar.stringFormat)
                                                {
                                                    case "G":
                                                        tar.showvalue = "???";
                                                        tar.value = covStr.ToString();
                                                        break;
                                                    case "0":
                                                        tar.showvalue = "???";
                                                        tar.value = covStr.ToString();
                                                        break;
                                                    case "0.00":
                                                        tar.showvalue = "???";
                                                        tar.value = covStr.ToString();
                                                        break;
                                                    case "#,##0":
                                                        tar.showvalue = "???";
                                                        tar.value = covStr.ToString();
                                                        break;
                                                    case "#,##0.00":
                                                        tar.showvalue = "???";
                                                        tar.value = covStr.ToString();
                                                        break;
                                                    default:
                                                        string cf = tar.stringFormat;
                                                        if (cf != "")
                                                        {
                                                            tar.showvalue = "???";
                                                            tar.value = covStr.ToString();
                                                        }
                                                        else
                                                        {
                                                            tar.showvalue = "???";
                                                            tar.value = covStr.ToString();
                                                        }
                                                        break;
                                                }

                                            }
                                        }
                                    }
                                    else
                                    {
                                        //smartserver offline
                                        for (int lab = 0; lab < memoryData.InputData.Count; lab++)
                                        {
                                            InputObjectstruct labtar = (InputObjectstruct)memoryData.InputData[lab];
                                            if (labtar.name == tar.name)
                                            {
                                                Label edittarget = (Label)pictureBox1.Controls[labtar.name];
                                                edittarget.Text = "???";

                                            }
                                        }

                                        tar.count = 0;
                                        memoryData.InputData[i] = tar;
                                    }


                                    //display
                                    Label disLab = (Label)pictureBox1.Controls[tar.name];

                                    if (tar.layer == LayerListSelect.Text)
                                    {
                                        disLab.Visible = true;
                                        if (tar.unituse == false)
                                        { disLab.Text = tar.showvalue; }
                                        else
                                        { disLab.Text = tar.showvalue + " " + tar.unit; }
                                    }
                                    else
                                    {
                                        disLab.Visible = false;
                                    }
                                }
                                else if (tar.potocol == "nico")
                                {
                                }

                                tar.count = 0;
                                memoryData.InputData[i] = tar;

                            }
                            else
                            {
                                tar.count += 1;
                                memoryData.InputData[i] = tar;
                            }
                            //log to mysql code
                        }
                        else
                        {
                            MessageBox.Show("no target!");
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                var w32ex = ex as Win32Exception;
                if (w32ex == null)
                {
                    w32ex = ex.InnerException as Win32Exception;
                }
                if (w32ex != null)
                {
                    int code = w32ex.ErrorCode;
                    if (code == 10060)
                    {
                        //string daytime = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
                        //File.WriteAllText("D:\\soapErrorLog.txt", daytime.ToString());
                        //File.WriteAllText("D:\\soapErrorLog.txt", code.ToString());
                        StartKiller();
                        MessageBox.Show("device : " + "192.168.1.250" + " offline!", "SmartServer offline");
                        //chkerrorip(ip);

                    }
                    else
                    {
                        //string daytime = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
                        //File.WriteAllText("D:\\soapErrorLog.txt", daytime.ToString());
                        //File.WriteAllText("D:\\soapErrorLog.txt", code.ToString());
                    }
                }


            }
        }

        private void NVMonitor_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void NVMonitor_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void ReadAllNV_DoWork(object sender, DoWorkEventArgs e)
        {
            if(ReadAllNV.CancellationPending )
            {
                e.Cancel = true;  //停止
                return;
            }
            else
            {
                //獲取VALUE
                SOAP20_DLL.SOAP ra = new SOAP20_DLL.SOAP();
                for (int i = 0; i < memoryData.SmartserverIP.Count; i++)
                {
                    string getIP = memoryData.SmartserverIP[i].ToString();
                    string Request = ra.request(getIP);
                    if (Request != null)
                    {
                        string device = "";
                        string function = "";
                        //string NV = "";

                        string[] d = Request.Split('※');
                        for (int di = 1; di < d.Length; di++)
                        {
                            string[] f = d[di].Split('$');
                            device = f[0]; // get device name
                            for (int fi = 1; fi < f.Length; fi++)
                            {
                                string[] n = f[fi].Split('@');
                                function = n[0]; // get function name
                                for (int ni = 1; ni < n.Length; ni++)
                                {
                                    string[] NVinfo = n[ni].Split('^');

                                    for (int dicount = 0; dicount < memoryData.ReadAllNV.Count; dicount++)
                                    {
                                        ReadNVvaluestruct tar = (ReadNVvaluestruct)memoryData.ReadAllNV[dicount];
                                        if (tar.IP == getIP && tar.device == device && tar.function == function && tar.NV == NVinfo[0].ToString())
                                        {
                                            tar.Value = NVinfo[2].ToString();
                                            tar.status = NVinfo[3].ToString();
                                            tar.preset = NVinfo[4].ToString();
                                            memoryData.ReadAllNV[dicount] = tar;
                                        } // if
                                    } // for ReadAllNV
                                } // for nv 
                            } // for function
                        } // for device
                    }
                } // for SmartserverIP
            }
        }
    }



    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DoubleClickButton : Button  //create new double click button (have button.doubleclick event)
    {
        public DoubleClickButton()
        {
            SetStyle(ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, true);
        }
    }

    public class LabelWithOptionalCopyTextOnDoubleClick : Label
    {
        private const int WM_LBUTTONDCLICK = 0x203;
        private string clipboardText;

        [DefaultValue(false)]
        [Description("Overrides default behavior of Label to copy label text to clipboard on double click")]
        public bool CopyTextOnDoubleClick { get; set; }

        protected override void OnDoubleClick(EventArgs e)
        {
            if (!string.IsNullOrEmpty(clipboardText))
                Clipboard.SetData(DataFormats.Text, clipboardText);
            clipboardText = null;
            base.OnDoubleClick(e);
        }

        protected override void WndProc(ref Message m)
        {
            if (!CopyTextOnDoubleClick)
            {
                if (m.Msg == WM_LBUTTONDCLICK)
                {
                    IDataObject d = Clipboard.GetDataObject();
                    if (d.GetDataPresent(DataFormats.Text))
                        clipboardText = (string)d.GetData(DataFormats.Text);
                }
            }
            base.WndProc(ref m);
        }

    }

}
