using AutoMapper;
using BLL.Specifications;
using CORE.DAL;
using CORE.DTO;
using CORE.DTO.Authors;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class GetByIdBooksQueryHandler : IRequestHandler<GetByIdBooksQuery, APIResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public GetByIdBooksQueryHandler(IUnitOfWork uow, IMapper mapper, IMemoryCache cache)
        {
            _uow = uow;
            _mapper = mapper;
            _cache = cache;
        }
        public async Task<APIResponse> Handle(GetByIdBooksQuery request, CancellationToken cancellationToken)
        {
            try
            {
                string Key = $"member-Book{request.Id}";
                var Result = await _cache.GetOrCreateAsync(Key, entry => {
                    entry.SetAbsoluteExpiration(
                        TimeSpan.FromMinutes(2));
                    return this.GetID(request);
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
            //
        }
        public async Task<BooksOutput> GetID(GetByIdBooksQuery request)
        {
            BookSpecification<Books> Author = new BookSpecification<Books>(request.Id);

            var allPosts = await _uow.Books.GetByIdAsync(Author);
            return _mapper.Map<BooksOutput>(allPosts);
        }
    }
}
