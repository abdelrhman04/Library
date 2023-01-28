using CORE.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Specifications
{
    public class StudentSpecification : BaseSpecification<Students>
    {
        public StudentSpecification() : base()
        {

        }
        public StudentSpecification(string id) : base(x => x.Id == id)
        {

        }
    }
}
