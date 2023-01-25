using CORE.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Specifications
{
    public class BookSpecification : BaseSpecification<Books>
    {
        public BookSpecification() : base()
        {

        }
        public BookSpecification(int id) : base(x => x.Id == id)
        {

        }
    }
}
