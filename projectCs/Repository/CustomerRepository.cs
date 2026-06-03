using projectCs.Entity;
using projectCs.Dtos;
using Microsoft.EntityFrameworkCore;

namespace projectCs.Data;
public class CustomerRepository(AppDbContext context) : ICustomerRepository
{

    public async Task<IEnumerable<CustomerDto>> GetAll()
    {
        return await context.Customers
          .Select(c => new CustomerDto(
                c.Id,

                c.CompanyName,
                c.TaxCode,
                c.Status ?? "Active"
                ))
          .ToListAsync();
    }
}
