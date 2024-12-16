using Infrastructure.Models;

namespace Api.Extensions;

public static class FluentEmailExtensions
{
    public static void AddFluentEmail(this IServiceCollection services, ConfigurationManager configuration)
    {
        IConfigurationSection emailSettings = configuration.GetSection("Mailing");
        services.Configure<EmailSettings>(emailSettings);

        string? fromEmail = emailSettings["username"];
        string? host = emailSettings["host"];
        int port = emailSettings.GetValue<int>("port");

        services.AddFluentEmail(fromEmail)
            .AddSmtpSender(host, port);
    }
}
