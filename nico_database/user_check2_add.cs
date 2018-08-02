using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nico_database
{
    public partial class user_check2_add : Form
    {
        public user_check2_add()
        {
            InitializeComponent();
        }

        private void apply_Click(object sender, EventArgs e)
        {
            if(user.Text != "" && password.Text != "")
            {
                AccountList addUser = new AccountList();

                string getMD5 = MD5code(password.Text);
                string level="";

                if(account_admin.Checked==true)
                {
                    level = "admin";
                }
                else if (account_designer.Checked == true)
                {
                    level = "design";
                }
                else if (account_viewer.Checked == true)
                {
                    level = "view";
                }

                addUser.name = user.Text;
                addUser.pass = getMD5;
                addUser.level = level;

                option_account lForm1 = (option_account)this.Owner;
                lForm1.getUser = addUser;
                this.Close();
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            AccountList clearUser = new AccountList();

            option_account lForm1 = (option_account)this.Owner;
            lForm1.getUser = clearUser;
            this.Close();
        }

        private String MD5code(String str)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
            Byte[] data = md5Hasher.ComputeHash((new System.Text.ASCIIEncoding()).GetBytes(str));
            System.Text.StringBuilder sBuilder = new System.Text.StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        private void user_check2_add_Load(object sender, EventArgs e)
        {

        }

        private void user_check2_add_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
