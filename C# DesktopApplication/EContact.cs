using C__DesktopApplication.Classes;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C__DesktopApplication
{
    public partial class EContact : Form
    {
        AccountClass c = new AccountClass();

        public EContact()
        {
            InitializeComponent();
            guna2tab.SelectTab("home_page");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c.UserName = UserNameAns.Text;
            c.Password = PasswordAns.Text;
            c.description = Expo_LinkAns.Text;
            c.Owner = OwnerAns.Text;
            if (DemandAns.Text != "")
                c.Demand = int.Parse(DemandAns.Text);
            else
                c.Demand = 0;
            c.Rank = RankAns.Text;
            c.EmaiAccess = Email_AccessAns.Text;
            if (VP_SpentAns.Text != "")
                c.VPSpent = int.Parse(VP_SpentAns.Text);
            else
                c.VPSpent = 0;


            c.Status = StatusAns.Text;


            bool sucess = c.Insert(c);
            if (sucess)
            {
                MessageBox.Show("New Account Inserted SucessFully");
            }
            else
            {
                MessageBox.Show("Error Occured");
            }

            UserNameAns.Text = "";
            PasswordAns.Text = "";
            Expo_LinkAns.Text = "";
            OwnerAns.Text = "";
            DemandAns.Text = "";
            RankAns.Text = "";
            Email_AccessAns.Text = "";
            VP_SpentAns.Text = "";
            StatusAns.Text = "";

            guna2tab.SelectTab("home_page");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            guna2tab.SelectTab("add_account");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            guna2tab.SelectTab("all_accounts");

            DataTable dt = c.Select();
            dataGridView1.DataSource = dt;

            dataGridView1.Columns.Remove("Account_ID");

            dataGridView1.Columns["userName"].HeaderText = "UserName";
            dataGridView1.Columns["Pass"].HeaderText = "Password";
            dataGridView1.Columns["Account_Desc"].HeaderText = "Description";
            dataGridView1.Columns["Account_Owner"].HeaderText = "Owner";
            dataGridView1.Columns["Email_Access"].HeaderText = "Email";
            dataGridView1.Columns["VP_Spent"].HeaderText = "VP";
            dataGridView1.Columns["Account_Rank"].HeaderText = "Rank";
            dataGridView1.Columns["Account_Status"].HeaderText = "Status";

            dataGridView1.Columns["userName"].Width = 130;
            dataGridView1.Columns["Pass"].Width = 70;
            dataGridView1.Columns["Account_Desc"].Width = 213;
            dataGridView1.Columns["Account_Owner"].Width = 60;
            dataGridView1.Columns["Email_Access"].Width = 60;
            dataGridView1.Columns["VP_Spent"].Width = 60;
            dataGridView1.Columns["Demand"].Width = 60;
            dataGridView1.Columns["Account_Rank"].Width = 60;
            dataGridView1.Columns["Account_Status"].Width = 60;
        }

        private void findbtn_Click(object sender, EventArgs e)
        {
            string sql = $"SELECT * FROM accountsdata WHERE {comboBox1.SelectedItem} = '{user_nameFind.Text}'";


            DataTable dt = c.search(sql);
            dataGridView2.DataSource = dt;


            dataGridView2.Columns.Remove("Account_ID");

            dataGridView2.Columns["userName"].HeaderText = "UserName";
            dataGridView2.Columns["Pass"].HeaderText = "Password";
            dataGridView2.Columns["Account_Desc"].HeaderText = "Description";
            dataGridView2.Columns["Account_Owner"].HeaderText = "Owner";
            dataGridView2.Columns["Email_Access"].HeaderText = "Email";
            dataGridView2.Columns["VP_Spent"].HeaderText = "VP";
            dataGridView2.Columns["Account_Rank"].HeaderText = "Rank";
            dataGridView2.Columns["Account_Status"].HeaderText = "Status";

            dataGridView2.Columns["userName"].Width = 130;
            dataGridView2.Columns["Pass"].Width = 70;
            dataGridView2.Columns["Account_Desc"].Width = 213;
            dataGridView2.Columns["Account_Owner"].Width = 60;
            dataGridView2.Columns["Email_Access"].Width = 60;
            dataGridView2.Columns["VP_Spent"].Width = 60;
            dataGridView2.Columns["Demand"].Width = 60;
            dataGridView2.Columns["Account_Rank"].Width = 60;
            dataGridView2.Columns["Account_Status"].Width = 60;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            guna2tab.SelectTab("account_finder");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = $"SELECT * FROM accountsdata WHERE userName = '{textBox1.Text}'";

            DataTable dt = c.search(sql);

            foreach (DataRow row in dt.Rows)
            {
                textBox2.Text = row[2].ToString();
                textBox7.Text = row[3].ToString();
                textBox3.Text = row[4].ToString();
                textBox4.Text = row[5].ToString();
                textBox5.Text = row[6].ToString();
                textBox6.Text = row[7].ToString();
                comboBox2.Text = row[8].ToString();
                comboBox3.Text = row[9].ToString();
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int vpspent = 0;
            int demand = 0;

            if (textBox5.Text != "")
                vpspent = int.Parse(textBox5.Text);
            else
                vpspent = 0;

            if (textBox6.Text != "")
                demand = int.Parse(textBox6.Text);
            else
                demand = 0;



            string sql = "UPDATE accountsdata SET " +
                $"userName = '{textBox1.Text}' , Pass = '{textBox2.Text}' , Account_Desc = '{textBox7.Text}' " +
                $", Account_Owner = '{textBox3.Text}' , Email_Access = '{textBox4.Text}' , Vp_Spent = {vpspent}," +
                $" Demand = {demand} , Account_Rank = '{comboBox2.Text}' ,Account_Status = '{comboBox3.Text}' " +
                $"WHERE UserName = '{textBox1.Text}'";

            bool sucess = c.update(sql);

            if (sucess)
            {
                MessageBox.Show("New Account Inserted SucessFully");
            }
            else
            {
                MessageBox.Show("Error Occured");
            }

            textBox1.Text = "";
            textBox2.Text = "";
            textBox7.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";

            guna2tab.SelectTab("home_page");

        }

        private void guna2TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2tab.SelectedIndex == 2)
            {
                guna2tab.SelectTab("all_accounts");

                DataTable dt = c.Select();
                dataGridView1.DataSource = dt;

                dataGridView1.Columns.Remove("Account_ID");

                dataGridView1.Columns["userName"].HeaderText = "UserName";
                dataGridView1.Columns["Pass"].HeaderText = "Password";
                dataGridView1.Columns["Account_Desc"].HeaderText = "Description";
                dataGridView1.Columns["Account_Owner"].HeaderText = "Owner";
                dataGridView1.Columns["Email_Access"].HeaderText = "Email";
                dataGridView1.Columns["VP_Spent"].HeaderText = "VP";
                dataGridView1.Columns["Account_Rank"].HeaderText = "Rank";
                dataGridView1.Columns["Account_Status"].HeaderText = "Status";

                dataGridView1.Columns["userName"].Width = 130;
                dataGridView1.Columns["Pass"].Width = 70;
                dataGridView1.Columns["Account_Desc"].Width = 213;
                dataGridView1.Columns["Account_Owner"].Width = 60;
                dataGridView1.Columns["Email_Access"].Width = 60;
                dataGridView1.Columns["VP_Spent"].Width = 60;
                dataGridView1.Columns["Demand"].Width = 60;
                dataGridView1.Columns["Account_Rank"].Width = 53;
                dataGridView1.Columns["Account_Status"].Width = 50;
            }
            if (guna2tab.SelectedIndex == 5)
            {
                guna2tab.SelectTab("delete_account");

                DataTable dt = c.Select();
                dataGridView3.DataSource = dt;

                dataGridView3.Columns.Remove("Account_ID");

                dataGridView3.Columns["userName"].HeaderText = "UserName";
                dataGridView3.Columns["Pass"].HeaderText = "Password";
                dataGridView3.Columns["Account_Desc"].HeaderText = "Description";
                dataGridView3.Columns["Account_Owner"].HeaderText = "Owner";
                dataGridView3.Columns["Email_Access"].HeaderText = "Email";
                dataGridView3.Columns["VP_Spent"].HeaderText = "VP";
                dataGridView3.Columns["Account_Rank"].HeaderText = "Rank";
                dataGridView3.Columns["Account_Status"].HeaderText = "Status";

                dataGridView3.Columns["userName"].Width = 130;
                dataGridView3.Columns["Pass"].Width = 70;
                dataGridView3.Columns["Account_Desc"].Width = 213;
                dataGridView3.Columns["Account_Owner"].Width = 60;
                dataGridView3.Columns["Email_Access"].Width = 60;
                dataGridView3.Columns["VP_Spent"].Width = 60;
                dataGridView3.Columns["Demand"].Width = 54;
                dataGridView3.Columns["Account_Rank"].Width = 53;
                dataGridView3.Columns["Account_Status"].Width = 50;
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            guna2tab.SelectTab("account_edit");
        }

        private void Back1_Click(object sender, EventArgs e)
        {
            guna2tab.SelectTab("home_page");
        }

        private void back3_Click(object sender, EventArgs e)
        {
            guna2tab.SelectTab("home_page");
        }

        private void back4_Click(object sender, EventArgs e)
        {
            guna2tab.SelectTab("home_page");
        }

        private void returnhomepage_Click(object sender, EventArgs e)
        {
            guna2tab.SelectTab("home_page");
        }

        private void back5_Click(object sender, EventArgs e)
        {
            guna2tab.SelectTab("home_page");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = $" DELETE FROM accountsdata WHERE userName = '{deleteAns.Text}'";

            bool sucess = c.delete(query);

            DataTable dt = c.Select();
            dataGridView3.DataSource = dt;

            dataGridView3.Columns.Remove("Account_ID");

            dataGridView3.Columns["userName"].HeaderText = "UserName";
            dataGridView3.Columns["Pass"].HeaderText = "Password";
            dataGridView3.Columns["Account_Desc"].HeaderText = "Description";
            dataGridView3.Columns["Account_Owner"].HeaderText = "Owner";
            dataGridView3.Columns["Email_Access"].HeaderText = "Email";
            dataGridView3.Columns["VP_Spent"].HeaderText = "VP";
            dataGridView3.Columns["Account_Rank"].HeaderText = "Rank";
            dataGridView3.Columns["Account_Status"].HeaderText = "Status";

            dataGridView3.Columns["userName"].Width = 130;
            dataGridView3.Columns["Pass"].Width = 70;
            dataGridView3.Columns["Account_Desc"].Width = 213;
            dataGridView3.Columns["Account_Owner"].Width = 60;
            dataGridView3.Columns["Email_Access"].Width = 60;
            dataGridView3.Columns["VP_Spent"].Width = 60;
            dataGridView3.Columns["Demand"].Width = 60;
            dataGridView3.Columns["Account_Rank"].Width = 60;
            dataGridView3.Columns["Account_Status"].Width = 60;
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            guna2tab.SelectTab("delete_account");
        }

        private void account_finder_Click(object sender, EventArgs e)
        {

        }
    }
}
