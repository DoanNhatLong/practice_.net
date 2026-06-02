using Microsoft.EntityFrameworkCore;
using project_ocr.entity;
using project_ocr.repository;
using project_ocr.service;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));
builder.Services.AddScoped<CustomerRepository>();
builder.Services.AddScoped<CustomerService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.MapGet("/", () => "API Running");

app.Run();