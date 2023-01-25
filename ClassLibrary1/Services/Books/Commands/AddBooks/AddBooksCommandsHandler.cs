using AutoMapper;
using CORE.DAL;
using CORE.DTO;
using CORE.DTO.Authors;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AddBooksCommandsHandler : IRequestHandler<AddBooksCommand, BooksOutput>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AddBooksCommandsHandler(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }
        public async Task<BooksOutput> Handle(AddBooksCommand request, CancellationToken cancellationToken)
        {

            Books post = mapper.Map<Books>(request.Book);
            post.Image = Upload(request.Book.Image_file);
            post = await unitOfWork.Books.AddAsync(post);
            return mapper.Map<BooksOutput>(post);

        }
        string Upload(IFormFile file,  string path = null)
        {
            try
            {

               var folderName = Path.Combine("wwwroot", "Image");

                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = Guid.NewGuid() + ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    //check if the file is already exists delete it
                    if (!string.IsNullOrEmpty(path))
                    {
                        if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), path)))
                            File.Delete(Path.Combine(Directory.GetCurrentDirectory(), path));
                    }
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return fileName;
                }
                else
                {
                    return "error";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
                // StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
