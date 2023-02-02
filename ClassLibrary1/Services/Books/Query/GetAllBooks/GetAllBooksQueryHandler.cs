using AutoMapper;
using AutoMapper.Execution;
using BLL.Specifications;
using CORE.DAL;
using CORE.DTO;
using CORE.DTO.Authors;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, APIResponse>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public GetAllBooksQueryHandler(IUnitOfWork _uow, IMapper mapper, IMemoryCache cache)
        {
            uow = _uow;
            _mapper = mapper;
            _cache = cache;
        }
        public async Task<APIResponse> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            try
            {
                string Key = $"member - allBookAll"; 
                var Result = await _cache.GetOrCreateAsync(Key, entry => {
                    entry.SetAbsoluteExpiration(
                        TimeSpan.FromMinutes(2));
                    return this.GetAll(request);
                });
                return new APIResponse
                {
                    IsError = true,
                    Code = 200,
                    Message = "",
                    Data = Result
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
        public async Task<List<BooksOutput>> GetAll(GetAllBooksQuery request)
        {
            BookSpecification<Books> Author = new BookSpecification<Books>(null, null,x=>x.Point);

            var allPosts = await uow.Books.GetAllAsync(Author);
            return _mapper.Map<List<BooksOutput>>(allPosts);
        }
    }
}
