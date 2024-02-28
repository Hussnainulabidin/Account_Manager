using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace C__DesktopApplication.Classes
{
    internal class AccountClass
    {
        string connstring = "server=localhost;uid=root;pwd=bozo_70712server;database=accounts";

        public int AccountID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string description { get; set; }

        public string Owner { get; set; }

        public string EmaiAccess { get; set; }

        public int Demand { get; set; }

        public int VPSpent { get; set; }

        public string Rank { get; set; }

        public string Status { get; set; }


        public DataTable Select()
        {
            MySqlConnection con = new MySqlConnection(connstring);

            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT * FROM accountsdata";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                con.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return dt;
        }

        public bool Insert(AccountClass c)
        {
            bool isSucess = false;

            MySqlConnection con = new MySqlConnection(connstring);

            try
            {
                string sql = "INSERT INTO accountsdata " +
                "(userName , Pass , Account_Desc , Account_Owner , Email_Access , VP_Spent , Demand , Account_Rank , Account_Status )" +
                "VALUES (@username , @password , @expolink ,@owner , @emailaccess , @vpspent , @demand , @accountrank , @accountstatus)";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@username", c.UserName);
                cmd.Parameters.AddWithValue("@password", c.Password);
                cmd.Parameters.AddWithValue("@expolink", c.description);
                cmd.Parameters.AddWithValue("@owner", c.Owner);
                cmd.Parameters.AddWithValue("@emailaccess", c.EmaiAccess);
                cmd.Parameters.AddWithValue("@vpspent", c.VPSpent);
                cmd.Parameters.AddWithValue("@demand", c.Demand);
                cmd.Parameters.AddWithValue("@accountrank", c.Rank);
                cmd.Parameters.AddWithValue("@accountstatus", c.Status);

                con.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSucess = true;
                }
                else
                {
                    isSucess = false;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return isSucess;
        }

        public DataTable search(string query)
        {
            MySqlConnection con = new MySqlConnection(connstring);

            DataTable dt = new DataTable();

            try
            {

                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                con.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return dt;
        }

        public bool update(string query)
        {
            bool isSucess = false;

            MySqlConnection con = new MySqlConnection(connstring);

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, con);

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSucess = true;
                }
                else
                {
                    isSucess = false;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return isSucess;
        }

        public bool delete(string query)
        {
            bool isSucess = false;

            MySqlConnection con = new MySqlConnection(connstring);

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, con);

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSucess = true;
                }
                else
                {
                    isSucess = false;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return isSucess;

        }
    }
}
