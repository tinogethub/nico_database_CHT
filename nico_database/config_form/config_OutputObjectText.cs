using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;


namespace nico_database
{
    public partial class config_OutputObjectText : Form
    {
        public string targetip = "";
        public string NVType = "";
        public string NVType2 = "";
        public string textboxName = "";

        public config_OutputObjectText()
        {
            InitializeComponent();
        }

        private void config_OutputObjectText_Load(object sender, EventArgs e)
        {
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
                                    for (int nv = deviceList.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes[obj].Nodes.Count - 1; nv >= 0; nv--)
                                    {
                                        //string[] chk = deviceList.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes[obj].Nodes[nv].Text.Split('#');
                                        //string snvt = chk[0].Substring(0, 3);

                                        //if (snvt == "UCP" || snvt == "pro" || snvt == "nci" || snvt == "nvo")
                                        //{
                                        //    deviceList.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes[obj].Nodes[nv].Remove();
                                        //}
                                        if (deviceList.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes[obj].Nodes[nv].Tag.ToString() != NVType2)
                                        {
                                            deviceList.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes[obj].Nodes[nv].Remove();
                                        }
                                        else if (deviceList.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes[obj].Nodes[nv].Tag.ToString() == NVType2)
                                        {
                                            if (deviceList.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes[obj].Text != "VirtFb")
                                            {
                                                string snvt = deviceList.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes[obj].Nodes[nv].Text.Substring(0, 3);
                                                if (snvt != "nvi")
                                                {
                                                    deviceList.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes[obj].Nodes[nv].Remove();
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
            for (int i = 0; i < memoryData.OutputTextData .Count; i++)
            {
                OutputTextObjectstruct lt = (OutputTextObjectstruct)memoryData.OutputTextData[i];
                if (lt.name   == textboxName)
                {
                    if (lt.target  != "")
                    {
                        string[] index = lt.targetindex.Split('_');
                        deviceList.SelectedNode = deviceList.Nodes[int.Parse(index[0])].Nodes[int.Parse(index[1])].Nodes[int.Parse(index[2])].Nodes[int.Parse(index[3])].Nodes[int.Parse(index[4])].Nodes[int.Parse(index[5])];
                        deviceList.Select();
                    }
                    else
                    {
                        deviceList.SelectedNode = deviceList.Nodes[0].Nodes[0].Nodes[0];
                        deviceList.Nodes[0].Expand();
                        deviceList.Nodes[0].Nodes[0].Expand();
                        deviceList.Nodes[0].Nodes[0].Nodes[0].Expand();
                    }
                
                textX.Text = lt.x.ToString();
                textY.Text = lt.y.ToString();
                textwidth.Text = lt.width.ToString();
                textheight.Text = lt.height.ToString();
                description.Text = lt.description;

                if (lt.log == true)
                {
                    checkBox1.Checked = true;
                }

                if (lt.mail == true)
                {
                    checkBox2.Checked = true;
                }

                if (lt.SMS == true)
                {
                    checkBox3.Checked = true;
                }

                //load group contact list
                for (int g = 0; g < memoryData.GroupContact2.Count; g++)
                {
                    ContactGroup2 tar = (ContactGroup2)memoryData.GroupContact2[g];
                    GroupContact.Items.Add(tar.groupname);
                }

                GroupContact.SelectedIndex = 0;
              }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 lForm1 = (Form1)this.Owner;//把Form2的父窗口指針賦給lForm1  
            lForm1.Retextbox = null;
            Close();
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
                    NVType = "nico";

                }
                else if (deviceType == "lon")
                {
                    Labtext.Text = deviceType + "@" + deviceIp + "@Net/LON/" + deviceList.SelectedNode.Parent.Parent.Text +
                      "/" + deviceList.SelectedNode.Parent.Text + "/" + deviceList.SelectedNode.Text;
                    NVType = "lon";

                }
            }
            else
            {
                Labtext.Text = "";
                targetindex.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (deviceList.SelectedNode.Level == 5)
            {
                TextBox editTb = new TextBox();
                editTb.Tag = textX.Text + "@" + textY.Text; // +"@" + NVType + "@" + targetip + "@" + Labtext.Text;
                editTb.Size = new Size(int.Parse(textwidth.Text), int.Parse(textheight.Text));
                Form1 lForm1 = (Form1)this.Owner;//把Form2的父窗口指針賦給lForm1  
                lForm1.Retextbox = editTb;
                lForm1.Gettooltip = description.Text;

                for (int i = 0; i < memoryData.OutputTextData.Count; i++)
                {
                    OutputTextObjectstruct edit = (OutputTextObjectstruct)memoryData.OutputTextData[i];

                    if (edit.name == textboxName)
                    {
                        edit.width = int.Parse(textwidth.Text);
                        edit.height = int.Parse(textheight.Text);
                        edit.x = int.Parse(textX.Text);
                        edit.y = int.Parse(textY.Text);
                        edit.ip = targetip;
                        string[] gettag = edit.tag.Split('@');
                        edit.NVtype = gettag[1];

                        edit.description = description.Text;

                        if (checkBox2.Checked == true || checkBox3.Checked == true)
                        {
                            if (GroupContact.Text != "")
                            {
                                edit.contactGroup = GroupContact.Text;
                            }
                            else
                            {
                                edit.contactGroup = "";
                            }
                        }

                        if (Labtext.Text != "")
                        {
                            edit.target = Labtext.Text;
                            edit.targetindex = targetindex.Text;

                            string[] getpath = deviceList.SelectedNode.FullPath.ToString().Split('\\');
                            edit.site = getpath[0];
                            edit.fab = getpath[1];
                            edit.area = getpath[2];
                            edit.device = getpath[3];
                            edit.function = getpath[4];
                            edit.NV = getpath[5];
                        }
                        else
                        {
                            edit.target = "";
                            edit.targetindex = "";
                        }

                        if (checkBox1.Checked == true)
                        {
                            edit.log = true;
                        }
                        else
                        {
                            edit.log = false;
                        }
                        if (checkBox2.Checked == true)
                        {
                            edit.mail = true;
                        }
                        else
                        {
                            edit.mail = false;
                        }
                        if (checkBox3.Checked == true)
                        {
                            edit.SMS = true;
                        }
                        else
                        {
                            edit.SMS = false;
                        }

                        memoryData.OutputTextData[i] = edit;
                        break;
                    }

                }
                Close();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                GroupContact.Enabled = true;
            }
            else if (checkBox2.Checked == false && checkBox3.Checked == false)
            {
                GroupContact.Enabled = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                GroupContact.Enabled = true;
            }
            else if (checkBox2.Checked == false && checkBox3.Checked == false)
            {
                GroupContact.Enabled = false;
            }
        }
    }
}
