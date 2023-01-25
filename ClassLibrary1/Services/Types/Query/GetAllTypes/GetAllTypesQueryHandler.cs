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
   public class GetAllTypesQueryHandler : IRequestHandler<GetAllTypesQuery, List<TypesOutput>>
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
        public async Task<List<TypesOutput>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
        {
            string Key = $"member-allTypesAll";
            return await _cache.GetOrCreateAsync(Key, entry => {
                entry.SetAbsoluteExpiration(
                    TimeSpan.FromMinutes(2));
                return this.GetAll(request);
            });
        }
        public async Task<List<TypesOutput>> GetAll(GetAllTypesQuery request)
        {
            TypeSpecification Types = new TypeSpecification();

            var allTypes = await uow.Types.GetAllAsync(Types);
            return _mapper.Map<List<TypesOutput>>(allTypes);
        }
    }
}
