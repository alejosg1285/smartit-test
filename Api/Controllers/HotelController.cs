using Application.Commands.Hotel.AssignRoom;
using Application.Commands.Hotel.Create;
using Application.Commands.Hotel.Toggle;
using Application.Commands.Hotel.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

//[Route("api/[controller]")]
//[ApiController]
public class HotelController : BaseApiController
{
    [HttpPost]
    [Authorize(Policy = "OnlyAdmin")]
    public async Task<IActionResult> CreateHotel([FromBody] CreateHotelCommand command)
    {
        return HandleResult(await Mediator.Send(command));
    }

    [HttpPut("{id}")]
    [Authorize(Policy = "OnlyAdmin")]
    public async Task<IActionResult> UpdateHotel(int id, [FromBody] UpdateHotelCommand command)
    {
        command.Id = id;
        return HandleResult(await Mediator.Send(command));
    }

    [HttpPut("activate/{id}")]
    [Authorize(Policy = "OnlyAdmin")]
    public async Task<IActionResult> ToggleHotel(int id)
    {
        ToggleHotelCommand command = new() { Id = id };
        return HandleResult(await Mediator.Send(command));
    }

    [HttpPost("assign/{id}")]
    [Authorize(Policy = "OnlyAdmin")]
    public async Task<IActionResult> AssignRoom(int id, [FromBody] AssignRoomHotelCommand command)
    {
        command.HotelId = id;
        return HandleResult(await Mediator.Send(command));
    }

    [HttpGet("{id}")]
    [Authorize(Policy = "OnlyAdmin")]
    public async Task<IActionResult> GetHotel(int id)
    {
        return Ok();
    }
}
