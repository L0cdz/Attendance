using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Attendance
{
    public partial class Config : Form
    {
        public Config()
        {
            InitializeComponent();
        }
        static MySqlConnection conn = null;

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Program.sever = tbServer.Text;
            Program.username = tbUser.Text;
            Program.database = tbData.Text;
            Program.password = tbPassword.Text;
            String connStr = "server=" + tbServer.Text + ";" + "user=" + tbUser.Text + ";" + "database=" + tbData.Text + ";" + "password=" + tbPassword.Text + ";";

           
            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();
                MessageBox.Show("Connection Successfull");
                Page_Login page_Login = new Page_Login();
                page_Login.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }


        }
    }
}
