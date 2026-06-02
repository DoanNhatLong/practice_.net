using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/test")]
public class TestController : ControllerBase
{
    [HttpGet]
    public string Get()
    {
        return "Hello World!";
    }
}