using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace projectCs.Entity;

[Table("document_item")]
[Index("DocumentId", Name = "document_id")]
public partial class DocumentItem
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("document_id")]
    public long DocumentId { get; set; }

    [Column("item_name")]
    [StringLength(255)]
    public string ItemName { get; set; } = null!;

    [Column("quantity")]
    public int? Quantity { get; set; }

    [Column("unit_price")]
    [Precision(15, 2)]
    public decimal? UnitPrice { get; set; }

    [Column("vat_rate", TypeName = "enum('TAX_0','TAX_5','TAX_8','TAX_10','NONE')")]
    public string? VatRate { get; set; }

    [Column("amount")]
    [Precision(15, 2)]
    public decimal Amount { get; set; }

    [ForeignKey("DocumentId")]
    [InverseProperty("DocumentItems")]
    public virtual Document Document { get; set; } = null!;
}
