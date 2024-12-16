using Application.Commands.Book;
using Application.Models;
using Application.Queries.Book;
using Application.Queries.Book.Detail;
using Application.Queries.Book.ListAll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class BookController : BaseApiController
{
    [HttpGet]
    [Authorize(Policy = "OnlyTravel")]
    public async Task<IActionResult> GetAvailibility([FromBody] GetAvailabilityQuery search)
    {
        return HandleResult(await Mediator.Send(search));
    }

    [HttpPost]
    [Authorize(Policy = "OnlyTravel")]
    public async Task<IActionResult> CreateBook([FromBody] BookRequest book)
    {
        return HandleResult(await Mediator.Send(new CreateBookCommand { BookRequest = book }));
    }

    [HttpGet("list")]
    [Authorize(Policy = "OnlyAdmin")]
    public async Task<IActionResult> GetAllBooks()
    {
        GetAllBookQuery request = new();
        return HandleResult(await Mediator.Send(request));
    }

    [HttpGet("detail/{id}")]
    [Authorize(Policy = "OnlyAdmin")]
    public async Task<IActionResult> GetDetailBook(int id)
    {
        DetailBookQuery query = new() { BookId = id };
        return HandleResult(await Mediator.Send(query));
    }
}
