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


            MultipartFormDataContent postData = new MultipartFormDataContent();
            postData.Add(new StringContent(_options.Value.Email), "from");
            postData.Add(new StringContent(emailMetadata.ToAddress), "to");
            postData.Add(new StringContent(emailMetadata.Subject), "subject");
            postData.Add(new StringContent(emailMetadata.Body), "html");
            var DomainName = _options.Value.Domain;
            using HttpResponseMessage request = await client.PostAsync("https://api.mailgun.net/v3/" + DomainName + "/messages", postData);

            //await _fluentEmail.To(emailMetadata.ToAddress)
            //    .Subject(emailMetadata.Subject)
            //    .Body(emailMetadata.Body)
            //    .SendAsync();
        }
        catch (Exception ex)
        {

        }
    }
}
