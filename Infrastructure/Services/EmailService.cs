using Application.Interfaces;
using Application.Models;
using FluentEmail.Core;
using Infrastructure.Models;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;

namespace Infrastructure.Services;

public class EmailService(IFluentEmail fluentEmail, IOptions<EmailSettings> config) : IEmailService
{
    private readonly IFluentEmail _fluentEmail = fluentEmail;
    private readonly IOptions<EmailSettings> _options = config;

    public async Task Send(MetadataEmail emailMetadata)
    {
        try
        {
            HttpClient client = new();

            string base64String = Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", _options.Value.Email, _options.Value.Password)));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(@"Basic", base64String);


            MultipartFormDataContent postData = new()
            {
                { new StringContent(_options.Value.Email), "from" },
                { new StringContent(emailMetadata.ToAddress), "to" },
                { new StringContent(emailMetadata.Subject), "subject" },
                { new StringContent(emailMetadata.Body), "html" }
            };
            var DomainName = _options.Value.Domain;
            using HttpResponseMessage request = await client.PostAsync("https://api.mailgun.net/v3/" + DomainName + "/messages", postData);
        }
        catch (Exception ex)
        {

        }
    }
}
