using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace nico_database
{
    public partial class config_PictureObject : Form
    {
        public string picName="";

        public config_PictureObject()
        {
            InitializeComponent();
        }

        private void config_PictureObject_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < memoryData.PictureData.Count; i++)
            {
                PictureboxObjectstruct tar = (PictureboxObjectstruct)memoryData.PictureData[i];
                if (tar.name == picName)
                {
                    imagePATH.Text = tar.path;
                    textX.Text = tar.x.ToString();
                    textY.Text = tar.y.ToString();
                    textwidth.Text = tar.width.ToString();
                    textheight.Text = tar.height.ToString();

                    if(tar.path != "" && tar.path != null)
                    {
                        if (System.IO.File.Exists(tar.path))
                        {
                            //find
                            FileStream fs = File.OpenRead(tar.path);
                            preview.Image = (Bitmap)Image.FromStream(fs);
                            fs.Close();
                        }
                        else
                        {
                            //not found
                        }
                    }
                }
            }
        }

        private void openimage_Click(object sender, EventArgs e)
        {
            OpenFileDialog myopen = new OpenFileDialog();
            myopen.Filter = "Image Files (*.jpg, *.bmp, *.gif, *.png)|*.jpg; *.bmp; *.gif; *.png;";
            if (myopen.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = File.OpenRead(myopen.FileName);
                preview.Image = (Bitmap)Image.FromStream(fs);
                fs.Close();
                imagePATH.Text = myopen.FileName.ToString();
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Form1 lForm1 = (Form1)this.Owner;//把Form2的父窗口指針賦給lForm1  
            lForm1.Repicturebox = null;
            Close();
        }

        private void cmdApply_Click(object sender, EventArgs e)
        {


            for (int i = 0; i < memoryData.PictureData.Count; i++)
            {
                PictureboxObjectstruct edit = (PictureboxObjectstruct)memoryData.PictureData[i];
                PictureBox editPB = new PictureBox();
                if (edit.name == picName)
                {
                    Form1 lForm1 = (Form1)this.Owner;//把Form2的父窗口指針賦給lForm1  
                    editPB.Location = new Point(int.Parse(textX.Text), int.Parse(textY.Text));
                    editPB.Size = new Size(int.Parse(textwidth.Text), int.Parse(textheight.Text));
                    editPB.Tag = imagePATH.Text;
                    
                    lForm1.Repicturebox = editPB;

                    edit.path = imagePATH.Text;
                    edit.x = int.Parse(textX.Text);
                    edit.y = int.Parse(textY.Text);
                    edit.width = int.Parse(textwidth.Text);
                    edit.height = int.Parse(textheight.Text);
                    memoryData.PictureData[i] = edit;
                    Close();
                }
            }
        }
    }
}
