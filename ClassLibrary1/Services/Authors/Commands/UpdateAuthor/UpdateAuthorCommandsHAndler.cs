using AutoMapper;
using CORE.DAL;
using CORE.DTO.Authors;
using MediatR;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UpdateAuthorCommandsHAndler : IRequestHandler<UpdateAuthorCommands, APIResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IMemoryCache _cache;
        public UpdateAuthorCommandsHAndler(IUnitOfWork _unitOfWork, IMapper _mapper, IMemoryCache cache)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
            _cache = cache;
        }
        public async Task<APIResponse> Handle(UpdateAuthorCommands request, CancellationToken cancellationToken)
        {
            try
            {
                string Key = $"member-{request.Author.Id}";
                Authors post = mapper.Map<Authors>(request.Author);
                post = await unitOfWork.Authors.UpdateAsync_Return(post);
                _cache.Remove(Key);
                return new APIResponse
                {
                    IsError = true,
                    Code = 200,
                    Message = "",
                    Data = mapper.Map<AuthorOutput>(post),
                };
            }
            catch(Exception ex)
            {
              return new APIResponse
              {
                IsError = true,
                Message = ex.Message,
              };
            }
        }
    }
}
