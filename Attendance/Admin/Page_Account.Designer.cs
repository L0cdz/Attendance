namespace Attendance
{
    partial class Page_Account
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.tbSDT = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "ID:";
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(56, 26);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(417, 27);
            this.tbSearch.TabIndex = 7;
            this.tbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(23, 75);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(558, 407);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(672, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 28);
            this.label1.TabIndex = 5;
            this.label1.Text = "Quản Lý Tài Khoản";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(587, 310);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 9;
            this.button1.Text = "Thêm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(687, 310);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 29);
            this.button2.TabIndex = 10;
            this.button2.Text = "Xóa";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(787, 310);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 29);
            this.button3.TabIndex = 11;
            this.button3.Text = "Sửa";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(599, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Tên:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(599, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Mật Khẩu:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(599, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "SDT:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(599, 242);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Email:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(672, 72);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(209, 27);
            this.tbName.TabIndex = 16;
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(672, 135);
            this.tbPass.Name = "tbPass";
            this.tbPass.Size = new System.Drawing.Size(209, 27);
            this.tbPass.TabIndex = 17;
            // 
            // tbSDT
            // 
            this.tbSDT.Location = new System.Drawing.Point(672, 187);
            this.tbSDT.Name = "tbSDT";
            this.tbSDT.Size = new System.Drawing.Size(209, 27);
            this.tbSDT.TabIndex = 18;
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(672, 239);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(209, 27);
            this.tbEmail.TabIndex = 19;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(487, 24);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 29);
            this.btnSearch.TabIndex = 20;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // Page_Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 494);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.tbSDT);
            this.Controls.Add(this.tbPass);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "Page_Account";
            this.Text = "Page_Account";
            this.Load += new System.EventHandler(this.Page_Account_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label2;
        private TextBox tbSearch;
        private DataGridView dataGridView1;
        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox tbName;
        private TextBox tbPass;
        private TextBox tbSDT;
        private TextBox tbEmail;
        private Button btnSearch;
    }
}