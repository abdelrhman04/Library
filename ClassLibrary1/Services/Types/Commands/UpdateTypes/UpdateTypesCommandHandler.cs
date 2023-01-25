using AutoMapper;
using CORE.DAL;
using CORE.DTO;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UpdateTypesCommandHandler : IRequestHandler<UpdateTypesCommand, TypesOutput>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IMemoryCache _cache;

        public UpdateTypesCommandHandler(IUnitOfWork _unitOfWork, IMapper _mapper, IMemoryCache cache)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
            _cache = cache;
        }
        public async Task<TypesOutput> Handle(UpdateTypesCommand request, CancellationToken cancellationToken)
        {
            string Key = $"member-allTypesAll";
            string Key2 = $"member-Type{request.Type.id}";
            Types post = mapper.Map<Types>(request.Type);
            post = await unitOfWork.Types.UpdateAsync_Return(post);
            _cache.Remove(Key);
            _cache.Remove(Key2);
            return mapper.Map<TypesOutput>(post);
        }
    }
}
