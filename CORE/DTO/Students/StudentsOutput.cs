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
        public string? Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public Gender gender { get; set; }
        public DateTime BirthDate { get; set; }
        public Class Class { get; set; }
        public Point point { get; set; }
    }
}
