using CORE.DTO;
using CORE.DTO.Authors;
using CORE.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DAL
{
    public class Authors : BaseEntity
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public ICollection<Books> Books { get; set; }

        public  AuthorOutput Output()
        {
            return new AuthorOutput
            {
                Name = this.Name,
                SurName = this.SurName,
                Books = this.Books.Select(x => x.Output()),
            };
        }
    }
}
