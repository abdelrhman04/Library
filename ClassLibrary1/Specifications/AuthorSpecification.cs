using CORE.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Specifications
{
    public class AuthorSpecification : BaseSpecification<Authors>
    {
        public AuthorSpecification() : base()
        {

        }
        public AuthorSpecification(int id) : base(x => x.Id == id)
        {

        }
    }
}
