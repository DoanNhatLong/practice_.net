using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace project_trade.Entity;

[Table("order_types")]
public partial class OrderType
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("type_name")]
    [StringLength(20)]
    public string TypeName { get; set; } = null!;

    [InverseProperty("OrderType")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
