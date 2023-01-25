using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DAL
{
    public class Brorows :BaseEntity
    {
        public string StudentId { get; set; }
        public DateTime TakenDate { get; set; }
        public DateTime BroughDate { get; set; }
        public Books Book { get; set; }
        public Students Student { get; set; }
    }
}
