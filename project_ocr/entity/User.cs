using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace project_ocr.entity;

[Table("user")]
[Index("Email", Name = "email", IsUnique = true)]
[Index("GoogleId", Name = "google_id", IsUnique = true)]
public partial class User
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("email")]
    [StringLength(100)]
    public string Email { get; set; } = null!;

    [Column("password_hash")]
    [StringLength(255)]
    public string? PasswordHash { get; set; }

    [Column("full_name")]
    [StringLength(100)]
    public string FullName { get; set; } = null!;

    [Column("google_id")]
    public string? GoogleId { get; set; }

    [Column("role", TypeName = "enum('ADMIN','USER')")]
    public string? Role { get; set; }

    [Column("status", TypeName = "enum('ACTIVE','INACTIVE')")]
    public string? Status { get; set; }

    [Column("created_at", TypeName = "timestamp")]
    public DateTime? CreatedAt { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();

    [InverseProperty("User")]
    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    [InverseProperty("User")]
    public virtual ICollection<UserCustomer> UserCustomers { get; set; } = new List<UserCustomer>();
}
