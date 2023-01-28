using CORE.DAL;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, APIResponse>
    {
        private readonly UserManager<Students> userManager;
        private readonly SignInManager<Students> SignInManager;
        private readonly IConfiguration _configuration;

        public LoginQueryHandler(UserManager<Students> userManager,
            SignInManager<Students> signInManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            SignInManager = signInManager;
            _configuration = configuration;

        }

        public async Task<APIResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            if (user != null && await userManager.CheckPasswordAsync(user, request.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                     new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddDays(1),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );
                return new APIResponse
                {
                    IsError = false,
                    Message = "تم تسجيل الدخول بنجاح",
                    Data = new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    },
                    Code = 200
                };
            }
            return new APIResponse
            {
                IsError = true,
                Message = "الرجاء التأكد من البيانات",
                Data = null,
                Code = 401
            };
        }
    }
}
