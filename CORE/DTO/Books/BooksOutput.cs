using CORE.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DTO
{
    public class BooksOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int PageCount { get; set; }
        public string Image_Path { get; set; }
        public Point Point { get; set; }
        public int? authorid { get; set; }
        public int typeid { get; set; }
    }
}
