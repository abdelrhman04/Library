using CORE.DAL;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DTO
{
    public class BooksInput
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int PageCount { get; set; }
        [Required]
        public IFormFile Image_file { get; set; }
        [Required]
        public Point Point { get; set; }
        [Required]
        public int? authorid { get; set; }
        [Required]
        public int typeid { get; set; }
    }
}
