
using project_trade.Dto;
using project_trade.Entity;

namespace project_trade.Repo;

public interface IUserRepository
{
    IEnumerable<UserDto> getAll();
    IEnumerable<AccountDto> getAllAccount();
    User? FindByUsername(string username);
    void CreateUser(LoginRequestDto requestDto);
}
