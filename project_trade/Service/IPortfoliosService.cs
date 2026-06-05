using project_trade.Entity;
namespace project_trade.Service;
public interface IPortfoliosService
{
    IEnumerable<Portfolio> getAll();
}
