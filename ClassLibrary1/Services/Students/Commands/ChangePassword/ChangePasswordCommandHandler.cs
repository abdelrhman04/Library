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
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, APIResponse>
    {
        private readonly UserManager<Students> userManager;
        private readonly IUnitOfWork uow;

        public ChangePasswordCommandHandler(UserManager<Students> userManager, IUnitOfWork uow)
        {
            this.userManager = userManager;
            this.uow = uow;
        }

        public async Task<APIResponse> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            try
            {  

                var Student = await uow.Students.GetByIdAsync(x => x.Id == request.Id);
                if (Student == null)
                {
                    return new APIResponse
                    {
                        IsError = false,
                        Code = 404,
                        Message = "Element Not Found"
                    };
                }
                var result = await userManager.ChangePasswordAsync(Student, request.CurrentPassword, request.NewPassword);
                if (result.Succeeded) {
                    return new APIResponse
                    {
                        IsError = false,
                        Code = 200,
                        Message = "Password Changed"
                    };
                }
                else
                {
                    return new APIResponse
                    {
                        IsError = true,
                        Code = 404,
                        Message = "Password Not Changed"
                    };
                }
                
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
