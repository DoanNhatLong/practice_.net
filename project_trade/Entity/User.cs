using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace project_trade.Entity;

[Table("users")]
[Index("Email", Name = "email", IsUnique = true)]
[Index("RoleId", Name = "role_id")]
[Index("Username", Name = "username", IsUnique = true)]
public partial class User
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("username")]
    [StringLength(50)]
    public string Username { get; set; } = null!;

    [Column("password_hash")]
    [StringLength(255)]
    public string? PasswordHash { get; set; } = null!;

    [Column("email")]
    [StringLength(100)]
    public string? Email { get; set; } = null!;

    [Column("role_id")]
    public int? RoleId { get; set; }

    [Column("total_traded_volume")]
    [Precision(20, 2)]
    public decimal? TotalTradedVolume { get; set; }

    [Column("created_at", TypeName = "timestamp")]
    public DateTime? CreatedAt { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    [InverseProperty("User")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [InverseProperty("User")]
    public virtual ICollection<Portfolio> Portfolios { get; set; } = new List<Portfolio>();

    [ForeignKey("RoleId")]
    [InverseProperty("Users")]
    public virtual Role? Role { get; set; }
}
