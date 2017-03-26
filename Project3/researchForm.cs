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
    public partial class researchForm : Form
    {
        public researchForm()
        {
            InitializeComponent();
        }

        public string rchtitle;
        public string rchdomain;
        public List<string> rchcitations;

        private void researchForm_Load(object sender, EventArgs e)
        {
            lbl_rchby.Text = rchtitle;
            lbl_rch_domain.Text = rchdomain;
           
            foreach (string s in rchcitations)
            {
                rchTb_rec.AppendText("--> ");
                rchTb_rec.AppendText(s);
                rchTb_rec.AppendText("\n");
                rchTb_rec.AppendText("\n");

            }
        }

    }
}
