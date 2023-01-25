using CORE.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Specifications
{
    public class TypeSpecification : BaseSpecification<Types>
    {
        public TypeSpecification() : base()
        {

        }
        public TypeSpecification(int id) : base(x => x.Id == id)
        {

        }
    }
}
