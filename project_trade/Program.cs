using Microsoft.EntityFrameworkCore;
using System.Data;
using MySqlConnector;
using StackExchange.Redis;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;
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
builder.Services.AddSingleton<IConnectionMultiplexer>
(
 sp => ConnectionMultiplexer.Connect("localhost:6379")
 );
builder.Services.AddScoped<IDbConnection>(sp =>
    new MySqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<project_trade.Service.LeaderboardService>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
.AddCookie()
  .AddGoogle(
options =>
{
    // .NET sẽ tự động tìm trong User Secrets trước
    options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
    options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
});


var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.MapGet("/", () => "API Running");

app.Run();
