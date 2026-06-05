using project_trade.Repository;
using project_trade.Entity;
using project_trade.Dto;

namespace project_trade.Service;
public class PortfoliosService
(IPortfoliosRepository repository
 ) : IPortfoliosService
{
    public void addPort(PortfoliosDto dto)
    {
        repository.addPort(dto);
    }
    public IEnumerable<Portfolio> getAll()
    {
        return repository.getAll();
    }
}
