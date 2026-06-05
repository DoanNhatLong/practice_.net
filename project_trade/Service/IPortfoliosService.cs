using project_trade.Entity;
using project_trade.Dto;
namespace project_trade.Service;
public interface IPortfoliosService
{
    IEnumerable<Portfolio> getAll();
    void addPort(PortfoliosDto dto);

}
