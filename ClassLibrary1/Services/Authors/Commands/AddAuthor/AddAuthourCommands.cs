using CORE.DTO;
using CORE.DTO.Authors;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AddAuthourCommands: IRequest<APIResponse>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string SurName { get; set; }
    }
}
