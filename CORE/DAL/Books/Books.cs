﻿using CORE.Constants;
using CORE.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DAL
{
    public partial class Books :BaseEntity
    {
        public string Name { get; set; }
        public int PageCount { get; set; }
        public string Image { get; set; }
        public Point Point { get; set; }
        
        
        public int? authorid { get; set; }
        public int typeid { get; set; }
        public Authors Author { get; set; }
        public Types Type { get; set; }
        public ICollection<Brorows> Brorows { get; set; }
        public  BooksOutput Output()
        {
            return new BooksOutput {
            Name= this.Name,
            PageCount= this.PageCount,
            Image= this.Image,
            Point= this.Point,
            authorid= this.authorid,
            typeid= this.typeid,
            };
        }
    }
}
