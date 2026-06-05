using Microsoft.AspNetCore.Mvc;
using project_trade.Entity;
using project_trade.Repo;

[ApiController]
[Route("")]
public class UserController(
    AppDbContext context,
    IUserRepository userRepository
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
}
