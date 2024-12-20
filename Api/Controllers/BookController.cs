using Application.Commands.Book;
using Application.Models;
using Application.Models.Dto;
using Application.Queries.Book;
using Application.Queries.Book.Detail;
using Application.Queries.Book.ListAll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class BookController : BaseApiController
{
    /// <summary>
    /// Get the rooms available according with parameters
    /// </summary>
    /// <inheritdoc cref="GetAvailabilityQuery"/>
    /// <returns><inheritdoc cref="AvailableResponseDto" /></returns>
    [HttpGet]
    [Authorize(Policy = "OnlyTravel")]
    public async Task<IActionResult> GetAvailibility([FromBody] GetAvailabilityQuery search)
    {
        return HandleResult(await Mediator.Send(search));
    }

    /// <summary>
    /// Register a new book for a room
    /// </summary>
    /// <inheritdoc cref="BookRequest"/>
    /// <returns></returns>
    [HttpPost]
    [Authorize(Policy = "OnlyTravel")]
    public async Task<IActionResult> CreateBook([FromBody] BookRequest book)
    {
        return HandleResult(await Mediator.Send(new CreateBookCommand { BookRequest = book }));
    }

    /// <summary>
    /// Get a list of the books
    /// </summary>
    /// <returns><inheritdoc cref="GetAllBookDto" /></returns>
    [HttpGet("list")]
    [Authorize(Policy = "OnlyAdmin")]
    public async Task<IActionResult> GetAllBooks()
    {
        GetAllBookQuery request = new();
        return HandleResult(await Mediator.Send(request));
    }

    /// <summary>
    /// Details about the book
    /// </summary>
    /// <param name="id">Identification number of the book</param>
    /// <returns><inheritdoc cref="BookDetailResponseDto" /></returns>
    [HttpGet("detail/{id}")]
    [Authorize(Policy = "OnlyAdmin")]
    public async Task<IActionResult> GetDetailBook(int id)
    {
        DetailBookQuery query = new() { BookId = id };
        return HandleResult(await Mediator.Send(query));
    }
}
