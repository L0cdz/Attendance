using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Attendance
{
    public partial class Page_Information : Form
    {
        static MySqlConnection conn = null;
        public Page_Information()
        {
            InitializeComponent();
        }
        
        

       
        static void Connection()
        {
            String connStr = "server=" + Program.sever.ToString() + ";" + "user=" + Program.username.ToString() + ";" + "database=" + Program.database.ToString() + ";" + "password=" + Program.password.ToString() + ";";
            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();
                // MessageBox.Show("Connection Open");
            }
            catch (Exception ex)
            {
                //   MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Connection();

          
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE account SET password = " + tbPass.Text + ", name = " + tbName.Text + ", phone = " + tbSDT.Text
         + ", email = " + tbEmail.Text + "WHERE idAccount = " + Program.id);
               // cmd.Connection = conn;
                cmd.ExecuteNonQuery();

                MessageBox.Show("Thanh Cong");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
   
     
        private void Page_Information_Load(object sender, EventArgs e)
        {
            Connection();
            try
            {
                conn.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("select *from account", conn);
                MySqlDataReader Reader = mySqlCommand.ExecuteReader();

                while (Reader.Read())
                {
                    if (Program.id.Equals(Reader.GetString("idAccount")))
                    {
                        tbName.Text = Reader.GetString("name");
                        tbEmail.Text = Reader.GetString("email");
                        tbSDT.Text = Reader.GetString("phone");
                        tbPass.Text = Reader.GetString("password");
                        conn.Clone();
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();
            }
            MessageBox.Show("Invalid");
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled = true;
        }
    }
}
