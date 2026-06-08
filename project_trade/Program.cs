using Microsoft.EntityFrameworkCore;
using project_trade.Entity;
using project_trade.Repo;
using project_trade.Repository;
using project_trade.Service;
using project_trade.Security;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<IPortfoliosRepository, PortfoliosRepository>();
builder.Services.AddScoped<IPortfoliosService, PortfoliosService>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddJwtAuthentication(builder.Configuration);


var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.MapControllers();

app.MapGet("/", () => "API Running");

app.Run();
