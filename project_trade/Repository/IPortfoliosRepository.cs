using project_trade.Entity;

namespace project_trade.Repository;
public interface IPortfoliosRepository
{
    IEnumerable<Portfolio> getAll();
}
