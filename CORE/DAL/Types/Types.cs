using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DAL
{
    public class Types:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Books> Books { get; set; }
        public object Output()
        {
            throw new NotImplementedException();
        }
    }
}
