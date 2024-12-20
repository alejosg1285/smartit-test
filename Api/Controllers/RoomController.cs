using Application.Commands.Room.Create;
using Application.Commands.Room.Toggle;
using Application.Commands.Room.Update;
using Application.Models.Dto;
using Application.Queries.Room.Detail;
using Application.Queries.Room.ListAll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class RoomController : BaseApiController
{
    /// <summary>
    /// Register a new room
    /// </summary>
    /// <param name="command"><inheritdoc cref="CreateRoomCommand" /></param>
    /// <returns></returns>
    [HttpPost]
    [Authorize(Policy = "OnlyAdmin")]
    public async Task<IActionResult> CreateRoom([FromBody] CreateRoomCommand command)
    {
        return HandleResult(await Mediator.Send(command));
    }

    /// <summary>
    /// Update the information for a room
    /// </summary>
    /// <param name="id">Identification of the room</param>
    /// <param name="command"><inheritdoc cref="UpdateRoomCommand" /></param>
    /// <returns></returns>
    [HttpPatch("{id}")]
    [Authorize(Policy = "OnlyAdmin")]
    public async Task<IActionResult> UpdateHotel(int id, [FromBody] UpdateRoomCommand command)
    {
        command.Id = id;
        return HandleResult(await Mediator.Send(command));
    }

    /// <summary>
    /// Activate or desactive a room by the identification number
    /// </summary>
    /// <param name="id">Ientification of the room</param>
    /// <returns></returns>
    [HttpPatch("activate/{id}")]
    [Authorize(Policy = "OnlyAdmin")]
    public async Task<IActionResult> ToggleHotel(int id)
    {
        ToggleRoomCommand command = new() { Id = id };
        return HandleResult(await Mediator.Send(command));
    }

    /// <summary>
    /// Get a list of the room recorded
    /// </summary>
    /// <returns><inheritdoc cref="RoomResponseDto" /></returns>
    [HttpGet("list")]
    [Authorize(Policy = "OnlyTravel")]
    public async Task<IActionResult> GetList()
    {
        GetAllRoomQuery query = new();
        return HandleResult(await Mediator.Send(query));
    }

    /// <summary>
    /// Get the information detail about a room
    /// </summary>
    /// <param name="id">Identification of the room</param>
    /// <returns><inheritdoc cref="RoomDetailResponseDto" /></returns>
    [HttpGet("detail/{id}")]
    [Authorize(Policy = "OnlyTravel")]
    public async Task<IActionResult> DetailRoom(int id)
    {
        DetailRoomQuery query = new() { RoomId = id };
        return HandleResult((await Mediator.Send(query)));
    }
}
