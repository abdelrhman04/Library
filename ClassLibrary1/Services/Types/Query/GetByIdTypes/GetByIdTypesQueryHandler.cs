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
    public class GetByIdTypesQueryHandler : IRequestHandler<GetByIdTypesQuery, TypesOutput>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public GetByIdTypesQueryHandler(IUnitOfWork uow, IMapper mapper, IMemoryCache cache)
        {
            _uow = uow;
            _mapper = mapper;
            _cache = cache;
        }
        public async Task<TypesOutput> Handle(GetByIdTypesQuery request, CancellationToken cancellationToken)
        {

            string Key = $"member-Type{request.Id}";
            return await _cache.GetOrCreateAsync(Key, entry => {
                entry.SetAbsoluteExpiration(
                    TimeSpan.FromMinutes(2));
                return this.GetID(request);
            });
            //
        }
        public async Task<TypesOutput> GetID(GetByIdTypesQuery request)
        {
            TypeSpecification Author = new TypeSpecification(request.Id);

            var allPosts = await _uow.Types.GetByIdAsync(Author);
            return _mapper.Map<TypesOutput>(allPosts);
        }
    }
}
