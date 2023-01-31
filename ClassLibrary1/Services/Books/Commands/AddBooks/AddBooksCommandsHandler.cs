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
using static System.Net.Mime.MediaTypeNames;

namespace BLL.Services
{
    public class AddBooksCommandsHandler : IRequestHandler<AddBooksCommand, APIResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IMemoryCache _cache;

        public AddBooksCommandsHandler(IUnitOfWork _unitOfWork, IMapper _mapper, IMemoryCache cache)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
            _cache = cache;
        }
        public async Task<APIResponse> Handle(AddBooksCommand request, CancellationToken cancellationToken)
        {
            try
            {
                string Key = $"member - allBookAll";
                Books post = mapper.Map<Books>(request.Book);
                post.Image = Upload(request.Book.Image_file);
                post = await unitOfWork.Books.AddAsync(post);
                _cache.Remove(Key);
                return new APIResponse
                {
                    IsError = false,
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
        string Upload(IFormFile file,  string path = null)
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
                    file.CopyTo(fs);
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
