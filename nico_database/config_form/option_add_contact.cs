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
    public partial class option_add_contact : Form
    {
        public string CMD = "";
        public string contact = "";

        public option_add_contact()
        {
            InitializeComponent();
        }

        private void CMDCancel_Click(object sender, EventArgs e)
        {
            option_contact lForm1 = (option_contact)this.Owner;//把Form2的父窗口指針賦給lForm1  
            lForm1.ReContact = null;
            Close();
        }

        private void CMDApply_Click(object sender, EventArgs e)
        {
            if (contactMail.Text != "" && contactName.Text != "")
            {
                Boolean adname = true;
                for (int i=0;i<memoryData.contact.Count;i++)
                {
                    Contactstruct tar = (Contactstruct)memoryData.contact[i];
                    if (tar.name == contactName.Text)
                    {
                        adname = false;
                        break;
                    }
                }

                option_contact lForm1 = (option_contact)this.Owner;//把Form2的父窗口指針賦給lForm1  
                lForm1.ReContact = contactName.Text;
                if (CMD == "add")
                {
                    if (adname == true)
                    {
                        Contactstruct add = new Contactstruct();
                        add.name = contactName.Text;
                        add.mail = contactMail.Text;
                        add.phone = contactPhone.Text;
                        add.description = contactDescription.Text;
                        memoryData.contact.Add(add);

                        ContactGroup2 tar = (ContactGroup2)memoryData.GroupContact2[0];

                        tar.groupmember.Add(add);

                        memoryData.GroupContact2[0] = tar;

                    }
                    else
                    {
                        lForm1.ReContact = null;
                        adname = true;
                        MessageBox.Show("contact name already in use.");
                    }

                }
                else if (CMD == "edit")
                {
                    for (int i = 0; i < memoryData.contact.Count; i++)
                    {
                        Contactstruct edit = (Contactstruct)memoryData.contact[i];
                        if (edit.name == contact)
                        {
                            string oldname = edit.name;
                            edit.name = contactName.Text;
                            edit.mail = contactMail.Text;
                            edit.phone = contactPhone.Text;
                            edit.description = contactDescription.Text;
                            memoryData.contact[i] = edit;

                            if (memoryData.GroupContact2.Count != 0)
                            {
                                for (int a = 0; a < memoryData.GroupContact2.Count; a++)
                                {
                                    ContactGroup2 editTarget = (ContactGroup2)memoryData.GroupContact2[a];
                                    for (int b = 0; b < editTarget.groupmember.Count; b++)
                                    {
                                        Contactstruct editContact = (Contactstruct)editTarget.groupmember[b];
                                        if (editContact.name == oldname)
                                        {
                                            editContact.name = contactName.Text;
                                            editContact.mail = contactMail.Text;
                                            editContact.phone = contactPhone.Text;
                                            editContact.description = contactDescription.Text;
                                            editTarget.groupmember[b] = editContact;
                                        }
                                    }
                                    memoryData.GroupContact2[a] = editTarget;
                                }
                            }

                        }
                    }
                }

                
                this.Close();
            }
            else
            {
                MessageBox.Show("★ can't empty!");
            }

        }

        private void option_add_contact_Load(object sender, EventArgs e)
        {
            if (CMD == "edit")
            {
                contactName.Enabled = false;
                for (int i = 0; i < memoryData.contact.Count; i++)
                {
                    Contactstruct tar = (Contactstruct)memoryData.contact[i];
                    if (tar.name == contact)
                    {
                        contactName.Text = tar.name;
                        contactMail.Text = tar.mail;
                        contactPhone.Text = tar.phone;
                        contactDescription.Text = tar.description;
                    }
                }
            }
            else if (CMD == "add")
            {
                contactName.Enabled = true;
            }
        }

    }
}
