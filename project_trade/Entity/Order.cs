using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace project_trade.Entity;

[Table("orders")]
[Index("OrderTypeId", Name = "order_type_id")]
[Index("StockId", Name = "stock_id")]
[Index("UserId", Name = "user_id")]
public partial class Order
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("user_id")]
    public int? UserId { get; set; }

    [Column("stock_id")]
    public int? StockId { get; set; }

    [Column("order_type_id")]
    public int? OrderTypeId { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("price")]
    [Precision(20, 2)]
    public decimal Price { get; set; }

    [Column("order_date", TypeName = "timestamp")]
    public DateTime? OrderDate { get; set; }

    [ForeignKey("OrderTypeId")]
    [InverseProperty("Orders")]
    public virtual OrderType? OrderType { get; set; }

    [ForeignKey("StockId")]
    [InverseProperty("Orders")]
    public virtual Stock? Stock { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Orders")]
    public virtual User? User { get; set; }
}
