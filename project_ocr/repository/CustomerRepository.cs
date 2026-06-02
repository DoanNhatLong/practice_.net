using Microsoft.EntityFrameworkCore;
  
using project_ocr.entity;

using project_ocr.dtos;
namespace project_ocr.repository;
public class CustomerRepository
{
    private readonly AppDbContext _context;

    public CustomerRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<CustomerResponse>> GetCustomers()
    {
        return await _context.Customers
            .Select(c => new CustomerResponse(
                c.CompanyName,
                c.TaxCode,
                c.Status
            ))
            .ToListAsync();
    }
}