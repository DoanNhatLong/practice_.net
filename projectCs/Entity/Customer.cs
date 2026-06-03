using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace projectCs.Entity;

[Table("customer")]
[Index("TaxCode", Name = "idx_customer_tax", IsUnique = true)]
public partial class Customer
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("company_name")]
    [StringLength(255)]
    public string CompanyName { get; set; } = null!;

    [Column("tax_code")]
    [StringLength(20)]
    public string TaxCode { get; set; } = null!;

    [Column("status", TypeName = "enum('ACTIVE','INACTIVE')")]
    public string? Status { get; set; }

    [Column("created_at", TypeName = "timestamp")]
    public DateTime? CreatedAt { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    [InverseProperty("Customer")]
    public virtual ICollection<UserCustomer> UserCustomers { get; set; } = new List<UserCustomer>();
}
