using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DTO
{
    public class BrorowsInput
    {
        [Required]
        public string StudentId { get; set; }
        [Required]
        public DateTime TakenDate { get; set; }
        [Required]
        public DateTime BroughDate { get; set; }
    }
}
