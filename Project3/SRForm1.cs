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
    public partial class SRForm1 : Form
    {
        public SRForm1()
        {
            InitializeComponent();
        }

        public string ftitle;
        public string ftitle1;
        public string ftitle1_desc;
        public string ftitle2;
        public string ftitle2_desc;
        public string ftitle3;
        public string ftitle3_desc;
        public string ftitle4;
        public string ftitle4_desc;
        public List<string> ss_ai;

        private void SRForm1_Load(object sender, EventArgs e)
        {
            if (ftitle == "Study Abroad")
            {
                lbl_sr_maintitle.Text = ftitle;
                lbl_sr_title1.Text = ftitle1;
                rtb_ss_title1desc.Text = ftitle1_desc;
                lbl_sr_title2.Text = ftitle2;
                rtb_sr_title2desc.Text = ftitle2_desc;
                lbl_sr_title3.Text = ftitle3;
                rtb_sr_title3desc.Text = ftitle3_desc;
                lbl_sr_title4.Hide();
                rtb_sr_title4desc.Hide();
            }
            else if(ftitle == "Advising")
            {

                lbl_sr_maintitle.Text = ftitle;
                lbl_sr_title1.Text = ftitle1;
                rtb_ss_title1desc.Text = ftitle1_desc;
                lbl_sr_title2.Text = ftitle2;
                rtb_sr_title2desc.Text = ftitle2_desc;
                lbl_sr_title3.Text = ftitle3;
                rtb_sr_title3desc.Text = ftitle3_desc;
                lbl_sr_title4.Text = ftitle4;
                rtb_sr_title4desc.Text = ftitle4_desc;
            }
            else if(ftitle == "Tutors / Lab Information")
            {
                lbl_sr_maintitle.Text = ftitle;
                rtb_ss_title1desc.Text = ftitle1_desc;
                rtb_sr_title2desc.Hide();
                rtb_sr_title3desc.Hide();
                rtb_sr_title4desc.Hide();
            }
            else if (ftitle == "Coop-Enrollment")
            {
                lbl_sr_maintitle.Text = ftitle;
                lbl_sr_title1.Text = ftitle1;
                rtb_ss_title1desc.Text = ftitle1_desc;
                lbl_sr_title2.Text = ftitle2;
                rtb_sr_title2desc.Text = ftitle2_desc;
                lbl_sr_title3.Text = ftitle3;
                rtb_sr_title3desc.Text = ftitle3_desc;
                lbl_sr_title4.Text = ftitle4;
                rtb_sr_title4desc.Text = ftitle4_desc;
            }
            else if (ftitle == "Forms")
            {
                lbl_sr_maintitle.Text = ftitle;
                lbl_sr_title1.Text = ftitle1;
                rtb_ss_title1desc.Text = ftitle1_desc;
                lbl_sr_title2.Text = ftitle2;
                rtb_sr_title2desc.Text = ftitle2_desc;
                rtb_sr_title3desc.Hide();
                rtb_sr_title4desc.Hide();
            }
        }
    }
}
