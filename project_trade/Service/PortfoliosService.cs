using project_trade.Repository;
using project_trade.Entity;

namespace project_trade.Service;
public class PortfoliosService
(IPortfoliosRepository repository
 ) : IPortfoliosService
{
    public IEnumerable<Portfolio> getAll()
    {
        return repository.getAll();
    }
}
