using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HotelController : ControllerBase
{
    [HttpGet("{id}")]
    [Authorize(Policy = "OnlyAdmin")]
    public async Task<IActionResult> GetHotel(int id)
    {
        return Ok();
    }
}
