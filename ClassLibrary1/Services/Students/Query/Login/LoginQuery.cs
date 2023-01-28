using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class LoginQuery : IRequest<APIResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
