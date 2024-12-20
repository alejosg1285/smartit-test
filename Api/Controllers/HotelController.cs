using Application.Commands.Hotel.AssignRoom;
using Application.Commands.Hotel.Create;
using Application.Commands.Hotel.Toggle;
using Application.Commands.Hotel.Update;
using Application.Models.Dto;
using Application.Queries.Hotel.Detail;
using Application.Queries.Hotel.ListAll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class HotelController : BaseApiController
{
    /// <summary>
    /// Register a new hotel
    /// </summary>
    /// <param name="command"><inheritdoc cref="CreateHotelCommand" /></param>
    /// <returns></returns>
    [HttpPost]
    [Authorize(Policy = "OnlyAdmin")]
    public async Task<IActionResult> CreateHotel([FromBody] CreateHotelCommand command)
    {
        return HandleResult(await Mediator.Send(command));
    }

    /// <summary>
    /// Update a hotel
    /// </summary>
    /// <param name="id">Identification of the hotel</param>
    /// <param name="command"><inheritdoc cref="UpdateHotelCommand" /></param>
    /// <returns></returns>
    [HttpPatch("{id}")]
    [Authorize(Policy = "OnlyAdmin")]
    public async Task<IActionResult> UpdateHotel(int id, [FromBody] UpdateHotelCommand command)
    {
        command.Id = id;
        return HandleResult(await Mediator.Send(command));
    }

    /// <summary>
    /// Activate or desactivate a hotel
    /// </summary>
    /// <param name="id">Identification of the hotel</param>
    /// <returns></returns>
    [HttpPatch("activate/{id}")]
    [Authorize(Policy = "OnlyAdmin")]
    public async Task<IActionResult> ToggleHotel(int id)
    {
        ToggleHotelCommand command = new() { Id = id };
        return HandleResult(await Mediator.Send(command));
    }

    /// <summary>
    /// Assign a new room to the hotel
    /// </summary>
    /// <param name="id">Identification of the hotel</param>
    /// <param name="command"><inheritdoc cref="AssignRoomHotelCommand" /></param>
    /// <returns></returns>
    [HttpPost("assign/{id}")]
    [Authorize(Policy = "OnlyAdmin")]
    public async Task<IActionResult> AssignRoom(int id, [FromBody] AssignRoomHotelCommand command)
    {
        command.HotelId = id;
        return HandleResult(await Mediator.Send(command));
    }

    /// <summary>
    /// Get the detail information of the hotel
    /// </summary>
    /// <param name="id">Identification of the hotel</param>
    /// <returns><inheritdoc cref="HotelDetailResponseDto" /></returns>
    [HttpGet("detail/{id}")]
    [Authorize(Policy = "OnlyAdmin")]
    public async Task<IActionResult> GetHotelDetail(int id)
    {
        DetailHotelQuery query = new() { HotelId = id };
        return HandleResult(await Mediator.Send(query));
    }

    /// <summary>
    /// Get a listo of the hotels registered
    /// </summary>
    /// <returns><inheritdoc cref="HotelResponseDto" /></returns>
    [HttpGet("list")]
    [Authorize(Policy = "OnlyAdmin")]
    public async Task<IActionResult> GetAllHotels()
    {
        GetAllHotelQuery query = new();
        return HandleResult(await Mediator.Send(query));
    }
}
