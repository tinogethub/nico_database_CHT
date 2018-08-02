using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using SmartServer;
using SOAP20_DLL;


namespace nico_database
{
    public partial class Device_manager : Form
    {
        
        //SmartServer.SOAP iLon = new SmartServer.SOAP(); //link to smartserver
        
       SOAP20_DLL.SOAP iLon = new SOAP20_DLL.SOAP();
        public string reip = "";

        public Device_manager()
        {
            InitializeComponent();
        }

        private void Device_manager_Load(object sender, EventArgs e)
        {
            //DeviceListTree.ExpandAll();
            DeviceListTree.CollapseAll();

            DeviceListTree.Nodes[0].Expand();
            DeviceListTree.Nodes[0].Nodes[0].Expand();
            DeviceListTree.Nodes[0].Nodes[0].Nodes[0].Expand();
            DeviceListTree.SelectedNode = DeviceListTree.Nodes[0].Nodes[0].Nodes[0];
            
        }
        private ListBox getAddDeviceName;
        public ListBox GetAddDeviceName
        {
            set
            {
                getAddDeviceName = value;
            }
        }


        //public string value//AddDeviceTreeNode to Form1
        //{
            //get { return getAddDeviceName; }
            //set { getAddDeviceName = value; }
        //}


        private string addDeviceCMD;

        private void DeviceListTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (DeviceListTree.Nodes.Count != 0)
            {
                if (DeviceListTree.SelectedNode != null)
                {

                    switch (DeviceListTree.SelectedNode.Level)
                    {
                        case 0:
                            DeviceListTree.ContextMenuStrip = DeviceTreeRightMenu;
                            addNewSiteToolStripMenuItem.Text = "add new site";
                            addNewFabToolStripMenuItem.Text = "add new fab";
                            addNewFabToolStripMenuItem.Visible = true;
                            delToolStripMenuItem.Text = "del site";

                            DeviceCPName.Enabled = true;
                            DeviceCPName.Text = DeviceListTree.SelectedNode.Text;
                            DeviceCPip.Enabled = false;
                            DeviceCPdescription.Enabled = true;
                            DeviceCPType.Enabled = false;
                            DeviceCPNVproportional_f.Enabled = false;
                            DeviceCPNVProportion_A.Enabled = false;
                            break;
                        case 1:
                            DeviceListTree.ContextMenuStrip = DeviceTreeRightMenu;
                            addNewSiteToolStripMenuItem.Text = "add new fab";
                            addNewFabToolStripMenuItem.Text = "add new area";
                            addNewFabToolStripMenuItem.Visible = true;
                            delToolStripMenuItem.Text = "del fab";

                            DeviceCPName.Enabled = true;
                            DeviceCPName.Text = DeviceListTree.SelectedNode.Text;
                            DeviceCPip.Enabled = false;
                            DeviceCPip.Text = "";
                            DeviceCPdescription.Enabled = true;
                            DeviceCPType.Enabled = false;
                            DeviceCPType.Text = "";
                            DeviceCPNVproportional_f.Enabled = false;
                            DeviceCPNVproportional_f.Text = "";
                            DeviceCPNVProportion_A.Enabled = false;
                            DeviceCPNVProportion_A.Text = "";
                            break;
                        case 2:
                            DeviceListTree.ContextMenuStrip = DeviceTreeRightMenu;
                            addNewSiteToolStripMenuItem.Text = "add new area";
                            addNewFabToolStripMenuItem.Text = "add new device";
                            addNewFabToolStripMenuItem.Visible = true;
                            delToolStripMenuItem.Text = "del area";

                            DeviceCPName.Enabled = true;
                            DeviceCPName.Text = DeviceListTree.SelectedNode.Text;
                            DeviceCPip.Enabled = false;
                            DeviceCPip.Text = "";
                            DeviceCPdescription.Enabled = true;
                            DeviceCPType.Enabled = false;
                            DeviceCPType.Text = "";
                            DeviceCPNVproportional_f.Enabled = false;
                            DeviceCPNVproportional_f.Text = "";
                            DeviceCPNVProportion_A.Enabled = false;
                            DeviceCPNVProportion_A.Text = "";
                            break;
                        case 3:
                            DeviceListTree.ContextMenuStrip = DeviceTreeRightMenu;
                            addNewSiteToolStripMenuItem.Text = "add new device";
                            addNewFabToolStripMenuItem.Text = "sort";
                            addNewFabToolStripMenuItem.Visible = true;
                            delToolStripMenuItem.Text = "del device";

                            DeviceCPName.Enabled = true;
                            DeviceCPName.Text = DeviceListTree.SelectedNode.Text;
                            DeviceCPip.Enabled = true;
                            DeviceCPip.Text = DeviceListTree.SelectedNode.ToolTipText;
                            DeviceCPdescription.Enabled = true;
                            DeviceCPType.Enabled = false;
                            DeviceCPType.Text = DeviceListTree.SelectedNode.Tag.ToString();
                            DeviceCPNVproportional_f.Enabled = false;
                            DeviceCPNVproportional_f.Text = "";
                            DeviceCPNVProportion_A.Enabled = false;
                            DeviceCPNVProportion_A.Text = "";
                            break;
                        case 4:
                            DeviceListTree.ContextMenuStrip = null;

                            DeviceCPName.Enabled = false;
                            DeviceCPName.Text = DeviceListTree.SelectedNode.Text;
                            DeviceCPip.Enabled = false;
                            DeviceCPip.Text = DeviceListTree.SelectedNode.Parent.ToolTipText;
                            DeviceCPdescription.Enabled = false;
                            DeviceCPType.Enabled = false;
                            DeviceCPType.Text = DeviceListTree.SelectedNode.Parent.Tag.ToString();
                            DeviceCPNVproportional_f.Enabled = false;
                            DeviceCPNVproportional_f.Text = "";
                            DeviceCPNVProportion_A.Enabled = false;
                            DeviceCPNVProportion_A.Text = "";
                            break;
                        case 5:
                            DeviceListTree.ContextMenuStrip = null;

                            DeviceCPName.Enabled = false;
                            DeviceCPName.Text = DeviceListTree.SelectedNode.Text;
                            DeviceCPip.Enabled = false;
                            DeviceCPip.Text = DeviceListTree.SelectedNode.Parent.Parent.ToolTipText;
                            DeviceCPdescription.Enabled = false;
                            DeviceCPdescription.Text = "";
                            DeviceCPType.Enabled = false;
                            DeviceCPType.Text = DeviceListTree.SelectedNode.Parent.Parent.Tag.ToString();


                            string[] getNVname = DeviceListTree.SelectedNode.Text.Split('#');
                            switch (getNVname[0])
                            {
                                case "UCPTproportional_f": //#-128":
                                case "proportional_f":
                                    DeviceCPNVproportional_f.Enabled = true;
                                    DeviceCPNVproportional_f.Text = "3000";
                                    DeviceCPNVProportion_A.Enabled = false;
                                    break;

                                case "nciProportion_A":
                                case "proportion_A":
                                    DeviceCPNVproportional_f.Enabled = false;
                                    DeviceCPNVProportion_A.Enabled = true;
                                    DeviceCPNVProportion_A.Text = "1";
                                    break;

                                default:
                                    DeviceCPNVproportional_f.Enabled = false;
                                    DeviceCPNVProportion_A.Enabled = false;
                                    break;
                            }
                            break;

                    }
                }
            }
        }

        private void addNewSiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DeviceListTree.SelectedNode != null)
            {
                addDeviceCMD = "addMain";
                AddDeviceTreeNode ADForm = new AddDeviceTreeNode();
                ADForm.Owner = this;  //使AddDevice的Owner指針指向Form1
                //ADForm.Show();
                //AddDeviceTree ad = new AddDeviceTree();
                //ad.Owner = this;


                switch (DeviceListTree.SelectedNode.Level)
                {
                    case 0:
                        ADForm.Text = "add new site";
                        ADForm.ShowDialog();

                        break;
                    case 1:
                        ADForm.Text = "add new fab";
                        ADForm.ShowDialog();

                        break;
                    case 2:
                        ADForm.Text = "add new area";
                        ADForm.ShowDialog();

                        break;
                    case 3:
                        AddDeviceTree ad = new AddDeviceTree();
                        ad.Owner = this;
                        ad.ShowDialog();
                        //DeviceListTree.Sort();
                        break;
                }

                //MessageBox.Show(getAddDeviceName);//顯示返回的值  
                if (DeviceListTree.SelectedNode != null)
                {
                    string failName;
                    if (getAddDeviceName != null)
                    {
                        for (int l = 0; l < getAddDeviceName.Items.Count; l++)
                        {
                            failName = getAddDeviceName.Items[l].ToString();
                            Boolean repeat = CheckAddNameNotRepeat(getAddDeviceName.Items[l].ToString());
                            if (repeat == false)
                            {
                                TreeNode td = new TreeNode();

                                if (DeviceListTree.SelectedNode.Level == 0)
                                {
                                    td.Text = getAddDeviceName.Items[l].ToString();
                                    td.Name = getAddDeviceName.Items[l].ToString();
                                    DeviceListTree.Nodes.Add(td);
                                }
                                else if (DeviceListTree.SelectedNode.Level == 3)
                                {
                                    createDeviceNode("main");
                                }
                                else
                                {
                                    td.Text = getAddDeviceName.Items[l].ToString();
                                    td.Name = getAddDeviceName.Items[l].ToString();
                                    DeviceListTree.SelectedNode.Parent.Nodes.Add(td);
                                }
                            }
                            else
                            { MessageBox.Show("input name already in use! (" + failName +")", "repeat name"); }
                        }
                    }
                }
            }
        }

        private void addNewFabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DeviceListTree.SelectedNode != null)
            {
                addDeviceCMD = "addSub";
                AddDeviceTreeNode ADForm = new AddDeviceTreeNode();
                ADForm.Owner = this;  //使AddDevice的Owner指針指向Form1
                //ADForm.Show();
                AddDeviceTree ad = new AddDeviceTree();
                ad.Owner = this;

                switch (DeviceListTree.SelectedNode.Level)
                {
                    case 0:
                        ADForm.Text = "add new fab";
                        ADForm.ShowDialog();

                        break;
                    case 1:
                        ADForm.Text = "add new area";
                        ADForm.ShowDialog();

                        break;
                    case 2:
                        ad.ShowDialog();
                        createDeviceNode("sub");
                        break;
                    case 3:
                        DeviceListTree.Sort();
                        break;

                }

                //MessageBox.Show(getAddDeviceName);//顯示返回的值  
                if (DeviceListTree.SelectedNode != null)
                {
                    string failName;
                    if (getAddDeviceName != null)
                    {
                        for (int l = 0; l < getAddDeviceName.Items.Count; l++)
                        {
                            failName = getAddDeviceName.Items[l].ToString();
                            Boolean repeat = CheckAddNameNotRepeat(getAddDeviceName.Items[l].ToString());
                            if (repeat == false)
                            {
                                TreeNode td = new TreeNode();

                                if (DeviceListTree.SelectedNode.Level == 0)
                                {
                                    td.Text = getAddDeviceName.Items[l].ToString();
                                    td.Name = getAddDeviceName.Items[l].ToString();
                                    DeviceListTree.SelectedNode.Nodes.Add(td);
                                }

                                else if (DeviceListTree.SelectedNode.Level == 2)
                                {
                                }
                                else if (DeviceListTree.SelectedNode.Level == 3)
                                {
                                    createDeviceNode("sub");
                                }
                                else
                                {
                                    td.Text = getAddDeviceName.Items[l].ToString();
                                    td.Name = getAddDeviceName.Items[l].ToString();
                                    DeviceListTree.SelectedNode.Nodes.Add(td);
                                }
                            }
                            else
                            { MessageBox.Show("input name already in use! (" + failName + ")", "repeat name"); }
                        }
                    }
                }
            }
        }

        private void createDeviceNode(string addLevel)
        {
            //MessageBox.Show(getAddDeviceName);//顯示返回的值  
            string failname="";
            if (getAddDeviceName != null)
            {
                for (int l = 0; l < getAddDeviceName.Items.Count; l++)
                {
                    string[] getString = getAddDeviceName.Items[l].ToString().Split('%');
                    Boolean repeat = new Boolean();
                    if (getString[0] == "nico")
                    {
                        //repeat = CheckAddNameNotRepeat(getString[2]);
                        repeat = false;
                    }
                    else if (getString[0] == "lon")
                    {
                        string[] tt = getString[2].Split('$');
                        failname = tt[0];
                        repeat = CheckAddNameNotRepeat(tt[0]);
                    }

                    //Boolean repeat = CheckAddNameNotRepeat(getString[2]);

                    if (repeat == false)
                    {
                        TreeNode td = new TreeNode();

                        //       string[] getString = getAddDeviceName.Split('%');
                        if (getString[0] == "nico")
                        {
                            td.ToolTipText = getString[1];
                            string TdName = CheckAddNVNameNotRepeat(getString[2] + "_1");
                            td.Text = TdName;
                            td.Name = TdName;
                            td.Tag = "nico";
                            td.ForeColor = Color.DarkRed;


                            switch (getString[2])
                            {

                                case "8108D":

                                    for (int i = 0; i < 8; i++)
                                    {
                                        TreeNode functionTd = new TreeNode();
                                        functionTd.Text = "PowerMonitor[" + i + "]";
                                        functionTd.Name = "PowerMonitor[" + i + "]";
                                        functionTd.ForeColor = Color.RoyalBlue;

                                        TreeNode NVTd1 = new TreeNode();
                                        TreeNode NVTd2 = new TreeNode();
                                        TreeNode NVTd3 = new TreeNode();
                                        TreeNode NVTd4 = new TreeNode();
                                        TreeNode NVTd5 = new TreeNode();
                                        TreeNode NVTd6 = new TreeNode();
                                        TreeNode NVTd7 = new TreeNode();

                                        int num = i;
                                        num += 1;
                                        NVTd1.Text = "Power_" + num;
                                        NVTd1.Name = "Power_" + num;
                                        NVTd1.ForeColor = Color.Gray;

                                        NVTd2.Text = "PowerFactor_" + num;
                                        NVTd2.Name = "PowerFactor_" + num;
                                        NVTd2.ForeColor = Color.Gray;

                                        NVTd3.Text = "Volts_" + num;
                                        NVTd3.Name = "Volts_" + num;
                                        NVTd3.ForeColor = Color.Gray;

                                        NVTd4.Text = "Amperes_" + num;
                                        NVTd4.Name = "Amperes_" + num;
                                        NVTd4.ForeColor = Color.Gray;

                                        NVTd5.Text = "KWH_" + num;
                                        NVTd5.Name = "KWH_" + num;
                                        NVTd5.ForeColor = Color.Gray;

                                        NVTd6.Text = "proportional_f";
                                        NVTd6.Name = "proportional_f";
                                        NVTd6.ForeColor = Color.Gray;

                                        NVTd7.Text = "proportion_A";
                                        NVTd7.Name = "proportion_A";
                                        NVTd7.ForeColor = Color.Gray;

                                        functionTd.Nodes.Add(NVTd1);
                                        functionTd.Nodes.Add(NVTd2);
                                        functionTd.Nodes.Add(NVTd3);
                                        functionTd.Nodes.Add(NVTd4);
                                        functionTd.Nodes.Add(NVTd5);
                                        functionTd.Nodes.Add(NVTd6);
                                        functionTd.Nodes.Add(NVTd7);

                                        td.Nodes.Add(functionTd);
                                    }

                                    for (int i = 0; i < 3; i++)
                                    {
                                        TreeNode functionTd = new TreeNode();
                                        functionTd.Text = "SumPwrMonitor[" + i + "]";
                                        functionTd.Name = "SumPwrMonitor[" + i + "]";
                                        functionTd.ForeColor = Color.RoyalBlue;

                                        TreeNode NVTd1 = new TreeNode();
                                        TreeNode NVTd2 = new TreeNode();

                                        int num = i;
                                        num += 1;
                                        NVTd1.Text = "SumPower_" + num;
                                        NVTd1.Name = "SumPower_" + num;
                                        NVTd1.ForeColor = Color.Gray;

                                        NVTd2.Text = "SumEnergy_KWH_" + num;
                                        NVTd2.Name = "SumEnergy_KWH_" + num;
                                        NVTd2.ForeColor = Color.Gray;

                                        functionTd.Nodes.Add(NVTd1);
                                        functionTd.Nodes.Add(NVTd2);
                                        td.Nodes.Add(functionTd);
                                    }

                                    break;
                                case "8404D":
                                    for (int i = 0; i < 1; i++)
                                    {
                                        TreeNode functionTd = new TreeNode();
                                        functionTd.Text = "VoltMonitor";
                                        functionTd.Name = "VoltMonitor";
                                        functionTd.ForeColor = Color.RoyalBlue;

                                        TreeNode NVTd1 = new TreeNode();
                                        TreeNode NVTd2 = new TreeNode();
                                        TreeNode NVTd3 = new TreeNode();

                                        int num = i;
                                        num += 1;
                                        NVTd1.Text = "Volts_R";
                                        NVTd1.Name = "Volts_R";
                                        NVTd1.ForeColor = Color.Gray;

                                        NVTd2.Text = "Volts_S";
                                        NVTd2.Name = "Volts_S";
                                        NVTd2.ForeColor = Color.Gray;

                                        NVTd3.Text = "Volts_T";
                                        NVTd3.Name = "Volts_T";
                                        NVTd3.ForeColor = Color.Gray;

                                        functionTd.Nodes.Add(NVTd1);
                                        functionTd.Nodes.Add(NVTd2);
                                        functionTd.Nodes.Add(NVTd3);

                                        td.Nodes.Add(functionTd);
                                    }

                                    for (int i = 0; i < 4; i++)
                                    {
                                        TreeNode functionTd = new TreeNode();
                                        functionTd.Text = "PowerMonitor[" + i + "]";
                                        functionTd.Name = "PowerMonitor[" + i + "]";
                                        functionTd.ForeColor = Color.RoyalBlue;

                                        TreeNode NVTd1 = new TreeNode();
                                        TreeNode NVTd2 = new TreeNode();
                                        TreeNode NVTd3 = new TreeNode();
                                        TreeNode NVTd4 = new TreeNode();
                                        TreeNode NVTd5 = new TreeNode();
                                        TreeNode NVTd6 = new TreeNode();
                                        TreeNode NVTd7 = new TreeNode();
                                        TreeNode NVTd8 = new TreeNode();
                                        TreeNode NVTd9 = new TreeNode();
                                        TreeNode NVTd10 = new TreeNode();

                                        int num = i;
                                        num += 1;
                                        NVTd1.Text = "Power_" + num;
                                        NVTd1.Name = "Power_" + num;
                                        NVTd1.ForeColor = Color.Gray;

                                        NVTd2.Text = "Amperes_R_" + num;
                                        NVTd2.Name = "Amperes_R_" + num;
                                        NVTd2.ForeColor = Color.Gray;

                                        NVTd3.Text = "Amperes_S_" + num;
                                        NVTd3.Name = "Amperes_S_" + num;
                                        NVTd3.ForeColor = Color.Gray;

                                        NVTd4.Text = "Amperes_T_" + num;
                                        NVTd4.Name = "Amperes_T_" + num;
                                        NVTd4.ForeColor = Color.Gray;

                                        NVTd5.Text = "Energy_KWH_" + num;
                                        NVTd5.Name = "Energy_KWH_" + num;
                                        NVTd5.ForeColor = Color.Gray;

                                        NVTd6.Text = "PowerFactor_" + num;
                                        NVTd6.Name = "PowerFactor_" + num;
                                        NVTd6.ForeColor = Color.Gray;

                                        NVTd7.Text = "PowerFactor_R_" + num;
                                        NVTd7.Name = "PowerFactor_R_" + num;
                                        NVTd7.ForeColor = Color.Gray;

                                        NVTd8.Text = "PowerFactor_S_" + num;
                                        NVTd8.Name = "PowerFactor_S_" + num;
                                        NVTd8.ForeColor = Color.Gray;

                                        NVTd9.Text = "PowerFactor_T_" + num;
                                        NVTd9.Name = "PowerFactor_T_" + num;
                                        NVTd9.ForeColor = Color.Gray;

                                        NVTd10.Text = "proportional_f";
                                        NVTd10.Name = "proportional_f";
                                        NVTd10.ForeColor = Color.Gray;

                                        functionTd.Nodes.Add(NVTd1);
                                        functionTd.Nodes.Add(NVTd2);
                                        functionTd.Nodes.Add(NVTd3);
                                        functionTd.Nodes.Add(NVTd4);
                                        functionTd.Nodes.Add(NVTd5);
                                        functionTd.Nodes.Add(NVTd6);
                                        functionTd.Nodes.Add(NVTd7);
                                        functionTd.Nodes.Add(NVTd8);
                                        functionTd.Nodes.Add(NVTd9);
                                        functionTd.Nodes.Add(NVTd10);

                                        td.Nodes.Add(functionTd);
                                    }
                                    break;
                            }
                            if (addLevel == "main")
                            {
                                DeviceListTree.SelectedNode.Parent.Nodes.Add(td);
                            }
                            else if (addLevel == "sub")
                            {
                                DeviceListTree.SelectedNode.Nodes.Add(td);
                            }

                        }
                        else if (getString[0] == "lon")
                        {
                            Boolean addFunction = true;

                            td.ToolTipText = getString[1];
                            string[] function = getString[2].Split('$');
                            td.Text = function[0];
                            td.Name = function[0];
                            td.Tag = "lon";
                            td.ForeColor = Color.DarkRed;

                            for (int i = 1; i < function.Length; i++) //split function
                            {
                                string[] NV = function[i].Split('@');
                                TreeNode functionTD = new TreeNode();
                                functionTD.Text = NV[0];
                                functionTD.Name = NV[0];
                                functionTD.ForeColor = Color.RoyalBlue;

                                //尋找一樣的節點
                                for (int fi=0;fi<td.Nodes .Count;fi++)
                                {
                                    if(td.Nodes[fi].Name == functionTD .Name )
                                    {
                                        //find function
                                        functionTD = td.Nodes[fi];  // 指向現有node位置
                                        addFunction = false;
                                        break;
                                    }
                                    else
                                    {
                                        //not find
                                        addFunction = true;
                                    }
                                }



                                for (int j = 1; j < NV.Length; j++) //split NV
                                {
                                    TreeNode NVtd = new TreeNode();
                                    string[] nvinfo = NV[j].Split('^');
                                    NVtd.Text = nvinfo[0]; //NV[j];
                                    NVtd.Name = nvinfo[0]; ;
                                    NVtd.Tag = nvinfo[1]; ;
                                    NVtd.ForeColor = Color.Gray;
                                    functionTD.Nodes.Add(NVtd);
                                }
                                if (addFunction == true)
                                {
                                    td.Nodes.Add(functionTD);
                                }
                                
                            }
                            //DeviceListTree.SelectedNode.Nodes.Add(td);
                            if (addLevel == "main")
                            {
                                DeviceListTree.SelectedNode.Parent.Nodes.Add(td);
                            }
                            else if (addLevel == "sub")
                            {
                                DeviceListTree.SelectedNode.Nodes.Add(td);
                            }
                        }



                    }
                    else
                    {
                        //MessageBox.Show("input name already in use! (" + failname + ")", "repeat name");
                        string[] tt = getString[2].Split('$');
                        if(tt[0] == "iLON App")
                        {
                            TreeNode renewApp = new TreeNode();
                            //DeviceListTree.SelectedNode.Nodes["iLON App"].Nodes["VirtFb"]
                            string[] function = getString[2].Split('$');
                            for (int i = 1; i < function.Length; i++)
                            {
                                string[] NV = function[i].Split('@');

                                for (int j = 1; j < NV.Length; j++) //split NV
                                {
                                    string[] nvinfo = NV[j].Split('^');

                                    //Search
                                    TreeNodeCollection nodes = DeviceListTree.SelectedNode.Nodes["iLON App"].Nodes["VirtFb"].Nodes;
                                    foreach (TreeNode n in nodes)
                                    {
                                        TreeNode[] Node = nodes.Find(nvinfo[0], true);
                                        //Node[0].Collapse();
                                        
                                        if (Node.Length == 0)
                                        {
                                            
                                            TreeNode NVtd = new TreeNode();
                                            NVtd.Text = nvinfo[0]; //NV[j];
                                            NVtd.Name = nvinfo[0]; ;
                                            NVtd.Tag = nvinfo[1]; ;
                                            NVtd.ForeColor = Color.Gray;
                                            DeviceListTree.SelectedNode.Nodes["iLON App"].Nodes["VirtFb"].Nodes.Add(NVtd);
                                        }
                                    }


                                }

                            }

                        }
                    }
                }
 
            }
        }

        //確認識別區塊名稱是否重複
        private Boolean CheckAddNameNotRepeat(string addName)
        {
            Boolean RepeatFlag = false;

            if (addDeviceCMD == "addMain")
            {
                if (DeviceListTree.SelectedNode.Level == 0)
                {

                    for (int i = 0; i < DeviceListTree.Nodes.Count; i++)
                    {
                        if (DeviceListTree.Nodes[i].Text == addName)
                        {
                            RepeatFlag = true;
                        }
                    }



                }
                else
                {
                    for (int i = 0; i < DeviceListTree.SelectedNode.Parent.Nodes.Count; i++)
                    {
                        if (DeviceListTree.SelectedNode.Parent.Nodes[i].Text == addName)
                        {
                            RepeatFlag = true;
                        }
                    }
                }
            }
            else if (addDeviceCMD == "addSub")
            {

                for (int i = 0; i < DeviceListTree.SelectedNode.Nodes.Count; i++)
                {
                    if (DeviceListTree.SelectedNode.Nodes[i].Text == addName )
                    {
                        RepeatFlag = true;
                    }
                }
            }
            else if (addDeviceCMD == "rename")
            {
                if (DeviceListTree.SelectedNode.Level == 0)
                {
                    for (int i = 0; i < DeviceListTree.Nodes.Count; i++)
                    {
                        if (DeviceListTree.Nodes[i].Text == addName)
                        {
                            RepeatFlag = true;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < DeviceListTree.SelectedNode.Parent.Nodes.Count; i++)
                    {
                        if (DeviceListTree.SelectedNode.Parent.Nodes[i].Text == addName)
                        {
                            RepeatFlag = true;
                        }
                    }
                }
            }


            return RepeatFlag;
        }
        //確認設備名稱是否重複自動改名
        private string CheckAddNVNameNotRepeat(string addNVName)
        {
            Boolean RepeatFlag = false;
        test:

            if (addDeviceCMD == "addMain")
            {
                foreach (TreeNode tnode in DeviceListTree.SelectedNode.Parent.Nodes)
                {
                    if (tnode.Name == addNVName)
                    {
                        RepeatFlag = true;
                        break; // TODO: might not be correct. Was : Exit For
                    }
                }
            }
            else if (addDeviceCMD == "addSub")
            {
                foreach (TreeNode tnode in DeviceListTree.SelectedNode.Nodes)
                {
                    if (tnode.Name == addNVName)
                    {
                        RepeatFlag = true;
                        break; // TODO: might not be correct. Was : Exit For
                    }
                }
            }


            if (RepeatFlag == true)
            {
                RepeatFlag = false;
                string[] getnum = addNVName.Split('_');
                int newindex = int.Parse(getnum[1]);
                addNVName = getnum[0] + "_" + (newindex + 1);
                goto test;
            }

            return addNVName;
        }

        private void delToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DeviceListTree.SelectedNode != null)
            {
                DialogResult myResult = MessageBox.Show("delete this ?", "delete select", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (myResult == DialogResult.Yes)
                {
                    string site,area,fab,device,ip;
                    
                    switch (DeviceListTree.SelectedNode.Level)
                    {
                        case 0: //delete site
                            if (DeviceListTree.Nodes.Count > 1)
                            {
                                site = DeviceListTree.SelectedNode.Text;
                                
                                //remove label data
                                for (int i = memoryData.InputData.Count - 1; i >= 0; i--)
                                {
                                    InputObjectstruct tar = (InputObjectstruct)memoryData.InputData[i];
                                    if (tar.site == site)
                                    {
                                        memoryData.iconDelTemp.Add(tar.name);
                                        memoryData.InputData.Remove(tar);
                                    }
                                }
                                //remove output button data
                                for (int i = memoryData.OutputButtonData.Count - 1; i >= 0; i--)
                                {
                                    OutputButtonObjectstruct tar = (OutputButtonObjectstruct)memoryData.OutputButtonData[i];
                                    if (tar.site == site)
                                    {
                                        memoryData.iconDelTemp.Add(tar.name);
                                        memoryData.OutputButtonData.Remove(tar);
                                    }
                                }
                                //remove output text data
                                for (int i = memoryData.OutputTextData.Count - 1; i >= 0; i--)
                                {
                                    OutputTextObjectstruct tar = (OutputTextObjectstruct)memoryData.OutputTextData[i];
                                    if (tar.site == site)
                                    {
                                        memoryData.iconDelTemp.Add(tar.name);
                                        memoryData.OutputTextData.Remove(tar);
                                    }
                                }
                                //remove output pop data
                                for (int i = memoryData.OutputPopData.Count - 1; i >= 0; i--)
                                {
                                    OutputPopObjectstruct tar = (OutputPopObjectstruct)memoryData.OutputPopData[i];
                                    if (tar.site == site)
                                    {
                                        memoryData.iconDelTemp.Add(tar.name);
                                        memoryData.OutputPopData.Remove(tar);
                                    }
                                }
                                //remove alarm data
                                for (int i = memoryData.AlarmData.Count - 1; i >= 0; i--)
                                {
                                    AlarmObjectstruct tar = (AlarmObjectstruct)memoryData.AlarmData[i];
                                    if (tar.site == site)
                                    {
                                        for (int j = 0; j < memoryData.AlarmMonitorValue.Count;j++ )
                                        {
                                            AlarmMoniTorNV mtar = (AlarmMoniTorNV)memoryData.AlarmMonitorValue[j];
                                            if(mtar.name == tar.name)
                                            {
                                                memoryData.AlarmMonitorValue.Remove(mtar);
                                                break;
                                            }
                                        }
                                        memoryData.iconDelTemp.Add(tar.name);
                                        memoryData.AlarmData.Remove(tar);
                                    }


                                }

                                DeviceListTree.Nodes.Remove(DeviceListTree.SelectedNode);
                            }
                            else
                            {
                                MessageBox.Show("site count must > 1");
                            }
                            break;

                        case 1: //delete fab

                            site = DeviceListTree.SelectedNode.Parent.Text;
                            fab = DeviceListTree.SelectedNode.Text;

                            //remove label data
                            for (int i = memoryData.InputData.Count - 1; i >= 0; i--)
                            {
                                InputObjectstruct tar = (InputObjectstruct)memoryData.InputData[i];
                                if (tar.site == site && tar.fab == fab)
                                {
                                    memoryData.iconDelTemp.Add(tar.name);
                                    memoryData.InputData.Remove(tar);
                                }
                            }
                            //remove output button data
                            for (int i = memoryData.OutputButtonData.Count - 1; i >= 0; i--)
                            {
                                OutputButtonObjectstruct tar = (OutputButtonObjectstruct)memoryData.OutputButtonData[i];
                                if (tar.site == site && tar.fab == fab)
                                {
                                    memoryData.iconDelTemp.Add(tar.name);
                                    memoryData.OutputButtonData.Remove(tar);
                                }
                            }
                            //remove output text data
                            for (int i = memoryData.OutputTextData.Count - 1; i >= 0; i--)
                            {
                                OutputTextObjectstruct tar = (OutputTextObjectstruct)memoryData.OutputTextData[i];
                                if (tar.site == site && tar.fab == fab)
                                {
                                    memoryData.iconDelTemp.Add(tar.name);
                                    memoryData.OutputTextData.Remove(tar);
                                }
                            }
                            //remove output pop data
                            for (int i = memoryData.OutputPopData.Count - 1; i >= 0; i--)
                            {
                                OutputPopObjectstruct tar = (OutputPopObjectstruct)memoryData.OutputPopData[i];
                                if (tar.site == site && tar.fab == fab)
                                {
                                    memoryData.iconDelTemp.Add(tar.name);
                                    memoryData.OutputPopData.Remove(tar);
                                }
                            }
                            //remove alarm data
                            for (int i = memoryData.AlarmData.Count - 1; i >= 0; i--)
                            {
                                AlarmObjectstruct tar = (AlarmObjectstruct)memoryData.AlarmData[i];
                                if (tar.site == site && tar.fab == fab)
                                {
                                    for (int j = 0; j < memoryData.AlarmMonitorValue.Count; j++)
                                    {
                                        AlarmMoniTorNV mtar = (AlarmMoniTorNV)memoryData.AlarmMonitorValue[j];
                                        if (mtar.name == tar.name)
                                        {
                                            memoryData.AlarmMonitorValue.Remove(mtar);
                                            break;
                                        }
                                    }
                                    memoryData.iconDelTemp.Add(tar.name);
                                    memoryData.AlarmData.Remove(tar);
                                }


                            }
                            DeviceListTree.Nodes.Remove(DeviceListTree.SelectedNode);
                            break;

                        case 2: //delete area

                            site = DeviceListTree.SelectedNode.Parent.Parent.Text;
                            fab = DeviceListTree.SelectedNode.Parent.Text;
                            area = DeviceListTree.SelectedNode.Text;

                            //remove label data
                            for (int i = memoryData.InputData.Count - 1; i >= 0; i--)
                            {
                                InputObjectstruct tar = (InputObjectstruct)memoryData.InputData[i];
                                if (tar.site == site && tar.fab == fab && tar.area == area)
                                {
                                    memoryData.iconDelTemp.Add(tar.name);
                                    memoryData.InputData.Remove(tar);
                                }
                            }
                            //remove output button data
                            for (int i = memoryData.OutputButtonData.Count - 1; i >= 0; i--)
                            {
                                OutputButtonObjectstruct tar = (OutputButtonObjectstruct)memoryData.OutputButtonData[i];
                                if (tar.site == site && tar.fab == fab && tar.area == area )
                                {
                                    memoryData.iconDelTemp.Add(tar.name);
                                    memoryData.OutputButtonData.Remove(tar);
                                }
                            }
                            //remove output text data
                            for (int i = memoryData.OutputTextData.Count - 1; i >= 0; i--)
                            {
                                OutputTextObjectstruct tar = (OutputTextObjectstruct)memoryData.OutputTextData[i];
                                if (tar.site == site && tar.fab == fab && tar.area == area)
                                {
                                    memoryData.iconDelTemp.Add(tar.name);
                                    memoryData.OutputTextData.Remove(tar);
                                }
                            }
                            //remove output pop data
                            for (int i = memoryData.OutputPopData.Count - 1; i >= 0; i--)
                            {
                                OutputPopObjectstruct tar = (OutputPopObjectstruct)memoryData.OutputPopData[i];
                                if (tar.site == site && tar.fab == fab && tar.area == area)
                                {
                                    memoryData.iconDelTemp.Add(tar.name);
                                    memoryData.OutputPopData.Remove(tar);
                                }
                            }
                            //remove alarm data
                            for (int i = memoryData.AlarmData.Count - 1; i >= 0; i--)
                            {
                                AlarmObjectstruct tar = (AlarmObjectstruct)memoryData.AlarmData[i];
                                if (tar.site == site && tar.fab == fab && tar.area == area)
                                {
                                    for (int j = 0; j < memoryData.AlarmMonitorValue.Count; j++)
                                    {
                                        AlarmMoniTorNV mtar = (AlarmMoniTorNV)memoryData.AlarmMonitorValue[j];
                                        if (mtar.name == tar.name)
                                        {
                                            memoryData.AlarmMonitorValue.Remove(mtar);
                                            break;
                                        }
                                    }
                                    memoryData.iconDelTemp.Add(tar.name);
                                    memoryData.AlarmData.Remove(tar);
                                }


                            }
                            DeviceListTree.Nodes.Remove(DeviceListTree.SelectedNode);
                            break;

                        case 3: //delete device

                            site = DeviceListTree.SelectedNode.Parent.Parent.Parent.Text;
                            fab = DeviceListTree.SelectedNode.Parent.Parent.Text;
                            area = DeviceListTree.SelectedNode.Parent.Text;
                            device = DeviceListTree.SelectedNode.Text;
                            ip = DeviceListTree.SelectedNode.ToolTipText;

                            //remove label data
                            for (int i = memoryData.InputData.Count-1; i >= 0 ;i-- )
                            {
                                InputObjectstruct tar = (InputObjectstruct)memoryData.InputData[i];
                                if(tar.ip == ip && tar.site == site && tar.fab == fab && tar.area == area && tar.device == device)
                                {
                                    memoryData.iconDelTemp.Add(tar.name);
                                    memoryData.InputData.Remove(tar);
                                }
                            }
                            //remove output button data
                            for (int i = memoryData.OutputButtonData.Count - 1; i >= 0; i--)
                            {
                                OutputButtonObjectstruct tar = (OutputButtonObjectstruct)memoryData.OutputButtonData[i];
                                if (tar.ip == ip && tar.site == site && tar.fab == fab && tar.area == area && tar.device == device)
                                {
                                    memoryData.iconDelTemp.Add(tar.name);
                                    memoryData.OutputButtonData.Remove(tar);
                                }
                            }
                            //remove output text data
                            for (int i = memoryData.OutputTextData.Count - 1; i >= 0; i--)
                            {
                                OutputTextObjectstruct tar = (OutputTextObjectstruct)memoryData.OutputTextData[i];
                                if (tar.ip == ip && tar.site == site && tar.fab == fab && tar.area == area && tar.device == device)
                                {
                                    memoryData.iconDelTemp.Add(tar.name);
                                    memoryData.OutputTextData.Remove(tar);
                                }
                            }
                            //remove output pop data
                            for (int i = memoryData.OutputPopData.Count - 1; i >= 0; i--)
                            {
                                OutputPopObjectstruct tar = (OutputPopObjectstruct)memoryData.OutputPopData[i];
                                if (tar.ip == ip && tar.site == site && tar.fab == fab && tar.area == area && tar.device == device)
                                {
                                    memoryData.iconDelTemp.Add(tar.name);
                                    memoryData.OutputPopData.Remove(tar);
                                }
                            }
                            //remove alarm data
                            for (int i = memoryData.AlarmData.Count - 1; i >= 0; i--)
                            {
                                AlarmObjectstruct tar = (AlarmObjectstruct)memoryData.AlarmData[i];
                                if (tar.site == site && tar.fab == fab && tar.area == area && tar.device == device)
                                {
                                    if (tar.SourceIP == ip)
                                    {
                                        for (int j = 0; j < memoryData.AlarmMonitorValue.Count; j++)
                                        {
                                            AlarmMoniTorNV mtar = (AlarmMoniTorNV)memoryData.AlarmMonitorValue[j];
                                            if (mtar.name == tar.name)
                                            {
                                                memoryData.AlarmMonitorValue.Remove(mtar);
                                                break;
                                            }
                                        }
                                        memoryData.iconDelTemp.Add(tar.name);
                                        memoryData.AlarmData.Remove(tar);
                                    }
                                    else if (tar.TargetIP == ip)
                                    {
                                        tar.TargetIP = "127.0.0.1";
                                        tar.TargetNVindex = "";
                                        tar.TargetNVName = "";
                                        memoryData.AlarmData[i] = tar;
                                    }
                                }
                                

                            }
                            DeviceListTree.Nodes.Remove(DeviceListTree.SelectedNode);
                                break;


                        //default:

                            //DeviceListTree.Nodes.Remove(DeviceListTree.SelectedNode);
                            //break;

                    }
                }

            }
        }

        private void DeviceCPApply_Click(object sender, EventArgs e)
        {
            if (DeviceListTree.SelectedNode != null)
            {
                addDeviceCMD = "rename";
                Boolean repeat = CheckAddNameNotRepeat(DeviceCPName.Text);

                switch (DeviceListTree.SelectedNode.Level)
                {
                    case 0:
                        if (repeat == false)
                        {
                            DeviceListTree.SelectedNode.Text = DeviceCPName.Text;
                            DeviceListTree.SelectedNode.Name = DeviceCPName.Text;
                        }
                        else
                        { MessageBox.Show("name already in use."); }
                        break;
                    case 1:
                        if (repeat == false)
                        {
                            DeviceListTree.SelectedNode.Text = DeviceCPName.Text;
                            DeviceListTree.SelectedNode.Name = DeviceCPName.Text;
                        }
                        else
                        { MessageBox.Show("name already in use."); }
                        break;
                    case 2:
                        if (repeat == false)
                        {
                            DeviceListTree.SelectedNode.Text = DeviceCPName.Text;
                            DeviceListTree.SelectedNode.Name = DeviceCPName.Text;
                        }
                        else
                        { MessageBox.Show("name already in use."); }
                        break;
                    case 3:
                        if (repeat == false)
                        {
                            DeviceListTree.SelectedNode.Text = DeviceCPName.Text;
                            DeviceListTree.SelectedNode.Name = DeviceCPName.Text;
                            DeviceListTree.SelectedNode.ToolTipText = DeviceCPip.Text;
                        }
                        else
                        { MessageBox.Show("name already in use."); }
                        break;
                    case 4:

                        break;
                    case 5:

                        break;
                }
            }
        }

        private void DeviceCPCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 lForm1 = (Form1)this.Owner;//把Form2的父窗口指針賦給lForm1  
            lForm1.DeviceNode = DeviceListTree;

            //get all smartserver ip
            if (DeviceListTree.Nodes.Count != 0)
            {
                memoryData.SmartserverIP.Clear();

                for (int site = 0; site < DeviceListTree.Nodes.Count; site++)
                {
                    for (int fab = 0; fab < DeviceListTree.Nodes[site].Nodes.Count; fab++)
                    {
                        for (int area = 0; area < DeviceListTree.Nodes[site].Nodes[fab].Nodes.Count; area++)
                        {
                            for (int device = 0; device < DeviceListTree.Nodes[site].Nodes[fab].Nodes[area].Nodes.Count; device++)
                            {
                                string getIP = DeviceListTree.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].ToolTipText;
                                int getIndex = memoryData.SmartserverIP.IndexOf(getIP);
                                if (getIndex == -1)
                                {
                                    memoryData.SmartserverIP.Add(getIP);
                                }

                            }
                        }
                    }
                }
            }

            Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

    }
}
