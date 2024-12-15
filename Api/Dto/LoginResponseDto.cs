namespace Api.Dto;

public class LoginResponseDto
{
    public bool IsAuthSuccess { get; set; }
    public string? ErrorMessage { get; set; }
    public string? Token { get; set; }
}
