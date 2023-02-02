using CORE.DAL;
using CORE.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RegisterCommand : IRequest<APIResponse>
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string SurName { get; set; }
        [Required]
        public Gender gender { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public Class Class { get; set; }
        public PointInput point { get; set; }
    }
}
