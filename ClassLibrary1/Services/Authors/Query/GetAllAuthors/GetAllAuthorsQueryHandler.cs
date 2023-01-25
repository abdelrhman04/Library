using AutoMapper;
using BLL.Specifications;
using CORE.DTO.Authors;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Hosting;

namespace BLL.Services
{
    public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, APIResponse>
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
        public async Task<APIResponse> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                string Key = $"member-AuthorAll";
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
        public async Task<List<AuthorOutput>> GetAll(GetAllAuthorsQuery request)
        {
            AuthorSpecification Author = new AuthorSpecification();

            var allPosts = await uow.Authors.GetAllAsync(Author);
            return _mapper.Map < List<AuthorOutput>>(allPosts);
        }
    }
}
