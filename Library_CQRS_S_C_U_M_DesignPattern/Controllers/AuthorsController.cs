using BLL;
using BLL.Services;
using CORE.DTO;
using CORE.DTO.Authors;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_CQRS_S_C_U_M_DesignPattern.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("AddAuthors", Name = "AddAuthors")]
        public async Task<ActionResult<APIResponse>> Add(AddAuthourCommands Author)
        {
            var dtos = await _mediator.Send(Author);
            return Ok(dtos);
        }
        [HttpPost("UpdateAuthors", Name = "Update")]
        public async Task<ActionResult<APIResponse>> Update(UpdateAuthorCommands Author)
        {
            var dtos = await _mediator.Send(Author);
            return Ok(dtos);
        }
        [HttpGet("GetAll", Name = "GetAll")]
        public async Task<ActionResult<APIResponse>> GetAll()
        {
            var dtos = await _mediator.Send(new GetAllAuthorsQuery());
            return Ok(dtos);
        }
        [HttpGet("Get", Name = "Get")]
        public async Task<ActionResult<APIResponse>> Get(int Id)
        {
            var dtos = await _mediator.Send(new GetByIdAuthorsQuery() { Id = Id });
            return Ok(dtos);
        }
        [HttpDelete("Delete", Name = "Delete")]
        public async Task<ActionResult<APIResponse>> Delete(int Id)
        {
            var dtos = await _mediator.Send(new DeleteAuthorCommands() { Id = Id });
            return Ok(dtos);
        }
    }
}
