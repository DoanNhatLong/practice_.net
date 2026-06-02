using Microsoft.AspNetCore.Mvc;
using project_ocr.entity;
using project_ocr.service;
using project_ocr.dtos;

namespace project_ocr.controller;

[ApiController]
[Route("admin")]
public class AdminController : ControllerBase
{
    private readonly CustomerService _service;

    public AdminController(CustomerService service)
    {
        _service = service;
    }

    [HttpGet("customers")]
    public async Task<List<CustomerResponse>> GetCustomers()
    {
        return await _service.GetCustomers();
    }
}