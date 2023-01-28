using CORE.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UpdateStudentsCommand : IRequest<APIResponse>
    {
        public StudentsInput Students { get; set; }
    }
}
