using Microsoft.EntityFrameworkCore;

namespace project_ocr.data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        
    }
    public DbSet<project_ocr.entity.Customer> Customers { get; set; }
}