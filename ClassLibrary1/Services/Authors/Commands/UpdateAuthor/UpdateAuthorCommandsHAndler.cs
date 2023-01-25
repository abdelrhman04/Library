using AutoMapper;
using CORE.DAL;
using CORE.DTO.Authors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UpdateAuthorCommandsHAndler : IRequestHandler<UpdateAuthorCommands, AuthorOutput>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateAuthorCommandsHAndler(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }
        public async Task<AuthorOutput> Handle(UpdateAuthorCommands request, CancellationToken cancellationToken)
        {

            Authors post = mapper.Map<Authors>(request.Author);
            post = await unitOfWork.Authors.UpdateAsync_Return(post);
            return mapper.Map<AuthorOutput>(post);

        }
    }
}
