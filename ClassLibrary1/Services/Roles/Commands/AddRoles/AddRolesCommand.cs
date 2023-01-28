using CORE.DTO;
using MediatR;

namespace BLL.Services
{
    public class AddRolesCommand : IRequest<APIResponse>
    {
        public RolesInput Role { get; set; }
    }
}
