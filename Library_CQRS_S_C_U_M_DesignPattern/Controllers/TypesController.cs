using BLL;
using BLL.Services;
using CORE.DTO;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_CQRS_S_C_U_M_DesignPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TypesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("AddTypes", Name = "AddTypes")]
        public async Task<ActionResult<APIResponse>> Add(AddTypesCommand _Type)
        {
            var dtos = await _mediator.Send(_Type);
            return Ok(dtos);
        }
        [HttpPost("updateTypes", Name = "updateTypes")]
        public async Task<ActionResult<APIResponse>> Update_Type(UpdateTypesCommand _Type)
        {
            var dtos = await _mediator.Send(_Type);
            return Ok(dtos);

        }
        [HttpDelete("DeleteTypes", Name = "DeleteTypes")]
        public async Task<ActionResult<APIResponse>> AddDelete(int _Type)
        {
            var dtos = await _mediator.Send(new DeleteTypesCommands() { Id = _Type });
            return Ok(dtos);
        }
        [HttpGet("GetAllTypes", Name = "GetAllTypes")]
        public async Task<ActionResult<APIResponse>> GetAll()
        {
            var dtos = await _mediator.Send(new GetAllTypesQuery() );
            return Ok(dtos);
        }
        [HttpGet("GetTypes", Name = "GetTypes")]
        public async Task<ActionResult<APIResponse>> Get(int id)
        {
            var dtos = await _mediator.Send(new GetByIdTypesQuery() {  Id = id });
            return Ok(dtos);
        }
  
      
    }
}
