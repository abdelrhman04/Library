using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DeleteTypesCommandsHandler : IRequestHandler<DeleteTypesCommands>
    {
        private readonly IUnitOfWork uow;

        public DeleteTypesCommandsHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public async Task<Unit> Handle(DeleteTypesCommands request, CancellationToken cancellationToken)
        {
            var DeleteItem = await uow.Types.GetByIdAsync(x => x.Id == request.Id);
            await uow.Types.DeleteAsync(DeleteItem);
            return Unit.Value;
        }
    }
}
