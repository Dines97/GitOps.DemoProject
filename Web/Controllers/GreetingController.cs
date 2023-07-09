using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class GreetingController : ControllerBase {
  private readonly IConfiguration _configuration;
  private readonly ILogger<GreetingController> _logger;

  public GreetingController(IConfiguration configuration, ILogger<GreetingController> logger) {
    _configuration = configuration;
    _logger = logger;
  }

  [HttpGet]
  public async Task<string> GetWebGreeting() {
    using var client = new HttpClient();

    var requestUrl = _configuration["WebApiUrl"] + "/Greeting/GetWebApiGreeting";
    _logger.LogInformation("{}", requestUrl);

    var response = await client.GetAsync(requestUrl);
    response.EnsureSuccessStatusCode();

    return await response.Content.ReadAsStringAsync();
  }
}