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
using System.Xml.Linq;

namespace BLL.Services
{
    public class UpdateStudentsCommandHandler : IRequestHandler<UpdateStudentsCommand, APIResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IMemoryCache _cache;
        public UpdateStudentsCommandHandler(IUnitOfWork _unitOfWork, IMapper _mapper, IMemoryCache cache)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
            _cache = cache;
        }

        public async Task<APIResponse> Handle(UpdateStudentsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                string Key = $"member-StudentAll";
                string Key2 = $"member-Student-{request.Students.Id}";
                Students student = await unitOfWork.Students.GetByIdAsync(x=>x.Id== request.Students.Id&& x.UserName== request.Students.Username);
                if (student != null) {
                    return new APIResponse
                    {
                        IsError = true,
                        Code = 400,
                        Message = "Uswename Using by Anthor Student",
                        Data = null,
                    };
                }
                Students student_Update = await unitOfWork.Students.GetByIdAsync(x => x.Id == request.Students.Id );
                

                student_Update.UserName = request.Students.Username;
                student_Update.Email = request.Students.Email;
                student_Update.Name = request.Students.Name;
                student_Update.SurName = request.Students.SurName;
                student_Update.gender = request.Students.gender;
                student_Update.BirthDate = request.Students.BirthDate;
                student_Update.Class = request.Students.Class;
                student_Update.point = request.Students.point;
                //student_Update.point.Region = request.Students.point.Region;
                //student_Update.point.City= request.Students.point.City;
                //student_Update.point.Country = request.Students.point.Country;
                student_Update = await unitOfWork.Students.UpdateAsync_Return(student_Update);
                _cache.Remove(Key2);
                _cache.Remove(Key);
                return new APIResponse
                {
                    IsError = true,
                    Code = 200,
                    Message = "",
                    Data = mapper.Map<StudentsOutput>(student_Update) ,
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
