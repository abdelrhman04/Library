using BLL.Services;
using CORE.DTO.Authors;
using CORE.DTO;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<BooksOutput>> Add([FromForm] BooksInput Book)
        {
            var dtos = await _mediator.Send(new AddBooksCommand() { Book = Book });
            return Ok(dtos);
        }
    }
}
