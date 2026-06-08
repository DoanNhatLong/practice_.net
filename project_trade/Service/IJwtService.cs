namespace project_trade.Service;

public interface IJwtService
{
    string GenerateToken(string username);
}
