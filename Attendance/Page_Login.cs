using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Attendance
{
    public partial class Page_Login : Form
    {
        static MySqlConnection conn = null;
        public Page_Login()
        {
            InitializeComponent();
        }

       
      
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        static void Connection()
        {
            String connStr = "server=" + Program.sever.ToString() + ";" + "user=" + Program.username.ToString() + ";" + "database=" + Program.database.ToString()+ ";" + "password=" + Program.password.ToString() + ";";
            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();
              //  MessageBox.Show("Connection Open");
            }
            catch(Exception ex)
            {
              //   MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void btnlogin_Click(object sender, EventArgs e)
        {
            Connection();
            string id = tbID.Text;
            string pwd = tbPwd.Text;
            try
            {
                conn.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("select *from account", conn);
                MySqlDataReader Reader = mySqlCommand.ExecuteReader();

                while (Reader.Read())
                {
                    if (id.Equals(Reader.GetString("idAccount")) && pwd.Equals(Reader.GetString("password")))
                    {
                        Program.id=id;
                        if ("admin".Equals(Reader.GetString("idAccount")))
                        {
                            Page_Admin pageAdmin = new Page_Admin();
                            pageAdmin.Show();
                            this.Hide();
                           
                        }
                        else
                        {
                            Page_Main pageMain = new Page_Main();
                            pageMain.Show();
                            this.Hide();
                            

                        }
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
  
    }
}