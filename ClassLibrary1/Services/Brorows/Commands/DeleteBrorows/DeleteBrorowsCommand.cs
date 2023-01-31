using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DeleteBrorowsCommand : IRequest<APIResponse>
    {
        public int Id { get; set; }
        public string student_id { get; set; }
    }
}
