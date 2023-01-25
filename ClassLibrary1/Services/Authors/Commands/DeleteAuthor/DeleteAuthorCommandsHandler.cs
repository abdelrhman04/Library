using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DeleteAuthorCommandsHandler : IRequestHandler<DeleteAuthorCommands, APIResponse>
    {
        private readonly IUnitOfWork uow;
        private readonly IMemoryCache _cache;
        public DeleteAuthorCommandsHandler(IUnitOfWork _uow, IMemoryCache cache)
        {
            uow = _uow;
            _cache = cache;
        }
        public async Task<APIResponse> Handle(DeleteAuthorCommands request, CancellationToken cancellationToken)
        {
            try {
                string Key = $"member-AuthorAll";
                var DeleteItem = await uow.Authors.GetByIdAsync(x => x.Id == request.Id);
                if (DeleteItem == null)
                {
                    return new APIResponse
                    {
                        IsError = false,
                        Code = 404,
                        Message = "Element Not Found"
                    };
                }
                await uow.Authors.DeleteAsync(DeleteItem);
                _cache.Remove(Key);
                return new APIResponse
                {
                    IsError= true,
                    Code=200,
                    Message="Element Deleted"
                };
            }
            catch(Exception ex)
            {
              return new APIResponse
              {
                IsError = true,
                Message = ex.Message,
              };
            }
         }
    }
    
    
}
