using AutoMapper;
using BLL.Specifications;
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
    public class GetByIdBrorowsQueryHandler : IRequestHandler<GetByIdBrorowsQuery, APIResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public GetByIdBrorowsQueryHandler(IUnitOfWork uow, IMapper mapper, IMemoryCache cache)
        {
            _uow = uow;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<APIResponse> Handle(GetByIdBrorowsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                string Key = $"member-Brorows-{request.Id}";
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
        }
        public async Task<BrorowsOutput> GetID(GetByIdBrorowsQuery request)
        {
            BrorowSpecification Author = new BrorowSpecification(request.Id);

            var allPosts = await _uow.Brorows.GetByIdAsync(Author);
            return _mapper.Map<BrorowsOutput>(allPosts);
        }
    }
}
