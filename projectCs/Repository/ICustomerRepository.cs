using projectCs.Dtos;
namespace projectCs.Data;
public interface ICustomerRepository
{
    Task<IEnumerable<CustomerDto>> GetAll();
}
