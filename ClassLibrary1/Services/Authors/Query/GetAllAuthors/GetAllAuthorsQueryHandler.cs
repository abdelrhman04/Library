using AutoMapper;
using BLL.Specifications;
using CORE.DTO.Authors;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace BLL.Services
{
    public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, List<AuthorOutput>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public GetAllAuthorsQueryHandler(IUnitOfWork _uow, IMapper mapper, IMemoryCache cache)
        {
            uow = _uow;
            _mapper = mapper;
            _cache = cache;
        }
        public async Task<List<AuthorOutput>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            string Key = $"member-AuthorAll";
            return await _cache.GetOrCreateAsync(Key, entry => {
                entry.SetAbsoluteExpiration(
                    TimeSpan.FromMinutes(2));
                return this.GetAll(request);
            });
        }
        public async Task<List<AuthorOutput>> GetAll(GetAllAuthorsQuery request)
        {
            AuthorSpecification Author = new AuthorSpecification();

            var allPosts = await uow.Authors.GetAllAsync(Author);
            return _mapper.Map < List<AuthorOutput>>(allPosts);
        }
    }
}
