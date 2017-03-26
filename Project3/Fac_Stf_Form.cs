using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project3
{
    public partial class Fac_Stf_Form : Form
    {
        public Fac_Stf_Form()
        {
            InitializeComponent();
        }

        public string FS_pic;
        public string FS_name;
        public string FS_title;
        public string FS_office;
        public string FS_phone;
        public string FS_email;

        private void Fac_Stf_Form_Load(object sender, EventArgs e)
        {
            pic_fac_stf.ImageLocation = FS_pic;
            lbl_fac_stf_name.Text = FS_name;
            lbl_fac_stf_title.Text = FS_title;
            lbl_fac_stf_office.Text = FS_office;
            lbl_fac_stf_phone.Text = FS_phone;
            lbl_fac_stf_email.Text = FS_email;
        }

        
    }
}
