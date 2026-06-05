using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace project_trade.Entity;

[Table("stocks")]
public partial class Stock
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("symbol")]
    [StringLength(10)]
    public string Symbol { get; set; } = null!;

    [Column("current_price")]
    [Precision(20, 2)]
    public decimal CurrentPrice { get; set; }

    [InverseProperty("Stock")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [InverseProperty("Stock")]
    public virtual ICollection<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
}
