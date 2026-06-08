using Microsoft.AspNetCore.Mvc;
using project_trade.Dto;
using project_trade.Service;

[ApiController]
[Route("admin/port")]
public class portfoliosController
(
IPortfoliosService portfoliosService,
LeaderboardService redis
 ) : ControllerBase
{
    [HttpGet]
    public IActionResult getAll()
    {
        var port = portfoliosService.getAll();
        return Ok(port);
    }
    [HttpPost]
    public IActionResult addPort([FromBody] PortfoliosDto dto)
    {
        portfoliosService.addPort(dto);
        return Ok("Add Completed");
    }
    [HttpGet("start")]
    public IActionResult init()
    {
        redis.init();
        return Ok("Redis");

    }
}

