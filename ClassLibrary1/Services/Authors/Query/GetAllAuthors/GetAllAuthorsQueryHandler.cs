using AutoMapper;
using BLL.Specifications;
using CORE.DAL;
using CORE.DTO.Authors;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Hosting;
using System.Collections.ObjectModel;

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
        public async Task<IEnumerable<Object>> GetAll(GetAllAuthorsQuery request)
        {
            return (await uow.Authors.GetAllAsync(new AuthorSpecification<Authors>(null, x => x.SurName, x => x.Books))).Select(x=>x.Output());
                
                
             
            
            //return _mapper.Map<IEnumerable<AuthorOutput>>((await uow.Authors.GetAllAsync(new AuthorSpecification<Authors>(null, x => x.SurName, x => x.Books))));
                
        }
    }
}
