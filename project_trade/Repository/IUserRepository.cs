
using project_trade.Dto;

namespace project_trade.Repo;

public interface IUserRepository
{
    IEnumerable<UserDto> getAll();
}
