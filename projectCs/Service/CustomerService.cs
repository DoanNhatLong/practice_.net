using projectCs.Data;
using projectCs.Dtos;

namespace projectCs.Service;
public class CustomerService(ICustomerRepository repository) : ICustomerService
{
    public Task<IEnumerable<CustomerDto>> GetCustomersAsync()
    {
        return repository.GetAll();
    }
}
