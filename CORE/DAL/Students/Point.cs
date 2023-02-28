using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DAL
{
    public class Point : BaseEntity
    {
        public string Region { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public object Output()
        {
            throw new NotImplementedException();
        }
    }
}
