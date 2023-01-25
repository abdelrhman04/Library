using MediatR;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly IMemoryCache _cache;
        public DeleteTypesCommandsHandler(IUnitOfWork uow, IMemoryCache cache)
        {
            this.uow = uow;
            _cache = cache;
        }
        public async Task<Unit> Handle(DeleteTypesCommands request, CancellationToken cancellationToken)
        {
            string Key = $"member-allTypesAll";
            var DeleteItem = await uow.Types.GetByIdAsync(x => x.Id == request.Id);
            await uow.Types.DeleteAsync(DeleteItem);
            _cache.Remove(Key);
            return Unit.Value;
        }
    }
}
