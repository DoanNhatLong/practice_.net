using project_trade.Dto;
using project_trade.Entity;

namespace project_trade.Repository;
public class PortfoliosRepository(
    AppDbContext context
    ) : IPortfoliosRepository
{
    public void addPort(PortfoliosDto portfoliosDto)
    {
        var exist = context.Portfolios
          .FirstOrDefault(p => p.UserId == portfoliosDto.UserId
              && p.StockId == portfoliosDto.StockId);
        if (exist != null)
        {
            exist.Quantity += portfoliosDto.Quantity;
        }
        else
        {
            var newPort = new Portfolio
            {
                UserId = portfoliosDto.UserId,
                StockId = portfoliosDto.StockId,
                Quantity = portfoliosDto.Quantity
            };
            context.Portfolios.Add(newPort);
        }
        context.SaveChanges();
    }
    public IEnumerable<Portfolio> getAll()
    {
        var port = context.Portfolios.ToList();
        return port;
    }
}
