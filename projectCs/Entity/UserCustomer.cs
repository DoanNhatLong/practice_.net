using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace projectCs.Entity;

[Table("user_customer")]
[Index("CustomerId", Name = "customer_id")]
[Index("UserId", "CustomerId", Name = "uq_user_customer", IsUnique = true)]
public partial class UserCustomer
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("user_id")]
    public long UserId { get; set; }

    [Column("customer_id")]
    public long CustomerId { get; set; }

    [Column("assigned_at", TypeName = "timestamp")]
    public DateTime? AssignedAt { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("UserCustomers")]
    public virtual Customer Customer { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("UserCustomers")]
    public virtual User User { get; set; } = null!;
}
