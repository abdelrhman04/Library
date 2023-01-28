using CORE.DAL;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class LogoutQueryHandler : IRequestHandler<LogoutQuery, APIResponse>
    {
        private readonly SignInManager<Students> SignInManager;

        public LogoutQueryHandler(SignInManager<Students> signInManager)
        {
            SignInManager = signInManager;
        }

        public async Task<APIResponse> Handle(LogoutQuery request, CancellationToken cancellationToken)
        {
            await SignInManager.SignOutAsync();
            return new APIResponse
            {
                IsError = false,
                Message = " ",
                Data = null,
                Code = 200
            };
        }
    }
}
