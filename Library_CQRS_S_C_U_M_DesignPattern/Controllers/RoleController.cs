using BLL.Services;
using BLL;
using CORE.DTO;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Library_CQRS_S_C_U_M_DesignPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("AddRoles", Name = "AddRoles")]
        public async Task<ActionResult<APIResponse>> Add(RolesInput Role)
        {
            var dtos = await _mediator.Send(new AddRolesCommand() { Role = Role });
            return Ok(dtos);
        }
        [HttpPost("UpdateRoles", Name = "UpdateRoles")]
        public async Task<ActionResult<APIResponse>> Update(RolesInput Role)
        {
            var dtos = await _mediator.Send(new UpdateRolesCommand() { Role = Role });
            return Ok(dtos);
        }
        [HttpGet("GetAllRoles", Name = "GetAllRoles")]
        public async Task<ActionResult<APIResponse>> GetAll()
        {
            var dtos = await _mediator.Send(new GetAllRolesQuery());
            return Ok(dtos);
        }
        [HttpGet("GetRoles", Name = "GetRoles")]
        public async Task<ActionResult<APIResponse>> Get(string Id)
        {
            var dtos = await _mediator.Send(new GetByIdRolesQuery() { Id = Id });
            return Ok(dtos);
        }
        [HttpDelete("DeleteRoles", Name = "DeleteRoles")]
        public async Task<ActionResult<APIResponse>> Delete(string Id)
        {
            var dtos = await _mediator.Send(new DeleteRolesCommand() { Id = Id });
            return Ok(dtos);
        }
    }
}
