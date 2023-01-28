using CORE.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UpdateRolesCommand : IRequest<APIResponse>
    {
        public RolesInput Role { get; set; }
    }
}
