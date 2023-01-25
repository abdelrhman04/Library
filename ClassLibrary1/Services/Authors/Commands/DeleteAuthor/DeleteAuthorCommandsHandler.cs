using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DeleteAuthorCommandsHandler : IRequestHandler<DeleteAuthorCommands>
    {
        private readonly IUnitOfWork uow;
        public DeleteAuthorCommandsHandler(IUnitOfWork _uow)
        {
            uow = _uow;
        }
        public async Task<Unit> Handle(DeleteAuthorCommands request, CancellationToken cancellationToken)
        {
            var DeleteItem = await uow.Authors.GetByIdAsync(x => x.Id == request.Id);
            await uow.Authors.DeleteAsync(DeleteItem);
            return Unit.Value;
        }
    }
    
    
}
