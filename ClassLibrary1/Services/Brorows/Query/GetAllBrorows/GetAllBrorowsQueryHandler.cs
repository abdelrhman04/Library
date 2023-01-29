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
    public class GetAllBrorowsQueryHandler : IRequestHandler<GetAllBrorowsQuery, APIResponse>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public GetAllBrorowsQueryHandler(IUnitOfWork _uow, IMapper mapper, IMemoryCache cache)
        {
            uow = _uow;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<APIResponse> Handle(GetAllBrorowsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                string Key = $"member-BrorowsAll";
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
        public async Task<List<BrorowsOutput>> GetAll(GetAllBrorowsQuery request)
        {
            BrorowSpecification Author = new BrorowSpecification();

            var allPosts = await uow.Brorows.GetAllAsync(Author);
            return _mapper.Map<List<BrorowsOutput>>(allPosts);
        }
    }
}
