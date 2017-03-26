namespace Project3
{
    partial class researchForm
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
            this.lbl_rchby = new System.Windows.Forms.Label();
            this.lbl_rch_domain = new System.Windows.Forms.Label();
            this.rchTb_rec = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lbl_rchby
            // 
            this.lbl_rchby.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_rchby.ForeColor = System.Drawing.Color.DeepPink;
            this.lbl_rchby.Location = new System.Drawing.Point(85, 68);
            this.lbl_rchby.Name = "lbl_rchby";
            this.lbl_rchby.Size = new System.Drawing.Size(456, 43);
            this.lbl_rchby.TabIndex = 0;
            // 
            // lbl_rch_domain
            // 
            this.lbl_rch_domain.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_rch_domain.ForeColor = System.Drawing.Color.DeepPink;
            this.lbl_rch_domain.Location = new System.Drawing.Point(467, 64);
            this.lbl_rch_domain.Name = "lbl_rch_domain";
            this.lbl_rch_domain.Size = new System.Drawing.Size(334, 43);
            this.lbl_rch_domain.TabIndex = 1;
            this.lbl_rch_domain.Text = "label1";
            
            // 
            // rchTb_rec
            // 
            this.rchTb_rec.Location = new System.Drawing.Point(53, 127);
            this.rchTb_rec.Name = "rchTb_rec";
            this.rchTb_rec.ReadOnly = true;
            this.rchTb_rec.Size = new System.Drawing.Size(1136, 738);
            this.rchTb_rec.TabIndex = 2;
            this.rchTb_rec.Text = "";
            // 
            // researchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1398, 949);
            this.Controls.Add(this.rchTb_rec);
            this.Controls.Add(this.lbl_rch_domain);
            this.Controls.Add(this.lbl_rchby);
            this.Name = "researchForm";
            this.Text = "Research Areas";
            this.Load += new System.EventHandler(this.researchForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_rchby;
        private System.Windows.Forms.Label lbl_rch_domain;
        private System.Windows.Forms.RichTextBox rchTb_rec;
    }
}