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
    public partial class Page_Absent : Form
    {
        public Page_Absent()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ;
        }

        private void Page_Absent_Load(object sender, EventArgs e)
        {
            for(int i = 0; i<Program.listAbsent.Count; i++)
            {
                cbb_Absent.Items.Add(Program.listAbsent[i]);
            }
        }

        private void btn_Absent_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
