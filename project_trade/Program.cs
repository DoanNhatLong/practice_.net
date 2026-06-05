using Microsoft.EntityFrameworkCore;
using project_trade.Entity;
using project_trade.Repo;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.MapGet("/", () => "API Running");

app.Run();
