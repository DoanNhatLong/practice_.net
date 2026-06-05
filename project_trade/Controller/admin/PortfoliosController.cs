using Microsoft.AspNetCore.Mvc;
using project_trade.Entity;
using project_trade.Service;

[ApiController]
[Route("admin/port")]
public class portfoliosController
(
AppDbContext context,
IPortfoliosService portfoliosService
 ) : ControllerBase
{
    [HttpGet]
    public IActionResult getAll()
    {
        var port = portfoliosService.getAll();
        return Ok(port);
    }
}

