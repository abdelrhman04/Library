using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DTO
{
    public class BrorowsOutput
    {
        public string StudentId { get; set; }
        public DateTime TakenDate { get; set; }
        public DateTime BroughDate { get; set; }
    }
}
