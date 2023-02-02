using AutoMapper;
using CORE.DAL;
using CORE.DTO;
using CORE.DTO.Authors;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UpdateRolesCommandHandler : IRequestHandler<UpdateRolesCommand, APIResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IMemoryCache _cache;
        public UpdateRolesCommandHandler(IUnitOfWork _unitOfWork, IMapper _mapper, IMemoryCache cache)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
            _cache = cache;
        }
        public async Task<APIResponse> Handle(UpdateRolesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                string Key = $"member-RoleAll";
                string Key2 = $"member-Role{request.Id}";
                IdentityRole post = await unitOfWork.IdentityRole.GetByIdAsync(x=>x.Id== request.Id);
                post.Name = request.Name;
                post = await unitOfWork.IdentityRole.UpdateAsync_Return(post);
                _cache.Remove(Key2);
                _cache.Remove(Key);
                return new APIResponse
                {
                    IsError = true,
                    Code = 200,
                    Message = "",
                    Data = mapper.Map<RolesOutput>(post),
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
    }
}
