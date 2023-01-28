using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ChangePasswordCommand : IRequest<APIResponse>
    {
        public String Id { get; set; }
        public String CurrentPassword { get; set; }
        public String NewPassword { get; set; }
    }
}
