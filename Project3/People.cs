﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3
{

    public class Faculty
    {
        public string username { get; set; }
        public string name { get; set; }
        public string tagline { get; set; }
        public string imagePath { get; set; }
        public string title { get; set; }
        public string interestArea { get; set; }
        public string office { get; set; }
        public string website { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string twitter { get; set; }
        public string facebook { get; set; }
    }

    public class Staff
    {
        public string username { get; set; }
        public string name { get; set; }
        public string tagline { get; set; }
        public string imagePath { get; set; }
        public string title { get; set; }
        public string interestArea { get; set; }
        public string office { get; set; }
        public string website { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string twitter { get; set; }
        public string facebook { get; set; }
    }

    public class People
    {
        public string title { get; set; }
        public string subTitle { get; set; }
        public List<Faculty> faculty { get; set; }
        public List<Staff> staff { get; set; }
    }

}
