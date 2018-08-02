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
    public partial class config_ButtonObject : Form
    {
        public ComboBox getLayerItem;
        public string buttonName = "";
        public string imagePath = null;

        public config_ButtonObject()
        {
            InitializeComponent();
        }

       

        private void FontCMD_Click(object sender, EventArgs e)
        {
            Demobutton.AutoSize = true;
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
                    buttonWidth.Text = Demobutton.Size.Width.ToString();
                    buttonHeight.Text = Demobutton.Size.Height.ToString();
                    //Demobutton.AutoSize = false;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); Demobutton.AutoSize = false; }
            
        }

        private void buttonText_KeyUp(object sender, KeyEventArgs e)
        {
            //Demobutton.AutoSize = true;
            Demobutton.Text = buttonText.Text;

            //Demobutton.AutoSize = false;
        }

        private void buttonWidth_KeyUp(object sender, KeyEventArgs e)
        {
            Demobutton.AutoSize = false;
            int w;
            w = int.Parse(buttonWidth.Text);
            Demobutton.Size = new Size(w, Demobutton.Size.Height);
        }

        private void buttonHeight_KeyUp(object sender, KeyEventArgs e)
        {
            Demobutton.AutoSize = false;
            int h;
            h = int.Parse(buttonHeight.Text);
            Demobutton.Size = new Size(Demobutton.Size.Width, h);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (buttonWidth.Text == "") { buttonWidth.Text = "80"; }
            if (buttonHeight.Text == "") { buttonHeight.Text = "28"; }
            if (buttonTargetList.Text == null) { buttonTargetList.SelectedIndex = 0; }

            Demobutton.Tag = textX.Text + "_" + textY.Text;

            Form1 lForm1 = (Form1)this.Owner;//把Form2的父窗口指針賦給lForm1  
            lForm1.Rebutton = Demobutton;
            
            lForm1.RebuttonTarget = buttonTargetList.SelectedItem.ToString();

            for (int i = 0; i < memoryData.ButtonData.Count; i++)
            {
                ButtonObjstruct edit = (ButtonObjstruct)memoryData.ButtonData[i];
                if (edit.name == buttonName)
                {
                    edit.AlignImage = Demobutton.ImageAlign.ToString();
                    edit.AlignText = Demobutton.TextAlign.ToString();
                    edit.backColor = Demobutton.BackColor.ToArgb();
                    if (Demobutton.Image != null)
                    { edit.backImage = imagePath; }
                    else
                    { edit.backImage = null; }
                    
                    edit.command = buttonTargetList.Text;
                    edit.font = Demobutton.Font;
                    edit.forecolor = Demobutton.ForeColor.ToArgb();
                    edit.height = Demobutton.Size.Height;
                    edit.text = Demobutton.Text;
                    edit.width = Demobutton.Size.Width;
                    edit.x = int.Parse(textX.Text);
                    edit.y = int.Parse(textY.Text);

                    if (backgroundimage.Checked == true)
                    {
                        edit.useBackIMG = true;
                        edit.useBackColor = false;
                        edit.backImage = imagePath;
                    }
                    else if (backgroundcolor.Checked == true)
                    {
                        edit.useBackIMG = false;
                        edit.useBackColor = true;
                        edit.backImage = "";
                    }
                    else if (backgroundcolor.Checked == false && backgroundimage.Checked == false)
                    {
                        edit.useBackIMG = false;
                        edit.useBackColor = false;
                        edit.backImage = "";
                    }


                    memoryData.ButtonData[i] = edit;
                    break;
                }
            }

            this.Close();  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 lForm1 = (Form1)this.Owner;//把Form2的父窗口指針賦給lForm1  
            lForm1.Rebutton = null;
            Close();
        }

        private void config_ButtonObject_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < getLayerItem.Items.Count; i++)
            {
                buttonTargetList.Items.Add(getLayerItem.Items[i].ToString());
            }
            buttonTargetList.SelectedIndex = 0;

            for (int i = 0; i < memoryData.ButtonData.Count; i++)
            {
                ButtonObjstruct lo = (ButtonObjstruct)memoryData.ButtonData[i];
                if (lo.name == buttonName)
                {
                    if (lo.AlignText == "BottomCenter") { textAlign.SelectedIndex = 0; Demobutton.TextAlign = ContentAlignment.BottomCenter; }
                    else if (lo.AlignText == "BottomLeft") { textAlign.SelectedIndex = 1; Demobutton.TextAlign = ContentAlignment.BottomLeft; }
                    else if (lo.AlignText == "BottomRight") { textAlign.SelectedIndex = 2; Demobutton.TextAlign = ContentAlignment.BottomRight; }
                    else if (lo.AlignText == "MiddleCenter") { textAlign.SelectedIndex = 3; Demobutton.TextAlign = ContentAlignment.MiddleCenter; }
                    else if (lo.AlignText == "MiddleLeft") { textAlign.SelectedIndex = 4; Demobutton.TextAlign = ContentAlignment.MiddleLeft; }
                    else if (lo.AlignText == "MiddleRight") { textAlign.SelectedIndex = 5; Demobutton.TextAlign = ContentAlignment.MiddleRight; }
                    else if (lo.AlignText == "TopCenter") { textAlign.SelectedIndex = 6; Demobutton.TextAlign = ContentAlignment.TopCenter; }
                    else if (lo.AlignText == "TopLeft") { textAlign.SelectedIndex = 7; Demobutton.TextAlign = ContentAlignment.TopLeft; }
                    else if (lo.AlignText == "TopRight") { textAlign.SelectedIndex = 8; Demobutton.TextAlign = ContentAlignment.TopRight; }

                    if (lo.AlignImage == "BottomCenter") { imageAlign.SelectedIndex = 0; Demobutton.ImageAlign = ContentAlignment.BottomCenter; }
                    else if (lo.AlignImage == "BottomLeft") { imageAlign.SelectedIndex = 1; Demobutton.ImageAlign = ContentAlignment.BottomLeft; }
                    else if (lo.AlignImage == "BottomRight") { imageAlign.SelectedIndex = 2; Demobutton.ImageAlign = ContentAlignment.BottomRight; }
                    else if (lo.AlignImage == "MiddleCenter") { imageAlign.SelectedIndex = 3; Demobutton.ImageAlign = ContentAlignment.MiddleCenter; }
                    else if (lo.AlignImage == "MiddleLeft") { imageAlign.SelectedIndex = 4; Demobutton.ImageAlign = ContentAlignment.MiddleLeft; }
                    else if (lo.AlignImage == "MiddleRight") { imageAlign.SelectedIndex = 5; Demobutton.ImageAlign = ContentAlignment.MiddleRight; }
                    else if (lo.AlignImage == "TopCenter") { imageAlign.SelectedIndex = 6; Demobutton.ImageAlign = ContentAlignment.TopCenter; }
                    else if (lo.AlignImage == "TopLeft") { imageAlign.SelectedIndex = 7; Demobutton.ImageAlign = ContentAlignment.TopLeft; }
                    else if (lo.AlignImage == "TopRight") { imageAlign.SelectedIndex = 8; Demobutton.ImageAlign = ContentAlignment.TopRight; }

                    
                    Demobutton.BackColor = Color.FromArgb(lo.backColor);
                    
                    if (lo.backImage != null && lo.backImage !="") 
                    { 
                        Demobutton.Image = Image.FromFile(lo.backImage); 
                        imagePath = lo.backImage; 
                    }

                    if (lo.useBackIMG == true)
                    {
                        backgroundimage.Checked = true;
                    }
                    else if (lo.useBackColor == true)
                    {
                        backgroundcolor.Checked = true;
                    }

                    Demobutton.AutoSize = true;
                    buttonTargetList.SelectedItem = lo.command;
                    Demobutton.Font = lo.font;
                    Demobutton.ForeColor=Color.FromArgb(lo.forecolor);
                    //buttonHeight .Text = lo.height.ToString();
                    //buttonWidth.Text = lo.width.ToString();
                    //Demobutton.Size = new Size(lo.width, lo.height);
                    buttonText.Text = lo.text;
                    Demobutton.Text = lo.text;
                    buttonWidth.Text = Demobutton.Size.Width.ToString();
                    buttonHeight.Text = Demobutton.Size.Height.ToString();
                    textX.Text = lo.x.ToString();
                    textY.Text = lo.y.ToString();
                    
                }
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
            {
                Demobutton.BackColor = Color.Transparent;
                Demobutton.Image = Image.FromFile(myopen.FileName);
                imagePath = myopen.FileName.ToString();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (textAlign.SelectedIndex)
            {
                case 0:
                    Demobutton.TextAlign = ContentAlignment.BottomCenter;
                    break;
                case 1:
                    Demobutton.TextAlign = ContentAlignment.BottomLeft ;
                    break;
                case 2:
                    Demobutton.TextAlign = ContentAlignment.BottomRight ;
                    break;
                case 3:
                    Demobutton.TextAlign = ContentAlignment.MiddleCenter ;
                    break;
                case 4:
                    Demobutton.TextAlign = ContentAlignment.MiddleLeft ;
                    break;
                case 5:
                    Demobutton.TextAlign = ContentAlignment.MiddleRight ;
                    break;
                case 6:
                    Demobutton.TextAlign = ContentAlignment.TopCenter ;
                    break;
                case 7:
                    Demobutton.TextAlign = ContentAlignment.TopLeft ;
                    break;
                case 8:
                    Demobutton.TextAlign = ContentAlignment.TopRight ;
                    break;
            }
        }

        private void imageAlign_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (imageAlign.SelectedIndex)
            {
                case 0:
                    Demobutton.ImageAlign  = ContentAlignment.BottomCenter;
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

        private void backgroundcolor_CheckedChanged(object sender, EventArgs e)
        {
            if (backgroundcolor.Checked == true)
            { ColorCMD.Enabled = true;
            backgroundimage.Enabled = false;
            ImageCMD.Enabled = false;
            }
            else if (backgroundcolor.Checked == false)
            {
                
                ColorCMD.Enabled = false;
                backgroundimage.Enabled = true;
            }
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

        private void config_ButtonObject_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void buttonTargetList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonText_KeyDown(object sender, KeyEventArgs e)
        {
            Demobutton.AutoSize = true;
        }

        private void buttonText_TextChanged(object sender, EventArgs e)
        {
            buttonWidth.Text = Demobutton.Size.Width.ToString();
            buttonHeight.Text = Demobutton.Size.Height.ToString();
        }

       

        
    }
}
