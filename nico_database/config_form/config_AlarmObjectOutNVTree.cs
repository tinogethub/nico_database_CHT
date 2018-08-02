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
    public partial class config_AlarmObjectOutNVTree : Form
    {
        public config_AlarmObjectOutNVTree()
        {
            InitializeComponent();
        }

        public string targetip = "";
        public string NVType = "";
        public string NVType2 = "";
        public string NVindex = "";
        public string NVvalue = "";
        public TreeNode DeviceNode;
       

        private void config_AlarmObjectOutNVTree_Load(object sender, EventArgs e)
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
                                    if (deviceList.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes[obj].Text != "VirtFb")
                                    {
                                        for (int nv = deviceList.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes[obj].Nodes.Count - 1; nv >= 0; nv--)
                                        {

                                            //if (deviceList.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes[obj].Nodes[nv].Tag.ToString() != NVType2)
                                            //{
                                            //    deviceList.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes[obj].Nodes[nv].Remove();
                                            //}
                                            //else
                                            //{
                                            string snvt = deviceList.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes[obj].Nodes[nv].Text.Substring(0, 3);
                                            if (snvt != "nvi")
                                            {
                                                deviceList.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes[obj].Nodes[nv].Remove();
                                            }
                                            //}

                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            deviceList.CollapseAll();

            if (NVindex != "")
            {
                string[] index = NVindex.Split('_');
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

            if (NVvalue != "")
            {
                if (NVvalue == "100.0 1")
                {
                    valueON.Checked = true;
                }
                else if (NVvalue == "0.0 0")
                {
                    valueOFF.Checked = true;
                }
                else
                {
                    valueCustomize.Checked = true;
                }
            }

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

        private void button2_Click(object sender, EventArgs e)
        {
            config_AlarmObject lForm1 = (config_AlarmObject)this.Owner;//把Form2的父窗口指針賦給lForm1  
            lForm1.Repath = null;
            Close();
        }
        private string value = "";
        private void button3_Click(object sender, EventArgs e)
        {
            if (Labtext.Text != "")
            {

                if (deviceList.SelectedNode != null)
                {
                    if (deviceList.SelectedNode.Level == 5)
                    {
                        if (valueON.Checked == true)
                        { 
                            //if (deviceList.SelectedNode.Tag.ToString() == "SNVT_switch")
                            value = "100.0 1";
                        }
                        else if (valueOFF.Checked == true)
                        {
                            value = "0.0 0";
                        }
                        else if (valueCustomize.Checked == true)
                        {
                            value = inputValue.Text;
                        }
                    }
                }

                config_AlarmObject lForm1 = (config_AlarmObject)this.Owner;//把Form2的父窗口指針賦給lForm1  
                lForm1.Repath = Labtext.Text + "@" + targetindex.Text + "@" + value;
                Close();
            }
        }

        private void valueON_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void valueOFF_CheckedChanged(object sender, EventArgs e)
        {
          
        }
    }
}
