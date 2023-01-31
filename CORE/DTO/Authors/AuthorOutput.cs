using CORE.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DTO.Authors
{
    public class AuthorOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public ICollection<BooksOutput> Books { get; set; }
    }
}
