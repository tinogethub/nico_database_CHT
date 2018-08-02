using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace nico_database
{
    public partial class Layer_edit : Form
    {
        public Layer_edit()
        {
            InitializeComponent();
        }

        //private Layerstruct tempLayer = new Layerstruct();

        private void layerListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (layerListBox.SelectedItem != null)
            {
                layerBackgroundGroup.Text = layerListBox.SelectedItem.ToString();
                layerName.Text = layerListBox.SelectedItem.ToString();
                for (int i = 0; i < memoryData.LayerData.Count; i++)
                {
                    Layerstruct edit = (Layerstruct)memoryData.LayerData[i];
                    if (edit.name == layerListBox.Text)
                    {
                        layerBackground.BackColor = Color.FromArgb(edit.backColor);
                        if (edit.backImage != "")
                        {
                            if (System.IO.File.Exists(edit.backImage))
                            {
                                //find
                                FileStream fs = File.OpenRead(edit.backImage);
                                layerBackground.Image = (Bitmap)Image.FromStream(fs);
                                fs.Close();
                            }
                            else
                            {
                                //not found
                            }
    
                        }
                        else
                        {
                            layerBackground.Image = null;
                        }
                        
                        if (edit.sizeMode == "Normal") { layerBackground.SizeMode = PictureBoxSizeMode.Normal; }
                        else if (edit.sizeMode == "StretchImage") { layerBackground.SizeMode = PictureBoxSizeMode.StretchImage; }

                    }
                }
                
            }
        }

        private void layerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                layerAddCmd.Focus();
                layerAddCmd_Click(sender, e);
            }
        }

        private void layerAddCmd_Click(object sender, EventArgs e)
        {
            if (layerName.Text != "")
            {
                if (layerNameRepeatChk(layerName.Text) == false)
                {
                    layerListBox.Items.Add(layerName.Text);

                    Layerstruct addnew = new Layerstruct();
                    addnew.name = layerName.Text;
                    addnew.sizeMode = "Normal";
                    addnew.backImage = "";
                    addnew.backColor = SystemColors.Control.ToArgb();
                    memoryData.LayerData.Add(addnew);
                    layerListBox.SelectedItem = layerName.Text;
                }
                else { MessageBox.Show("layer name already in use."); }

            }
            else { MessageBox.Show("layer name can not empty"); }
        }

        private Boolean layerNameRepeatChk(string inputName)
        {
            Boolean Repeat = false;
            for (int i = 0; i < layerListBox.Items.Count; i++)
            {
                if (layerListBox.FindString(inputName) != -1)
                {
                    Repeat = true;
                }
            }

            return Repeat;
        }

        private void layerRenameCmd_Click(object sender, EventArgs e)
        {
            if (layerListBox.SelectedItem != null)
            {
                if (layerListBox.SelectedIndex != 0)
                {
                    
                    for (int i = 0; i < memoryData.LayerData.Count; i++)
                    {
                        Layerstruct getVal = (Layerstruct)memoryData.LayerData[i];
                        if (getVal.name == layerListBox.Text)
                        {
                            getVal.name = layerName.Text;
                            memoryData.LayerData[i] = getVal;
                            break;
                        }
                    }

                    for (int i = 0; i < memoryData.LabelData.Count;i++ )
                    {
                        LabelObjstruct edit = (LabelObjstruct)memoryData.LabelData[i];
                        if (edit.layer == layerListBox.Text)
                        {
                            edit.layer = layerName.Text;
                            memoryData.LabelData[i] = edit;
                        }
                    }

                    for (int i = 0; i < memoryData.ButtonData.Count; i++)
                    {
                        ButtonObjstruct edit = (ButtonObjstruct)memoryData.ButtonData[i];
                        if (edit.layer == layerListBox.Text)
                        {
                            edit.layer = layerName.Text;
                            memoryData.ButtonData[i] = edit;
                        }
                    }

                    for (int i = 0; i < memoryData.InputData.Count; i++)
                    {
                        InputObjectstruct edit = (InputObjectstruct)memoryData.InputData[i];
                        if (edit.layer == layerListBox.Text)
                        {
                            edit.layer = layerName.Text;
                            memoryData.InputData[i] = edit;
                        }
                    }

                    for (int i = 0; i < memoryData.OutputButtonData.Count; i++)
                    {
                        OutputButtonObjectstruct edit = (OutputButtonObjectstruct)memoryData.OutputButtonData[i];
                        if (edit.layer == layerListBox.Text)
                        {
                            edit.layer = layerName.Text;
                            memoryData.OutputButtonData[i] = edit;
                        }
                    }

                    for (int i = 0; i < memoryData.OutputTextData.Count; i++)
                    {
                        OutputTextObjectstruct edit = (OutputTextObjectstruct)memoryData.OutputTextData[i];
                        if (edit.layer == layerListBox.Text)
                        {
                            edit.layer = layerName.Text;
                            memoryData.OutputTextData[i] = edit;
                        }
                    }

                    for (int i = 0; i < memoryData.OutputPopData.Count; i++)
                    {
                        OutputPopObjectstruct edit = (OutputPopObjectstruct)memoryData.OutputPopData[i];
                        if (edit.layer == layerListBox.Text)
                        {
                            edit.layer = layerName.Text;
                            memoryData.OutputPopData[i] = edit;
                        }
                    }

                    for (int i = 0; i < memoryData.PictureData.Count; i++)
                    {
                        PictureboxObjectstruct edit = (PictureboxObjectstruct)memoryData.PictureData[i];
                        if (edit.layer == layerListBox.Text)
                        {
                            edit.layer = layerName.Text;
                            memoryData.PictureData[i] = edit;
                        }
                    }

                    for (int i = 0; i < memoryData.AlarmData.Count; i++)
                    {
                        AlarmObjectstruct edit = (AlarmObjectstruct)memoryData.AlarmData[i];
                        if (edit.layer == layerListBox.Text)
                        {
                            edit.layer = layerName.Text;
                            memoryData.AlarmData[i] = edit;
                        }
                    }

                        layerListBox.Items[layerListBox.SelectedIndex] = layerName.Text;
                }
                else { MessageBox.Show("bottom layer can not rename!"); }
            }
        }

        private void layerDelCmd_Click(object sender, EventArgs e)
        {
            if (layerListBox.SelectedItem != null)
            {
                if (layerListBox.SelectedIndex != 0)
                {
                    string tarName = layerListBox.Text;

                    string message = "target : "  + layerListBox.SelectedItem.ToString();
                    string caption = "delete layer";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        
                        

                        for(int i=memoryData.AlarmData.Count-1;i>=0;i--)
                        {
                            AlarmObjectstruct tar = (AlarmObjectstruct)memoryData.AlarmData[i];
                            if(tar.layer == tarName)
                            {
                                memoryData.AlarmData.Remove(tar);
                                int index = memoryData.iconTemp.IndexOf(tar.name);
                                if(index != -1)
                                {
                                    memoryData.iconTemp.RemoveAt(index);
                                    memoryData.iconDelTemp.Add(tar.name);
                                }
                            }

                            for (int a=0;a<memoryData.AlarmMonitorValue.Count;a++)
                            {
                                AlarmMoniTorNV mtar = (AlarmMoniTorNV)memoryData.AlarmMonitorValue[a];
                                if(mtar.name == tar.name)
                                {
                                    memoryData.AlarmMonitorValue.Remove(mtar);
                                    break;
                                }
                            }

                        }

                        for(int i=memoryData.ButtonData.Count-1;i>=0;i--)
                        {
                            ButtonObjstruct tar = (ButtonObjstruct)memoryData.ButtonData[i];
                            if(tar.layer == tarName)
                            {
                                memoryData.ButtonData.Remove(tar);
                                int index = memoryData.iconTemp.IndexOf(tar.name);
                                if (index != -1)
                                {
                                    memoryData.iconTemp.RemoveAt(index);
                                    memoryData.iconDelTemp.Add(tar.name);
                                }
                            }

                        }

                        for (int i = memoryData.InputData.Count - 1; i >= 0; i--)
                        {
                            InputObjectstruct tar = (InputObjectstruct)memoryData.InputData[i];
                            if (tar.layer == tarName)
                            {
                                memoryData.InputData.Remove(tar);
                                int index = memoryData.iconTemp.IndexOf(tar.name);
                                if (index != -1)
                                {
                                    memoryData.iconTemp.RemoveAt(index);
                                    memoryData.iconDelTemp.Add(tar.name);
                                }
                            }
                        }

                        for (int i = memoryData.LabelData.Count - 1; i >= 0; i--)
                        {
                            LabelObjstruct tar = (LabelObjstruct)memoryData.LabelData[i];
                            if (tar.layer == tarName)
                            {
                                memoryData.LabelData.Remove(tar);
                                int index = memoryData.iconTemp.IndexOf(tar.name);
                                if (index != -1)
                                {
                                    memoryData.iconTemp.RemoveAt(index);
                                    memoryData.iconDelTemp.Add(tar.name);
                                }
                            }
                        }

                        for (int i = memoryData.OutputButtonData.Count - 1; i >= 0; i--)
                        {
                            OutputButtonObjectstruct tar = (OutputButtonObjectstruct)memoryData.OutputButtonData[i];
                            if (tar.layer == tarName)
                            {
                                memoryData.OutputButtonData.Remove(tar);
                                int index = memoryData.iconTemp.IndexOf(tar.name);
                                if (index != -1)
                                {
                                    memoryData.iconTemp.RemoveAt(index);
                                    memoryData.iconDelTemp.Add(tar.name);
                                }
                            }
                        }

                        for (int i = memoryData.OutputPopData.Count - 1; i >= 0; i--)
                        {
                            OutputPopObjectstruct tar = (OutputPopObjectstruct)memoryData.OutputPopData[i];
                            if (tar.layer == tarName)
                            {
                                memoryData.OutputPopData.Remove(tar);
                                int index = memoryData.iconTemp.IndexOf(tar.name);
                                if (index != -1)
                                {
                                    memoryData.iconTemp.RemoveAt(index);
                                    memoryData.iconDelTemp.Add(tar.name);
                                }
                            }
                        }

                        for (int i = memoryData.OutputTextData.Count - 1; i >= 0; i--)
                        {
                            OutputTextObjectstruct tar = (OutputTextObjectstruct)memoryData.OutputTextData[i];
                            if (tar.layer == tarName)
                            {
                                memoryData.OutputTextData.Remove(tar);
                                int index = memoryData.iconTemp.IndexOf(tar.name);
                                if (index != -1)
                                {
                                    memoryData.iconTemp.RemoveAt(index);
                                    memoryData.iconDelTemp.Add(tar.name);
                                }
                            }
                        }

                        for (int i = memoryData.PictureData.Count - 1; i >= 0; i--)
                        {
                            PictureboxObjectstruct tar = (PictureboxObjectstruct)memoryData.PictureData[i];
                            if (tar.layer == tarName)
                            {
                                memoryData.PictureData.Remove(tar);
                                int index = memoryData.iconTemp.IndexOf(tar.name);
                                if (index != -1)
                                {
                                    memoryData.iconTemp.RemoveAt(index);
                                    memoryData.iconDelTemp.Add(tar.name);
                                }
                            }
                        }

                        for (int i = 0; i < memoryData.LayerData.Count; i++)
                        {
                            Layerstruct getVal = (Layerstruct)memoryData.LayerData[i];
                            if (getVal.name == tarName)
                            {
                                memoryData.LayerData.Remove(memoryData.LayerData[i]);
                                //layerListBox.Items.Remove(layerListBox.SelectedItem);
                                layerListBox.Items.RemoveAt(layerListBox.SelectedIndex);
                                break;
                            }
                        }

                    }

                    
                    
                }
                else
                {
                    MessageBox.Show("bottom layer can not delete!");
                }
            }
        }

        private void layerDelAllCmd_Click(object sender, EventArgs e)
        {
            string message = "target : " + layerListBox.SelectedItem.ToString();
            string caption = "delete layer";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                for (int layerindex = 1; layerindex < memoryData.LayerData.Count;layerindex ++ )
                {
                    for (int i = memoryData.ButtonData.Count - 1; i >= 0; i--)
                    {
                        ButtonObjstruct tar = (ButtonObjstruct)memoryData.ButtonData[i];
                        if (tar.layer == layerListBox.Items[layerindex].ToString()) 
                        {
                            memoryData.ButtonData.Remove(tar);
                            int index = memoryData.iconTemp.IndexOf(tar.name);
                            if (index != -1)
                            {
                                memoryData.iconTemp.RemoveAt(index);
                                memoryData.iconDelTemp.Add(tar.name);
                            }
                        }
                    }

                    for(int i = memoryData.LabelData.Count-1; i>=0;i--)
                    {
                        LabelObjstruct tar = (LabelObjstruct)memoryData.LabelData[i];
                        if (tar.layer == layerListBox.Items[layerindex].ToString())
                        {
                            memoryData.LabelData.Remove(tar);
                            int index = memoryData.iconTemp.IndexOf(tar.name);
                            if (index != -1)
                            {
                                memoryData.iconTemp.RemoveAt(index);
                                memoryData.iconDelTemp.Add(tar.name);
                            }
                        }
                    }

                    for (int i = memoryData.InputData.Count - 1; i >= 0; i--)
                    {
                        InputObjectstruct tar = (InputObjectstruct)memoryData.InputData[i];
                        if (tar.layer == layerListBox.Items[layerindex].ToString())
                        {
                            memoryData.InputData.Remove(tar);
                            int index = memoryData.iconTemp.IndexOf(tar.name);
                            if (index != -1)
                            {
                                memoryData.iconTemp.RemoveAt(index);
                                memoryData.iconDelTemp.Add(tar.name);
                            }
                        }
                    }

                    for (int i = memoryData.OutputButtonData.Count - 1; i >= 0; i--)
                    {
                        OutputButtonObjectstruct tar = (OutputButtonObjectstruct)memoryData.OutputButtonData[i];
                        if (tar.layer == layerListBox.Items[layerindex].ToString())
                        {
                            memoryData.OutputButtonData.Remove(tar);
                            int index = memoryData.iconTemp.IndexOf(tar.name);
                            if (index != -1)
                            {
                                memoryData.iconTemp.RemoveAt(index);
                                memoryData.iconDelTemp.Add(tar.name);
                            }
                        }
                    }

                    for (int i = memoryData.OutputTextData.Count - 1; i >= 0; i--)
                    {
                        OutputTextObjectstruct tar = (OutputTextObjectstruct)memoryData.OutputTextData[i];
                        if (tar.layer == layerListBox.Items[layerindex].ToString())
                        {
                            memoryData.OutputTextData.Remove(tar);
                            int index = memoryData.iconTemp.IndexOf(tar.name);
                            if (index != -1)
                            {
                                memoryData.iconTemp.RemoveAt(index);
                                memoryData.iconDelTemp.Add(tar.name);
                            }
                        }
                    }

                    for (int i = memoryData.OutputPopData.Count - 1; i >= 0; i--)
                    {
                        OutputPopObjectstruct tar = (OutputPopObjectstruct)memoryData.OutputPopData[i];
                        if (tar.layer == layerListBox.Items[layerindex].ToString())
                        {
                            memoryData.OutputPopData.Remove(tar);
                            int index = memoryData.iconTemp.IndexOf(tar.name);
                            if (index != -1)
                            {
                                memoryData.iconTemp.RemoveAt(index);
                                memoryData.iconDelTemp.Add(tar.name);
                            }
                        }
                    }

                    for (int i = memoryData.PictureData.Count - 1; i >= 0; i--)
                    {
                        PictureboxObjectstruct tar = (PictureboxObjectstruct)memoryData.PictureData[i];
                        if (tar.layer == layerListBox.Items[layerindex].ToString())
                        {
                            memoryData.PictureData.Remove(tar);
                            int index = memoryData.iconTemp.IndexOf(tar.name);
                            if (index != -1)
                            {
                                memoryData.iconTemp.RemoveAt(index);
                                memoryData.iconDelTemp.Add(tar.name);
                            }
                        }
                    }

                    for (int i = memoryData.AlarmData.Count - 1; i >= 0; i--)
                    {
                        AlarmObjectstruct tar = (AlarmObjectstruct)memoryData.AlarmData[i];
                        if (tar.layer == layerListBox.Items[layerindex].ToString())
                        {
                            for (int am = 0; am < memoryData.AlarmMonitorValue.Count;am++ )
                            {
                                AlarmMoniTorNV edit = (AlarmMoniTorNV)memoryData.AlarmMonitorValue[am];
                                if(edit.name == tar.name)
                                {
                                    memoryData.AlarmMonitorValue.Remove(edit);
                                    break;
                                }
                            }
                            memoryData.AlarmData.Remove(tar);
                            int index = memoryData.iconTemp.IndexOf(tar.name);
                            if (index != -1)
                            {
                                memoryData.iconTemp.RemoveAt(index);
                                memoryData.iconDelTemp.Add(tar.name);
                            }
                        }
                    }

                }

            }




            for (int i = layerListBox.Items.Count - 1; i > 0; i--)
            {
                layerListBox.Items.RemoveAt(i);
                memoryData.LayerData.RemoveAt(i);
            }
        }

        private void layerIMGChoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog myopen = new OpenFileDialog();
            myopen.Filter = "Image Files (*.jpg, *.bmp, *.gif, *.png)|*.jpg; *.bmp; *.gif; *.png;";
            if (myopen.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = File.OpenRead(myopen.FileName);

                layerBackground.SizeMode = PictureBoxSizeMode.Normal;
                layerBackground.Image  = (Bitmap)Image.FromStream(fs);
                fs.Close();
            }

            for (int i = 0; i < memoryData.LayerData.Count; i++)
            {
                Layerstruct getVal = (Layerstruct)memoryData.LayerData[i];
                if (getVal.name == layerListBox.Text)
                {
                    getVal.backImage = myopen.FileName.ToString();
                    memoryData.LayerData[i] = getVal;
                    break;
                }
            }
        }

        private void layerDisplayFull_Click(object sender, EventArgs e)
        {
            layerBackground.SizeMode = PictureBoxSizeMode.StretchImage;
            for (int i = 0; i < memoryData.LayerData.Count; i++)
            {
                Layerstruct getVal = (Layerstruct)memoryData.LayerData[i];
                if (getVal.name == layerListBox.Text)
                {
                    getVal.sizeMode = layerBackground.SizeMode.ToString();
                    memoryData.LayerData[i] = getVal;
                    break;
                }
            }
        }

        private void layerDisplayColor_Click(object sender, EventArgs e)
        {
            ColorDialog mycolor = new ColorDialog();
            //mycolor.ShowDialog();
            if (mycolor.ShowDialog() == DialogResult.OK)
            {
                layerBackground.Image = null;
                layerBackground.BackColor = mycolor.Color;
                for (int i = 0; i < memoryData.LayerData.Count; i++)
                {
                    Layerstruct getVal = (Layerstruct)memoryData.LayerData[i];
                    if (getVal.name == layerListBox.Text)
                    {
                        getVal.backColor = mycolor.Color.ToArgb();
                        memoryData.LayerData[i] = getVal;
                        break;
                    }
                }
            }
        }

        private void layerDisplayClear_Click(object sender, EventArgs e)
        {
            layerBackground.BackColor = Color.Transparent;
            layerBackground.Image = null;
            for (int i = 0; i < memoryData.LayerData.Count; i++)
            {
                Layerstruct getVal = (Layerstruct)memoryData.LayerData[i];
                if (getVal.name == layerListBox.Text)
                {

                    getVal.backImage = "";
                    getVal.backColor = layerBackground.BackColor.ToArgb();
                    memoryData.LayerData[i] = getVal;
                    break;
                }
            }
        }

        private void Layer_edit_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 lForm1 = (Form1)this.Owner;//把Form2的父窗口指針賦給lForm1  
            lForm1.ReListbox = layerListBox; //使用父窗口指針賦值  
            Close();
        }

        private void Layer_edit_Load(object sender, EventArgs e)
        {
            if (memoryData.LayerData.Count > 0)
            {
                Layerstruct getstr = (Layerstruct)memoryData.LayerData[0];
                if (getstr.backImage != "")
                {
                    if (System.IO.File.Exists(getstr.backImage))
                    {
                        //have file
                        FileStream fs = File.OpenRead(getstr.backImage);
                        layerBackground.Image = (Bitmap)Image.FromStream(fs);
                        //Bitmap bmp1 = (Bitmap)Image.FromStream(fs);
                        fs.Close();
                    }
                    else
                    {
                        //not found
                    }
    
                }
                else
                { layerBackground.Image = null; }

                if (getstr.sizeMode == "Normal")
                { layerBackground.SizeMode = PictureBoxSizeMode.Normal; }
                else if (getstr.sizeMode == "StretchImage")
                { layerBackground.SizeMode = PictureBoxSizeMode.StretchImage; }

                layerBackground.BackColor = Color.FromArgb(getstr.backColor);

                for (int i = 1; i < memoryData.LayerData.Count; i++)
                {
                    Layerstruct getname = (Layerstruct)memoryData.LayerData[i];
                    layerListBox.Items.Add(getname.name);
                }
            }
        }

        private void layerDisplayZoom_Click(object sender, EventArgs e)
        {
            layerBackground.SizeMode = PictureBoxSizeMode.Zoom;
            for (int i = 0; i < memoryData.LayerData.Count; i++)
            {
                Layerstruct getVal = (Layerstruct)memoryData.LayerData[i];
                if (getVal.name == layerListBox.Text)
                {
                    getVal.sizeMode = layerBackground.SizeMode.ToString();
                    memoryData.LayerData[i] = getVal;
                    break;
                }
            }
        }

        private void copyLayer_Click(object sender, EventArgs e)
        {
            
        }

        private string chkAddIconName(string addname)
        {
            Boolean repeat = false;
        retry:

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

    }
}
