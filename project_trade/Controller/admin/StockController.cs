using Microsoft.AspNetCore.Mvc;
using project_trade.Entity;
using project_trade.Repository;

[ApiController]
[Route("admin/stock")]
public class StockController(
    AppDbContext context,
    IStockRepository stockRepository
    ) : ControllerBase
{
    [HttpGet]
    public IActionResult getStock()
    {
        var stock = stockRepository.getAll();
        return Ok(stock);
    }
    [HttpPut("{id}")]
    public IActionResult update(int id, [FromBody] decimal price)

    {
        stockRepository.UpdatePrice(id, price);
        return Ok("Update Complete");

    }
    [HttpPost]
    public IActionResult addStock([FromBody] StockRequest request)
    {
        stockRepository.AddStock(request.Symbol, request.price);
        return Ok("Add Complete");
    }


    public record StockRequest(string Symbol, decimal price);
}
