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
    public partial class config_AlarmObject : Form
    {
        public TreeView deviceTree = new TreeView();
        public TreeView deviceTreeLoad = new TreeView();
        
        public string AlarmName = "";
        public string NVType = "";
        public string NVTagType = "";
        private string targetip = "";
        private string sourceip = "";
        private string logicTrueAudio = "";
        private string logicFalseAudio = "";
        private string logicTrueImage = "";
        private string logicFalseImage = "";
        System.Media.SoundPlayer soundplay = new System.Media.SoundPlayer();
        ToolTip outNVtip = new ToolTip();

        private Font showTrueValue;
        private Font showFalseValue;
        private Int32 showTrueValueColor;
        private Int32 showFalseValueColor;
         
        public config_AlarmObject()
        {
            InitializeComponent();
        }

        private void radTargetTypeVal_CheckedChanged(object sender, EventArgs e)
        {
            if (radTargetTypeVal.Checked == true)
            {
                textTargetValue.Enabled = true;
                treeTarget.Enabled = false;
                treeTarget.BackColor = SystemColors.Control;
                textTarget.Enabled = false;
                logicList.Items.Clear();
                

                if (NVType == "SNVT_switch")
                {
                    textTargetPreset.Items.Clear();
                    textTargetValue.Enabled = true;
                    textTargetPreset.Enabled = false;
                    logicList.Items.Add("<");
                    logicList.Items.Add("<=");
                    logicList.Items.Add("==");
                    logicList.Items.Add("!=");
                    logicList.Items.Add(">=");
                    logicList.Items.Add(">");
                    logicList.Items.Add("~");
                }
                else if (NVType == "SNVT_occupancy")
                {
                    textTargetPreset.Items.Clear();
                    textTargetValue.Enabled = false;
                    textTargetPreset.Enabled = true;
                    textTargetPreset.Items.Add("OC_OCCUPIED");
                    textTargetPreset.Items.Add("OC_UNOCCUPIED");
                    textTargetPreset.Items.Add("OC_STANDBY");
                    logicList.Items.Add("==");
                    logicList.Items.Add("!=");
                }
                else
                {
                    textTargetPreset.Items.Clear();
                    textTargetValue.Enabled = true;
                    textTargetPreset.Enabled = false;
                    logicList.Items.Add("<");
                    logicList.Items.Add("<=");
                    logicList.Items.Add("==");
                    logicList.Items.Add("!=");
                    logicList.Items.Add(">=");
                    logicList.Items.Add(">");
                    logicList.Items.Add("~");
                }

                if (logicList.Text == "~")
                {
                    textTargetValue.Enabled = false;
                    textTargetPreset.Enabled = false;
                }


            }
            else if(radTargetTypeTag.Checked==true)
            {
                textTargetValue.Enabled = false;
                treeTarget.Enabled = true;
                treeTarget.BackColor = SystemColors.Window;
                textTarget.Enabled = true;
                logicList.Items.Clear();


                if (NVType == "SNVT_switch")
                {
                    textTargetPreset.Items.Clear();
                    //textTargetValue.Enabled = true;
                    textTargetPreset.Enabled = false;
                    logicList.Items.Add("<");
                    logicList.Items.Add("<=");
                    logicList.Items.Add("==");
                    logicList.Items.Add("!=");
                    logicList.Items.Add(">=");
                    logicList.Items.Add(">");
                }
                else if (NVType == "SNVT_occupancy")
                {
                    textTargetPreset.Items.Clear();
                    textTargetValue.Enabled = false;
                    textTargetPreset.Enabled = true;
                    textTargetPreset.Items.Add("OC_OCCUPIED");
                    textTargetPreset.Items.Add("OC_UNOCCUPIED");
                    textTargetPreset.Items.Add("OC_STANDBY");
                    logicList.Items.Add("==");
                    logicList.Items.Add("!=");
                }
                else
                {
                    textTargetPreset.Items.Clear();
                    textTargetValue.Enabled = true;
                    textTargetPreset.Enabled = false;
                    logicList.Items.Add("<");
                    logicList.Items.Add("<=");
                    logicList.Items.Add("==");
                    logicList.Items.Add("!=");
                    logicList.Items.Add(">=");
                    logicList.Items.Add(">");
                    logicList.Items.Add("~");
                }
                
            }
        }

        private void logicList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (logicList.SelectedIndex == 6)
            {
                logicMin.Enabled = true;
                logicMax.Enabled = true;
                textTargetValue.Enabled = false;
            }
            else
            {
                logicMin.Enabled = false;
                logicMax.Enabled = false;
                textTargetValue.Enabled = true;
            }
        }

        private void treeSource_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeSource.SelectedNode != null && treeSource.SelectedNode.Level == 5 && NVType !="device")
            {
                int site, fab, area, device, obj, nv;
                nv = treeSource.SelectedNode.Index;
                obj = treeSource.SelectedNode.Parent.Index;
                device = treeSource.SelectedNode.Parent.Parent.Index;
                area = treeSource.SelectedNode.Parent.Parent.Parent.Index;
                fab = treeSource.SelectedNode.Parent.Parent.Parent.Parent.Index;
                site = treeSource.SelectedNode.Parent.Parent.Parent.Parent.Parent.Index;

                sourceip = treeSource.SelectedNode.Parent.Parent.ToolTipText;

                string deviceType = treeSource.SelectedNode.Parent.Parent.Tag.ToString();
                string deviceIp = treeSource.SelectedNode.Parent.Parent.ToolTipText;
                
                textSource.Tag = site.ToString() + "_" + fab.ToString() + "_" + area.ToString() + "_" + device.ToString() + "_" + obj.ToString() + "_" + nv.ToString();
                        //textSource.Text = treeSource.SelectedNode.FullPath;
                if (deviceType == "nico")
                {
                           // textSource.Text = deviceType + "@" + deviceIp + "@" + treeSource.SelectedNode.Parent.Parent.Text +
                           //     treeSource.SelectedNode.Parent.Text + treeSource.SelectedNode.Text;
                           // NVType = "nico";
                }
                else if (deviceType == "lon")
                {
                            textSource.Text = deviceType + "@" + deviceIp + "@Net/LON/" + treeSource.SelectedNode.Parent.Parent.Text +
                              "/" + treeSource.SelectedNode.Parent.Text + "/" + treeSource.SelectedNode.Text;
                            //NVType = "lon";
                }
                
            }
            else if (treeSource.SelectedNode != null && treeSource.SelectedNode.Level == 3 && NVType == "device")
            {
                int site, fab, area, device;
                device = treeSource.SelectedNode.Index;
                area = treeSource.SelectedNode.Parent.Index;
                fab = treeSource.SelectedNode.Parent.Parent.Index;
                site = treeSource.SelectedNode.Parent.Parent.Parent.Index;

                sourceip = treeSource.SelectedNode.ToolTipText;
                string deviceType = treeSource.SelectedNode.Tag.ToString();
                string deviceIp = treeSource.SelectedNode.ToolTipText;

                textSource.Tag = site.ToString() + "_" + fab.ToString() + "_" + area.ToString() + "_" + device.ToString() ;
                
                if (deviceType == "nico")
                {
                    // textSource.Text = deviceType + "@" + deviceIp + "@" + treeSource.SelectedNode.Parent.Parent.Text +
                    //     treeSource.SelectedNode.Parent.Text + treeSource.SelectedNode.Text;
                    // NVType = "nico";
                }
                else if (deviceType == "lon")
                {
                    textSource.Text = deviceType + "@" + deviceIp + "@Net/LON/" + treeSource.SelectedNode.Text;// +"/NodeObject/nviRequest";
                    //NVType = "lon";
                }
            }
            else
            {
                textSource.Text = "";
                textSource.Tag = "";
            }
        }

        private void treeTarget_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeTarget.SelectedNode != null && treeTarget.SelectedNode.Level == 5 && NVType != "device")
            {
                int site, fab, area, device, obj, nv;
                nv = treeTarget.SelectedNode.Index;
                obj = treeTarget.SelectedNode.Parent.Index;
                device = treeTarget.SelectedNode.Parent.Parent.Index;
                area = treeTarget.SelectedNode.Parent.Parent.Parent.Index;
                fab = treeTarget.SelectedNode.Parent.Parent.Parent.Parent.Index;
                site = treeTarget.SelectedNode.Parent.Parent.Parent.Parent.Parent.Index;

                targetip = treeTarget.SelectedNode.Parent.Parent.ToolTipText;
                string deviceType = treeTarget.SelectedNode.Parent.Parent.Tag.ToString();
                string deviceIp = treeTarget.SelectedNode.Parent.Parent.ToolTipText;

                textTarget.Tag = site.ToString() + "_" + fab.ToString() + "_" + area.ToString() + "_" + device.ToString() + "_" + obj.ToString() + "_" + nv.ToString();
                //textTarget.Text = treeTarget.SelectedNode.FullPath;
                if (deviceType == "nico")
                {
                    // textTarget.Text = deviceType + "@" + deviceIp + "@" + treeTarget.SelectedNode.Parent.Parent.Text +
                    //     treeTarget.SelectedNode.Parent.Text + treeTarget.SelectedNode.Text;
                    // NVType = "nico";
                }
                else if (deviceType == "lon")
                {
                    textTarget.Text = deviceType + "@" + deviceIp + "@Net/LON/" + treeTarget.SelectedNode.Parent.Parent.Text +
                      "/" + treeTarget.SelectedNode.Parent.Text + "/" + treeTarget.SelectedNode.Text;
                    //NVType = "lon";
                }

            }
            else if (treeTarget.SelectedNode != null && treeTarget.SelectedNode.Level == 3 && NVType == "device")
            {
                int site, fab, area, device;
                device = treeTarget.SelectedNode.Index;
                area = treeTarget.SelectedNode.Parent.Index;
                fab = treeTarget.SelectedNode.Parent.Parent.Index;
                site = treeTarget.SelectedNode.Parent.Parent.Parent.Index;

                targetip = treeTarget.SelectedNode.ToolTipText;
                string deviceType = treeTarget.SelectedNode.Tag.ToString();
                string deviceIp = treeTarget.SelectedNode.ToolTipText;

                textTarget.Tag = site.ToString() + "_" + fab.ToString() + "_" + area.ToString() + "_" + device.ToString();

                if (deviceType == "nico")
                {
                    // textTarget.Text = deviceType + "@" + deviceIp + "@" + treeTarget.SelectedNode.Parent.Parent.Text +
                    //     treeTarget.SelectedNode.Parent.Text + treeTarget.SelectedNode.Text;
                    // NVType = "nico";
                }
                else if (deviceType == "lon")
                {
                    textTarget.Text = deviceType + "@" + deviceIp + "@Net/LON/" + treeTarget.SelectedNode.Text + "/NodeObject/nviRequest";
                    //NVType = "lon";
                }
            }
            else
            {
                textTarget.Text = "";
                textTarget.Tag = "";
            }
        }

        private void config_AlarmObject_Load(object sender, EventArgs e)
        {
            //output nv tooltip
            outNVtip.AutoPopDelay = 5000;
            outNVtip.InitialDelay = 500;
            outNVtip.ReshowDelay = 500;
            outNVtip.ShowAlways = true;
            outNVtip.SetToolTip(this.TrueOutNV1, TrueOutNV1.Tag.ToString());
            outNVtip.SetToolTip(this.TrueOutNV2, TrueOutNV2.Tag.ToString());
            outNVtip.SetToolTip(this.TrueOutNV3, TrueOutNV3.Tag.ToString());
            outNVtip.SetToolTip(this.TrueOutNV4, TrueOutNV4.Tag.ToString());
            outNVtip.SetToolTip(this.TrueOutNV5, TrueOutNV5.Tag.ToString());
            outNVtip.SetToolTip(this.TrueOutNV6, TrueOutNV6.Tag.ToString());
            outNVtip.SetToolTip(this.TrueOutNV7, TrueOutNV7.Tag.ToString());
            outNVtip.SetToolTip(this.TrueOutNV8, TrueOutNV8.Tag.ToString());
            outNVtip.SetToolTip(this.FalseOutNV1, FalseOutNV1.Tag.ToString());
            outNVtip.SetToolTip(this.FalseOutNV2, FalseOutNV2.Tag.ToString());
            outNVtip.SetToolTip(this.FalseOutNV3, FalseOutNV3.Tag.ToString());
            outNVtip.SetToolTip(this.FalseOutNV4, FalseOutNV4.Tag.ToString());
            outNVtip.SetToolTip(this.FalseOutNV5, FalseOutNV5.Tag.ToString());
            outNVtip.SetToolTip(this.FalseOutNV6, FalseOutNV6.Tag.ToString());
            outNVtip.SetToolTip(this.FalseOutNV7, FalseOutNV7.Tag.ToString());
            outNVtip.SetToolTip(this.FalseOutNV8, FalseOutNV8.Tag.ToString());

            if (NVType == "device")
            {
                treeTarget.Enabled = false;
                textTarget.Enabled = false;
                groupSetlogic.Enabled = false;
                groupTrue.Text = "Device offline";
                imageTrue.Visible = false;
                groupFalse.Text = "Device online";
                imageFalse.Visible = false;

                //load device source tree
                for (int site = 0; site < deviceTreeLoad.Nodes.Count; site++)
                {
                    for (int fab = 0; fab < deviceTreeLoad.Nodes[site].Nodes.Count; fab++)
                    {
                        for (int area = 0; area < deviceTreeLoad.Nodes[site].Nodes[fab].Nodes.Count; area++)
                        {
                            for (int device = 0; device < deviceTreeLoad.Nodes[site].Nodes[fab].Nodes[area].Nodes.Count; device++)
                            {
                                for (int obj = deviceTreeLoad.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes.Count-1; obj >= 0; obj--)
                                    {
                                        deviceTreeLoad.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes[obj].Remove();
                                    }
                            }
                        }
                    }
                }
                //deviceTreeLoad.CollapseAll();
                foreach (TreeNode node in deviceTreeLoad.Nodes)
                {
                    treeSource.Nodes.Add((TreeNode)node.Clone());
                    treeTarget.Nodes.Add((TreeNode)node.Clone());
                }

            }
            else
            {
                treeTarget.Enabled = true;
                textTarget.Enabled = true;
                groupSetlogic.Enabled = true;
                groupTrue.Text = "Logic = True";
                imageTrue.Visible = true;
                groupFalse.Text = "Logic = False";
                imageFalse.Visible = true;

                //load device source tree
                for (int site = 0; site < deviceTreeLoad.Nodes.Count; site++)
                {
                    for (int fab = 0; fab < deviceTreeLoad.Nodes[site].Nodes.Count; fab++)
                    {
                        for (int area = 0; area < deviceTreeLoad.Nodes[site].Nodes[fab].Nodes.Count; area++)
                        {
                            for (int device = 0; device < deviceTreeLoad.Nodes[site].Nodes[fab].Nodes[area].Nodes.Count; device++)
                            {
                                if (deviceTreeLoad.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Tag.ToString() == "lon")
                                {
                                    for (int obj = 0; obj < deviceTreeLoad.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes.Count; obj++)
                                    {
                                        for (int nv = deviceTreeLoad.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes[obj].Nodes.Count - 1; nv >= 0; nv--)
                                        {

                                            if (deviceTreeLoad.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes[obj].Nodes[nv].Tag.ToString() != NVType)
                                            {
                                                deviceTreeLoad.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes[obj].Nodes[nv].Remove();
                                            }
                                            else if (deviceTreeLoad.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes[obj].Nodes[nv].Tag.ToString() == NVType)
                                            {

                                                if (deviceTreeLoad.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes[obj].Text != "VirtFb")
                                                {
                                                    string snvt = deviceTreeLoad.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes[obj].Nodes[nv].Text.Substring(0, 3);
                                                    if (snvt != "nvo")
                                                    {
                                                        deviceTreeLoad.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes[obj].Nodes[nv].Remove();
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
                //deviceTreeLoad.CollapseAll();

                foreach (TreeNode node in deviceTreeLoad.Nodes)
                {
                    treeSource.Nodes.Add((TreeNode)node.Clone());
                    treeTarget.Nodes.Add((TreeNode)node.Clone());
                }

            }
            treeSource.CollapseAll();
            treeTarget.CollapseAll();

            //search data
            string gfname = "";
            string gtname = "";
            for (int i = 0; i < memoryData.AlarmData.Count; i++)
            {
                AlarmObjectstruct tar = (AlarmObjectstruct)memoryData.AlarmData[i];
                if (tar.name == AlarmName)
                {
                    gtname = tar.AlarmTrueMailgroup;
                    gfname = tar.AlarmFalseMailgroup;

                    targetip = tar.TargetIP;
                    sourceip = tar.SourceIP;
                    if (tar.NVType != "")
                    {
                        NVType = tar.NVType;
                    }

                    //load group contact list
                    for (int ii = 0; ii < memoryData.GroupContact2.Count; ii++)
                    {
                        ContactGroup2 tarcon = (ContactGroup2)memoryData.GroupContact2[ii];
                        trueGroupContact.Items.Add(tarcon.groupname);
                        falseGroupContact.Items.Add(tarcon.groupname);
                    }

                    trueGroupContact.Text = gtname;
                    falseGroupContact.Text = gfname;
                    
                    textSource.Text = tar.SourceNVName;
                    textSource.Tag = tar.SourceNVindex;
                    if (tar.SourceNVindex != "")
                    {
                        string[] ind = tar.SourceNVindex.Split('_');
                        if (NVType == "device")
                        {
                            //sel node site-fab-area-device
                            treeSource.SelectedNode = treeSource.Nodes[int.Parse(ind[0])].Nodes[int.Parse(ind[1])].Nodes[int.Parse(ind[2])].Nodes[int.Parse(ind[3])];
                        }
                        else
                        {
                            //sel node site-fab-area-device-object-nv
                            treeSource.SelectedNode = treeSource.Nodes[int.Parse(ind[0])].Nodes[int.Parse(ind[1])].Nodes[int.Parse(ind[2])].Nodes[int.Parse(ind[3])].Nodes[int.Parse(ind[4])].Nodes[int.Parse(ind[5])];
                        }
                    }

                    textTarget.Text = tar.TargetNVName;
                    textTarget.Tag = tar.TargetNVindex;
                    if (NVType != "device")
                    {

                        if (tar.TargetNVindex != "")
                        {
                            string[] ind = tar.TargetNVindex.Split('_');
                            //sel node
                            treeTarget.SelectedNode = treeTarget.Nodes[int.Parse(ind[0])].Nodes[int.Parse(ind[1])].Nodes[int.Parse(ind[2])].Nodes[int.Parse(ind[3])].Nodes[int.Parse(ind[4])].Nodes[int.Parse(ind[5])];
                        }
                    }

                    if (tar.CompareType == "tag")
                    {
                        radTargetTypeTag.Checked = true;
                    }
                    else if (tar.CompareType == "value")
                    {
                        radTargetTypeVal.Checked = true;
                    }

                    if (NVType == "SNVT_switch")
                    {
                        logicList.Items.Clear();
                        textTargetPreset.Items.Clear();
                        textTargetValue.Enabled = true;
                        textTargetPreset.Enabled = false;
                        logicList.Items.Add("<");
                        logicList.Items.Add("<=");
                        logicList.Items.Add("==");
                        logicList.Items.Add("!=");
                        logicList.Items.Add(">=");
                        logicList.Items.Add(">");
                        logicList.Items.Add("~");
                    }
                    else if (NVType == "SNVT_occupancy")
                    {
                        logicList.Items.Clear();
                        textTargetPreset.Items.Clear();
                        textTargetValue.Enabled = false;
                        textTargetPreset.Enabled = true;
                        textTargetPreset.Items.Add("OC_OCCUPIED");
                        textTargetPreset.Items.Add("OC_UNOCCUPIED");
                        textTargetPreset.Items.Add("OC_STANDBY");
                        logicList.Items.Add("==");
                        logicList.Items.Add("!=");
                        textTargetPreset.Text = tar.CompareValue;
                    }
                    else
                    {
                        logicList.Items.Clear();
                        textTargetPreset.Items.Clear();
                        textTargetValue.Enabled = true;
                        textTargetPreset.Enabled = false;
                        logicList.Items.Add("<");
                        logicList.Items.Add("<=");
                        logicList.Items.Add("==");
                        logicList.Items.Add("!=");
                        logicList.Items.Add(">=");
                        logicList.Items.Add(">");
                        logicList.Items.Add("~");
                    }

                    logicList.Text = tar.CompareLogic;
                    if (tar.CompareValue.ToString() != "")
                    {
                        textTargetValue.Text = tar.CompareValue.ToString();
                    }
                    else
                    {
                        textTargetValue.Text = "0";
                    }
                    logicMin.Text = tar.CompareMin.ToString();
                    logicMax.Text = tar.CompareMax.ToString();
                    smapleRate.Text = tar.sampleRate.ToString();
                    timeOver.Text = tar.timeOver.ToString();
                    description.Text = tar.description;

                    if (tar.LogicTrueAudioUse == true)
                    {
                        TrueChkAudio.Checked = true;
                        logicTrueAudio = tar.LogicTrueAudioPath;
                    }
                    else
                    {
                        TrueChkAudio.Checked = false;
                        logicTrueAudio = tar.LogicTrueAudioPath;
                    }

                    if (tar.LogicTrueOutImagePath != "")
                    {
                        logicTrueImage = tar.LogicTrueOutImagePath;
                        AlarmTrueImage.Image = Image.FromFile(tar.LogicTrueOutImagePath);
                    }

                    if (tar.LogicTrueOutSMS == true)
                    {
                        TrueChkSMS.Checked = true;
                    }
                    else
                    {
                        TrueChkSMS.Checked = false;
                    }

                    if (tar.LogicTrueOutemail == true)
                    {
                        TrueChkmail.Checked = true;
                        //trueGroupContact

                    }
                    else
                    {
                        TrueChkmail.Checked = false;
                    }

                    if (tar.LogicTrueOutLog == true)
                    {
                        TrueChkLog.Checked = true;
                    }
                    else
                    {
                        TrueChkLog.Checked = false;
                    }
                    
                    TrueMsg.Text = tar.LogicTrueOutMSG;

                    if (tar.LogicTrueOutNV == true)
                    {
                        TrueChkOutNV.Checked = true;
                    }
                    else
                    {
                        TrueChkOutNV.Checked = false;
                    }
                    if (tar.LogicTrueOutNV1 != "")
                    {
                        TrueOutNV1.Tag = tar.LogicTrueOutNV1;
                        string[] tip = tar.LogicTrueOutNV1.Split('@');
                        outNVtip.SetToolTip(this.TrueOutNV1, tip[1] + "@" + tip[2]);
                    }
                    if (tar.LogicTrueOutNV2 != "")
                    {
                        TrueOutNV2.Tag = tar.LogicTrueOutNV2;
                        string[] tip = tar.LogicTrueOutNV2.Split('@');
                        outNVtip.SetToolTip(this.TrueOutNV2, tip[1] + "@" + tip[2]);
                    }
                    if (tar.LogicTrueOutNV3 != "")
                    {
                        TrueOutNV3.Tag = tar.LogicTrueOutNV3 ;
                        string[] tip = tar.LogicTrueOutNV3.Split('@');
                        outNVtip.SetToolTip(this.TrueOutNV3, tip[1] + "@" + tip[2]);
                    }
                    if (tar.LogicTrueOutNV4 != "")
                    {
                        TrueOutNV4.Tag = tar.LogicTrueOutNV4 ;
                        string[] tip = tar.LogicTrueOutNV4.Split('@');
                        outNVtip.SetToolTip(this.TrueOutNV4, tip[1] + "@" + tip[2]);
                    }
                    if (tar.LogicTrueOutNV5 != "")
                    {
                        TrueOutNV5.Tag = tar.LogicTrueOutNV5 ;
                        string[] tip = tar.LogicTrueOutNV5.Split('@');
                        outNVtip.SetToolTip(this.TrueOutNV5, tip[1] + "@" + tip[2]);
                    }
                    if (tar.LogicTrueOutNV6 != "")
                    {
                        TrueOutNV6.Tag = tar.LogicTrueOutNV6 ;
                        string[] tip = tar.LogicTrueOutNV6.Split('@');
                        outNVtip.SetToolTip(this.TrueOutNV6, tip[1] + "@" + tip[2]);
                    }
                    if (tar.LogicTrueOutNV7 != "")
                    {
                        TrueOutNV7.Tag = tar.LogicTrueOutNV7 ;
                        string[] tip = tar.LogicTrueOutNV7.Split('@');
                        outNVtip.SetToolTip(this.TrueOutNV7, tip[1] + "@" + tip[2]);
                    }
                    if (tar.LogicTrueOutNV8 != "")
                    {
                        TrueOutNV8.Tag = tar.LogicTrueOutNV8 ;
                        string[] tip = tar.LogicTrueOutNV8.Split('@');
                        outNVtip.SetToolTip(this.TrueOutNV8, tip[1] + "@" + tip[2]);
                    }
                    
                    AlarmTrueWidth.Text = tar.LogicTrueWidth.ToString();
                    AlarmTrueHeight.Text = tar.LogicTrueHeight.ToString();
                    AlarmTrueX.Text = tar.LogicTrueX.ToString();
                    AlarmTrueY.Text = tar.LogicTrueY.ToString();

                    if (tar.LogicFalseAudioUse == true)
                    {
                        FalseChkAudio.Checked = true;
                        logicFalseAudio = tar.LogicFalseAudioPath;
                    }
                    else
                    {
                        FalseChkAudio.Checked = false;
                        logicFalseAudio = tar.LogicFalseAudioPath;
                    }

                    if (tar.LogicFalseOutImagePath != "")
                    {
                        logicFalseImage = tar.LogicFalseOutImagePath;
                        AlarmFalseImage.Image = Image.FromFile(tar.LogicFalseOutImagePath);
                        AlarmFalseImage.Tag = tar.LogicFalseOutImagePath;
                    }

                    if (tar.LogicFalseOutSMS == true)
                    {
                        FalseChkSMS.Checked = true;
                    }
                    else
                    {
                        FalseChkSMS.Checked = false;
                    }

                    if (tar.LogicFalseOutemail == true)
                    {
                        FalseChkmail.Checked = true;
                    }
                    else
                    {
                        FalseChkmail.Checked = false;
                    }

                    if (tar.LogicFalseOutLog == true)
                    {
                        falseChkLog.Checked = true;
                    }
                    else
                    {
                        falseChkLog.Checked = false;
                    }

                    FalseMsg.Text = tar.LogicFalseOutMSG;

                    if (tar.LogicFalseOutNV == true)
                    {
                        FalseChkOutNV.Checked = true;
                    }
                    else
                    {
                        FalseChkOutNV.Checked = false;
                    }

                    //FalseOutNV1
                    if (tar.LogicFalseOutNV1 != "")
                    {
                        FalseOutNV1.Tag = tar.LogicFalseOutNV1 ;
                        string[] tip = tar.LogicFalseOutNV1.Split('@');
                        outNVtip.SetToolTip(this.FalseOutNV1, tip[1]+tip[2]);
                    }

                    if (tar.LogicFalseOutNV2 != "")
                    {
                        FalseOutNV2.Tag = tar.LogicFalseOutNV2 ;
                        string[] tip = tar.LogicFalseOutNV2.Split('@');
                        outNVtip.SetToolTip(this.FalseOutNV2, tip[1] + tip[2]);
                    }

                    if (tar.LogicFalseOutNV3 != "")
                    {
                        FalseOutNV3.Tag = tar.LogicFalseOutNV3 ;
                        string[] tip = tar.LogicFalseOutNV3.Split('@');
                        outNVtip.SetToolTip(this.FalseOutNV3, tip[1] + tip[2]);
                    }

                    if (tar.LogicFalseOutNV4 != "")
                    {
                        FalseOutNV4.Tag = tar.LogicFalseOutNV4 ;
                        string[] tip = tar.LogicFalseOutNV4.Split('@');
                        outNVtip.SetToolTip(this.FalseOutNV4, tip[1] + tip[2]);
                    }

                    if (tar.LogicFalseOutNV5 != "")
                    {
                        FalseOutNV5.Tag = tar.LogicFalseOutNV5 ;
                        string[] tip = tar.LogicFalseOutNV5.Split('@');
                        outNVtip.SetToolTip(this.FalseOutNV5, tip[1] + tip[2]);
                    }

                    if (tar.LogicFalseOutNV6 != "")
                    {
                        FalseOutNV6.Tag = tar.LogicFalseOutNV6 ;
                        string[] tip = tar.LogicFalseOutNV6.Split('@');
                        outNVtip.SetToolTip(this.FalseOutNV6, tip[1] + tip[2]);
                    }

                    if (tar.LogicFalseOutNV7 != "")
                    {
                        FalseOutNV7.Tag = tar.LogicFalseOutNV7 ;
                        string[] tip = tar.LogicFalseOutNV7.Split('@');
                        outNVtip.SetToolTip(this.FalseOutNV7, tip[1] + tip[2]);
                    }

                    if (tar.LogicFalseOutNV8 != "")
                    {
                        FalseOutNV8.Tag = tar.LogicFalseOutNV8 ;
                        string[] tip = tar.LogicFalseOutNV8.Split('@');
                        outNVtip.SetToolTip(this.FalseOutNV8, tip[1] + tip[2]);
                    }

                    AlarmFalseWidth.Text = tar.LogicFalseWidth.ToString();
                    AlarmFalseHeight.Text = tar.LogicFalseHeight.ToString();
                    AlarmFalseX.Text=tar.LogicFalseX.ToString();
                    AlarmFalseY.Text=tar.LogicFalseY.ToString();

                    if (tar.userTrueValue == true)
                    {
                        TrueChkShowValue.Checked = true;
                        showTrueValue = tar.LogicTrueOutFont;
                        showTrueValueColor = tar.LogicTrueforecolor;
                    }
                    else
                    {
                        TrueChkShowValue.Checked = false;
                    }

                    if (tar.userFalseValue == true)
                    {
                        FalseChkShowValue.Checked = true;
                        showFalseValue = tar.LogicFalseOutFont;
                        showFalseValueColor = tar.LogicFalseforecolor;
                    }
                    else
                    {
                        FalseChkShowValue.Checked = false;
                    }

                    break;
                }
            }
            
        }

        private void AlarmTruePlay_Click(object sender, EventArgs e)
        {
            //path   sp.SoundLocation = @"D:\ALARM.wav";  
            if(logicTrueAudio !="")
            {
            //soundplay.SoundLocation =  logicTrueAudio;
            //soundplay.Play();
            
            }
        }

        private void AlarmTruePause_Click(object sender, EventArgs e)
        {
            soundplay.Stop();
        }

        private void AlarmFalsePlay_Click(object sender, EventArgs e)
        {
            //path   sp.SoundLocation = @"D:\ALARM.wav";  
            if (logicFalseAudio != "")
            {
                //soundplay.SoundLocation = logicFalseAudio;
                //soundplay.Play();
                
            }
        }

        private void AlarmFalsePause_Click(object sender, EventArgs e)
        {
            soundplay.Stop();
        }

        private void TrueChkOutNV_CheckedChanged(object sender, EventArgs e)
        {
            if (TrueChkOutNV.Checked == true)
            {
                TrueOutNV1.Enabled = true;
                TrueOutNV2.Enabled = true;
                TrueOutNV3.Enabled = true;
                TrueOutNV4.Enabled = true;
                TrueOutNV5.Enabled = true;
                TrueOutNV6.Enabled = true;
                TrueOutNV7.Enabled = true;
                TrueOutNV8.Enabled = true;
            }
            else if (TrueChkOutNV.Checked == false)
            {
                TrueOutNV1.Enabled = false;
                TrueOutNV2.Enabled = false;
                TrueOutNV3.Enabled = false;
                TrueOutNV4.Enabled = false;
                TrueOutNV5.Enabled = false;
                TrueOutNV6.Enabled = false;
                TrueOutNV7.Enabled = false;
                TrueOutNV8.Enabled = false;
            }
        }

        private void FalseChkOutNV_CheckedChanged(object sender, EventArgs e)
        {
            if (FalseChkOutNV.Checked == true)
            {
                FalseOutNV1.Enabled = true;
                FalseOutNV2.Enabled = true;
                FalseOutNV3.Enabled = true;
                FalseOutNV4.Enabled = true;
                FalseOutNV5.Enabled = true;
                FalseOutNV6.Enabled = true;
                FalseOutNV7.Enabled = true;
                FalseOutNV8.Enabled = true;
            }
            else if (FalseChkOutNV.Checked == false)
            {
                FalseOutNV1.Enabled = false;
                FalseOutNV2.Enabled = false;
                FalseOutNV3.Enabled = false;
                FalseOutNV4.Enabled = false;
                FalseOutNV5.Enabled = false;
                FalseOutNV6.Enabled = false;
                FalseOutNV7.Enabled = false;
                FalseOutNV8.Enabled = false;
            }
        }

        private void TrueChkAudio_CheckedChanged(object sender, EventArgs e)
        {
            if (TrueChkAudio.Checked == true)
            {
                AlarmTrueAudio.Enabled = true;
                AlarmTruePlay.Enabled = true;
                AlarmTruePause.Enabled = true;
            }
            else if (TrueChkAudio.Checked == false)
            {
                AlarmTrueAudio.Enabled = false;
                AlarmTruePlay.Enabled = false;
                AlarmTruePause.Enabled = false;
            }
        }

        private void FalseChkAudio_CheckedChanged(object sender, EventArgs e)
        {
            if (FalseChkAudio.Checked == true)
            {
                AlarmFalseAudio.Enabled = true;
                AlarmFalsePlay.Enabled = true;
                AlarmFalsePause.Enabled = true;
            }
            else if (FalseChkAudio.Checked == false)
            {
                AlarmFalseAudio.Enabled = false;
                AlarmFalsePlay.Enabled = false;
                AlarmFalsePause.Enabled = false;
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Form1 lForm1 = (Form1)this.Owner;//把Form2的父窗口指針賦給lForm1  
            lForm1.Repicturebox = null;
            Close();
        }

        private void AlarmTrueImageSel_Click(object sender, EventArgs e)
        {
            OpenFileDialog myopen = new OpenFileDialog();
            myopen.Filter = "Image Files (*.jpg, *.bmp, *.gif, *.png)|*.jpg; *.bmp; *.gif; *.png;";
            if (myopen.ShowDialog() == DialogResult.OK)
            {
                logicTrueImage = myopen.FileName;
                AlarmTrueImage.Image = Image.FromFile(myopen.FileName);
            }
        }

        private void cmdApply_Click(object sender, EventArgs e)
        {
            Boolean apply = false;
            if (radTargetTypeVal.Checked == true)
            {
                if (textSource.Text != "")
                { apply = true; }
                else
                { apply = false; }
            }
            else if(radTargetTypeTag.Checked==true)
            {
                if (textTarget.Text != "" && textSource.Text != "")
                { apply = true; }
                else
                { apply = false; }
            }

            if (apply == true)
            {
               
                    for (int i = 0; i < memoryData.AlarmData.Count; i++)
                    {
                        AlarmObjectstruct edit = (AlarmObjectstruct)memoryData.AlarmData[i];
                        if (AlarmName == edit.name)
                        {   //input data struct
                            //edit.ip = targetip;
                            edit.TargetIP = targetip;
                            edit.SourceIP = sourceip;
                            edit.LogicFalseHeight = int.Parse(AlarmFalseHeight.Text);
                            edit.LogicFalseWidth = int.Parse(AlarmFalseWidth.Text);
                            edit.LogicFalseX = int.Parse(AlarmFalseX.Text);
                            edit.LogicFalseY = int.Parse(AlarmFalseY.Text);

                            edit.LogicTrueHeight = int.Parse(AlarmTrueHeight.Text);
                            edit.LogicTrueWidth = int.Parse(AlarmTrueWidth.Text);
                            edit.LogicTrueX = int.Parse(AlarmTrueX.Text);
                            edit.LogicTrueY = int.Parse(AlarmTrueY.Text);
                            edit.CompareLogic = logicList.Text;
                            edit.description = description.Text;

                            edit.NVType = NVType;

                            if (radTargetTypeTag.Checked == true)
                            {
                                edit.CompareType = "tag";
                                edit.CompareMax = 0;
                                edit.CompareMin = 0;
                                edit.CompareValue = "";
                            }
                            else if (radTargetTypeVal.Checked == true)
                            {
                                edit.CompareType = "value";
                                edit.CompareMax = float.Parse(logicMax.Text);
                                edit.CompareMin = float.Parse(logicMin.Text);
                                if (NVType == "SNVT_switch")
                                {
                                    //string[] getNVswitch = textTargetValue.Text.Split(' ');
                                    edit.CompareValue = textTargetValue.Text;// int.Parse(getNVswitch[0]);
                                }
                                else if (NVType == "SNVT_occupancy")
                                {
                                edit.CompareValue = textTargetPreset.Text;
                                }
                                else
                                {
                                    edit.CompareValue = textTargetValue.Text;
                                }

                            }

                            edit.NVType = NVType;
                            if (smapleRate.Text != "0" && smapleRate.Text != "")
                            {
                                edit.sampleRate = int.Parse(smapleRate.Text);
                            }
                            else
                            {
                                edit.sampleRate = 600;
                            }

                            if (timeOver.Text != "0" && timeOver.Text != "")
                            {
                                edit.timeOver = int.Parse(timeOver.Text);
                            }
                            else
                            {
                                edit.timeOver = 0;
                            }

                            edit.SourceNVName = textSource.Text;
                            edit.SourceNVindex = textSource.Tag.ToString();
                            edit.TargetNVName = textTarget.Text;
                            edit.TargetNVindex = textTarget.Tag.ToString();

                            if (NVType == "device")
                            {
                                edit.NV = "nviRequest";
                                edit.function = "NodeObject";
                                edit.device = treeSource.SelectedNode.Text;
                                edit.area = treeSource.SelectedNode.Parent.Text;
                                edit.fab = treeSource.SelectedNode.Parent.Parent.Text;
                                edit.site = treeSource.SelectedNode.Parent.Parent.Parent.Text;
                            }
                            else
                            {
                                edit.NV = treeSource.SelectedNode.Text;
                                edit.function = treeSource.SelectedNode.Parent.Text;
                                edit.device = treeSource.SelectedNode.Parent.Parent.Text;
                                edit.area = treeSource.SelectedNode.Parent.Parent.Parent.Text;
                                edit.fab = treeSource.SelectedNode.Parent.Parent.Parent.Parent.Text;
                                edit.site = treeSource.SelectedNode.Parent.Parent.Parent.Parent.Parent.Text;
                            }

                            

                            if (TrueChkAudio.Checked == true)
                            {
                                edit.LogicTrueAudioPath = logicTrueAudio;
                                edit.LogicTrueAudioUse = true;
                            }
                            else
                            {
                                edit.LogicTrueAudioPath = "";
                                edit.LogicTrueAudioUse = false;
                            }

                            if (logicTrueImage != "")
                            { edit.LogicTrueOutImagePath = logicTrueImage; }

                            if (TrueChkmail.Checked == true)
                            { 
                                edit.LogicTrueOutemail = true;
                                if (trueGroupContact.Text != "")
                                {
                                    edit.AlarmTrueMailgroup = trueGroupContact.Text;
                                }
                                else
                                {
                                    edit.AlarmTrueMailgroup = "";
                                }

                            }
                            else
                            { 
                                edit.LogicTrueOutemail = false; 
                            }

                            if (TrueChkSMS.Checked == true)
                            { edit.LogicTrueOutSMS = true; }
                            else
                            { edit.LogicTrueOutSMS = false; }

                            if (TrueChkLog.Checked == true)
                            { edit.LogicTrueOutLog = true; }
                            else
                            { edit.LogicTrueOutLog = false; }

                            edit.LogicTrueOutMSG = TrueMsg.Text;

                            if (TrueChkOutNV.Checked == true)
                            { edit.LogicTrueOutNV = true; }
                            else
                            { edit.LogicTrueOutNV = false; }

                            if (TrueOutNV1.Tag.ToString() != "none")
                            {
                                string[] tonv1 = TrueOutNV1.Tag.ToString().Split('@');
                                edit.LogicTrueOutNV1 = TrueOutNV1.Tag.ToString();
                                edit.LogicTrueOutNV1index = tonv1[3];
                                edit.LogicTrueOutNV1Value = tonv1[4];
                            }
                            if (TrueOutNV2.Tag.ToString() != "none")
                            {
                                string[] tonv1 = TrueOutNV2.Tag.ToString().Split('@');
                                edit.LogicTrueOutNV2 = TrueOutNV2.Tag.ToString();
                                edit.LogicTrueOutNV2index = tonv1[3];
                                edit.LogicTrueOutNV2Value = tonv1[4];
                            }
                            if (TrueOutNV3.Tag.ToString() != "none")
                            {
                                string[] tonv1 = TrueOutNV3.Tag.ToString().Split('@');
                                edit.LogicTrueOutNV3 = TrueOutNV3.Tag.ToString();
                                edit.LogicTrueOutNV3index = tonv1[3];
                                edit.LogicTrueOutNV3Value = tonv1[4];
                            }
                            if (TrueOutNV4.Tag.ToString() != "none")
                            {
                                string[] tonv1 = TrueOutNV4.Tag.ToString().Split('@');
                                edit.LogicTrueOutNV4 = TrueOutNV4.Tag.ToString();
                                edit.LogicTrueOutNV4index = tonv1[3];
                                edit.LogicTrueOutNV4Value = tonv1[4];
                            }
                            if (TrueOutNV5.Tag.ToString() != "none")
                            {
                                string[] tonv1 = TrueOutNV5.Tag.ToString().Split('@');
                                edit.LogicTrueOutNV5 = TrueOutNV5.Tag.ToString();
                                edit.LogicTrueOutNV5index = tonv1[3];
                                edit.LogicTrueOutNV5Value = tonv1[4];
                            }
                            if (TrueOutNV6.Tag.ToString() != "none")
                            {
                                string[] tonv1 = TrueOutNV6.Tag.ToString().Split('@');
                                edit.LogicTrueOutNV6 = TrueOutNV6.Tag.ToString();
                                edit.LogicTrueOutNV6index = tonv1[3];
                                edit.LogicTrueOutNV6Value = tonv1[4];
                            }
                            if (TrueOutNV7.Tag.ToString() != "none")
                            {
                                string[] tonv1 = TrueOutNV7.Tag.ToString().Split('@');
                                edit.LogicTrueOutNV7 = TrueOutNV7.Tag.ToString();
                                edit.LogicTrueOutNV7index = tonv1[3];
                                edit.LogicTrueOutNV7Value = tonv1[4];
                            }
                            if (TrueOutNV8.Tag.ToString() != "none")
                            {
                                string[] tonv1 = TrueOutNV8.Tag.ToString().Split('@');
                                edit.LogicTrueOutNV8 = TrueOutNV8.Tag.ToString();
                                edit.LogicTrueOutNV8index = tonv1[3];
                                edit.LogicTrueOutNV8Value = tonv1[4];
                            }

                            if (FalseChkAudio.Checked == true)
                            {
                                edit.LogicFalseAudioPath = logicFalseAudio;
                                edit.LogicFalseAudioUse = true;
                            }
                            else
                            {
                                edit.LogicFalseAudioPath = "";
                                edit.LogicFalseAudioUse = false;
                            }

                            if (logicFalseImage != "")
                            { edit.LogicFalseOutImagePath = logicFalseImage; }

                            if (FalseChkSMS.Checked == true)
                            { edit.LogicFalseOutSMS = true; }
                            else { edit.LogicFalseOutSMS = false; }

                            if (FalseChkmail.Checked == true)
                            { 
                                edit.LogicFalseOutemail = true;
                                if (falseGroupContact.Text != "")
                                {
                                    edit.AlarmFalseMailgroup = falseGroupContact.Text;
                                }
                                else
                                {
                                    edit.AlarmFalseMailgroup = "";
                                }
                            }
                            else
                            {
                                edit.LogicFalseOutemail = false; 
                            }

                            if (falseChkLog.Checked == true)
                            { edit.LogicFalseOutLog = true; }
                            else
                            { edit.LogicFalseOutLog = false; }

                            edit.LogicFalseOutMSG = FalseMsg.Text;

                            if (FalseChkOutNV.Checked == true)
                            { edit.LogicFalseOutNV = true; }
                            else
                            { edit.LogicFalseOutNV = false; }

                            if (FalseOutNV1.Tag.ToString() != "none")
                            {
                                string[] fonv1 = FalseOutNV1.Tag.ToString().Split('@');
                                edit.LogicFalseOutNV1 = FalseOutNV1.Tag.ToString();
                                edit.LogicFalseOutNV1index = fonv1[3];
                                edit.LogicFalseOutNV1Value = fonv1[4];
                            }
                            else
                            {

                            }
                            if (FalseOutNV2.Tag.ToString() != "none")
                            {
                                string[] fonv1 = FalseOutNV2.Tag.ToString().Split('@');
                                edit.LogicFalseOutNV2 = FalseOutNV2.Tag.ToString();
                                edit.LogicFalseOutNV2index = fonv1[3];
                                edit.LogicFalseOutNV2Value = fonv1[4];
                            }
                            if (FalseOutNV3.Tag.ToString() != "none")
                            {
                                string[] fonv1 = FalseOutNV3.Tag.ToString().Split('@');
                                edit.LogicFalseOutNV3 = FalseOutNV3.Tag.ToString();
                                edit.LogicFalseOutNV3index = fonv1[3];
                                edit.LogicFalseOutNV3Value = fonv1[4];
                            }
                            if (FalseOutNV4.Tag.ToString() != "none")
                            {
                                string[] fonv1 = FalseOutNV4.Tag.ToString().Split('@');
                                edit.LogicFalseOutNV4 = FalseOutNV4.Tag.ToString();
                                edit.LogicFalseOutNV4index = fonv1[3];
                                edit.LogicFalseOutNV4Value = fonv1[4];
                            }
                            if (FalseOutNV5.Tag.ToString() != "none")
                            {
                                string[] fonv1 = FalseOutNV5.Tag.ToString().Split('@');
                                edit.LogicFalseOutNV5 = FalseOutNV5.Tag.ToString();
                                edit.LogicFalseOutNV5index = fonv1[3];
                                edit.LogicFalseOutNV5Value = fonv1[4];
                            }
                            if (FalseOutNV6.Tag.ToString() != "none")
                            {
                                string[] fonv1 = FalseOutNV6.Tag.ToString().Split('@');
                                edit.LogicFalseOutNV6 = FalseOutNV6.Tag.ToString();
                                edit.LogicFalseOutNV6index = fonv1[3];
                                edit.LogicFalseOutNV6Value = fonv1[4];
                            }
                            if (FalseOutNV7.Tag.ToString() != "none")
                            {
                                string[] fonv1 = FalseOutNV7.Tag.ToString().Split('@');
                                edit.LogicFalseOutNV7 = FalseOutNV7.Tag.ToString();
                                edit.LogicFalseOutNV7index = fonv1[3];
                                edit.LogicFalseOutNV7Value = fonv1[4];
                            }
                            if (FalseOutNV8.Tag.ToString() != "none")
                            {
                                string[] fonv1 = FalseOutNV8.Tag.ToString().Split('@');
                                edit.LogicFalseOutNV8 = FalseOutNV8.Tag.ToString();
                                edit.LogicFalseOutNV8index = fonv1[3];
                                edit.LogicFalseOutNV8Value = fonv1[4];
                            }

                            if (TrueChkShowValue.Checked == true)
                            {
                                
                                if (showTrueValue != null)
                                {
                                    edit.LogicTrueOutFont = showTrueValue;
                                    edit.LogicTrueforecolor = showTrueValueColor;
                                }
                                else
                                {
                                    Font t = new Font("Arial", 12);
                                    edit.LogicTrueOutFont = t;
                                    edit.LogicTrueforecolor = Color.Red.ToArgb();
                                }
                                edit.userTrueValue = true;
                            }
                            else
                            {
                                edit.LogicTrueforecolor = SystemColors.ControlText.ToArgb();
                                edit.LogicTrueOutFont = new Font("Arial", 12);
                                edit.userTrueValue = false;
                            }

                            if (FalseChkShowValue.Checked == true)
                            {
                                if (showFalseValue != null)
                                {
                                    edit.LogicFalseOutFont = showFalseValue;
                                    edit.LogicFalseforecolor = showFalseValueColor;
                                }
                                else
                                {
                                    Font t = new Font("Arial",12);
                                    edit.LogicFalseOutFont = t;
                                    edit.LogicFalseforecolor = Color.Green.ToArgb();
                                }
                                edit.userFalseValue = true;
                            }
                            else
                            {
                                edit.LogicFalseforecolor = SystemColors.ControlText.ToArgb();
                                edit.LogicFalseOutFont = new Font("Arial", 12);
                                edit.userFalseValue = false;
                            }

                            memoryData.AlarmData[i] = edit;
                            //input struct end

                            //request object info
                            Form1 lForm1 = (Form1)this.Owner;//把Form2的父窗口指針賦給lForm1  
                            PictureBox send = new PictureBox();
                            send.Tag = AlarmFalseImage.Tag;
                            send.Size = new Size(int.Parse(AlarmFalseWidth.Text), int.Parse(AlarmFalseHeight.Text));
                            send.Location = new Point(int.Parse(AlarmFalseX.Text), int.Parse(AlarmFalseY.Text));
                            lForm1.Repicturebox = send;
                            lForm1.Gettooltip = description.Text;

                            for (int a = 0; a < memoryData.AlarmMonitorValue.Count; a++)
                            {
                                AlarmMoniTorNV edit2 = (AlarmMoniTorNV)memoryData.AlarmMonitorValue[a];
                                if (AlarmName == edit2.name)
                                {
                                    edit2.ip = sourceip;
                                    //edit2.name = textSource.Text;
                                    edit2.NVpath = textSource.Text;
                                    edit2.NVtype = NVType;
                                    edit2.NVvalue = "";
                                    edit2.sampleRate = int.Parse(smapleRate.Text);
                                    edit2.sampleRatecount = 0;
                                    edit2.device = edit.device;
                                    edit2.function = edit.function;
                                    edit2.NV = edit.NV;

                                    memoryData.AlarmMonitorValue[a] = edit2;
                                }
                            }
                            

                            break;
                        }


                    }
                    Close();
                
            }
        }

        private void AlarmTrueAudio_Click(object sender, EventArgs e)
        {
            OpenFileDialog myopen = new OpenFileDialog();
            //myopen.Filter = "Audio Files (*.wav)|*.wav";
            myopen.Filter = "Audio Files(*.wav;*.mp3;*.wma)|*.wav;*.mp3;*.wma";//|All files (*.*)|*.*";
            //Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*
            if (myopen.ShowDialog() == DialogResult.OK)
            {
                logicTrueAudio = myopen.FileName;
                
            }
        }

        private void AlarmFalseImageSel_Click(object sender, EventArgs e)
        {
            OpenFileDialog myopen = new OpenFileDialog();
            myopen.Filter = "Image Files (*.jpg, *.bmp, *.gif, *.png)|*.jpg; *.bmp; *.gif; *.png;";
            if (myopen.ShowDialog() == DialogResult.OK)
            {
                logicFalseImage = myopen.FileName;
                AlarmFalseImage.Image = Image.FromFile(myopen.FileName);
                AlarmFalseImage.Tag = myopen.FileName;
            }
        }

        private void AlarmFalseAudio_Click(object sender, EventArgs e)
        {
            OpenFileDialog myopen = new OpenFileDialog();
            //myopen.Filter = "Audio Files (*.wav)|*.wav";
            myopen.Filter = "Audio Files(*.wav;*.mp3;*.wma)|*.wav;*.mp3;*.wma";//|All files (*.*)|*.*";
            if (myopen.ShowDialog() == DialogResult.OK)
            {
                logicFalseAudio = myopen.FileName;
            }
        }

        private string repath; //接收label config 的值
        public string Repath
        {
            set
            {
                repath = value;
            }
        }

        private void TrueOutNV1_Click(object sender, EventArgs e)
        {
            Button tar = (Button)sender;
            config_AlarmObjectOutNVTree lForm = new config_AlarmObjectOutNVTree();
            lForm.Owner = this;
            lForm.NVType2 = NVType;
            foreach (TreeNode node in deviceTree.Nodes)
            {
                lForm.deviceList.Nodes.Add((TreeNode)node.Clone());
            }
            if (tar.Tag.ToString() != "none")
            {
                string[] NVpath = tar.Tag.ToString().Split('@');
                lForm.NVType = NVpath[2];
                lForm.NVindex = NVpath[3];
                lForm.NVvalue = NVpath[4];
            }
            lForm.ShowDialog();
            
            if (repath != null)
            {
                tar.Tag = repath;
                string[] tip = repath.Split('@');
                outNVtip.SetToolTip(tar, tip[1]+"@"+tip[2]);
            }

        }

        private void FalseOutNV1_Click(object sender, EventArgs e)
        {
            Button tar = (Button)sender;
            config_AlarmObjectOutNVTree lForm = new config_AlarmObjectOutNVTree();
            lForm.Owner = this;
            lForm.NVType2 = NVType;
            foreach (TreeNode node in deviceTree.Nodes)
            {
                lForm.deviceList.Nodes.Add((TreeNode)node.Clone());
            }
            if (tar.Tag.ToString() != "none")
            {
                string[] NVpath = tar.Tag.ToString().Split('@');
                lForm.NVType = NVpath[2];
                lForm.NVindex = NVpath[3];
            }
            lForm.ShowDialog();

            if (repath != null)
            {
                tar.Tag = repath;
                string[] tip = repath.Split('@');
                outNVtip.SetToolTip(tar, tip[1] + "@" + tip[2]);
            }
        }

        private void config_AlarmObject_FormClosing(object sender, FormClosingEventArgs e)
        {
            soundplay.Stop();
        }

        private void TrueChkSMS_CheckedChanged(object sender, EventArgs e)
        {
            if (TrueChkSMS.Checked == true)
            { trueGroupContact.Enabled = true; }
            else
            { trueGroupContact.Enabled = false; }
        }

        private void TrueChkmail_CheckedChanged(object sender, EventArgs e)
        {
            if (TrueChkmail.Checked == true)
            { 
                trueGroupContact.Enabled = true;
                trueGroupContact.SelectedIndex = 0;
            }

            else
            { trueGroupContact.Enabled = false; }
        }

        private void FalseChkSMS_CheckedChanged(object sender, EventArgs e)
        {
            if (FalseChkSMS.Checked == true)
            { falseGroupContact.Enabled = true; }
            else
            { falseGroupContact.Enabled = false; }
        }

        private void FalseChkmail_CheckedChanged(object sender, EventArgs e)
        {
            if (FalseChkmail.Checked == true)
            { 
                falseGroupContact.Enabled = true;
                falseGroupContact.SelectedIndex = 0;
            }
            else
            { falseGroupContact.Enabled = false; }
        }

        private void TrueChkShowValue_CheckedChanged(object sender, EventArgs e)
        {
            if (TrueChkShowValue.Checked == true)
            {
                TrueFontCMD.Enabled = true;

                AlarmTrueImageSel.Enabled = false;
                AlarmTrueWidth.Enabled = false;
                AlarmTrueHeight.Enabled = false;
            }
            else
            {
                TrueFontCMD.Enabled = false;

                AlarmTrueImageSel.Enabled = true;
                AlarmTrueWidth.Enabled = true;
                AlarmTrueHeight.Enabled = true;
            }
        }

        private void FalseChkShowValue_CheckedChanged(object sender, EventArgs e)
        {
            if (FalseChkShowValue.Checked == true)
            {
                FalseFontCMD.Enabled = true;

                AlarmFalseImageSel.Enabled = false;
                AlarmFalseWidth.Enabled = false;
                AlarmFalseHeight.Enabled = false;
            }
            else
            {
                FalseFontCMD.Enabled = false;

                AlarmFalseImageSel.Enabled = true;
                AlarmFalseWidth.Enabled = true;
                AlarmFalseHeight.Enabled = true;
            }
        }

        private void TrueFontCMD_Click(object sender, EventArgs e)
        {
            FontDialog setFont = new FontDialog();
            setFont.ShowColor = true;
            if (showTrueValue != null)
            {
                setFont.Font = showTrueValue;
                setFont.Color = Color.FromArgb(showTrueValueColor);
            }
            else
            {
                setFont.Font = new Font("Arial", 12);
                setFont.Color = Color.Black;
            }
            

            if (setFont.ShowDialog() == DialogResult.OK)
            {
                showTrueValue = setFont.Font;
                showTrueValueColor = setFont.Color.ToArgb();
            }
            setFont.Dispose();
        }

        private void FalseFontCMD_Click(object sender, EventArgs e)
        {
            FontDialog setFont = new FontDialog();
            setFont.ShowColor = true;

            if (showFalseValue != null)
            {
                setFont.Font = showFalseValue;
                setFont.Color = Color.FromArgb(showFalseValueColor);
            }
            else
            {
                setFont.Font = new Font("Arial", 12);
                setFont.Color = Color.Black;
            }

            if (setFont.ShowDialog() == DialogResult.OK)
            {
                showFalseValue = setFont.Font;
                showFalseValueColor = setFont.Color.ToArgb();
            }
            setFont.Dispose();
        }

        


    }
}
