using CORE.DAL;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Specifications
{
    public class RoleSpecification : BaseSpecification<IdentityRole>
    {
        public RoleSpecification() : base()
        {

        }
        public RoleSpecification(string id) : base(x => x.Id == id)
        {

        }
    }
}
