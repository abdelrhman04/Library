using CORE.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UpdateBrorowsCommand : IRequest<APIResponse>
    {
        [Required]
        public int Id { get; set; } = 0;
        [Required]
        public string StudentId { get; set; }
        [Required]
        public DateTime TakenDate { get; set; }
        [Required]
        public DateTime BroughDate { get; set; }
    }
}
