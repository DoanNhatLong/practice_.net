using projectCs.Dtos;

namespace projectCs.Service;
public interface ICustomerService
{
    Task<IEnumerable<CustomerDto>> GetCustomersAsync();
}
