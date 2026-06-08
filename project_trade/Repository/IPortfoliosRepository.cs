using project_trade.Entity;
using project_trade.Dto;

namespace project_trade.Repository;
public interface IPortfoliosRepository
{
    IEnumerable<Portfolio> getAll();
    void addPort(PortfoliosDto portfoliosDto);
    void CalcAccount(PortfoliosDto portfoliosDto);
}
