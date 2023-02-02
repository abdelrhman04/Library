using BLL.Services;
using BLL;
using CORE.DTO;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CORE.DAL;

namespace Library_CQRS_S_C_U_M_DesignPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrorowsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrorowsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("AddBrorows", Name = "AddBrorows")]
        public async Task<ActionResult<APIResponse>> Add(AddBrorowsCommand Brorow)
        {
            var dtos = await _mediator.Send(Brorow);
            return Ok(dtos);
        }
        [HttpPost("UpdateBrorows", Name = "UpdateBrorows")]
        public async Task<ActionResult<APIResponse>> Update(UpdateBrorowsCommand Brorow)
        {
            var dtos = await _mediator.Send(Brorow);
            return Ok(dtos);
        }
        [HttpGet("GetAllBrorows", Name = "GetAllBrorows")]
        public async Task<ActionResult<APIResponse>> GetAll()
        {
            var dtos = await _mediator.Send(new GetAllBrorowsQuery());
            return Ok(dtos);
        }
        [HttpGet("GetBrorows", Name = "GetBrorows")]
        public async Task<ActionResult<APIResponse>> Get(int Id ,string student_id)
        {
            var dtos = await _mediator.Send(new GetByIdBrorowsQuery() { Id = Id,student_id=student_id });
            return Ok(dtos);
        }
        [HttpDelete("DeleteBrorows", Name = "DeleteBrorows")]
        public async Task<ActionResult<APIResponse>> Delete(int Id, string student_id)
        {
            var dtos = await _mediator.Send(new DeleteBrorowsCommand() { Id = Id, student_id = student_id });
            return Ok(dtos);
        }
    }
}
