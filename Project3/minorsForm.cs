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
    public partial class minorsForm : Form
    {
        public minorsForm()
        {
            InitializeComponent();
        }
        public string mntitle;
        public string mndesc;
        public string mnnote;
        public List<string> mncourses;

        private void minorsForm_Load(object sender, EventArgs e)
        {
            lbl_minor_title.Text = mntitle;
            txt_minor_des.Text = mndesc;
            lbl_minors_note.Text = mnnote;
            foreach(string s in mncourses)
            {
                tb_courses.AppendText(s);
                tb_courses.AppendText("\n");
            }
        }

    }
}
