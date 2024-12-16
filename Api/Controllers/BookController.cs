using Application.Queries.Book;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class BookController : BaseApiController
{
    [HttpGet]
    //[Authorize(Policy = "OnlyTravel")]
    public async Task<IActionResult> GetAvailibility([FromBody] GetAvailabilityQuery search)
    {
        return HandleResult(await Mediator.Send(search));
    }
}
