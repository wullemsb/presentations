using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace Microsoft.eShopWeb.Infrastructure.Services;

// This class is used by the application to send email for account confirmation and password reset.
// For more details see https://go.microsoft.com/fwlink/?LinkID=532713
public class EmailSender : IEmailSender
{
    private readonly IHttpClientFactory _httpClientFactory;

    public EmailSender(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task SendEmailAsync(string email, string subject, string message)
    {
        var client = _httpClientFactory.CreateClient();

        client.BaseAddress = new Uri("TODO");

        var response = await client.GetAsync($"Mail?subject={subject}&body={message}");
        response.EnsureSuccessStatusCode();
    }
}
