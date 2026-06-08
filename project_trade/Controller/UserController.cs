using Microsoft.AspNetCore.Mvc;
using project_trade.Entity;
using project_trade.Dto;
using project_trade.Service;
using project_trade.Repo;

[ApiController]
[Route("")]
public class UserController(
    AppDbContext context,
    IUserRepository userRepository,
    IJwtService jwtService
    ) : ControllerBase
{
    [HttpGet("users")]
    public IActionResult getUser()
    {
        var users = userRepository.getAll();
        return Ok(users);
    }
    [HttpGet("roles")]
    public IActionResult getRole()
    {
        var roles = context.Roles.ToList();
        return Ok(roles);
    }
    [HttpGet("stocks")]
    public IActionResult getStock()
    {
        var stocks = context.Stocks.ToList();
        return Ok(stocks);
    }
    [HttpGet("o-type")]
    public IActionResult getType()
    {
        var o_type = context.OrderTypes.ToList();
        return Ok(o_type);
    }
    [HttpGet("account")]
    public IActionResult getAccount()
    {
        var account = userRepository.getAllAccount();
        return Ok(account);
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequestDto requestDto)
    {
        var token = jwtService.GenerateToken(requestDto.Username);
        return Ok(new { Token = token });

    }
}

