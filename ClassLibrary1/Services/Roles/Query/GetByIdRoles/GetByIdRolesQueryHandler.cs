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
    public class GetByIdRolesQueryHandler : IRequestHandler<GetByIdRolesQuery, APIResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public GetByIdRolesQueryHandler(IUnitOfWork uow, IMapper mapper, IMemoryCache cache)
        {
            _uow = uow;
            _mapper = mapper;
            _cache = cache;
        }
        public async Task<APIResponse> Handle(GetByIdRolesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                string Key = $"member-Role{request.Id}";
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
        public async Task<RolesOutput> GetID(GetByIdRolesQuery request)
        {
            RoleSpecification Author = new RoleSpecification(request.Id);

            var allPosts = await _uow.IdentityRole.GetByIdAsync(Author);
            return _mapper.Map<RolesOutput>(allPosts);
        }
    }
}
