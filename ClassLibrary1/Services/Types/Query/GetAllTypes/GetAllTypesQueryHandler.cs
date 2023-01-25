using AutoMapper;
using BLL.Specifications;
using CORE.DTO;
using CORE.DTO.Authors;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
   public class GetAllTypesQueryHandler : IRequestHandler<GetAllTypesQuery, APIResponse>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public GetAllTypesQueryHandler(IUnitOfWork _uow, IMapper mapper, IMemoryCache cache)
        {
            uow = _uow;
            _mapper = mapper;
            _cache = cache;
        }
        public async Task<APIResponse> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                string Key = $"member-allTypesAll";
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
        public async Task<List<TypesOutput>> GetAll(GetAllTypesQuery request)
        {
            TypeSpecification Types = new TypeSpecification();

            var allTypes = await uow.Types.GetAllAsync(Types);
            return _mapper.Map<List<TypesOutput>>(allTypes);
        }
    }
}
