namespace Application.Models;

public class MetadataEmail(string toAddress, string subject, string body = "")
{
    public string? ToAddress { get; set; } = toAddress;
    public string? Subject { get; set; } = subject;
    public string? Body { get; set; } = body;
}
