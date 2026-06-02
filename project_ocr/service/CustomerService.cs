using project_ocr.dtos;
using project_ocr.repository;
namespace project_ocr.service;

public class CustomerService
{
    private readonly CustomerRepository _repository;

    public CustomerService(CustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<CustomerResponse>> GetCustomers()
    {
        return await _repository.GetCustomers();
    }
}