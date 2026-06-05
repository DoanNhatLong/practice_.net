using project_trade.Entity;

namespace project_trade.Repository;
public class StockRepository(AppDbContext context) : IStockRepository
{
    public void AddStock(string symbol, decimal price)
    {
        var stock = new Stock
        {
            Symbol = symbol,
            CurrentPrice = price
        };
        context.Stocks.Add(stock);
        context.SaveChanges();
    }
    public IEnumerable<Stock> getAll()
    {
        var stocks = context.Stocks.ToList();
        return stocks;
    }

    public void UpdatePrice(int id, decimal newPrice)
    {
        var stock = context.Stocks.Find(id);
        if (stock != null)
        {
            stock.CurrentPrice = newPrice;
            context.SaveChanges();
        }
    }
}
