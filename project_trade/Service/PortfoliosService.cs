using project_trade.Repository;
using project_trade.Entity;
using project_trade.Dto;

namespace project_trade.Service;
public class PortfoliosService
(IPortfoliosRepository repository,
AppDbContext context
 ) : IPortfoliosService
{
    public void addPort(PortfoliosDto dto)
    {
        using var transaction = context.Database.BeginTransaction();
        try
        {
            repository.addPort(dto);
            repository.CalcAccount(dto);
            context.SaveChanges();
            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
        }
    }
    public IEnumerable<Portfolio> getAll()
    {
        return repository.getAll();
    }
}
