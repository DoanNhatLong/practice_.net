using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace project_trade.Entity;

[Table("accounts")]
[Index("UserId", Name = "user_id")]
public partial class Account
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("user_id")]
    public int? UserId { get; set; }

    [Column("balance")]
    [Precision(20, 2)]
    public decimal? Balance { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Accounts")]
    public virtual User? User { get; set; }
}
