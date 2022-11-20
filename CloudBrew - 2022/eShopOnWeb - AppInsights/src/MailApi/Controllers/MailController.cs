using Microsoft.AspNetCore.Mvc;

namespace MailApi.Controllers;
[ApiController]
[Route("[controller]")]
public class MailController : ControllerBase
{
    private readonly ILogger<MailController> _logger;

    public MailController(ILogger<MailController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "send")]
    public IActionResult Send(string subject, string body)
    {
        _logger.LogInformation("Send mail - {subject}",subject);
        return Ok();
    }
}
