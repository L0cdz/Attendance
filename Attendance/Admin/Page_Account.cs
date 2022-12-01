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
    public partial class Page_Account : Form
    {
        static MySqlConnection conn = null;
        static int selectedRow;
        public Page_Account()
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectedRow];
            tbName.Text = row.Cells[2].Value.ToString();
            tbPass.Text = row.Cells[1].Value.ToString();
            tbSDT.Text = row.Cells[3].Value.ToString();
            tbEmail.Text = row.Cells[4].Value.ToString();
        }

        private void Page_Account_Load(object sender, EventArgs e)
        {
            Connection();
            conn.Open();
            string query = "Select *from account";
            MySqlCommand cmn = new MySqlCommand(query, conn);
            MySqlDataReader mySqlDataReader = cmn.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(mySqlDataReader);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        DataTable dt = new DataTable("account");
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Connection();
            conn.Open();
            string query = "Select *from account where idAccount like'%"+tbSearch.Text+"'";
            MySqlCommand cmn = new MySqlCommand(query, conn);
            MySqlDataAdapter ad = new MySqlDataAdapter(cmn);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Clone();
            
        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            DataGridViewRow dataGridViewRow = dataGridView1.Rows[selectedRow];

            dataGridViewRow.Cells[2].Value = tbName.Text;
            dataGridViewRow.Cells[1].Value = tbPass.Text;
            dataGridViewRow.Cells[3].Value = tbSDT.Text;
            dataGridViewRow.Cells[4].Value = tbEmail.Text;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectedRow = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(selectedRow);
        }
    }
}
