using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;  //ArrayList use

namespace nico_database
{
    public partial class option_add_group : Form
    {
        public option_add_group()
        {
            InitializeComponent();
        }

        public string CMD = "";
        public string groupName = "";
        public int editIndex;
        ArrayList loadContact = new ArrayList();

        private void option_add_group_Load(object sender, EventArgs e)
        {
            groupTextbox.Text = groupName;
            //load all contact info
            ContactGroup2 gtar = (ContactGroup2)memoryData.GroupContact2[0];
            if (gtar.groupmember != null)
            {
                for (int i = 0; i < gtar.groupmember.Count; i++)
                {
                    Contactstruct tar = (Contactstruct)gtar.groupmember[i];
                    loadContact.Add(tar);
                    listBox1.Items.Add(tar.name);
                }
            }

            if(listBox1.Items.Count !=0)
            {
                if (CMD == "add")
                {
                    groupTextbox.ReadOnly = false;
                }
                else if (CMD == "edit")
                {
                    //groupTextbox.ReadOnly = true;

                    for (int i = 0; i < memoryData.GroupContact2.Count; i++)
                    {
                        ContactGroup2 tar = (ContactGroup2)memoryData.GroupContact2[i];
                        if (tar.groupname == groupName)
                        {
                            for (int cc = 0; cc < tar.groupmember.Count; cc++)
                            {
                                Contactstruct add = (Contactstruct)tar.groupmember[cc];
                                int index = listBox1.FindString(add.name);
                                if (index != -1)
                                {
                                    listBox1.SetSelected(index, true);
                                }

                            }

                            break;
                        }
                    }



                }
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string showname = "";
            memoryData.contact.Clear();

            if (listBox1.SelectedItem != null)
            {
                contactList.Text = "";
                ContactGroup2 tar = (ContactGroup2)memoryData.GroupContact2[0];
                //Contactstruct

                for (int i = 0; i < listBox1.SelectedItems .Count; i++)
                {
                    for (int j = 0; j < tar.groupmember.Count;j++ )
                    {
                        Contactstruct add = (Contactstruct)tar.groupmember[j];
                        if (listBox1.SelectedItems[i].ToString() == add.name)
                        {
                            showname = showname + listBox1.SelectedItems[i].ToString() + ";";
                            memoryData.contact.Add(add);
                        }
                    }
                }
            }

            contactList.Text = showname;

        }

        private void CMDApply_Click(object sender, EventArgs e)
        {
            option_contact lForm1 = (option_contact)this.Owner;//把Form2的父窗口指針賦給lForm1  
            lForm1.ReGroup = groupTextbox.Text;

            if (CMD == "edit")
            {
                for(int i=0;i<memoryData.GroupContact2.Count;i++)
                {
                    ContactGroup2 edit = (ContactGroup2)memoryData.GroupContact2[i];
                    if (edit.groupname == groupName)
                    {
                        edit.groupname = groupTextbox.Text;
                        edit.groupmember.Clear();
                        
                        for (int cc = 0; cc < memoryData.contact.Count; cc++)
                        {
                            Contactstruct add = (Contactstruct)memoryData.contact[cc];
                            edit.groupmember.Add(add);
                        }

                        memoryData.GroupContact2[i] = edit;

                        break;
                    }

                }

            }
            else if (CMD == "add")
            {
                ContactGroup2 addGroup = new ContactGroup2();
                addGroup.groupname = groupTextbox.Text;
                addGroup.groupmember = new ArrayList();

                for(int cc=0;cc< memoryData.contact.Count;cc++)
                {
                    Contactstruct add = (Contactstruct)memoryData.contact[cc];
                    addGroup.groupmember.Add(add);
                }

                memoryData.GroupContact2.Add(addGroup);

            }

            
            lForm1.ReGroup = groupTextbox.Text;

            this.Close();
        }

        private void option_add_group_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void option_add_group_FormClosed(object sender, FormClosedEventArgs e)
        {
            //option_contact lForm1 = (option_contact)this.Owner;//把Form2的父窗口指針賦給lForm1  
            //lForm1.ReGroup = groupTextbox.Text;
            //this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            option_contact lForm1 = (option_contact)this.Owner;//把Form2的父窗口指針賦給lForm1  
            lForm1.ReGroup = null;

            this.Close();
        }

        
    }
}
