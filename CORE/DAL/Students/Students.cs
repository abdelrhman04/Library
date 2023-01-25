﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CORE.DAL
{
    public class Students:IdentityUser
    {
        public Students()
        {
           // BirthDate= DateTime.Now;
        }
        public string Name { get; set; }
        public string SurName { get; set; }
        public Gender gender { get; set; }
        public DateTime BirthDate { get;  set; }
        public Class Class { get; set; }
        public Point Point { get; set; }
        public ICollection<Brorows> Brorows { get; set; }


    }
}