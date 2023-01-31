using AutoMapper;
using CORE.DAL;
using CORE.DTO;
using CORE.DTO.Authors;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UpdateBooksCommandHandler : IRequestHandler<UpdateBooksCommand, APIResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IMemoryCache _cache;
        public UpdateBooksCommandHandler(IUnitOfWork _unitOfWork, IMapper _mapper, IMemoryCache cache)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
            _cache = cache;
        }
        public async Task<APIResponse> Handle(UpdateBooksCommand request, CancellationToken cancellationToken)
        {
            try
            {
                string Key = $"member - allBookAll";
                string Key2 = $"member-Book{request.Books.Id}";
                var image_name = await unitOfWork.Books.GetByIdAsync(x => x.Id == request.Books.Id);

                Books post = mapper.Map<Books>(request.Books);
                post.Image = Upload(request.Books.Image_file,path: image_name.Image);
                post = await unitOfWork.Books.UpdateAsync_Return(post);
                _cache.Remove(Key);
                _cache.Remove(Key2);
                return new APIResponse
                {
                    IsError = true,
                    Code = 200,
                    Message = "",
                    Data = mapper.Map<BooksOutput>(post),
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
        string Upload(IFormFile file, string path)
        {
            try
            {

                if (file.Length > 0)
                {
                    string BinaryPath = Guid.NewGuid().ToString() + file.FileName;

                    FileStream fs = new FileStream(
                      Path.Combine(Directory.GetCurrentDirectory(),
                      "wwwroot", "Image", BinaryPath)
                      , FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    FileInfo delete = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(),
                      "wwwroot", "Image", path));
                    file.CopyTo(fs);
                    delete.Delete();
                    fs.Position = 0;
                    fs.Close();
                    return BinaryPath;
                }
                else
                {
                    return "error";
                }
            }
            catch (Exception ex)
            {
                throw;
                // StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
