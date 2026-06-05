using project_trade.Entity;

namespace project_trade.Repository;
public class PortfoliosRepository(
    AppDbContext context
    ) : IPortfoliosRepository
{
    public IEnumerable<Portfolio> getAll()
    {
        var port = context.Portfolios.ToList();
        return port;
    }
}
