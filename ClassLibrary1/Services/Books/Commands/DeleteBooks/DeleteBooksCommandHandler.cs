using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DeleteBooksCommandHandler : IRequestHandler<DeleteBooksCommand, APIResponse>
    {
        private readonly IUnitOfWork uow;
        private readonly IMemoryCache _cache;
        public DeleteBooksCommandHandler(IUnitOfWork _uow, IMemoryCache cache)
        {
            uow = _uow;
            _cache = cache;
        }
        public async Task<APIResponse> Handle(DeleteBooksCommand request, CancellationToken cancellationToken)
        {
            try
            {
                string Key = $"member - allBookAll"; 
                var DeleteItem = await uow.Books.GetByIdAsync(x => x.Id == request.Id);

                if (DeleteItem == null)
                {
                    return new APIResponse
                    {
                        IsError = false,
                        Code = 404,
                        Message = "Element Not Found"
                    };
                }
                Upload(DeleteItem.Image);
                await uow.Books.DeleteAsync(DeleteItem);
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
        void Upload( string path)
        {
            try
            {
                    string BinaryPath = Guid.NewGuid().ToString() + path;
                    FileInfo delete = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(),
                      "wwwroot", "Image", path));
                    delete.Delete();
            }
            catch (Exception ex)
            {
                throw;
                // StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
