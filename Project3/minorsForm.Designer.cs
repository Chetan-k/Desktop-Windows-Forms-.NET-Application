namespace Project3
{
    partial class minorsForm
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
            this.lbl_minor_title = new System.Windows.Forms.Label();
            this.txt_minor_des = new System.Windows.Forms.TextBox();
            this.lbl_minors_courses = new System.Windows.Forms.Label();
            this.lbl_minors_note = new System.Windows.Forms.Label();
            this.tb_courses = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_minor_title
            // 
            this.lbl_minor_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_minor_title.Location = new System.Drawing.Point(357, 50);
            this.lbl_minor_title.Name = "lbl_minor_title";
            this.lbl_minor_title.Size = new System.Drawing.Size(756, 73);
            this.lbl_minor_title.TabIndex = 0;
            this.lbl_minor_title.Text = "Tiltle";
            // 
            // txt_minor_des
            // 
            this.txt_minor_des.BackColor = System.Drawing.SystemColors.Window;
            this.txt_minor_des.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_minor_des.Enabled = false;
            this.txt_minor_des.Location = new System.Drawing.Point(25, 18);
            this.txt_minor_des.Multiline = true;
            this.txt_minor_des.Name = "txt_minor_des";
            this.txt_minor_des.ReadOnly = true;
            this.txt_minor_des.Size = new System.Drawing.Size(760, 153);
            this.txt_minor_des.TabIndex = 1;
           
            // 
            // lbl_minors_courses
            // 
            this.lbl_minors_courses.AutoSize = true;
            this.lbl_minors_courses.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_minors_courses.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_minors_courses.Location = new System.Drawing.Point(121, 340);
            this.lbl_minors_courses.Name = "lbl_minors_courses";
            this.lbl_minors_courses.Size = new System.Drawing.Size(123, 31);
            this.lbl_minors_courses.TabIndex = 2;
            this.lbl_minors_courses.Text = "Courses";
            // 
            // lbl_minors_note
            // 
            this.lbl_minors_note.ForeColor = System.Drawing.Color.Red;
            this.lbl_minors_note.Location = new System.Drawing.Point(348, 541);
            this.lbl_minors_note.Name = "lbl_minors_note";
            this.lbl_minors_note.Size = new System.Drawing.Size(790, 147);
            this.lbl_minors_note.TabIndex = 3;
            this.lbl_minors_note.Text = "note";
            // 
            // tb_courses
            // 
            this.tb_courses.BackColor = System.Drawing.SystemColors.Window;
            this.tb_courses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_courses.Enabled = false;
            this.tb_courses.Location = new System.Drawing.Point(13, 18);
            this.tb_courses.Multiline = true;
            this.tb_courses.Name = "tb_courses";
            this.tb_courses.ReadOnly = true;
            this.tb_courses.Size = new System.Drawing.Size(376, 143);
            this.tb_courses.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(121, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "Description";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.txt_minor_des);
            this.panel1.Location = new System.Drawing.Point(353, 126);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(820, 190);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.tb_courses);
            this.panel2.Location = new System.Drawing.Point(353, 340);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(406, 184);
            this.panel2.TabIndex = 7;
            // 
            // minorsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1720, 1051);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_minors_note);
            this.Controls.Add(this.lbl_minors_courses);
            this.Controls.Add(this.lbl_minor_title);
            this.Name = "minorsForm";
            this.Text = "Our Courses";
            this.Load += new System.EventHandler(this.minorsForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_minor_title;
        private System.Windows.Forms.TextBox txt_minor_des;
        private System.Windows.Forms.Label lbl_minors_courses;
        private System.Windows.Forms.Label lbl_minors_note;
        private System.Windows.Forms.TextBox tb_courses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}