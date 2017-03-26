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
    public partial class SRForm2 : Form
    {
        public SRForm2()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        public string ftitle;
        public string ftitle1;
        public string ftitle1_desc;
        public string pic;
        public string ftitle2;
        public string ftitle2_desc;
        public string ftitle3;
        public string ftitle3_desc;
        public string ftitle4;
        public string ftitle4_desc;
        public string ftitle5;
        public string ftitle5_desc;
        public string ftitle6;
        public string ftitle6_desc;

        private void SRForm2_Load(object sender, EventArgs e)
        {
            lbl_sr_maintitle.Text = ftitle;
            lbl_sr_title1.Text = ftitle1;
            rtb_sr_title1desc.Text = ftitle1_desc;
            pic_sr_samb.ImageLocation = pic;
            lbl_sr_title2.Text = ftitle2;
            rtb_sr_title2desc.Text = ftitle2_desc;
            lbl_sr_title3.Text = ftitle3;
            rtb_sr_title3desc.Text = ftitle3_desc;
            lbl_sr_title4.Text = ftitle4;
            rtb_sr_title4desc.Text = ftitle4_desc;
            lbl_sr_title5.Text = ftitle5;
            rtb_sr_title5desc.Text = ftitle5_desc;
            lbl_sr_title6.Text = ftitle6;
            rtb_sr_title6desc.Text = ftitle6_desc;
        }
    }
}
