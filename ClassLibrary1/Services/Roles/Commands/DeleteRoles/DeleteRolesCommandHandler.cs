using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DeleteRolesCommandHandler : IRequestHandler<DeleteRolesCommand, APIResponse>
    {
        private readonly IUnitOfWork uow;
        private readonly IMemoryCache _cache;
        public DeleteRolesCommandHandler(IUnitOfWork _uow, IMemoryCache cache)
        {
            uow = _uow;
            _cache = cache;
        }
        public async Task<APIResponse> Handle(DeleteRolesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                string Key = $"member-RoleAll";
                var DeleteItem = await uow.IdentityRole.GetByIdAsync(x => x.Id == request.Id);
                if (DeleteItem == null)
                {
                    return new APIResponse
                    {
                        IsError = false,
                        Code = 404,
                        Message = "Element Not Found"
                    };
                }
                await uow.IdentityRole.DeleteAsync(DeleteItem);
                _cache.Remove(Key);
                return new APIResponse
                {
                    IsError = true,
                    Code = 200,
                    Message = "Element Deleted"
                };
            }
            catch (Exception ex)
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
