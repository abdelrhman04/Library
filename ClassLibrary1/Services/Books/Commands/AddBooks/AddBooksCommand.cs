using CORE.DAL;
using CORE.DTO;
using CORE.DTO.Authors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AddBooksCommand : IRequest<BooksOutput>
    {
        public BooksInput Book { get; set; }
    }
}
