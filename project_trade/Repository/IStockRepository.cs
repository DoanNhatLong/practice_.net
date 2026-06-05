using project_trade.Entity;

namespace project_trade.Repository;
public interface IStockRepository

{
    IEnumerable<Stock> getAll();
    void UpdatePrice(int id, decimal newPrice);
    void AddStock(string symbol, decimal price);
}
