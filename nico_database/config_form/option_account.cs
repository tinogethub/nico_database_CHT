using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;  //ArrayList use
using System.IO;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace nico_database
{
    public partial class option_account : Form
    {
        public Boolean addName = false;
        public string MYSQL_str = "";
        public AccountList getUser = new AccountList();
        string selectName = "";

        public option_account()
        {
            InitializeComponent();
        }

        private void option_account_Load(object sender, EventArgs e)
        {
            database SQLstr = (database)memoryData.database[0];
            MySqlConnection conn = new MySqlConnection(MYSQL_str);
            MySqlCommand command = conn.CreateCommand();

            int number = 0;
            string name = "";
            string password = "";
            string level = "";

            try
            {
                conn.Open();
                command.CommandText = "SELECT * FROM nico_db.user_data";
                MySqlDataReader reader;
                reader = command.ExecuteReader();
                memoryData.accountListTemp.Clear();
                while (reader.Read())
                 {
                    number = (int)reader["no"];
                    name = (String)reader["name"];
                    password = (String)reader["pass"];
                    level = (String)reader["level"];
                    AccountList add = new AccountList();
                    add.no = number;
                    add.name = name;
                    add.pass = password;
                    add.level = level;
                    memoryData.accountListTemp.Add(add);
                    listBox1.Items.Add(name);
                }

                conn.Close();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1 .SelectedIndex != -1)
            {
                selectName = listBox1.SelectedItem.ToString();
                int selectItem = listBox1.SelectedIndex;
                AccountList tar = (AccountList)memoryData.accountListTemp[selectItem];
                user.Text = tar.name;
                if (tar.level == "admin")
                {
                    account_admin.Checked = true;
                }
                else if (tar.level == "design")
                {
                    account_designer.Checked = true;
                }
                else if (tar.level == "view")
                {
                    account_viewer.Checked = true;
                }
            }
            

        }

        private void CMD_add_Click(object sender, EventArgs e)
        {
            getUser.name = null;
            user_check2_add le = new user_check2_add();
            le.Owner = this;
            le.ShowDialog();
            
            if(getUser.name != null)
            {
                int findtar = listBox1.FindString(getUser.name);
                if(findtar != -1)
                {
                    MessageBox.Show("This name already in use!");
                }
                else
                {
                    database SQLstr = (database)memoryData.database[0];
                    MySqlConnection conn = new MySqlConnection(MYSQL_str);
                    MySqlCommand command = conn.CreateCommand();
                    conn.Open();
                    command.CommandText = @"Insert into user_data(name,pass,level) values('"
                                         + getUser.name + "','" + getUser.pass + "','" + getUser.level + "')";

                    command.ExecuteNonQuery();

                    conn.Close();

                    int chkno = 0;
                    string chkname = "";
                    string chkpass = "";
                    string chklevel = "";

                    conn.Open();
                    command.CommandText = "SELECT * FROM nico_db.user_data where name = '" + getUser.name + "'";
                    MySqlDataReader reader;
                    reader = command.ExecuteReader();
                    reader.Read();
                    chkno = (int)reader["no"];
                    chkname = (String)reader["name"];
                    chkpass = (String)reader["pass"];
                    chklevel = (String)reader["level"];
                    conn.Close();

                    AccountList add = new AccountList();
                    add.no = chkno;
                    add.name = chkname;
                    add.pass = chkpass;
                    add.level = chklevel;
                    memoryData.accountListTemp.Add(add);
                    listBox1.Items.Add(chkname);
                }

                
            }

        }

        private void CMD_edit_Click(object sender, EventArgs e)
        {
            int selectItem = listBox1.SelectedIndex;
            AccountList tar = (AccountList)memoryData.accountListTemp[selectItem];

            string editName = user.Text ;
            string editPass = MD5code(password.Text );
            string editLevel = "";
            if (account_admin.Checked == true)
            {
                editLevel = "admin";
            }
            else if (account_designer.Checked == true)
            {
                editLevel = "design";
            }
            else if (account_viewer.Checked == true)
            {
                editLevel = "view";
            }
            try
            {
                database SQLstr = (database)memoryData.database[0];
                MySqlConnection conn = new MySqlConnection(MYSQL_str);
                MySqlCommand command = conn.CreateCommand();
                conn.Open();
                command.CommandText = @"update nico_db.user_data set name ='" + editName + "',pass = '" + editPass + "',level = '" + editLevel + "' where no = '" + tar.no + "'";
                command.ExecuteNonQuery();
                conn.Close();

                tar.name = editName;
                tar.pass = editPass;
                tar.level = editLevel;
                memoryData.accountListTemp[selectItem] = tar;
                listBox1.SelectedIndex = -1;
                listBox1.Items[selectItem] = editName;
                listBox1.SelectedIndex = selectItem;
            }
            catch( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void CMD_del_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count >1)
            {
                int selectItem = listBox1.SelectedIndex;
                AccountList tar = (AccountList)memoryData.accountListTemp[selectItem];

                try
                {
                    database SQLstr = (database)memoryData.database[0];
                    MySqlConnection conn = new MySqlConnection(MYSQL_str);
                    MySqlCommand command = conn.CreateCommand();
                    conn.Open();
                    command.CommandText = @"delete FROM nico_db.user_data where no='" + tar.no + "'";
                    command.ExecuteNonQuery();
                    conn.Close();

                    listBox1.SelectedIndex = -1;
                    listBox1.Items.RemoveAt(selectItem);
                    memoryData.accountListTemp.RemoveAt(selectItem);
                    listBox1.SelectedIndex = 0;
                }
                catch
                {

                }
            }
            else
            {
                //MessageBox.Show("");
            }

            
        }

        private void CMD_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
