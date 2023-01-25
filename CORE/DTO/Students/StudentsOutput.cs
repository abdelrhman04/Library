using CORE.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DTO
{
    public class StudentsOutput
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public Gender gender { get; set; }
        public DateTime BirthDate { get; set; }
        public Class Class { get; set; }
    }
}
