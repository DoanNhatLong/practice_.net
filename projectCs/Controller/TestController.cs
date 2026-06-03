using Microsoft.AspNetCore.Mvc;
using projectCs.Service;
[ApiController]
[Route("")]

public class TestController
(ICustomerService customerService

 )
: ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return
          Ok("Hello");
    }
    [HttpGet("customer")]
    public async Task<IActionResult> getCustomer()
    {
        var data = await customerService.GetCustomersAsync();
        return Ok(data);
    }
}
