using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.Collections;

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
       //edit account
        private void button3_Click(object sender, EventArgs e)
        {
            DataGridViewRow dataGridViewRow = dataGridView1.Rows[selectedRow];


            dataGridViewRow.Cells[2].Value = tbName.Text;
            dataGridViewRow.Cells[1].Value = tbPass.Text;
            dataGridViewRow.Cells[3].Value = tbSDT.Text;
            dataGridViewRow.Cells[4].Value = tbEmail.Text;
            string id = dataGridViewRow.Cells[0].Value.ToString();
            Connection();
            try
            {
                conn.Open();
                String query = "UPDATE `account` SET `password`= " + "'" + tbPass.Text + "'" + "  ,`name`=" + "'" + tbName.Text + "'" + ",`phone`= " + "'" + tbSDT.Text + "'" + ",`email`=" + "'" + tbEmail.Text + "'" + "WHERE idAccount = '" + id + "'";
                MySqlCommand sqlcom = new MySqlCommand(query, conn);
                // cmd.Connection = conn;
                sqlcom.ExecuteNonQuery();
                MessageBox.Show("Thanh Cong");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //xoa account
        private void button2_Click(object sender, EventArgs e)
        {

            DataGridViewRow dataGridViewRow = dataGridView1.Rows[selectedRow];
            string id = dataGridViewRow.Cells[0].Value.ToString();
            selectedRow = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(selectedRow);
            Connection();
            String dele = "DELETE FROM `account` WHERE idAccount = '" + id + "'";

            try
            {
                conn.Open();
                MySqlCommand sqlcom = new MySqlCommand(dele, conn);
                // cmd.Connection = conn;
                sqlcom.ExecuteNonQuery();

                MessageBox.Show("Thanh Cong");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Them account
        private void button1_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            string pas= tbPass.Text;
            string pohne = tbSDT.Text;
            string em = tbEmail.Text;
            Random rd = new Random();
            string id = "5200" + rd.Next(1, 200).ToString();
            Connection();
            try
            {
                conn.Open();
                String query = "INSERT INTO `account`(`idAccount`, `password`, `name`, `phone`, `email`) VALUES('" +id + "'" + ", '" +pas + "', '" +name + "', '" +pohne + "', '" +em + "')";
                MySqlCommand sqlcom = new MySqlCommand(query, conn);
                // cmd.Connection = conn;
                sqlcom.ExecuteNonQuery();
                MessageBox.Show("Thanh Cong");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
