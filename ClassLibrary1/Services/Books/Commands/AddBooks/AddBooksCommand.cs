using CORE.DAL;
using CORE.DTO;
using CORE.DTO.Authors;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AddBooksCommand : IRequest<APIResponse>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int PageCount { get; set; }
        [Required]
        public IFormFile Image_file { get; set; }
        public PointInput Point { get; set; }
        [Required]
        public int? authorid { get; set; }
        [Required]
        public int typeid { get; set; }
    }
}
