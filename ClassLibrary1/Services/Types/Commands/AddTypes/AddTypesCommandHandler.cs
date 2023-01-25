using AutoMapper;
using CORE.DAL;
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
    public class AddTypesCommandHandler : IRequestHandler<AddTypesCommand, TypesOutput>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IMemoryCache _cache;
        public AddTypesCommandHandler(IUnitOfWork _unitOfWork, IMapper _mapper, IMemoryCache cache)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
            _cache = cache;
        }
        public async Task<TypesOutput> Handle(AddTypesCommand request, CancellationToken cancellationToken)
        {
            string Key = $"member-allTypesAll";
            
            Types post = mapper.Map<Types>(request.Type);
            post = await unitOfWork.Types.AddAsync(post);
            _cache.Remove(Key);
            return mapper.Map<TypesOutput>(post);
        }
    }
}
