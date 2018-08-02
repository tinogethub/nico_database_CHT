using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace nico_database
{
    public partial class config_InputTagObject : Form
    {
        public string NVType = "";
        public string LabelName;
        public float showValue = 0;
        public float show2 = 0;
        public string targetip = "";
        public string monitorType = "";
        public Boolean load = false;
        public string loadValue;
        public string loadNV;

        public config_InputTagObject()
        {
            InitializeComponent();
        }

        private void FontCMD_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.ShowColor = true;
            fd.Font = previewLab.Font;
            fd.Color = previewLab.ForeColor;
            try
            {
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    previewLab.Font = fd.Font;
                    previewLab.ForeColor = fd.Color;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void ColorCMD_Click(object sender, EventArgs e)
        {
            ColorDialog mycolor = new ColorDialog();
            mycolor.Color = previewLab.BackColor;
            if (mycolor.ShowDialog() == DialogResult.OK)
            {
                previewLab.BackColor = mycolor.Color;
            }
        }

        private void config_InputTagObject_Load(object sender, EventArgs e)
        {
            formatList.SelectedIndex = 0;
            Labtext.ForeColor = Color.DarkRed;
            Labtext.BackColor = Color.White;

            //TreeNode[] arr1 = deviceList.Nodes.Find("proportional_f", true);
            //for (int i = 0; i < arr1.Length; i++) { deviceList.SelectedNode = arr1[i]; deviceList.SelectedNode.Remove(); }
            //TreeNode[] arr2 = deviceList.Nodes.Find("UCPTproportional_f", true);
            //for (int i = 0; i < arr2.Length; i++) { deviceList.SelectedNode = arr2[i]; deviceList.SelectedNode.Remove(); }
            //TreeNode[] arr3 = deviceList.Nodes.Find("nciProportion_A", true);
            //for (int i = 0; i < arr3.Length; i++) { deviceList.SelectedNode = arr3[i]; deviceList.SelectedNode.Remove(); }
            //TreeNode[] arr4 = deviceList.Nodes.Find("proportion_A", true);
            //for (int i = 0; i < arr4.Length; i++) { deviceList.SelectedNode = arr4[i]; deviceList.SelectedNode.Remove(); }

            for (int site = 0; site < deviceList.Nodes.Count; site++)
            {
                for (int fab = 0; fab < deviceList.Nodes[site].Nodes.Count; fab++)
                {
                    for (int area = 0; area < deviceList.Nodes[site].Nodes[fab].Nodes.Count; area++)
                    {
                        for (int device = 0; device < deviceList.Nodes[site].Nodes[fab].Nodes[area].Nodes.Count; device++)
                        {
                            if (deviceList.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Tag.ToString() == "lon")
                            {
                                for (int obj = 0; obj < deviceList.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes.Count; obj++)
                                {
                                    for (int nv = deviceList.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes[obj].Nodes.Count-1; nv >=0 ; nv--)
                                    {
                                        //string[] chk = deviceList.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes[obj].Nodes[nv].Text.Split('#');
                                        //if (chk[0] == "UCPTproportional_f" || chk[0] == "proportional_f" || chk[0]=="nciProportion_A" || chk[0]=="proportion_A")
                                        //{
                                        //    deviceList.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes[obj].Nodes[nv].Remove();
                                        //}

                                        string[] tempNVType = deviceList.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes[obj].Nodes[nv].Tag.ToString().Split('#');

                                        if (tempNVType[0] != NVType)
                                            //if (deviceList.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes[obj].Nodes[nv].Tag.ToString() != NVType)
                                        {
                                            deviceList.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes[obj].Nodes[nv].Remove();
                                        }
                                        else if (deviceList.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes[obj].Nodes[nv].Tag.ToString() == NVType)
                                        {
                                            if (deviceList.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes[obj].Text != "VirtFb")
                                            {
                                                string snvt = deviceList.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes[obj].Nodes[nv].Text.Substring(0, 3);
                                                if (snvt != "nvo")
                                                {
                                                    deviceList.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes[obj].Nodes[nv].Remove();
                                                }
                                                else
                                                {
                                                    deviceList.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes[obj].Nodes[nv].Tag = deviceList.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes[obj].Nodes[nv].FullPath.ToString();
                                                }
                                            }
                                            
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            deviceList.CollapseAll();

            for (int i = 0; i < memoryData.InputData.Count; i++)
            {
                InputObjectstruct ol = (InputObjectstruct)memoryData.InputData[i];

                if (ol.name == LabelName)
                {
                    textX.Text = ol.x.ToString();
                    textY.Text = ol.y.ToString();
                    previewLab.Font = ol.font;
                    previewLab.ForeColor = Color.FromArgb(ol.forecolor );
                    previewLab.BackColor = Color.FromArgb(ol.backcolor);
                    previewLab.BorderStyle = ol.border;
                    if (ol.logdata == true)
                    {
                        LogUse.Checked = true;
                        LogTime.Text = ol.logtime.ToString();
                    }
                    else
                    {
                        LogUse.Checked = false;
                    }

                     lonPollTime.Text = ol.lonPolltime.ToString();

                     if (ol.NVtype == "SNVT_switch")
                     {
                         previewLab.Text = ol.showvalue;
                     }
                     else if (ol.NVtype == "SNVT_occupancy")
                     {
                         previewLab.Text = ol.showvalue;
                     }
                     else
                     {
                         string[] num = ol.value.Split('@');
                         if (num.Length == 1)
                         {
                             showValue = float.Parse(ol.value);
                             previewLab.Text = showValue.ToString(ol.stringFormat);
                         }
                         else if (num.Length == 2)
                         {
                             
                             show2 = float.Parse(ol.value);
                             previewLab.Text = show2.ToString(ol.stringFormat);
                         }

                         
                         //previewLab.Text = showValue.ToString("G");
                         //previewLab.Text = showValue.ToString(ol.stringFormat);
                     }


                     //previewLab.Text = showValue.ToString(ol.stringFormat);


                     if (ol.stringFormat == "G" || ol.stringFormat == "")
                     { formatList.SelectedIndex = 0; }
                     else if (ol.stringFormat == "0")
                     { formatList.SelectedIndex = 1; }
                     else if (ol.stringFormat == "0.0")
                     { formatList.SelectedIndex = 2; }
                     else if (ol.stringFormat == "0.00")
                     { formatList.SelectedIndex = 3; }
                     else if (ol.stringFormat == "#,##0")
                     { formatList.SelectedIndex = 4; }
                     else if (ol.stringFormat == "#,##0.00")
                     { formatList.SelectedIndex = 5; }
                     else { formatList.SelectedIndex = 6; formatUser.Text = ol.stringFormat; }

                     load = true;
                     loadNV = ol.NVtype;
                     loadValue = ol.value;

                    //ol.value;
                    //ol.stringFormat;
                     description.Text = ol.description;
                    Labtext.Text = ol.target;
                    targetindex.Text = ol.targetindex;
                    if (ol.target != "")
                    {
                        string[] index = ol.targetindex.Split('_');
                        deviceList.SelectedNode = deviceList.Nodes[int.Parse(index[0])].Nodes[int.Parse(index[1])].Nodes[int.Parse(index[2])].Nodes[int.Parse(index[3])].Nodes[int.Parse(index[4])].Nodes[int.Parse(index[5])];
                    }
                    else
                    {
                        deviceList.SelectedNode = deviceList.Nodes[0].Nodes[0].Nodes[0];
                        deviceList.Nodes[0].Expand();
                        deviceList.Nodes[0].Nodes[0].Expand();
                        deviceList.Nodes[0].Nodes[0].Nodes[0].Expand();
                    }
                    

                    if (ol.unituse == true)
                    {
                        checkUnit.Checked = true;
                        unitList.Text = ol.unit;
                        previewLab.Text = showValue.ToString(ol.stringFormat) + " " + unitList.Text;
                    }
                    else
                    {
                        checkUnit.Checked = false;
                    }
                    



                    if (ol.border.ToString() == "None") { borderStyle.SelectedIndex = 0; }
                    else if (ol.border.ToString() == "FixedSingle") { borderStyle.SelectedIndex = 1; }
                    else if (ol.border.ToString() == "Fixed3D") { borderStyle.SelectedIndex = 2; }
                }
            }
            

            deviceList.Select();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 lForm1 = (Form1)this.Owner;//把Form2的父窗口指針賦給lForm1  
            lForm1.Relab = null;
            Close();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (deviceList.SelectedNode.Level == 5)
            {
                previewLab.Tag = textX.Text + "_" + textY.Text;

                Form1 lForm1 = (Form1)this.Owner;//把Form2的父窗口指針賦給lForm1  
                lForm1.Relab = previewLab;
                lForm1.Gettooltip = description.Text;

                for (int i = 0; i < memoryData.InputData.Count; i++)
                {
                    InputObjectstruct getstr = (InputObjectstruct)memoryData.InputData[i];

                    if (getstr.name == LabelName)
                    {
                        getstr.forecolor = previewLab.ForeColor.ToArgb();
                        getstr.font = previewLab.Font;
                        getstr.backcolor = previewLab.BackColor.ToArgb();
                        getstr.border = previewLab.BorderStyle;
                        getstr.x = int.Parse(textX.Text);
                        getstr.y = int.Parse(textY.Text);
                        getstr.ip = targetip;

                        if (lonPollTime.Text != "0")
                        {
                            //if (lonPollTime.Text != "")
                            getstr.lonPolltime = int.Parse(lonPollTime.Text);
                        }
                        else
                        {
                            getstr.lonPolltime = 600;
                        }

                        getstr.stringFormat = formatUser.Text;
                        getstr.NVtype = NVType;
                        getstr.showvalue = previewLab.Text;
                        getstr.description = description.Text;

                        if (LogUse.Checked == true) { getstr.logdata = true; getstr.logtime = int.Parse(LogTime.Text); }
                        else if (LogNot.Checked == true) { getstr.logdata = false; getstr.logtime = 0; }

                        if (checkUnit.Checked == true) { getstr.unituse = true; getstr.unit = unitList.Text; }
                        else { getstr.unituse = false; getstr.unit = ""; }

                        if (NVType == "SNVT_switch")
                        {
                            getstr.unituse = false; getstr.unit = ""; getstr.stringFormat = "";
                        }
                        else if (NVType == "SNVT_occupancy")
                        {
                            getstr.unituse = false; getstr.unit = ""; getstr.stringFormat = "";
                        }
                                                                        

                        if (Labtext.Text != "")
                        {
                            getstr.target = Labtext.Text;
                            getstr.targetindex = targetindex.Text;
                            string[] getpath = deviceList.SelectedNode.FullPath.ToString().Split('\\');
                            getstr.area = getpath[2];
                            getstr.fab = getpath[1];
                            getstr.site = getpath[0];
                            getstr.device = getpath[3];
                            getstr.function = getpath[4];
                            getstr.NV = getpath[5];
                        }
                        else
                        {
                            getstr.target = "";
                            getstr.targetindex = "";
                            getstr.area = "";
                            getstr.fab = "";
                            getstr.site = "";
                            getstr.device = "";
                            getstr.function = "";
                            getstr.NV = "";
                        }

                        string[] gettemp = Labtext.Text.Split('@');

                        getstr.potocol = gettemp[0]; //monitorType;
                        getstr.count = 0;
                        memoryData.InputData[i] = getstr;
                        
                        break;
                    }
                }

                this.Close();  
            }
        }

        private void checkUnit_CheckedChanged(object sender, EventArgs e)
        {
            if (checkUnit.Checked == true) 
            { unitList.Enabled = true; unitList.SelectedIndex = 0;
            previewLab.Text = showValue.ToString(formatUser.Text) + " " + unitList.Text;
            }
            else if 
            (checkUnit.Checked == false) 
            { unitList.Enabled = false;
            previewLab.Text = showValue.ToString(formatUser.Text);
            }
        }

        private void LogUse_CheckedChanged(object sender, EventArgs e)
        {
            if (LogUse.Checked == true) 
            { 
                LogTime.Enabled = true; 
                label5.Enabled = true; 
            }
            else if (LogNot.Checked == true) 
            { 
                LogTime.Enabled = false; 
                label5.Enabled = false; 
            }
        }

        private void borderStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (borderStyle.SelectedIndex == 0) { previewLab.BorderStyle = BorderStyle.None; }
            else if (borderStyle.SelectedIndex == 1) { previewLab.BorderStyle = BorderStyle.FixedSingle; }
            else if (borderStyle.SelectedIndex == 2) { previewLab.BorderStyle = BorderStyle.Fixed3D; }
        }

        private void deviceList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (deviceList.SelectedNode != null && deviceList.SelectedNode.Level == 5)
            {
                int site, fab, area, device, obj, nv;
                nv = deviceList.SelectedNode.Index;
                obj = deviceList.SelectedNode.Parent.Index;
                device = deviceList.SelectedNode.Parent.Parent.Index;
                area = deviceList.SelectedNode.Parent.Parent.Parent.Index;
                fab = deviceList.SelectedNode.Parent.Parent.Parent.Parent.Index;
                site = deviceList.SelectedNode.Parent.Parent.Parent.Parent.Parent.Index;
                targetindex.Text = site.ToString() + "_" + fab.ToString() + "_" + area.ToString() + "_" + device.ToString() + "_" + obj.ToString() + "_" + nv.ToString();
                targetip = deviceList.SelectedNode.Parent.Parent.ToolTipText;

                string deviceType = deviceList.SelectedNode.Parent.Parent.Tag.ToString();
                string deviceIp = deviceList.SelectedNode.Parent.Parent.ToolTipText;
                if (deviceType == "nico")
                {
                    Labtext.Text = deviceType + "@" + deviceIp + "@" + deviceList.SelectedNode.Parent.Parent.Text +
                        deviceList.SelectedNode.Parent.Text + deviceList.SelectedNode.Text;
                    monitorType = "nico";
                    smartserverLab.Visible = false;
                    lonPollTime.Visible = false;
                    smartserverLab2.Visible = false;
                }
                else if (deviceType == "lon")
                {
                    Labtext.Text = deviceType + "@" + deviceIp + "@Net/LON/" + deviceList.SelectedNode.Parent.Parent.Text +
                      "/"+ deviceList.SelectedNode.Parent.Text+ "/" + deviceList.SelectedNode.Text;
                    monitorType = "lon";
                    smartserverLab.Visible = true;
                    lonPollTime.Visible = true;
                    smartserverLab2.Visible = true;

                    if (NVType == "SNVT_switch")
                    {
                        formatList.SelectedIndex = 0;
                        formatList.Enabled = false;
                        formatUser.Text = "SNVT_switch";
                        formatUser.Enabled = false;
                        previewLab.Text = "100.0 1";
                    }
                    else if (NVType == "SNVT_occupancy")
                    {
                        formatList.SelectedIndex = 0;
                        formatList.Enabled = false;
                        formatUser.Text = "SNVT_occupancy";
                        formatUser.Enabled = false;
                        previewLab.Text = "occupancy";
                    }
                    else
                    {
                        formatList.Enabled = true;
                        formatUser.Enabled = true;
                        //formatList.SelectedIndex = 0;
                    }

                }
            }
            else
            {
                Labtext.Text = "";
                targetindex.Text = "";
            }
        }

        private void formatList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //formatUser.Text
            
            if (formatList.Text == "General") 
            { 
                formatUser.Text = "G";
                formatUser.ReadOnly = true;
                formatUser.ForeColor = SystemColors.WindowText;
                formatUser.BackColor = SystemColors.Window;
                previewLab.Text = showValue.ToString("G");
            }
            else if (formatList.Text == "-1234") 
            { 
                formatUser.Text = "0";
                formatUser.ReadOnly = true;
                formatUser.ForeColor = SystemColors.WindowText;
                formatUser.BackColor = SystemColors.Window;
                previewLab.Text = showValue.ToString("0");
            }
            else if (formatList.Text == "-1234.1")
            {
                formatUser.Text = "0.0";
                formatUser.ReadOnly = true;
                formatUser.ForeColor = SystemColors.WindowText;
                formatUser.BackColor = SystemColors.Window;
                previewLab.Text = showValue.ToString("0.0");
            }
            else if (formatList.Text == "-1234.12")
            { 
                formatUser.Text = "0.00";
                formatUser.ReadOnly = true;
                formatUser.ForeColor = SystemColors.WindowText;
                formatUser.BackColor = SystemColors.Window;
                previewLab.Text = showValue.ToString("0.00");
            }
            else if (formatList.Text == "-1,234") 
            { 
                formatUser.Text = "#,##0";
                formatUser.ReadOnly = true;
                formatUser.ForeColor = SystemColors.WindowText;
                formatUser.BackColor = SystemColors.Window;
                previewLab.Text = showValue.ToString("#,##0");
            }
            else if (formatList.Text == "-1,234.12") 
            { 
                formatUser.Text = "#,##0.00";
                formatUser.ReadOnly = true;
                formatUser.ForeColor = SystemColors.WindowText;
                formatUser.BackColor = SystemColors.Window;
                previewLab.Text = showValue.ToString("#,##0.00");
            }
            else if (formatList.Text == "Customize") 
            {
                formatUser.Text = "";
                formatUser.ReadOnly = false;
                formatUser.ForeColor = SystemColors.WindowText;
                formatUser.BackColor = SystemColors.Window;
                string cf = formatUser.Text;
                if (cf != "")
                {
                    previewLab.Text = showValue.ToString(cf);
                }
                else { previewLab.Text = showValue.ToString("G"); }
            }
            if (checkUnit.Checked == true)
            {
                previewLab.Text = previewLab.Text + unitList.Text ;
            }
        }

        private void formatUser_KeyUp(object sender, KeyEventArgs e)
        {
            string cf = formatUser.Text;
            if (checkUnit.Checked == true)
            {
                previewLab.Text = showValue.ToString(cf) + " " + unitList.Text;
            }
            else
            {
                previewLab.Text = showValue.ToString(cf);
            }
            
        }

        private void unitList_SelectedIndexChanged(object sender, EventArgs e)
        {
            previewLab.Text = showValue.ToString(formatUser.Text) + " " + unitList.Text;
        }

        private void lonPollTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 | (int)e.KeyChar > 57) & (int)e.KeyChar!=8)
              {
                e.Handled = true;
              }
        }

        
    }
}
