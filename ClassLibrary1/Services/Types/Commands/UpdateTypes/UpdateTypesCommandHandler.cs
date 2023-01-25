using AutoMapper;
using CORE.DAL;
using CORE.DTO;
using MediatR;
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

        public UpdateTypesCommandHandler(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }
        public async Task<TypesOutput> Handle(UpdateTypesCommand request, CancellationToken cancellationToken)
        {
            Types post = mapper.Map<Types>(request.Type);
            post = await unitOfWork.Types.UpdateAsync_Return(post);
            return mapper.Map<TypesOutput>(post);
        }
    }
}
