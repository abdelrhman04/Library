using BLL.Services;
using BLL;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using CORE.DTO;

namespace Library_CQRS_S_C_U_M_DesignPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete("DeleteStudnt", Name = "DeleteStudnt")]
        public async Task<ActionResult<APIResponse>> StudntDelete(string Id)
        {
            var dtos = await _mediator.Send(new DeleteStudentsCommand() { Id = Id });
            return Ok(dtos);
        }


        [HttpPost("RegistrerStudnt", Name = "RegistrerStudnt")]
        public async Task<ActionResult<APIResponse>> Registrer(StudentsInput student)
        {
            var dtos = await _mediator.Send(new RegisterCommand() { Students = student });
            return Ok(dtos);
        }
        [HttpPost("UpdateStudnt", Name = "UpdateStudnt")]
        public async Task<ActionResult<APIResponse>> Update(StudentsInput student)
        {
            var dtos = await _mediator.Send(new UpdateStudentsCommand() { Students = student });
            return Ok(dtos);
        }
        [HttpPost("ChangePassword", Name = "ChangePassword")]
        public async Task<ActionResult<APIResponse>> ChangePassword(ChangePasswordCommand student)
        {
            var dtos = await _mediator.Send(student);
            return Ok(dtos);
        }

        [HttpGet("GetAllStudnt", Name = "GetAllStudnt")]
        public async Task<ActionResult<APIResponse>> GetAll()
        {
            var dtos = await _mediator.Send(new GetAllStudentsQuery());
            return Ok(dtos);
        }
        [HttpGet("GetStudnt", Name = "GetStudnt")]
        public async Task<ActionResult<APIResponse>> Get(string id)
        {
            var dtos = await _mediator.Send(new GetByIdStudentsQuery() { Id = id });
            return Ok(dtos);
        }
        [HttpPost("Login", Name = "Login")]
        public async Task<ActionResult<APIResponse>> Login(string Email,string password)
        {
            var dtos = await _mediator.Send(new LoginQuery() { Email=Email,Password=password});
            return Ok(dtos);
        }
        [HttpGet("LogOut", Name = "LogOut")]
        public async Task<ActionResult<APIResponse>> LogOut()
        {
            var dtos = await _mediator.Send(new LogoutQuery());
            return Ok(dtos);
        }
        [HttpPost("ConfirmEmail", Name = "ConfirmEmail")]
        public async Task<ActionResult<APIResponse>> ConfirmEmail( string token,string id)
        {
            var dtos = await _mediator.Send(new ConfirmEmailQuery() { token=token,
                                                                                Id=id});
            return Ok(dtos);
        }
        [HttpPost("ResetPassword", Name = "ResetPassword")]
        public async Task<ActionResult<APIResponse>> ResetPassword(string token, string id)
        {
            var dtos = await _mediator.Send(new ResetPasswordQuery()
            {
                token = token,
                Id = id
            });
            return Ok(dtos);
        }
    }
}
