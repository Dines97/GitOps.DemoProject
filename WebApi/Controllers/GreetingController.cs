using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class GreetingController : ControllerBase {
  private readonly IConfiguration _configuration;

  public GreetingController(IConfiguration configuration) {
    _configuration = configuration;
  }

  [HttpGet]
  public string GetWebApiGreeting() {
    return _configuration["Message"];
  }
}