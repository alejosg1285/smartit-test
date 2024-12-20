using Api.Dto;
using Api.Extensions;
using Api.Services;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController(UserManager<AppUser> userManager, JwtHandler jwtHandler) : ControllerBase
{
    private readonly UserManager<AppUser> _userManager = userManager;
    private readonly JwtHandler _jwtHandler = jwtHandler;

    /// <summary>
    /// Register a new user
    /// </summary>
    /// <inheritdoc cref="UserRegistrationDto"/>
    /// <returns></returns>
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegistrationDto userDto)
    {
        if (userDto is null)
        {
            return BadRequest();
        }

        AppUser user = userDto.fromDto();
        IdentityResult result = await _userManager.CreateAsync(user, userDto.Password);
        if (!result.Succeeded)
        {
            IEnumerable<string> errors = result.Errors.Select(e => e.Description);

            return BadRequest(new RegistrationResponseDto { IsSuccessfulRegistration = false, Errors = errors });
        }

        await _userManager.AddToRoleAsync(user, userDto.RoleName);

        return StatusCode(201);
    }

    /// <summary>
    /// Authenticate the user by E-mail and Password
    /// </summary>
    /// <inheritdoc cref="LoginDto"/>
    /// <returns><inheritdoc cref="LoginResponseDto" /></returns>
    [HttpPost("authenticate")]
    public async Task<IActionResult> Authenticate([FromBody] LoginDto loginDto)
    {
        AppUser user = await _userManager.FindByNameAsync(loginDto.Email!);
        if (user is null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
        {
            return Unauthorized(new LoginResponseDto { ErrorMessage = "Invalid authentication" });
        }

        IList<string> roles = await _userManager.GetRolesAsync(user);
        string token = _jwtHandler.CreateToken(user, roles);

        return Ok(new LoginResponseDto { IsAuthSuccess = true, Token = token });
    }
}
