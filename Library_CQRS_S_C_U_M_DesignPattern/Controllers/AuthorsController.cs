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
        public async Task<ActionResult<AuthorOutput>> Add(AuthorInput Author)
        {
            var dtos = await _mediator.Send(new AddAuthourCommands(){ Author= Author});
            return Ok(dtos);
        }
        [HttpPost("UpdateAuthors", Name = "Update")]
        public async Task<ActionResult<AuthorOutput>> Update(AuthorInput Author)
        {
            var dtos = await _mediator.Send(new UpdateAuthorCommands() { Author = Author });
            return Ok(dtos);
        }
        [HttpGet("GetAll", Name = "GetAll")]
        public async Task<ActionResult<AuthorOutput>> GetAll()
        {
            var dtos = await _mediator.Send(new GetAllAuthorsQuery());
            return Ok(dtos);
        }
        [HttpGet("Get", Name = "Get")]
        public async Task<ActionResult<AuthorOutput>> Get(int Id)
        {
            var dtos = await _mediator.Send(new GetByIdAuthorsQuery() { Id = Id });
            return Ok(dtos);
        }
        [HttpDelete("Delete", Name = "Delete")]
        public async Task<ActionResult> Delete(int Id)
        {
            var dtos = await _mediator.Send(new DeleteAuthorCommands() { Id = Id });
            return Ok(dtos);
        }
    }
}
