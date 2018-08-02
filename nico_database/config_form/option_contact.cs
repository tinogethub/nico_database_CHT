using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;        //mail using
using System.Web;       //mail using
using System.Net.Mail;  //mail using
using System.Collections;  //ArrayList use

namespace nico_database
{
    public partial class option_contact : Form
    {
        public option_contact()
        {
            InitializeComponent();
        }

        private void option_contact_Load(object sender, EventArgs e)
        {
            memoryData.contact.Clear();
            memoryData.GroupContact2.Clear();

            Loadgroup();


            grouplist.SelectedIndex = 0;

            //contactlist.Items.Clear();
            //grouplist.Items.Clear();
            //grouplist.Items.Add("all contact");
            

            //if (memoryData.contact.Count > 0)
            //{
            //    for (int i = 0; i < memoryData.contact.Count; i++)
            //    {
            //        Contactstruct tar = (Contactstruct)memoryData.contact[i];
            //        contactlist.Items.Add(tar.name);
            //    }
            //}
        }



        //↓↓↓↓↓↓↓↓↓↓  group list right menu  ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
        private void addGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grouplist.Items.Add("new group");
            grouplist.SelectedItem = "new group";
            int ind = grouplist.SelectedIndex;

            option_add_group lForm = new option_add_group();
            lForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
            lForm.CMD = "add";
            lForm.groupName = "new group";
            lForm.ShowDialog();

            if (reGroup != null)
            {
                grouplist.Items[ind] = reGroup;
                reGroup = null;
            }
        }

        private void delGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grouplist.SelectedItem.ToString() != "all contact")  // "all contact" is default item
            {
                for (int i = 1; i < memoryData.GroupContact2.Count; i++)
                {
                    ContactGroup2 deltar = (ContactGroup2)memoryData.GroupContact2[i];
                    if (deltar.groupname == grouplist.SelectedItem.ToString()) 
                    {
                        memoryData.GroupContact2.Remove(deltar);
                        grouplist.Items.RemoveAt(grouplist.SelectedIndex);
                        break;
                    }
                }
            }
        }


        private void editGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grouplist.SelectedItem != null)
            {
                //string oldname = grouplist.SelectedItem.ToString ();
                //grouplist.SelectedItem = oldname;
                int ind = grouplist.SelectedIndex;
                option_add_group lForm = new option_add_group();
                lForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
                lForm.CMD = "edit";
                lForm.groupName = grouplist.SelectedItem.ToString();
                lForm.ShowDialog();
                if (reGroup != null)
                {
                    grouplist.Items[ind] = reGroup;
                    reContact = null;
                }
            }
        }
        //↑↑↑↑↑↑↑↑↑↑   group list right menu   ↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

        //↓↓↓↓↓↓↓↓↓↓   contact list right menu  ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
        private void addContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            option_add_contact lForm = new option_add_contact();
            lForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
            lForm.CMD = "add";
            lForm.ShowDialog();

            if (reContact != null)
            {
                contactlist.Items.Add(reContact);
                contactlist.SelectedItem = reContact;

                reContact = null;
            }
        }

        private void editContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (contactlist.SelectedItem != null)
            {
                option_add_contact lForm = new option_add_contact();
                lForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
                lForm.CMD = "edit";
                lForm.contact = contactlist.SelectedItem.ToString();
                lForm.ShowDialog();

                if (reContact != null)
                {
                    for (int i = 0; i < memoryData.contact.Count; i++)
                    {
                        Contactstruct tar = (Contactstruct)memoryData.contact[i];
                        if (tar.name == reContact)
                        {
                            contactName.Text = tar.name;
                            contactMail.Text = tar.mail;
                            contactPhone.Text = tar.phone;
                            contactDescription.Text = tar.description;
                            contactlist.SelectedItem = reContact;
                        }
                    }

                    reContact = null;
                }
            }
        }

        private void delContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (contactlist.SelectedItem != null)
            {
                if (grouplist.SelectedItem.ToString() == "all contact")
                {
                    //remove from group
                    for (int i = 0; i < memoryData.GroupContact2.Count; i++)
                    {
                        ContactGroup2 tar = (ContactGroup2)memoryData.GroupContact2[i];
                        
                        for (int a = 0; a < tar.groupmember.Count; a++)
                        {
                            Contactstruct edit = (Contactstruct)tar.groupmember[a];
                            if (edit.name != contactlist.SelectedItem.ToString())
                            {
                                tar.groupmember.Remove(edit);
                                memoryData.GroupContact2[i] = tar;
                            }
                        }

                    }

                    //remove from contact data
                    for (int i = 0; i < memoryData.contact.Count; i++)
                    {
                        Contactstruct tar = (Contactstruct)memoryData.contact[i];
                        if (tar.name == contactlist.SelectedItem.ToString())
                        {
                            memoryData.contact.Remove(tar);
                        }
                    }

                    contactlist.Items.RemoveAt(contactlist.SelectedIndex);
                }
                else
                {
                    for (int i = 1; i < memoryData.GroupContact2.Count; i++)
                    {
                        ContactGroup2 tarGroup = (ContactGroup2)memoryData.GroupContact2[i];
                        if(tarGroup.groupname == grouplist.SelectedItem.ToString())
                        {
                            if (tarGroup.groupmember != null)
                            {
                                for (int a = 0; a < tarGroup.groupmember.Count; a++)
                                {
                                    Contactstruct deltar = (Contactstruct)tarGroup.groupmember[a];
                                    if(deltar.name == contactlist.SelectedItem.ToString())
                                    {
                                        tarGroup.groupmember.Remove(deltar);
                                        memoryData.GroupContact2[i] = tarGroup;
                                        break;
                                    }
                                }
                            }

                        }
                    }
                }
            }
        }


        //↑↑↑↑↑↑↑↑↑↑   contact list right menu  ↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

        private string reContact; //接收contact 的值
        public string ReContact
        {
            set
            {
                reContact = value;
            }
        }
        private string reGroup; //接收group 的值
        public string ReGroup
        {
            set
            {
                reGroup = value;
            }
        }

        private void contactlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (contactlist.SelectedItem != null)
            {
                for (int i = 0; i < memoryData.contact.Count; i++)
                {
                    Contactstruct tar = (Contactstruct)memoryData.contact[i];
                    if (tar.name == contactlist.SelectedItem.ToString())
                    {
                        contactName.Text = tar.name;
                        contactMail.Text = tar.mail;
                        contactPhone.Text = tar.phone;
                        contactDescription.Text = tar.description;

                    }
                }
            }
        }

        private void addContact_Click(object sender, EventArgs e)
        {
            option_add_contact lForm = new option_add_contact();
            lForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
            lForm.CMD = "add";
            lForm.ShowDialog();

            if (reContact != null)
            {
                contactlist.Items.Add(reContact);
                contactlist.SelectedItem = reContact;



                reContact = null;
            }

        }

        private void addGroup_Click(object sender, EventArgs e)
        {
            grouplist.Items.Add("new group");
            grouplist.SelectedItem = "new group";
            int ind = grouplist.SelectedIndex;

            option_add_group lForm = new option_add_group();
            lForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
            lForm.CMD = "add";
            lForm.groupName = "new group";
            lForm.ShowDialog();

            if (reGroup != null)
            {
                grouplist.Items[ind] = reGroup;
                reGroup = null;
            }
            else
            {
                grouplist.Items.RemoveAt(ind);
            }

        }

        private void editContact_Click(object sender, EventArgs e)
        {
            if (contactlist.SelectedItem != null)
            {
                option_add_contact lForm = new option_add_contact();
                lForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
                lForm.CMD = "edit";
                lForm.contact = contactlist.SelectedItem.ToString();
                lForm.ShowDialog();

                if (reContact != null)
                {
                    for (int i = 0; i < memoryData.contact.Count; i++)
                    {
                        Contactstruct tar = (Contactstruct)memoryData.contact[i];
                        if (tar.name == reContact)
                        {
                            contactName.Text = tar.name;
                            contactMail.Text = tar.mail;
                            contactPhone.Text = tar.phone;
                            contactDescription.Text = tar.description;
                            contactlist.SelectedItem = reContact;
                        }
                    }


                    ContactGroup2 gptar = (ContactGroup2)memoryData.GroupContact2[0];
                    for (int cc = 0; cc < gptar.groupmember.Count; cc++)
                    {
                        Contactstruct edit = (Contactstruct)gptar.groupmember[cc];
                        if (edit.name == reContact)
                        {
                            edit.name = contactName.Text;
                            edit.mail = contactMail.Text;
                            edit.phone = contactPhone.Text;
                            edit.description = contactDescription.Text;
                            gptar.groupmember[cc] = edit;
                            break;
                        }
                    }

                    reContact = null;
                }
            }

        }

        private void CMDApply_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void editGroup_Click(object sender, EventArgs e)
        {
            if (grouplist.SelectedItem != null && grouplist.SelectedItem.ToString() != "all contact")
            {
                //string oldname = grouplist.SelectedItem.ToString ();
                //grouplist.SelectedItem = oldname;
                int ind = grouplist.SelectedIndex;
                option_add_group lForm = new option_add_group();
                lForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
                lForm.CMD = "edit";
                lForm.groupName = grouplist.SelectedItem.ToString();
                lForm.ShowDialog();
                if (reGroup != null)
                {
                    grouplist.Items[ind] = reGroup;
                    reContact = null;
                }
            }
        }

        private void grouplist_SelectedIndexChanged(object sender, EventArgs e)
        {
            contactName.Text = "";
            contactMail.Text = "";
            contactPhone.Text = "";
            contactDescription.Text = "";

            if (grouplist.SelectedItem != null)
            {
                for (int i = 0; i < memoryData.GroupContact2.Count; i++)
                {
                    ContactGroup2 tar = (ContactGroup2)memoryData.GroupContact2[i];
                    if (tar.groupname == grouplist.SelectedItem.ToString())
                    {
                        contactlist.Items.Clear();
                        if (tar.groupmember !=null)
                        {
                            for (int a = 0; a < tar.groupmember.Count; a++)
                            {
                                Contactstruct edit = (Contactstruct)tar.groupmember[a];
                                if (edit.name != null)
                                {
                                    contactlist.Items.Add(edit.name);
                                }
                            }
                        }
                    }
                }
            }

            if (grouplist.SelectedItem != null)
            {
                if (grouplist.SelectedItem.ToString() == "all contact")
                {
                    addContact.Enabled = true;
                    editContact.Enabled = true;
                }
                else
                {
                    addContact.Enabled = false;
                    editContact.Enabled = false;
                }
            }

        }

        private void contactlist_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void contactlist_MouseDown(object sender, MouseEventArgs e)
        {
            if (grouplist.SelectedItem != null)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    if (grouplist.SelectedItem.ToString() == "all contact")
                    {
                        contactRightMenu.Items[0].Enabled = true;
                        contactRightMenu.Items[1].Enabled = true;
                        //contactRightMenu.Items[2] = "————";
                        //contactRightMenu.Items[3].Enabled = true;
                    }
                    else
                    {
                        contactRightMenu.Items[0].Enabled = false;
                        contactRightMenu.Items[1].Enabled = false;
                        //contactRightMenu.Items[2] = "————";
                        //contactRightMenu.Items[3].Enabled = true;
                    }
                }
            }
        }

        private void Savegroup()
        {
            string curFile = Application.StartupPath + @"\Resources\mailGroup.txt";
            Boolean findfile = File.Exists(curFile);
            
            if (findfile == true)
            {
                System.IO.File.Delete(Application.StartupPath + @"\Resources\mailGroup.txt");
            }
            

            StringBuilder buffer = new StringBuilder();
            string mem = "";
            if (memoryData.GroupContact2.Count > 0)
            {
                for (int i = 0; i < memoryData.GroupContact2.Count; i++)
                {
                    ContactGroup2 tar = (ContactGroup2)memoryData.GroupContact2[i];
                    buffer.Append("#" + tar.groupname);

                    if (tar.groupmember != null)
                    {
                        for (int a = 0; a < tar.groupmember.Count; a++)
                        {
                            Contactstruct member = (Contactstruct)tar.groupmember[a];

                            if (member.name != null && member.name != "" && member.mail != null && member.mail != "")
                            {
                                mem = member.name + "$" + member.mail + "$" + member.phone + "$" + member.description;
                                buffer.Append("#" + mem);
                            }
                        }
                    }


                    buffer.Append(Environment.NewLine);
                }
            }
            File.WriteAllText(Application.StartupPath + @"\Resources\mailGroup.txt", buffer.ToString());
            
        }

        private void Loadgroup()
        {
            try
            {
                //load sample

                string curFile = Application.StartupPath + @"\Resources\mailGroup.txt";
                Boolean findfile = File.Exists(curFile);

                if (findfile == true)
                {
                    StreamReader rd = new StreamReader(Application.StartupPath + @"\Resources\mailGroup.txt");
                    while (rd.EndOfStream == false)
                    {
                        string[] getConfig = rd.ReadLine().Split('#');
                        if (getConfig[1] != "")
                        {
                            ContactGroup2 groupLoad = new ContactGroup2();
                            groupLoad.groupname = getConfig[1];
                            groupLoad.groupmember = new System.Collections.ArrayList();

                            Contactstruct addmember = new Contactstruct();
                            for (int i = 2; i < getConfig.Length; i++)
                            {
                                string[] member = getConfig[i].Split('$');
                                //Contactstruct addmember = new Contactstruct();
                                addmember.name = member[0];
                                addmember.mail = member[1];
                                addmember.phone = member[2];
                                addmember.description = member[3];

                                groupLoad.groupmember.Add(addmember);
                            }

                            memoryData.GroupContact2.Add(groupLoad);


                            if (getConfig[1] == "all contact")
                            {
                                ContactGroup2 tarGroup = (ContactGroup2)memoryData.GroupContact2[0];
                                if (tarGroup.groupmember != null)
                                {
                                    for (int a = 0; a < tarGroup.groupmember.Count; a++)
                                    {
                                        Contactstruct addMember = (Contactstruct)tarGroup.groupmember[a];
                                        memoryData.contact.Add(addMember);
                                        contactlist.Items.Add(addMember.name);
                                    }
                                }
                            }
                            else
                            {
                                grouplist.Items.Add(groupLoad.groupname);
                            }
                            
                        }

                    }
                    rd.Dispose();
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

        private void option_contact_FormClosing(object sender, FormClosingEventArgs e)
        {
            Savegroup();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}