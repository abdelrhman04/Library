using CORE.DTO;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BLL.Services
{
    public class AddRolesCommand : IRequest<APIResponse>
    {
        [Required]
        public string Name { get; set; }
    }
}
