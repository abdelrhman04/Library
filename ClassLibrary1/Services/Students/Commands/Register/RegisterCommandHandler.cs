using AutoMapper;
using CORE.DAL;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, APIResponse>
    {
        private readonly UserManager<Students> userManager;
        private readonly IMapper mapper;
        private readonly IMemoryCache _cache;
        IEmailService emailService;
        public RegisterCommandHandler(UserManager<Students> userManager, IEmailService _emailService, IMapper _mapper, IMemoryCache cache)
        {
            this.userManager = userManager;
            mapper = _mapper;
            _cache = cache;
            emailService = _emailService;
        }

        public async Task<APIResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                string Key = $"member-StudentAll";
                var userExists = await userManager.FindByEmailAsync(request.Email);
                if (userExists != null)
                    return new APIResponse
                    {
                        IsError = true,
                        Message = "هذا المستخدم موجود بالفعل",
                        Data = StatusCodes.Status500InternalServerError
                    };
                var token = Guid.NewGuid().ToString();
                Point point = new Point
                {
                    Region= request.point.Region,
                    City= request.point.City,
                    Country= request.point.Country,
                };
                Students user =new Students
                {
                    Name = request.Name,
                    SurName=request.SurName,
                    UserName=request.Username,
                    Email= request.Email,
                    gender = request.gender,
                    Class= request.Class,
                    BirthDate= request.BirthDate,
                    point= point,
                    EmailVerifyToken= token
                };
                var result = await userManager.CreateAsync(user, request.Password);
                if (!result.Succeeded)
                    return new APIResponse
                    {
                        IsError = true,
                        Message = "لم يتم إنشاء مستخدم الرجاء التحقق من البيانات و المحاولة مجدداً",
                        Data = StatusCodes.Status500InternalServerError
                    };
                _cache.Remove(Key);
                string confirmationLink = "https://app.mohandisy.com/api/Account/ConfirmEmail?token=" + token;
                var response = await emailService.
                    SendDynamicTemplateConfirmationEmail(user.Email, confirmationLink);
                return new APIResponse
                {
                    IsError = false,
                    Message = "تم إنشاء المستخدم الرجاء تسجيل الدخول",
                    Data = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new APIResponse
                {
                    IsError = true,
                    Message = ex.Message,
                    Data = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}
