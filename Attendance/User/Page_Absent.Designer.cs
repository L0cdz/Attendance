namespace Attendance
{
    partial class Page_Absent
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
            this.cbb_Absent = new System.Windows.Forms.ComboBox();
            this.btn_Absent = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbb_Absent
            // 
            this.cbb_Absent.FormattingEnabled = true;
            this.cbb_Absent.Location = new System.Drawing.Point(85, 52);
            this.cbb_Absent.Name = "cbb_Absent";
            this.cbb_Absent.Size = new System.Drawing.Size(297, 28);
            this.cbb_Absent.TabIndex = 0;
            this.cbb_Absent.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btn_Absent
            // 
            this.btn_Absent.Location = new System.Drawing.Point(195, 103);
            this.btn_Absent.Name = "btn_Absent";
            this.btn_Absent.Size = new System.Drawing.Size(94, 29);
            this.btn_Absent.TabIndex = 1;
            this.btn_Absent.Text = "Báo Vắng";
            this.btn_Absent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Absent.UseVisualStyleBackColor = true;
            this.btn_Absent.Click += new System.EventHandler(this.btn_Absent_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(195, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chọn Ca Vắng";
            // 
            // Page_Absent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 241);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Absent);
            this.Controls.Add(this.cbb_Absent);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(505, 505);
            this.Name = "Page_Absent";
            this.Text = "Page_Absent";
            this.Load += new System.EventHandler(this.Page_Absent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cbb_Absent;
        private Button btn_Absent;
        private Label label1;
    }
}