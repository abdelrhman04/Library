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
    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, APIResponse>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public GetAllStudentsQueryHandler(IUnitOfWork _uow, IMapper mapper, IMemoryCache cache)
        {
            uow = _uow;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<APIResponse> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                string Key = $"member-StudentAll";
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
        public async Task<List<StudentsOutput>> GetAll(GetAllStudentsQuery request)
        {
            StudentSpecification Author = new StudentSpecification();

            var allPosts = await uow.Students.GetAllAsync(Author);
            return _mapper.Map<List<StudentsOutput>>(allPosts);
        }
    }
}
