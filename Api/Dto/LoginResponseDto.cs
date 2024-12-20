namespace Api.Dto;

/// <summary>
/// Response to authentication proccess
/// </summary>
public class LoginResponseDto
{
    /// <summary>
    /// Boolean to indicate if the authentication was successful
    /// </summary>
    public bool IsAuthSuccess { get; set; }

    /// <summary>
    /// Error message if there any
    /// </summary>
    public string? ErrorMessage { get; set; }

    /// <summary>
    /// Token string if the authentication was successful
    /// </summary>
    public string? Token { get; set; }
}
