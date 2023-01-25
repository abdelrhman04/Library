using BLL.Services;
using CORE.DTO.Authors;
using CORE.DTO;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;

namespace Library_CQRS_S_C_U_M_DesignPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //[HttpPost, DisableRequestSizeLimit]
        [Consumes("multipart/form-data")]
        [HttpPost("AddBook", Name = "AddBook")]
        public async Task<ActionResult<APIResponse>> Add([FromForm] BooksInput Book)
        {
            var dtos = await _mediator.Send(new AddBooksCommand() { Book = Book });
            return Ok(dtos);
        }
        [Consumes("multipart/form-data")]
        [HttpPost("updateBook", Name = "updateBook")]
        public async Task<ActionResult<APIResponse>> Update_Type([FromForm] BooksInput _Type)
        {
            var dtos = await _mediator.Send(new UpdateBooksCommand() { Books = _Type });
            return Ok(dtos);

        }
        [HttpDelete("DeleteBook", Name = "DeleteBook")]
        public async Task<ActionResult<APIResponse>> AddDelete(int _Type)
        {
            var dtos = await _mediator.Send(new DeleteBooksCommand() { Id = _Type });
            return Ok(dtos);
        }
        [HttpGet("GetAllBook", Name = "GetAllBook")]
        public async Task<ActionResult<APIResponse>> GetAll()
        {
            var dtos = await _mediator.Send(new GetAllBooksQuery());
            return Ok(dtos);
        }
        [HttpGet("GetBook", Name = "GetBook")]
        public async Task<ActionResult<APIResponse>> Get(int id)
        {
            var dtos = await _mediator.Send(new GetByIdBooksQuery() { Id = id });
            return Ok(dtos);
        }

    }
}
