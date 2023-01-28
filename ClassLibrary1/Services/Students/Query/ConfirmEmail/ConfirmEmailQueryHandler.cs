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
    public class ConfirmEmailQueryHandler : IRequestHandler<ConfirmEmailQuery, APIResponse>
    {
        private readonly UserManager<Students> userManager;
        private readonly IUnitOfWork uow;

        public ConfirmEmailQueryHandler(UserManager<Students> userManager, IUnitOfWork uow)
        {
            this.userManager = userManager;
            this.uow = uow;
        }

        public async Task<APIResponse> Handle(ConfirmEmailQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.token == null)
                {
                    return  new APIResponse
                    {
                        IsError = true,
                        Code = 400,
                        Message = "الرمز غير صحيح"
                    };
                }
                var user = await uow.Students.GetByIdAsync(x => x.EmailVerifyToken == request.token);
                if (user == null)
                {
                    return new APIResponse
                    {
                        IsError = false,
                        Code = 404,
                        Message = "الرمز غير صحيح او غير صالح"
                    };
                }

                user.EmailConfirmed = true;
                //Create EmailVerifyToken
                user.EmailVerifyToken = "";
                await uow.Students.UpdateAsync(user);
                uow.Save();

                return new APIResponse
                {
                    IsError = false,
                    Code = 200,
                    Message = "تم تأكيد البريد الالكتروني بنجاح"
                };
            }
            catch (Exception ex)
            {
                return new APIResponse
                {
                    IsError = true,
                    Message = ex.Message
                };
            }
        }
    }
}
