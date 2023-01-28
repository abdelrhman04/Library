using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DTO
{
    public class RolesInput
    {
        public string? Id { get; set; }
        [Required]
       public string Name { get; set; }
    }
}
