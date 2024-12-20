namespace Api.Dto;

/// <summary>
/// Response for the register user process
/// </summary>
public class RegistrationResponseDto
{
    /// <summary>
    /// Indicate that the register was successful
    /// </summary>
    public bool IsSuccessfulRegistration { get; set; }

    /// <summary>
    /// List of errors if there are any
    /// </summary>
    public IEnumerable<string>? Errors { get; set; }
}
