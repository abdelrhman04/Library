using AutoMapper;
using BLL.Specifications;
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
    public class GetByIdAuthorsQueryHandler : IRequestHandler<GetByIdAuthorsQuery, AuthorOutput>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public GetByIdAuthorsQueryHandler(IUnitOfWork uow, IMapper mapper, IMemoryCache cache)
        {
            _uow = uow;
            _mapper = mapper;
            _cache = cache;
        }
        public async Task<AuthorOutput> Handle(GetByIdAuthorsQuery request, CancellationToken cancellationToken)
        {

            string Key = $"member-{request.Id}";
            return await _cache.GetOrCreateAsync(Key, entry => {
                entry.SetAbsoluteExpiration(
                    TimeSpan.FromMinutes(2));
                return  this.GetID(request);
            });
            //
        }
        public async Task<AuthorOutput> GetID(GetByIdAuthorsQuery request)
        {
            AuthorSpecification Author = new AuthorSpecification(request.Id);

            var allPosts = await _uow.Authors.GetByIdAsync(Author);
           return _mapper.Map<AuthorOutput>(allPosts);
        }
    }
}
