using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace project_trade.Entity;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderType> OrderTypes { get; set; }

    public virtual DbSet<Portfolio> Portfolios { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=trade11;user=root;password=ad1412", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.4.7-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Balance).HasDefaultValueSql("'0.00'");

            entity.HasOne(d => d.User).WithMany(p => p.Accounts).HasConstraintName("accounts_ibfk_1");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.OrderDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.OrderType).WithMany(p => p.Orders).HasConstraintName("orders_ibfk_3");

            entity.HasOne(d => d.Stock).WithMany(p => p.Orders).HasConstraintName("orders_ibfk_2");

            entity.HasOne(d => d.User).WithMany(p => p.Orders).HasConstraintName("orders_ibfk_1");
        });

        modelBuilder.Entity<OrderType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<Portfolio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasOne(d => d.Stock).WithMany(p => p.Portfolios).HasConstraintName("portfolios_ibfk_2");

            entity.HasOne(d => d.User).WithMany(p => p.Portfolios).HasConstraintName("portfolios_ibfk_1");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.TotalTradedVolume).HasDefaultValueSql("'0.00'");

            entity.HasOne(d => d.Role).WithMany(p => p.Users).HasConstraintName("users_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
