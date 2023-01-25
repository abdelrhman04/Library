using CORE.DTO.Authors;
using CORE.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UpdateAuthorCommands : IRequest<AuthorOutput>
    {
        public AuthorInput Author { get; set; }
    }
}
