using Application.Models;

namespace Application.Interfaces;

public interface IEmailService
{
    Task Send(MetadataEmail emailMetadata);
}
