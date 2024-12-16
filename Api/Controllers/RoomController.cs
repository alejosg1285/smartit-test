using Application.Commands.Room.Create;
using Application.Commands.Room.Toggle;
using Application.Commands.Room.Update;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class RoomController : BaseApiController
{
    [HttpPost]
    //[Authorize(Policy = "OnlyAdmin")]
    public async Task<IActionResult> CreateRoom([FromBody] CreateRoomCommand command)
    {
        return HandleResult(await Mediator.Send(command));
    }

    [HttpPut("{id}")]
    //[Authorize(Policy = "OnlyAdmin")]
    public async Task<IActionResult> UpdateHotel(int id, [FromBody] UpdateRoomCommand command)
    {
        command.Id = id;
        return HandleResult(await Mediator.Send(command));
    }

    [HttpPut("activate/{id}")]
    //[Authorize(Policy = "OnlyAdmin")]
    public async Task<IActionResult> ToggleHotel(int id)
    {
        ToggleRoomCommand command = new() { Id = id };
        return HandleResult(await Mediator.Send(command));
    }
}
