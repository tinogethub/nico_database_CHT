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
    public partial class config_OutputObjectButton : Form
    {
        public string targetip = "";
        public string NVType = "";
        public string NVType2 = "";
        public string picboxName = "";
        private string userOnImagePath = "";
        private string userOffImagePath = "";
        

        public config_OutputObjectButton()
        {
            InitializeComponent();
        }

        private void config_OutputObjectButton_Load(object sender, EventArgs e)
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
                                        string[] tmpStr = NVType2.Split('@');
                                        if (deviceList.Nodes[site].Nodes[fab].Nodes[area].Nodes[device].Nodes[obj].Nodes[nv].Tag.ToString() != "SNVT_switch") //tmpStr[1])
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
            for (int i = 0; i < memoryData.OutputButtonData.Count; i++)
            {
                OutputButtonObjectstruct lt = (OutputButtonObjectstruct)memoryData.OutputButtonData[i];
                if (lt.name == picboxName)
                {
                    if (lt.target != "")
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
                        ContactGroup2 gc = (ContactGroup2)memoryData.GroupContact2[g];
                        GroupContact.Items.Add(gc.groupname);
                    }

                    GroupContact.SelectedIndex = 0;

                    if (lt.buttontype == "0")
                    { buttonType1.Checked = true; }
                    else if (lt.buttontype == "1")
                    { buttonType2.Checked = true; }
                    else if (lt.buttontype == "2")
                    { buttonType3.Checked = true; }
                    else if (lt.buttontype == "3")
                    { buttonType4.Checked = true; }
                    else if (lt.buttontype == "4")
                    { buttonType5.Checked = true;

                    userOnImagePath = lt.userOnImagePath;
                    userOffImagePath = lt.userOffImagePath;
                    userON.Image = Image.FromFile(userOnImagePath);
                    userOFF.Image = Image.FromFile(userOffImagePath);
                    }

                    if (lt.NVvalue == "100.0 1")
                    { valueType1.Checked = true; }
                    else if (lt.NVvalue == "0.0 0")
                    { valueType2.Checked = true; }
                    else if (lt.NVvalue == "toggle")
                    { valueType4.Checked = true; }
                }
                
            }


        }

        private void valueType1_CheckedChanged(object sender, EventArgs e)
        {
            if (valueType1.Checked == true)
            { valueType3Text.Enabled = false; }
            else if (valueType2.Checked == true)
            { valueType3Text.Enabled = false; }
            else if (valueType3.Checked == true)
            { valueType3Text.Enabled = true; }
            else if (valueType4.Checked == true)
            { valueType3Text.Enabled = false; }

        }

        private void buttonType1_CheckedChanged(object sender, EventArgs e)
        {
            if (buttonType1.Checked == true)
            {
                switchImg.Enabled = true;
                pushImg.Enabled = false;
                push2Img.Enabled = false;
                knob1Img.Enabled = false;

                    //textwidth.Text = "53";
                    //textheight.Text = "22";

                ONlab.Enabled = false;
                OFFlab.Enabled = false;
                onimage.Enabled = false;
                offimage.Enabled = false;
                userON.Enabled = false;
                userOFF.Enabled = false;
            }
            else if (buttonType2.Checked == true)
            {
                switchImg.Enabled = false;
                pushImg.Enabled = true;
                push2Img.Enabled = false;
                knob1Img.Enabled = false;

                    //textwidth.Text = "66";
                    //textheight.Text = "60";

                ONlab.Enabled = false;
                OFFlab.Enabled = false;
                onimage.Enabled = false;
                offimage.Enabled = false;
                userON.Enabled = false;
                userOFF.Enabled = false;
            }
            else if (buttonType3.Checked == true)
            {
                switchImg.Enabled = false;
                pushImg.Enabled = false;
                push2Img.Enabled = true;
                knob1Img.Enabled = false;

                    //textwidth.Text = "66";
                    //textheight.Text = "60";

                ONlab.Enabled = false;
                OFFlab.Enabled = false;
                onimage.Enabled = false;
                offimage.Enabled = false;
                userON.Enabled = false;
                userOFF.Enabled = false;
            }
            else if (buttonType4.Checked == true)
            {
                switchImg.Enabled = false;
                pushImg.Enabled = false;
                push2Img.Enabled = false;
                knob1Img.Enabled = true;

                    //textwidth.Text = "45";
                    //textheight.Text = "45";

                ONlab.Enabled = false;
                OFFlab.Enabled = false;
                onimage.Enabled = false;
                offimage.Enabled = false;
                userON.Enabled = false;
                userOFF.Enabled = false;
            }
            else if (buttonType5.Checked == true)
            {
                switchImg.Enabled = false;
                pushImg.Enabled = false;
                push2Img.Enabled = false;
                knob1Img.Enabled = false;

                    //textwidth.Text = "64";
                    //textheight.Text = "64";


                ONlab.Enabled = true;
                OFFlab.Enabled = true;
                onimage.Enabled = true;
                offimage.Enabled = true;
                userON.Enabled = true;
                userOFF.Enabled = true;
                if (userOnImagePath == "")
                {
                    userOnImagePath = Application.StartupPath + @"\Resources\image\buttonknob1-on.png"; ;
                }

                if (userOffImagePath == "")
                {
                    userOffImagePath = Application.StartupPath + @"\Resources\image\buttonknob1-off.png"; ;
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
                    valueType1.Enabled = false;
                    valueType2.Enabled = false;
                }
                else if (deviceType == "lon")
                {
                    Labtext.Text = deviceType + "@" + deviceIp + "@Net/LON/" + deviceList.SelectedNode.Parent.Parent.Text +
                      "/" + deviceList.SelectedNode.Parent.Text + "/" + deviceList.SelectedNode.Text;
                    NVType = "lon";
                    valueType1.Enabled = true;
                    valueType2.Enabled = true;
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
            Form1 lForm1 = (Form1)this.Owner;//把Form2的父窗口指針賦給lForm1  
            lForm1.Repicturebox = null;
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (deviceList.SelectedNode.Level == 5)
            {

                for (int i = 0; i < memoryData.OutputButtonData.Count; i++)
                {
                    OutputButtonObjectstruct edit = (OutputButtonObjectstruct)memoryData.OutputButtonData[i];
                    if (edit.name == picboxName)
                    {
                        string Typetmp = "", Valuetmp = "", imgPath = "";
                        PictureBox editPb = new PictureBox();
                        //editPb.Tag = textX.Text + "@" + textY.Text;// +"@" + NVType + "@" + targetip + "@" + Labtext.Text;
                        
                        editPb.Location = new Point(int.Parse(textX.Text), int.Parse(textY.Text));
                        Form1 lForm1 = (Form1)this.Owner;//把Form2的父窗口指針賦給lForm1  
                        lForm1.Gettooltip = description.Text;

                        edit.description = description.Text;

                        edit.x = int.Parse(textX.Text);
                        edit.y = int.Parse(textY.Text);
                        edit.ip = targetip;
                        string[] getty = NVType2.Split('@');
                        edit.NVtype = getty[1];

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

                        if (buttonType1.Checked == true)
                        {
                            Typetmp = "0"; edit.buttontype = "0";  //edit.NVtype = "0";
                            if (valueType2.Checked == true)
                            {
                                editPb.Image = Image.FromFile(Application.StartupPath + @"\Resources\image\switch_off_png.png");
                                editPb.Tag = Application.StartupPath + @"\Resources\image\switch_off_png.png";
                                imgPath = Application.StartupPath + @"\Resources\image\switch_off_png.png";
                                edit.imagePath = Application.StartupPath + @"\Resources\image\switch_off_png.png";
                            }
                            else
                            {
                                editPb.Image = Image.FromFile(Application.StartupPath + @"\Resources\image\switch_on_png.png");
                                editPb.Tag = Application.StartupPath + @"\Resources\image\switch_on_png.png";
                                imgPath = Application.StartupPath + @"\Resources\image\switch_on_png.png";
                                edit.imagePath = Application.StartupPath + @"\Resources\image\switch_on_png.png";
                            }
                            //editPb.Size = new Size(53, 22);
                        }
                        else if (buttonType2.Checked == true)
                        {
                            Typetmp = "1"; edit.buttontype = "1"; //edit.NVtype = "1";
                            editPb.Image = Image.FromFile(Application.StartupPath + @"\Resources\image\button1_up.png");
                            editPb.Tag = Application.StartupPath + @"\Resources\image\button1_up.png";
                            imgPath = Application.StartupPath + @"\Resources\image\button1_up.png";
                            edit.imagePath = Application.StartupPath + @"\Resources\image\button1_up.png";
                            //editPb.Size = new Size(66, 60);
                        }
                        else if (buttonType3.Checked == true)
                        {
                            Typetmp = "2"; edit.buttontype = "2"; //edit.NVtype = "2";
                            editPb.Image = Image.FromFile(Application.StartupPath + @"\Resources\image\button2_up.png");
                            editPb.Tag = Application.StartupPath + @"\Resources\image\button2_up.png";
                            imgPath = Application.StartupPath + @"\Resources\image\button2_up.png";
                            edit.imagePath = Application.StartupPath + @"\Resources\image\button2_up.png";
                            //editPb.Size = new Size(66, 60);
                        }
                        else if (buttonType4.Checked == true)
                        {
                            Typetmp = "3"; edit.buttontype = "3"; //edit.NVtype = "3";
                            editPb.Image = Image.FromFile(Application.StartupPath + @"\Resources\image\buttonknob1-off.png");
                            editPb.Tag = Application.StartupPath + @"\Resources\image\buttonknob1-off.png";
                            imgPath = Application.StartupPath + @"\Resources\image\buttonknob1-off.png";
                            edit.imagePath = Application.StartupPath + @"\Resources\image\buttonknob1-off.png";
                            //editPb.Size = new Size(45, 45);
                        }
                        else if (buttonType5.Checked == true)
                        {
                            Typetmp = "4"; edit.buttontype = "4"; //edit.NVtype = "4";
                            editPb.Image = Image.FromFile(userOffImagePath);
                            editPb.Tag = userOffImagePath;
                            imgPath = userOffImagePath;
                            edit.imagePath = userOffImagePath;
                        }
                        
                        editPb.Size = new Size(int.Parse(textwidth.Text), int.Parse(textheight.Text));
                        if (valueType1.Checked == true)
                        { edit.NVvalue = "100.0 1"; Valuetmp = "100.0 1"; }
                        else if (valueType2.Checked == true)
                        { edit.NVvalue = "0.0 0"; Valuetmp = "0.0 0"; }
                        else if (valueType3.Checked == true)
                        { edit.NVvalue = valueType3Text.Text; Valuetmp = valueType3Text.Text; }
                        else if (valueType4.Checked == true)
                        { edit.NVvalue = "toggle"; Valuetmp = "toggle"; }

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

                            edit.width = editPb.Size.Width;
                            edit.height = editPb.Size.Height;
                            edit.userOnImagePath = userOnImagePath;
                            edit.userOffImagePath = userOffImagePath;

                            if (GroupContact.Text != "")
                            {
                                edit.contactGroup = GroupContact.Text;
                            }
                            else
                            {
                                edit.contactGroup = "";
                            }

                        //editPb.Tag = Typetmp + "$" + edit.NVvalue + "$" + imgPath;
                        memoryData.OutputButtonData[i] = edit;
                        lForm1.Repicturebox = editPb;
                        break;
                    }
                }
                Close();
            }
        }

        private void onimage_Click(object sender, EventArgs e)
        {
            OpenFileDialog myopen = new OpenFileDialog();
            myopen.Filter = "Image Files (*.jpg, *.bmp, *.gif, *.png)|*.jpg; *.bmp; *.gif; *.png;";
            if (myopen.ShowDialog() == DialogResult.OK)
            {
                userON.Image = Image.FromFile(myopen.FileName);
                userOnImagePath = myopen.FileName.ToString();
            }
        }

        private void offimage_Click(object sender, EventArgs e)
        {
            OpenFileDialog myopen = new OpenFileDialog();
            myopen.Filter = "Image Files (*.jpg, *.bmp, *.gif, *.png)|*.jpg; *.bmp; *.gif; *.png;";
            if (myopen.ShowDialog() == DialogResult.OK)
            {
                userOFF.Image = Image.FromFile(myopen.FileName);
                userOffImagePath = myopen.FileName.ToString();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

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
