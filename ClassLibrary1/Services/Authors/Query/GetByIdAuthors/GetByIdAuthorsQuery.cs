using CORE.DTO.Authors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class GetByIdAuthorsQuery : IRequest<APIResponse>
    {
        public int Id { get; set; }
    }
}
