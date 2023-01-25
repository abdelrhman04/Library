using CORE.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DTO
{
    public class StudentsInput
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string SurName { get; set; }
        [Required]
        public Gender gender { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public Class Class { get; set; }
    }
}
