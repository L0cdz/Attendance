namespace Attendance.User
{
    partial class Page_Compensate
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
            this.cbbCompensate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCompensate = new System.Windows.Forms.Button();
            this.cbbShift = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbbCompensate
            // 
            this.cbbCompensate.FormattingEnabled = true;
            this.cbbCompensate.Location = new System.Drawing.Point(85, 70);
            this.cbbCompensate.Name = "cbbCompensate";
            this.cbbCompensate.Size = new System.Drawing.Size(297, 28);
            this.cbbCompensate.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(206, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chọn Ca Bù";
            // 
            // btnCompensate
            // 
            this.btnCompensate.Location = new System.Drawing.Point(185, 173);
            this.btnCompensate.Name = "btnCompensate";
            this.btnCompensate.Size = new System.Drawing.Size(94, 29);
            this.btnCompensate.TabIndex = 2;
            this.btnCompensate.Text = "Báo Bù";
            this.btnCompensate.UseVisualStyleBackColor = true;
            this.btnCompensate.Click += new System.EventHandler(this.btnCompensate_Click);
            // 
            // cbbShift
            // 
            this.cbbShift.FormattingEnabled = true;
            this.cbbShift.Location = new System.Drawing.Point(156, 123);
            this.cbbShift.Name = "cbbShift";
            this.cbbShift.Size = new System.Drawing.Size(151, 28);
            this.cbbShift.TabIndex = 3;
            this.cbbShift.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // Page_Compensate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 241);
            this.Controls.Add(this.cbbShift);
            this.Controls.Add(this.btnCompensate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbbCompensate);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(505, 505);
            this.Name = "Page_Compensate";
            this.Text = "Page_Compensate";
            this.Load += new System.EventHandler(this.Page_Compensate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cbbCompensate;
        private Label label1;
        private Button btnCompensate;
        private ComboBox cbbShift;
    }
}