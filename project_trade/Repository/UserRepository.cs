using System.Linq;
using project_trade.Dto;
using project_trade.Entity;
namespace project_trade.Repo;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public IEnumerable<UserDto> getAll()
    {
        var user = context.Users
          .Select(u => new UserDto
         (
               u.Id,
               u.Username,
               u.Role.RoleName,
               u.Email

          ))
        .ToList();
        return user;
    }

    public IEnumerable<AccountDto> getAllAccount()
    {
        var account = context.Accounts
          .Select(a => new AccountDto
             (
              a.Id,
              a.User.Username,
              a.Balance ?? 0
              ))
          .ToList();
        return account;
    }
}
