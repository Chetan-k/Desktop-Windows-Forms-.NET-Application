using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RESTUtil;
using System.Diagnostics;

namespace Project3
{
    public partial class Form1 : Form
    {
        //fair
        //Set up our rest call
        REST rj = new REST("http://ist.rit.edu/api");
        //set up another rest call (but we won't use)
        REST rjGoogle = new REST("http://www.google.com/api");

        //instantiate my obj
        People people;
        Employment employment;
        Minors minors;
        Degrees degrees;
        Research research;
        Resources resources;

        //For timing
        Stopwatch sw = new Stopwatch();

        public Form1()
        {

            InitializeComponent();
            
        }

        private void Populate()
        {
            //get about...
            string jsonAbout = rj.getJSON("/about/");
            //need a way to take this string and cast it to a specific type of object.
            //Console.WriteLine(jsonAbout);

            //create a new object of type About called about and populate it with the 
            //data from the call.
            About about = JToken.Parse(jsonAbout).ToObject<About>();
            //put out the description of about into the label
            textBox1.Text = about.description;
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Populate();
            //Get the objects...
            //get employment

            string jsonEmp = rj.getJSON("/employment/");
            employment = JToken.Parse(jsonEmp).ToObject<Employment>();

            lbl_emp_int_title.Text = employment.introduction.title;
            lbl_emp_cnt_title.Text = employment.introduction.content[0].title;
            txt_emp_cnt_desc.Text = employment.introduction.content[0].description;
            lbl_emp_cnt_title2.Text = employment.introduction.content[1].title;
            txt_emp_cnt2_desc.Text = employment.introduction.content[1].description;
            foreach(string s in employment.employers.employerNames)
            {
                txt_emp_employers.AppendText(s);
                txt_emp_employers.AppendText("\n");
            }
            foreach (string s in employment.careers.careerNames)
            {
                txt_emp_careers.AppendText(s);
                txt_emp_careers.AppendText("\n");
            }

            //set up the listView...
            //make columns...
            //for co-op table
            listView1.View = View.Details;//text
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            listView1.Width = 820;
            listView1.Columns.Add("EMPLOYER", 235);
            listView1.Columns.Add("DEGREE", 235);
            listView1.Columns.Add("CITY", 235);
            listView1.Columns.Add("TERM", 115);

            ListViewItem item;

            for (var i = 0; i < employment.coopTable.coopInformation.Count; i++)
            {
                item = new ListViewItem(
                    new string[]{
                      employment.coopTable.coopInformation[i].employer,
                      employment.coopTable.coopInformation[i].degree,
                      employment.coopTable.coopInformation[i].city,
                      employment.coopTable.coopInformation[i].term
                    }
                );
                //append the row
                listView1.Items.Add(item);
            }

            //for employment table
            listView2.View = View.Details;//text
            listView2.GridLines = true;
            listView2.FullRowSelect = true;

            listView2.Width = 820;
            listView2.Columns.Add("DEGREE", 175);
            listView2.Columns.Add("EMPLOYER", 175);
            listView2.Columns.Add("LOCATION", 175);
            listView2.Columns.Add("TITLE", 175);
            listView2.Columns.Add("START DATE", 120);

            ListViewItem empl;

            for (var i = 0; i < employment.employmentTable.professionalEmploymentInformation.Count; i++)
            {
                empl = new ListViewItem(
                    new string[]{
                      employment.employmentTable.professionalEmploymentInformation[i].employer,
                      employment.employmentTable.professionalEmploymentInformation[i].degree,
                      employment.employmentTable.professionalEmploymentInformation[i].city,
                      employment.employmentTable.professionalEmploymentInformation[i].title,
                       employment.employmentTable.professionalEmploymentInformation[i].startDate
                    }
                );
                //append the row
                listView2.Items.Add(empl);
            }

            //get minors
            string jsonMnr = rj.getJSON("/minors/");
            minors = JToken.Parse(jsonMnr).ToObject<Minors>();

            //get degrees
            string jsonDegree = rj.getJSON("/degrees/");
            degrees = JToken.Parse(jsonDegree).ToObject<Degrees>();

            //get research
            string jsonResearch = rj.getJSON("/research/");
            research = JToken.Parse(jsonResearch).ToObject<Research>();

            //get resources
            string jsonResource = rj.getJSON("/resources/");
            resources = JToken.Parse(jsonResource).ToObject<Resources>();

            //get news
            string jsonnew = rj.getJSON("/news/");
            News news = JToken.Parse(jsonnew).ToObject<News>();
            //appending to the news tab page
            rtb_news_latest.Text = news.year[0].title + "\n" + news.year[0].date + "\n" + "   " + news.year[0].description + "\n" + "\n" + news.year[1].title + "\n" + news.year[1].date + "\n" + "  " + news.year[1].description + "\n" + "\n" + news.year[3].title + "\n" + news.year[3].date + "\n" + "  " + news.year[3].description + "\n" + "\n" + news.year[4].title + "\n" + news.year[4].date + "\n" + "  " + news.year[4].description + "\n" + "\n" + news.year[5].title + "\n" + news.year[5].date + "\n" + "  " + news.year[5].description;
            rtb_news_quarter.Text = news.quarter[0].title + "\n" + news.quarter[0].date + "\n" + "   " + news.quarter[0].description + "\n" + "\n" + news.quarter[1].title + "\n" + news.quarter[1].date + "\n" + "  " + news.quarter[1].description;
            rtb_news_older.Text = news.older[0].title + "\n" + news.older[0].date + "\n" + "   " + news.older[0].description + "\n" + "\n" + news.older[1].title + "\n" + news.older[1].date + "\n" + "  " + news.older[1].description + "\n" + "\n" + news.older[2].title + "\n" + news.older[2].date + "\n" + "  " + news.older[2].description + "\n" + "\n" + news.older[3].title + "\n" + news.older[3].date + "\n" + "  " + news.older[3].description + "\n" + "\n" + news.older[4].title + "\n" + news.older[4].date + "\n" + "  " + news.older[4].description + "\n" + "\n" + news.older[5].title + "\n" + news.older[5].date + "\n" + "  " + news.older[5].description;

            //get people
            string jsonPeople = rj.getJSON("/people/");
            people = JToken.Parse(jsonPeople).ToObject<People>();

            //get images of faculties for their research areas
            pic_rec_fac1.ImageLocation = people.faculty[1].imagePath;
            pic_rec_fac2.ImageLocation = people.faculty[3].imagePath;
            pic_rec_fac3.ImageLocation = people.faculty[4].imagePath;
            pic_rec_fac4.ImageLocation = people.faculty[5].imagePath;
            pic_rec_fac5.ImageLocation = people.faculty[7].imagePath;
            pic_rec_fac6.ImageLocation = people.faculty[8].imagePath;
            pic_rec_fac7.ImageLocation = people.faculty[9].imagePath;
            pic_rec_fac8.ImageLocation = people.faculty[11].imagePath;
            pic_rec_fac9.ImageLocation = people.faculty[12].imagePath;
            pic_rec_fac10.ImageLocation = people.faculty[13].imagePath;
            pic_rec_fac11.ImageLocation = people.faculty[15].imagePath;
            pic_rec_fac12.ImageLocation = people.faculty[17].imagePath;
            pic_rec_fac13.ImageLocation = people.faculty[19].imagePath;
            pic_rec_fac14.ImageLocation = people.faculty[22].imagePath;
            pic_rec_fac15.ImageLocation = people.faculty[24].imagePath;
            pic_rec_fac16.ImageLocation = people.faculty[26].imagePath;
            pic_rec_fac17.ImageLocation = people.faculty[28].imagePath;
            pic_rec_fac18.ImageLocation = people.faculty[29].imagePath;
            pic_rec_fac19.ImageLocation = people.faculty[30].imagePath;
            pic_rec_fac20.ImageLocation = people.faculty[31].imagePath;
            pic_rec_fac21.ImageLocation = people.faculty[32].imagePath;

        }

     
        //show 2nd form with details based on the click of degrees
        private void lbl_MDD_Click(object sender, EventArgs e)
        {
            minorsForm info = new minorsForm();
            Label l = (Label)sender;
            if (l.Name =="lbl_MDD")
            {
                info.mntitle = minors.UgMinors[0].title;
                info.mncourses = minors.UgMinors[0].courses;
                info.mnnote = minors.UgMinors[0].note;
                info.mndesc = minors.UgMinors[0].description;
            }
            else if(l.Name=="lbl_MG")
            {
                info.mntitle = minors.UgMinors[1].title;
                info.mncourses = minors.UgMinors[1].courses;
                info.mnnote = minors.UgMinors[1].note;
                info.mndesc = minors.UgMinors[1].description;
            }
            else if (l.Name=="lbl_MH")
            {
                info.mntitle = minors.UgMinors[2].title;
                info.mncourses = minors.UgMinors[2].courses;
                info.mnnote = minors.UgMinors[2].note;
                info.mndesc = minors.UgMinors[2].description;
            }
            else if (l.Name == "lbl_MMD")
            {
                info.mntitle = minors.UgMinors[3].title;
                info.mncourses = minors.UgMinors[3].courses;
                info.mnnote = minors.UgMinors[3].note;
                info.mndesc = minors.UgMinors[3].description;
            }
            else if (l.Name == "lbl_MDev")
            {
                info.mntitle = minors.UgMinors[4].title;
                info.mncourses = minors.UgMinors[4].courses;
                info.mnnote = minors.UgMinors[4].note;
                info.mndesc = minors.UgMinors[4].description;
            }
            else if (l.Name == "lbl_MN")
            {
                info.mntitle = minors.UgMinors[5].title;
                info.mncourses = minors.UgMinors[5].courses;
                info.mnnote = minors.UgMinors[5].note;
                info.mndesc = minors.UgMinors[5].description;
            }
            else if (l.Name == "lbl_MWD")
            {
                info.mntitle = minors.UgMinors[6].title;
                info.mncourses = minors.UgMinors[6].courses;
                info.mnnote = minors.UgMinors[6].note;
                info.mndesc = minors.UgMinors[6].description;
            }
            else
            {
                info.mntitle = minors.UgMinors[7].title;
                info.mncourses = minors.UgMinors[7].courses;
                info.mnnote = minors.UgMinors[7].note;
                info.mndesc = minors.UgMinors[7].description;
            }
            info.Show();
        }

        //show 2nd form with details based on the click of minors
        private void lbl_ug_wmc_Click(object sender, EventArgs e)
        {
            minorsForm Deginfo = new minorsForm();
            Label d = (Label)sender;
            if (d.Name == "lbl_ug_wmc")
            {
                Deginfo.mntitle = degrees.undergraduate[0].title;
                Deginfo.mncourses = degrees.undergraduate[0].concentrations;
                Deginfo.mndesc = degrees.undergraduate[0].description;
            }
            else if (d.Name == "lbl_ug_hcc")
            {
                Deginfo.mntitle = degrees.undergraduate[1].title;
                Deginfo.mncourses = degrees.undergraduate[1].concentrations;
                Deginfo.mndesc = degrees.undergraduate[1].description;
            }
            else
            {
                Deginfo.mntitle = degrees.undergraduate[2].title;
                Deginfo.mncourses = degrees.undergraduate[2].concentrations;
                Deginfo.mndesc = degrees.undergraduate[2].description;
            }
            Deginfo.Show();
        }

        private void lbl_g_ist_Click(object sender, EventArgs e)
        {
            minorsForm Deginfo = new minorsForm();
            Label d = (Label)sender;
            if (d.Name == "lbl_g_ist")
            {
                Deginfo.mntitle = degrees.graduate[0].title;
                Deginfo.mncourses = degrees.graduate[0].concentrations;
                Deginfo.mndesc = degrees.graduate[0].description;
            }
            else if (d.Name == "lbl_g_hci")
            {
                Deginfo.mntitle = degrees.graduate[1].title;
                Deginfo.mncourses = degrees.graduate[1].concentrations;
                Deginfo.mndesc = degrees.graduate[1].description;
            }
            else
            {
                Deginfo.mntitle = degrees.graduate[2].title;
                Deginfo.mncourses = degrees.graduate[2].concentrations;
                Deginfo.mndesc = degrees.graduate[2].description;
            }
            Deginfo.Show();
        }

        //show 2nd form with details based on the click of faculty and staff
        private void lbl_fac1_Click(object sender, EventArgs e)
        {
            Fac_Stf_Form info = new Fac_Stf_Form();
            Label fs = (Label)sender;
            if(fs.Name == "lbl_fac1")
            {
                info.FS_pic = people.faculty[0].imagePath;
                info.FS_name = people.faculty[0].name;
                info.FS_title = people.faculty[0].title;
                info.FS_office = people.faculty[0].office;
                info.FS_phone = people.faculty[0].phone;
                info.FS_email = people.faculty[0].email;
            }
            else if(fs.Name == "lbl_fac2")
            {
                info.FS_pic = people.faculty[1].imagePath;
                info.FS_name = people.faculty[1].name;
                info.FS_title = people.faculty[1].title;
                info.FS_office = people.faculty[1].office;
                info.FS_phone = people.faculty[1].phone;
                info.FS_email = people.faculty[1].email;
            }
            else if (fs.Name == "lbl_fac3")
            {
                info.FS_pic = people.faculty[2].imagePath;
                info.FS_name = people.faculty[2].name;
                info.FS_title = people.faculty[2].title;
                info.FS_office = people.faculty[2].office;
                info.FS_phone = people.faculty[2].phone;
                info.FS_email = people.faculty[2].email;
            }
            else if (fs.Name == "lbl_fac4")
            {
                info.FS_pic = people.faculty[3].imagePath;
                info.FS_name = people.faculty[3].name;
                info.FS_title = people.faculty[3].title;
                info.FS_office = people.faculty[3].office;
                info.FS_phone = people.faculty[3].phone;
                info.FS_email = people.faculty[3].email;
            }
            else if (fs.Name == "lbl_fac5")
            {
                info.FS_pic = people.faculty[4].imagePath;
                info.FS_name = people.faculty[4].name;
                info.FS_title = people.faculty[4].title;
                info.FS_office = people.faculty[4].office;
                info.FS_phone = people.faculty[4].phone;
                info.FS_email = people.faculty[4].email;
            }
            else if (fs.Name == "lbl_fac6")
            {
                info.FS_pic = people.faculty[5].imagePath;
                info.FS_name = people.faculty[5].name;
                info.FS_title = people.faculty[5].title;
                info.FS_office = people.faculty[5].office;
                info.FS_phone = people.faculty[5].phone;
                info.FS_email = people.faculty[5].email;
            }
            else if (fs.Name == "lbl_fac7")
            {
                info.FS_pic = people.faculty[6].imagePath;
                info.FS_name = people.faculty[6].name;
                info.FS_title = people.faculty[6].title;
                info.FS_office = people.faculty[6].office;
                info.FS_phone = people.faculty[6].phone;
                info.FS_email = people.faculty[6].email;
            }
            else if (fs.Name == "lbl_fac8")
            {
                info.FS_pic = people.faculty[7].imagePath;
                info.FS_name = people.faculty[7].name;
                info.FS_title = people.faculty[7].title;
                info.FS_office = people.faculty[7].office;
                info.FS_phone = people.faculty[7].phone;
                info.FS_email = people.faculty[7].email;
            }
            else if (fs.Name == "lbl_fac9")
            {
                info.FS_pic = people.faculty[8].imagePath;
                info.FS_name = people.faculty[8].name;
                info.FS_title = people.faculty[8].title;
                info.FS_office = people.faculty[8].office;
                info.FS_phone = people.faculty[8].phone;
                info.FS_email = people.faculty[8].email;
            }
            else if (fs.Name == "lbl_fac10")
            {
                info.FS_pic = people.faculty[9].imagePath;
                info.FS_name = people.faculty[9].name;
                info.FS_title = people.faculty[9].title;
                info.FS_office = people.faculty[9].office;
                info.FS_phone = people.faculty[9].phone;
                info.FS_email = people.faculty[9].email;
            }
            else if (fs.Name == "lbl_fac11")
            {
                info.FS_pic = people.faculty[10].imagePath;
                info.FS_name = people.faculty[10].name;
                info.FS_title = people.faculty[10].title;
                info.FS_office = people.faculty[10].office;
                info.FS_phone = people.faculty[10].phone;
                info.FS_email = people.faculty[10].email;
            }
            else if (fs.Name == "lbl_fac12")
            {
                info.FS_pic = people.faculty[12].imagePath;
                info.FS_name = people.faculty[12].name;
                info.FS_title = people.faculty[12].title;
                info.FS_office = people.faculty[12].office;
                info.FS_phone = people.faculty[12].phone;
                info.FS_email = people.faculty[12].email;
            }
            else if (fs.Name == "lbl_fac13")
            {
                info.FS_pic = people.faculty[13].imagePath;
                info.FS_name = people.faculty[13].name;
                info.FS_title = people.faculty[13].title;
                info.FS_office = people.faculty[13].office;
                info.FS_phone = people.faculty[13].phone;
                info.FS_email = people.faculty[13].email;
            }
            else if (fs.Name == "lbl_fac14")
            {
                info.FS_pic = people.faculty[14].imagePath;
                info.FS_name = people.faculty[14].name;
                info.FS_title = people.faculty[14].title;
                info.FS_office = people.faculty[14].office;
                info.FS_phone = people.faculty[14].phone;
                info.FS_email = people.faculty[14].email;
            }
            else if (fs.Name == "lbl_fac15")
            {
                info.FS_pic = people.faculty[15].imagePath;
                info.FS_name = people.faculty[15].name;
                info.FS_title = people.faculty[15].title;
                info.FS_office = people.faculty[15].office;
                info.FS_phone = people.faculty[15].phone;
                info.FS_email = people.faculty[15].email;
            }
            else if (fs.Name == "lbl_fac16")
            {
                info.FS_pic = people.faculty[16].imagePath;
                info.FS_name = people.faculty[16].name;
                info.FS_title = people.faculty[16].title;
                info.FS_office = people.faculty[16].office;
                info.FS_phone = people.faculty[16].phone;
                info.FS_email = people.faculty[16].email;
            }
            else if (fs.Name == "lbl_fac17")
            {
                info.FS_pic = people.faculty[17].imagePath;
                info.FS_name = people.faculty[17].name;
                info.FS_title = people.faculty[17].title;
                info.FS_office = people.faculty[17].office;
                info.FS_phone = people.faculty[17].phone;
                info.FS_email = people.faculty[17].email;
            }
            else if (fs.Name == "lbl_fac18")
            {
                info.FS_pic = people.faculty[18].imagePath;
                info.FS_name = people.faculty[18].name;
                info.FS_title = people.faculty[18].title;
                info.FS_office = people.faculty[18].office;
                info.FS_phone = people.faculty[18].phone;
                info.FS_email = people.faculty[18].email;
            }
            else if (fs.Name == "lbl_fac19")
            {
                info.FS_pic = people.faculty[19].imagePath;
                info.FS_name = people.faculty[19].name;
                info.FS_title = people.faculty[19].title;
                info.FS_office = people.faculty[19].office;
                info.FS_phone = people.faculty[19].phone;
                info.FS_email = people.faculty[19].email;
            }
            else if (fs.Name == "lbl_fac20")
            {
                info.FS_pic = people.faculty[21].imagePath;
                info.FS_name = people.faculty[21].name;
                info.FS_title = people.faculty[21].title;
                info.FS_office = people.faculty[21].office;
                info.FS_phone = people.faculty[21].phone;
                info.FS_email = people.faculty[21].email;
            }
            else if (fs.Name == "lbl_fac21")
            {
                info.FS_pic = people.faculty[22].imagePath;
                info.FS_name = people.faculty[22].name;
                info.FS_title = people.faculty[22].title;
                info.FS_office = people.faculty[22].office;
                info.FS_phone = people.faculty[22].phone;
                info.FS_email = people.faculty[22].email;
            }
            else if (fs.Name == "lbl_fac22")
            {
                info.FS_pic = people.faculty[23].imagePath;
                info.FS_name = people.faculty[23].name;
                info.FS_title = people.faculty[23].title;
                info.FS_office = people.faculty[23].office;
                info.FS_phone = people.faculty[23].phone;
                info.FS_email = people.faculty[23].email;
            }
            else if (fs.Name == "lbl_fac23")
            {
                info.FS_pic = people.faculty[24].imagePath;
                info.FS_name = people.faculty[24].name;
                info.FS_title = people.faculty[24].title;
                info.FS_office = people.faculty[24].office;
                info.FS_phone = people.faculty[24].phone;
                info.FS_email = people.faculty[24].email;
            }
            else if (fs.Name == "lbl_fac24")
            {
                info.FS_pic = people.faculty[25].imagePath;
                info.FS_name = people.faculty[25].name;
                info.FS_title = people.faculty[25].title;
                info.FS_office = people.faculty[25].office;
                info.FS_phone = people.faculty[25].phone;
                info.FS_email = people.faculty[25].email;
            }
            else if (fs.Name == "lbl_fac25")
            {
                info.FS_pic = people.faculty[26].imagePath;
                info.FS_name = people.faculty[26].name;
                info.FS_title = people.faculty[26].title;
                info.FS_office = people.faculty[26].office;
                info.FS_phone = people.faculty[26].phone;
                info.FS_email = people.faculty[26].email;
            }
            else if (fs.Name == "lbl_fac26")
            {
                info.FS_pic = people.faculty[28].imagePath;
                info.FS_name = people.faculty[28].name;
                info.FS_title = people.faculty[28].title;
                info.FS_office = people.faculty[28].office;
                info.FS_phone = people.faculty[28].phone;
                info.FS_email = people.faculty[28].email;
            }
            else if (fs.Name == "lbl_fac27")
            {
                info.FS_pic = people.faculty[29].imagePath;
                info.FS_name = people.faculty[29].name;
                info.FS_title = people.faculty[29].title;
                info.FS_office = people.faculty[29].office;
                info.FS_phone = people.faculty[29].phone;
                info.FS_email = people.faculty[29].email;
            }
            else if (fs.Name == "lbl_fac28")
            {
                info.FS_pic = people.faculty[30].imagePath;
                info.FS_name = people.faculty[30].name;
                info.FS_title = people.faculty[30].title;
                info.FS_office = people.faculty[30].office;
                info.FS_phone = people.faculty[30].phone;
                info.FS_email = people.faculty[30].email;
            }
            else if (fs.Name == "lbl_fac29")
            {
                info.FS_pic = people.faculty[31].imagePath;
                info.FS_name = people.faculty[31].name;
                info.FS_title = people.faculty[31].title;
                info.FS_office = people.faculty[31].office;
                info.FS_phone = people.faculty[31].phone;
                info.FS_email = people.faculty[31].email;
            }
            else
            {
                info.FS_pic = people.faculty[32].imagePath;
                info.FS_name = people.faculty[32].name;
                info.FS_title = people.faculty[32].title;
                info.FS_office = people.faculty[32].office;
                info.FS_phone = people.faculty[32].phone;
                info.FS_email = people.faculty[32].email;
            }
            info.Show();
        }

        private void lbl_stf1_Click(object sender, EventArgs e)
        {
            Fac_Stf_Form info = new Fac_Stf_Form();
            Label fs = (Label)sender;
            if (fs.Name == "lbl_stf1")
            {
                info.FS_pic = people.staff[0].imagePath;
                info.FS_name = people.staff[0].name;
                info.FS_title = people.staff[0].title;
                info.FS_office = people.staff[0].office;
                info.FS_phone = people.staff[0].phone;
                info.FS_email = people.staff[0].email;
            }
            else if(fs.Name == "lbl_stf2")
            {
                info.FS_pic = people.staff[1].imagePath;
                info.FS_name = people.staff[1].name;
                info.FS_title = people.staff[1].title;
                info.FS_office = people.staff[1].office;
                info.FS_phone = people.staff[1].phone;
                info.FS_email = people.staff[1].email;
            }
            else if (fs.Name == "lbl_stf3")
            {
                info.FS_pic = people.staff[2].imagePath;
                info.FS_name = people.staff[2].name;
                info.FS_title = people.staff[2].title;
                info.FS_office = people.staff[2].office;
                info.FS_phone = people.staff[2].phone;
                info.FS_email = people.staff[2].email;
            }
            else if (fs.Name == "lbl_stf4")
            {
                info.FS_pic = people.staff[3].imagePath;
                info.FS_name = people.staff[3].name;
                info.FS_title = people.staff[3].title;
                info.FS_office = people.staff[3].office;
                info.FS_phone = people.staff[3].phone;
                info.FS_email = people.staff[3].email;
            }
            else if (fs.Name == "lbl_stf5")
            {
                info.FS_pic = people.staff[4].imagePath;
                info.FS_name = people.staff[4].name;
                info.FS_title = people.staff[4].title;
                info.FS_office = people.staff[4].office;
                info.FS_phone = people.staff[4].phone;
                info.FS_email = people.staff[4].email;
            }
            else if (fs.Name == "lbl_stf6")
            {
                info.FS_pic = people.staff[5].imagePath;
                info.FS_name = people.staff[5].name;
                info.FS_title = people.staff[5].title;
                info.FS_office = people.staff[5].office;
                info.FS_phone = people.staff[5].phone;
                info.FS_email = people.staff[5].email;
            }
            else if (fs.Name == "lbl_stf7")
            {
                info.FS_pic = people.staff[6].imagePath;
                info.FS_name = people.staff[6].name;
                info.FS_title = people.staff[6].title;
                info.FS_office = people.staff[6].office;
                info.FS_phone = people.staff[6].phone;
                info.FS_email = people.staff[6].email;
            }
            else if (fs.Name == "lbl_stf8")
            {
                info.FS_pic = people.staff[7].imagePath;
                info.FS_name = people.staff[7].name;
                info.FS_title = people.staff[7].title;
                info.FS_office = people.staff[7].office;
                info.FS_phone = people.staff[7].phone;
                info.FS_email = people.staff[7].email;
            }
            else if (fs.Name == "lbl_stf9")
            {
                info.FS_pic = people.staff[8].imagePath;
                info.FS_name = people.staff[8].name;
                info.FS_title = people.staff[8].title;
                info.FS_office = people.staff[8].office;
                info.FS_phone = people.staff[8].phone;
                info.FS_email = people.staff[8].email;
            }
            else if (fs.Name == "lbl_stf10")
            {
                info.FS_pic = people.staff[9].imagePath;
                info.FS_name = people.staff[9].name;
                info.FS_title = people.staff[9].title;
                info.FS_office = people.staff[9].office;
                info.FS_phone = people.staff[9].phone;
                info.FS_email = people.staff[9].email;
            }
            else if (fs.Name == "lbl_stf11")
            {
                info.FS_pic = people.staff[10].imagePath;
                info.FS_name = people.staff[10].name;
                info.FS_title = people.staff[10].title;
                info.FS_office = people.staff[10].office;
                info.FS_phone = people.staff[10].phone;
                info.FS_email = people.staff[10].email;
            }
            else if (fs.Name == "lbl_stf12")
            {
                info.FS_pic = people.staff[11].imagePath;
                info.FS_name = people.staff[11].name;
                info.FS_title = people.staff[11].title;
                info.FS_office = people.staff[11].office;
                info.FS_phone = people.staff[11].phone;
                info.FS_email = people.staff[11].email;
            }
            else if (fs.Name == "lbl_stf13")
            {
                info.FS_pic = people.staff[12].imagePath;
                info.FS_name = people.staff[12].name;
                info.FS_title = people.staff[12].title;
                info.FS_office = people.staff[12].office;
                info.FS_phone = people.staff[12].phone;
                info.FS_email = people.staff[12].email;
            }
            info.Show();
        }

        //show 2nd form with details based on the click of research areas 
        private void lbl_rec_analytics_Click(object sender, EventArgs e)
        {
            //Fac_Stf_Form info = new Fac_Stf_Form();
            //Label fs = (Label)sender;

            researchForm rech = new researchForm();
            Label rd = (Label)sender;

            if(rd.Name == "lbl_rec_analytics")
            {
                rech.rchtitle = "Research By Domain Area:";
                rech.rchdomain = research.byInterestArea[4].areaName;
                rech.rchcitations = research.byInterestArea[4].citations;
            }
            else if (rd.Name == "lbl_rec_database")
            {
                rech.rchtitle = "Research By Domain Area:";
                rech.rchdomain = research.byInterestArea[3].areaName;
                rech.rchcitations = research.byInterestArea[3].citations;
            }
            else if (rd.Name == "lbl_rec_education")
            {
                rech.rchtitle = "Research By Domain Area:";
                rech.rchdomain = research.byInterestArea[1].areaName;
                rech.rchcitations = research.byInterestArea[1].citations;
            }
            else if (rd.Name == "lbl_rec_geo")
            {
                rech.rchtitle = "Research By Domain Area:";
                rech.rchdomain = research.byInterestArea[2].areaName;
                rech.rchcitations = research.byInterestArea[2].citations;
            }
            else if (rd.Name == "lbl_rec_hci")
            {
                rech.rchtitle = "Research By Domain Area:";
                rech.rchdomain = research.byInterestArea[0].areaName;
                rech.rchcitations = research.byInterestArea[0].citations;
            }
            else if (rd.Name == "lbl_rec_hi")
            {
                rech.rchtitle = "Research By Domain Area:";
                rech.rchdomain = research.byInterestArea[8].areaName;
                rech.rchcitations = research.byInterestArea[8].citations;
            }
            else if (rd.Name == "lbl_rec_mobile")
            {
                rech.rchtitle = "Research By Domain Area:";
                rech.rchdomain = research.byInterestArea[7].areaName;
                rech.rchcitations = research.byInterestArea[7].citations;
            }
            else if (rd.Name == "lbl_rec_networking")
            {
                rech.rchtitle = "Research By Domain Area:";
                rech.rchdomain = research.byInterestArea[6].areaName;
                rech.rchcitations = research.byInterestArea[6].citations;
            }
            else if (rd.Name == "lbl_rec_programming")
            {
                rech.rchtitle = "Research By Domain Area:";
                rech.rchdomain = research.byInterestArea[9].areaName;
                rech.rchcitations = research.byInterestArea[9].citations;
            }
            else if (rd.Name == "lbl_rec_sa")
            {
                rech.rchtitle = "Research By Domain Area:";
                rech.rchdomain = research.byInterestArea[10].areaName;
                rech.rchcitations = research.byInterestArea[10].citations;
            }
            else if (rd.Name == "lbl_rec_uc")
            {
                rech.rchtitle = "Research By Domain Area:";
                rech.rchdomain = research.byInterestArea[11].areaName;
                rech.rchcitations = research.byInterestArea[11].citations;
            }
            else
            {
                rech.rchtitle = "Research By Domain Area:";
                rech.rchdomain = research.byInterestArea[5].areaName;
                rech.rchcitations = research.byInterestArea[5].citations;
            }
            rech.Show();
        }

        //show 2nd form with details based on the click of faculty research areas
        private void pic_rec_fac1_Click(object sender, EventArgs e)
        {
          
            researchForm rech = new researchForm();
            PictureBox rf = (PictureBox)sender;

            if(rf.Name == "pic_rec_fac1")
            {
                rech.rchdomain = research.byFaculty[19].facultyName;
                rech.rchcitations = research.byFaculty[19].citations;
            }
            else if (rf.Name == "pic_rec_fac2")
            {
                rech.rchdomain = research.byFaculty[6].facultyName;
                rech.rchcitations = research.byFaculty[6].citations;
            }
            else if (rf.Name == "pic_rec_fac3")
            {
                rech.rchdomain = research.byFaculty[18].facultyName;
                rech.rchcitations = research.byFaculty[18].citations;
            }
            else if (rf.Name == "pic_rec_fac4")
            {
                rech.rchdomain = research.byFaculty[12].facultyName;
                rech.rchcitations = research.byFaculty[12].citations;
            }
            /* else if (rf.Name == "pic_rec_fac5")
            {
                API doesnt have the Prifessor details
                rech.rchdomain = research.byFaculty[Erik golen].facultyName;
                rech.rchcitations = research.byFaculty[Erik golen].citations;
            } */
            else if (rf.Name == "pic_rec_fac6")
            {
                rech.rchdomain = research.byFaculty[13].facultyName;
                rech.rchcitations = research.byFaculty[13].citations;
            }
            else if (rf.Name == "pic_rec_fac7")
            {
                rech.rchdomain = research.byFaculty[7].facultyName;
                rech.rchcitations = research.byFaculty[7].citations;
            }
            else if (rf.Name == "pic_rec_fac8")
            {
                rech.rchdomain = research.byFaculty[14].facultyName;
                rech.rchcitations = research.byFaculty[14].citations;
            }
            else if (rf.Name == "pic_rec_fac9")
            {
                rech.rchdomain = research.byFaculty[11].facultyName;
                rech.rchcitations = research.byFaculty[11].citations;
            }
            else if (rf.Name == "pic_rec_fac10")
            {
                rech.rchdomain = research.byFaculty[17].facultyName;
                rech.rchcitations = research.byFaculty[17].citations;
            }
            else if (rf.Name == "pic_rec_fac11")
            {
                rech.rchdomain = research.byFaculty[20].facultyName;
                rech.rchcitations = research.byFaculty[20].citations;
            }
            else if (rf.Name == "pic_rec_fac12")
            {
                rech.rchdomain = research.byFaculty[15].facultyName;
                rech.rchcitations = research.byFaculty[15].citations;
            }
            /* else if (rf.Name == "pic_rec_fac13")
            {
                API doesnt have the details of this professor
                rech.rchdomain = research.byFaculty[Leone Jim].facultyName;
                rech.rchcitations = research.byFaculty[Leone Jim].citations;
            } */
            else if (rf.Name == "pic_rec_fac14")
            {
                rech.rchdomain = research.byFaculty[8].facultyName;
                rech.rchcitations = research.byFaculty[8].citations;
            }
            else if (rf.Name == "pic_rec_fac15")
            {
                rech.rchdomain = research.byFaculty[9].facultyName;
                rech.rchcitations = research.byFaculty[9].citations;
            }
            else if (rf.Name == "pic_rec_fac16")
            {
                rech.rchdomain = research.byFaculty[10].facultyName;
                rech.rchcitations = research.byFaculty[10].citations;
            }
            else if (rf.Name == "pic_rec_fac17")
            {
                rech.rchdomain = research.byFaculty[1].facultyName;
                rech.rchcitations = research.byFaculty[1].citations;
            }
            else if (rf.Name == "pic_rec_fac18")
            {
                rech.rchdomain = research.byFaculty[16].facultyName;
                rech.rchcitations = research.byFaculty[16].citations;
            }
            else if (rf.Name == "pic_rec_fac19")
            {
                rech.rchdomain = research.byFaculty[2].facultyName;
                rech.rchcitations = research.byFaculty[2].citations;
            }
            else if (rf.Name == "pic_rec_fac20")
            {
                rech.rchdomain = research.byFaculty[3].facultyName;
                rech.rchcitations = research.byFaculty[3].citations;
            }
            else if (rf.Name == "pic_rec_fac21")
            {
                rech.rchdomain = research.byFaculty[4].facultyName;
                rech.rchcitations = research.byFaculty[4].citations;
            }
            rech.Show();
        }

        //show 2nd form with details based on the click of different student resources
        private void pic_sr_sa_Click(object sender, EventArgs e)
        {
            SRForm1 sr = new SRForm1();
            sr.ftitle = resources.studyAbroad.title;
            sr.ftitle1_desc = resources.studyAbroad.description;
            sr.ftitle2 = resources.studyAbroad.places[0].nameOfPlace;
            sr.ftitle2_desc = resources.studyAbroad.places[0].description;
            sr.ftitle3 = resources.studyAbroad.places[1].nameOfPlace;
            sr.ftitle3_desc = resources.studyAbroad.places[1].description;
            sr.Show();
        }

        private void pic_sr_ss_Click(object sender, EventArgs e)
        {
            SRForm1 sr = new SRForm1();
            sr.ftitle = resources.studentServices.title;
            sr.ftitle1 = resources.studentServices.academicAdvisors.title;
            sr.ftitle1_desc = resources.studentServices.academicAdvisors.description;
            sr.ftitle2 = resources.studentServices.professonalAdvisors.title;
            sr.ftitle2_desc = "-->"+resources.studentServices.professonalAdvisors.advisorInformation[0].name + ", " + resources.studentServices.professonalAdvisors.advisorInformation[0].department + ", " + resources.studentServices.professonalAdvisors.advisorInformation[0].email + "\n" + "-->" + resources.studentServices.professonalAdvisors.advisorInformation[1].name + ", " + resources.studentServices.professonalAdvisors.advisorInformation[1].department + ", " + resources.studentServices.professonalAdvisors.advisorInformation[1].email + "\n" + "-->" + resources.studentServices.professonalAdvisors.advisorInformation[2].name + ", " + resources.studentServices.professonalAdvisors.advisorInformation[2].department + ", " + resources.studentServices.professonalAdvisors.advisorInformation[2].email;
            sr.ftitle3 = resources.studentServices.facultyAdvisors.title;
            sr.ftitle3_desc = resources.studentServices.facultyAdvisors.description;
            sr.ftitle4 = resources.studentServices.istMinorAdvising.title;
            sr.ftitle4_desc = "-->"+resources.studentServices.istMinorAdvising.minorAdvisorInformation[0].title + ": " + resources.studentServices.istMinorAdvising.minorAdvisorInformation[0].advisor + ", " + resources.studentServices.istMinorAdvising.minorAdvisorInformation[0].email + "\n" +"-->"+resources.studentServices.istMinorAdvising.minorAdvisorInformation[1].title + ": " + resources.studentServices.istMinorAdvising.minorAdvisorInformation[1].advisor + ", " + resources.studentServices.istMinorAdvising.minorAdvisorInformation[1].email + "\n" +"-->"+ resources.studentServices.istMinorAdvising.minorAdvisorInformation[2].title + ": " + resources.studentServices.istMinorAdvising.minorAdvisorInformation[2].advisor + ", " + resources.studentServices.istMinorAdvising.minorAdvisorInformation[2].email +"\n"+"-->"+ resources.studentServices.istMinorAdvising.minorAdvisorInformation[3].title + ": " + resources.studentServices.istMinorAdvising.minorAdvisorInformation[3].advisor + ", " + resources.studentServices.istMinorAdvising.minorAdvisorInformation[3].email + "\n" +"-->"+ resources.studentServices.istMinorAdvising.minorAdvisorInformation[4].title + ": " + resources.studentServices.istMinorAdvising.minorAdvisorInformation[4].advisor + ", " + resources.studentServices.istMinorAdvising.minorAdvisorInformation[4].email + "\n"+"-->"+ resources.studentServices.istMinorAdvising.minorAdvisorInformation[5].title + ": " + resources.studentServices.istMinorAdvising.minorAdvisorInformation[5].advisor + ", " + resources.studentServices.istMinorAdvising.minorAdvisorInformation[5].email +"\n"+"-->"+ resources.studentServices.istMinorAdvising.minorAdvisorInformation[6].title + ": " + resources.studentServices.istMinorAdvising.minorAdvisorInformation[6].advisor + ", " + resources.studentServices.istMinorAdvising.minorAdvisorInformation[6].email + "\n"+"-->"+ resources.studentServices.istMinorAdvising.minorAdvisorInformation[7].title + ": " + resources.studentServices.istMinorAdvising.minorAdvisorInformation[7].advisor + ", " + resources.studentServices.istMinorAdvising.minorAdvisorInformation[7].email;
            sr.Show();
        }

        private void pic_sr_tl_Click(object sender, EventArgs e)
        {
            SRForm1 sr = new SRForm1();
            sr.ftitle = resources.tutorsAndLabInformation.title;
            sr.ftitle1_desc = resources.tutorsAndLabInformation.description + "\n" + "\n" + "Lab Hours and TA Schedule: " + resources.tutorsAndLabInformation.tutoringLabHoursLink;
            sr.Show();
        }

        private void pic_sr_coop_Click(object sender, EventArgs e)
        {
            SRForm1 sr = new SRForm1();
            sr.ftitle = resources.coopEnrollment.title;
            sr.ftitle1 = resources.coopEnrollment.enrollmentInformationContent[0].title;
            sr.ftitle1_desc = resources.coopEnrollment.enrollmentInformationContent[0].description;
            sr.ftitle2 = resources.coopEnrollment.enrollmentInformationContent[1].title;
            sr.ftitle2_desc = resources.coopEnrollment.enrollmentInformationContent[1].description;
            sr.ftitle3 = resources.coopEnrollment.enrollmentInformationContent[2].title;
            sr.ftitle3_desc = resources.coopEnrollment.enrollmentInformationContent[2].description;
            sr.ftitle4 = resources.coopEnrollment.enrollmentInformationContent[3].title;
            sr.ftitle4_desc = resources.coopEnrollment.enrollmentInformationContent[3].description+"\n"+"\n"+"RIT Job Zone Guide Link: "+resources.coopEnrollment.RITJobZoneGuidelink;
            sr.Show();
        }

        private void pic_sr_forms_Click(object sender, EventArgs e)
        {
            SRForm1 sr = new SRForm1();
            sr.ftitle = "Forms";
            sr.ftitle1 = "Undergraduate Forms";
            sr.ftitle1_desc = resources.forms.undergraduateForms[0].formName + ":  " + resources.forms.undergraduateForms[0].href;
            sr.ftitle2 = "Graduate Forms";
            sr.ftitle2_desc = resources.forms.graduateForms[0].formName + ":  " + resources.forms.graduateForms[0].href + "\n" + resources.forms.graduateForms[1].formName + ":  " + resources.forms.graduateForms[1].href + "\n" + resources.forms.graduateForms[2].formName + ":  " + resources.forms.graduateForms[2].href + "\n" + resources.forms.graduateForms[3].formName + ":  " + resources.forms.graduateForms[3].href + "\n" + resources.forms.graduateForms[4].formName + ":  " + resources.forms.graduateForms[4].href + "\n" + resources.forms.graduateForms[5].formName + ":  " + resources.forms.graduateForms[5].href + "\n" + resources.forms.graduateForms[6].formName + ":  " + resources.forms.graduateForms[6].href;
            sr.Show();
        }

        private void pic_sr_sam_Click(object sender, EventArgs e)
        {
            SRForm2 sr = new SRForm2();
            sr.ftitle = resources.studentAmbassadors.title;
            sr.ftitle1 = resources.studentAmbassadors.subSectionContent[0].title;
            sr.ftitle1_desc = resources.studentAmbassadors.subSectionContent[0].description;
            sr.pic = resources.studentAmbassadors.ambassadorsImageSource;
            sr.ftitle2 = resources.studentAmbassadors.subSectionContent[1].title;
            sr.ftitle2_desc = resources.studentAmbassadors.subSectionContent[1].description;
            sr.ftitle3 = resources.studentAmbassadors.subSectionContent[2].title;
            sr.ftitle3_desc = resources.studentAmbassadors.subSectionContent[2].description;
            sr.ftitle4 = resources.studentAmbassadors.subSectionContent[3].title;
            sr.ftitle4_desc = resources.studentAmbassadors.subSectionContent[3].description;
            sr.ftitle5 = resources.studentAmbassadors.subSectionContent[4].title;
            sr.ftitle5_desc = resources.studentAmbassadors.subSectionContent[4].description;
            sr.ftitle6 = resources.studentAmbassadors.subSectionContent[5].title;
            sr.ftitle6_desc = resources.studentAmbassadors.subSectionContent[5].description + "\n" + "\n" + "Interested students are encouraged to apply via our Google Forms.: " + resources.studentAmbassadors.applicationFormLink + "\n" + "\n" + "NOTE: " + resources.studentAmbassadors.note;

            sr.Show();
        }
    }

}
