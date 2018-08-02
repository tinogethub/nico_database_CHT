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
    public partial class config_OutputObjectPopEdit : Form
    {
        public string targetip = "";
        public string NVType = "";
        public string NVType2 = "";
        public string popName = "";
        public string imagePath = null;

        public config_OutputObjectPopEdit()
        {
            InitializeComponent();
        }

        private void config_OutputObjectPopEdit_Load(object sender, EventArgs e)
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
                                        string[] tmpStr = NVType2.Split('@');
                                        if (deviceList.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes[obj].Nodes[nv].Tag.ToString() != tmpStr[1])
                                        {
                                            deviceList.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes[obj].Nodes[nv].Remove();
                                        }
                                        else if (deviceList.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes[obj].Nodes[nv].Tag.ToString() == tmpStr[1])
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

            for (int i = 0; i < memoryData.OutputPopData.Count; i++)
            {
                OutputPopObjectstruct tar = (OutputPopObjectstruct)memoryData.OutputPopData[i];
                if (tar.name == popName)
                {
                    if (tar.target != "")
                    {
                        string[] index = tar.targetindex.Split('_');
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

                    if (tar.AlignText.ToString() != "")
                    {
                        textAlign.Text = tar.AlignText.ToString();
                    }
                    if (tar.AlignIMG.ToString() != "")
                    {
                        imageAlign.Text = tar.AlignIMG.ToString();
                    }

                    Demobutton.BackColor = Color.FromArgb(tar.backColor);
                    description.Text = tar.description;

                    if (tar.backImage != null && tar.backImage != "")
                    {
                        Demobutton.Image = Image.FromFile(tar.backImage);
                        imagePath = tar.backImage;
                    }

                    if (tar.useBackIMG == true)
                    {
                        backgroundimage.Checked = true;
                    }
                    else if (tar.useBackColor == true)
                    {
                        backgroundcolor.Checked = true;
                    }

                    if (tar.log == true)
                    {
                        checkBox1.Checked = true;
                    }

                    if (tar.mail == true)
                    {
                        checkBox2.Checked = true;
                    }

                    if (tar.SMS == true)
                    {
                        checkBox3.Checked = true;
                    }
                    //load group contact list
                    for (int g = 0; g < memoryData.GroupContact2.Count; g++)
                    {
                        ContactGroup2 gc = (ContactGroup2)memoryData.GroupContact2[g];
                        GroupContact.Items.Add(gc.groupname);
                    }

                    GroupContact.SelectedIndex = 0;
                }
            }
        }

        private void buttonText_KeyUp(object sender, KeyEventArgs e)
        {
            Demobutton.Text = buttonText.Text;
        }

        private void buttonWidth_KeyUp(object sender, KeyEventArgs e)
        {
            int w;
            w = int.Parse(buttonWidth.Text);
            Demobutton.Size = new Size(w, Demobutton.Size.Height);
        }

        private void buttonHeight_KeyUp(object sender, KeyEventArgs e)
        {
            int h;
            h = int.Parse(buttonHeight.Text);
            Demobutton.Size = new Size(Demobutton.Size.Width, h);
        }

        private void FontCMD_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.ShowColor = true;
            fd.Color = Demobutton.ForeColor;
            fd.Font = Demobutton.Font;
            try
            {
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    Demobutton.Font = fd.Font;
                    Demobutton.ForeColor = fd.Color;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void textAlign_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (textAlign.SelectedIndex)
            {
                case 0:
                    Demobutton.TextAlign = ContentAlignment.BottomCenter;
                    break;
                case 1:
                    Demobutton.TextAlign = ContentAlignment.BottomLeft;
                    break;
                case 2:
                    Demobutton.TextAlign = ContentAlignment.BottomRight;
                    break;
                case 3:
                    Demobutton.TextAlign = ContentAlignment.MiddleCenter;
                    break;
                case 4:
                    Demobutton.TextAlign = ContentAlignment.MiddleLeft;
                    break;
                case 5:
                    Demobutton.TextAlign = ContentAlignment.MiddleRight;
                    break;
                case 6:
                    Demobutton.TextAlign = ContentAlignment.TopCenter;
                    break;
                case 7:
                    Demobutton.TextAlign = ContentAlignment.TopLeft;
                    break;
                case 8:
                    Demobutton.TextAlign = ContentAlignment.TopRight;
                    break;
            }
        }

        private void backgroundimage_CheckedChanged(object sender, EventArgs e)
        {
            if (backgroundimage.Checked == true)
            {
                ImageCMD.Enabled = true;
                backgroundcolor.Enabled = false;
                ColorCMD.Enabled = false;
            }
            else if (backgroundimage.Checked == false)
            {
                ImageCMD.Enabled = false;
                backgroundcolor.Enabled = true;
                ColorCMD.Enabled = false;
                Demobutton.Image = null;
            }
        }

        private void ImageCMD_Click(object sender, EventArgs e)
        {
            OpenFileDialog myopen = new OpenFileDialog();
            myopen.Filter = "Image Files (*.jpg, *.bmp, *.gif, *.png)|*.jpg; *.bmp; *.gif; *.png;";
            if (myopen.ShowDialog() == DialogResult.OK)

                Demobutton.BackColor = Color.Transparent;
            Demobutton.Image = Image.FromFile(myopen.FileName);
            imagePath = myopen.FileName.ToString();
        }

        private void ColorCMD_Click(object sender, EventArgs e)
        {
            ColorDialog mycolor = new ColorDialog();
            mycolor.Color = Demobutton.BackColor;
            if (mycolor.ShowDialog() == DialogResult.OK)
            {
                Demobutton.BackColor = mycolor.Color;
            }
        }

        private void imageAlign_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (imageAlign.SelectedIndex)
            {
                case 0:
                    Demobutton.ImageAlign = ContentAlignment.BottomCenter;
                    break;
                case 1:
                    Demobutton.ImageAlign = ContentAlignment.BottomLeft;
                    break;
                case 2:
                    Demobutton.ImageAlign = ContentAlignment.BottomRight;
                    break;
                case 3:
                    Demobutton.ImageAlign = ContentAlignment.MiddleCenter;
                    break;
                case 4:
                    Demobutton.ImageAlign = ContentAlignment.MiddleLeft;
                    break;
                case 5:
                    Demobutton.ImageAlign = ContentAlignment.MiddleRight;
                    break;
                case 6:
                    Demobutton.ImageAlign = ContentAlignment.TopCenter;
                    break;
                case 7:
                    Demobutton.ImageAlign = ContentAlignment.TopLeft;
                    break;
                case 8:
                    Demobutton.ImageAlign = ContentAlignment.TopRight;
                    break;
            }
        }

        private void CMDCancel_Click(object sender, EventArgs e)
        {
            Form1 lForm1 = (Form1)this.Owner;//把Form2的父窗口指針賦給lForm1  
            lForm1.Rebutton = null;
            Close();
        }

        private void CMDApply_Click(object sender, EventArgs e)
        {
            if (buttonWidth.Text == "") { buttonWidth.Text = "80"; }
            if (buttonHeight.Text == "") { buttonHeight.Text = "28"; }

            Demobutton.Tag = textX.Text + "_" + textY.Text;

            Form1 lForm1 = (Form1)this.Owner;//把Form2的父窗口指針賦給lForm1  
            lForm1.Rebutton = Demobutton;
            lForm1.Gettooltip = description.Text;

            for (int i = 0; i < memoryData.OutputPopData.Count; i++)
            {
                OutputPopObjectstruct edit = (OutputPopObjectstruct)memoryData.OutputPopData[i];
                if (edit.name == popName)
                {
                    edit.AlignIMG = Demobutton.ImageAlign;
                    edit.AlignText = Demobutton.TextAlign;
                    edit.backColor = Demobutton.BackColor.ToArgb();
                    if (Demobutton.Image != null)
                    { edit.backImage = imagePath; }
                    else
                    { edit.backImage = null; }

                    edit.font = Demobutton.Font;
                    edit.forecolor = Demobutton.ForeColor.ToArgb();
                    edit.text = Demobutton.Text;
                    edit.height = Demobutton.Size.Height;
                    edit.width = Demobutton.Size.Width;
                    edit.x = int.Parse(textX.Text);
                    edit.y = int.Parse(textY.Text);
                    edit.ip = targetip;

                    string[] gettag = edit.tag.Split('@');
                    edit.NVtype = gettag[1];

                    edit.description = description.Text;

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

                    if (backgroundimage.Checked == true)
                    {
                        edit.useBackIMG = true;
                        edit.useBackColor = false;
                    }
                    else if (backgroundcolor.Checked == true)
                    {
                        edit.useBackIMG = false;
                        edit.useBackColor = true;
                    }
                    else if (backgroundcolor.Checked == false && backgroundimage.Checked == false)
                    {
                        edit.useBackIMG = false;
                        edit.useBackColor = false;
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

                    if (GroupContact.Text != "")
                    {
                        edit.contactGroup = GroupContact.Text;
                    }
                    else
                    {
                        edit.contactGroup = "";
                    }

                    memoryData.OutputPopData[i] = edit;
                    break;
                }
            }
            this.Close();
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

        private void backgroundcolor_CheckedChanged(object sender, EventArgs e)
        {
            if (backgroundcolor.Checked == true)
            {
                ColorCMD.Enabled = true;
                backgroundimage.Enabled = false;
                ImageCMD.Enabled = false;
            }
            else if (backgroundcolor.Checked == false)
            {

                ColorCMD.Enabled = false;
                backgroundimage.Enabled = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                GroupContact.Enabled = true;
            }
            else if (checkBox2.Enabled == false && checkBox3.Checked == false)
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
            else if (checkBox2.Enabled == false && checkBox3.Checked == false)
            {
                GroupContact.Enabled = false;
            }
        }


    }
}
