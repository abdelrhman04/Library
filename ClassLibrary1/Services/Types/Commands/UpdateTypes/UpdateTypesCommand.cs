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
    public class UpdateTypesCommand : IRequest<APIResponse>
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
