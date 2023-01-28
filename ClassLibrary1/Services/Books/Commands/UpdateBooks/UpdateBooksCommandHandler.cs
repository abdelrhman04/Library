﻿using AutoMapper;
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
                Books post = mapper.Map<Books>(request.Books);
                post.Image = Upload(request.Books.Image_file, post.Image_Path);
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
        string Upload(IFormFile file, string path = null)
        {
            try
            {

                var folderName = Path.Combine("wwwroot", "Image");

                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName =  ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
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
                throw;
                // StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}