using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace project_ocr.entity;

[Table("document")]
[Index("CustomerId", Name = "customer_id")]
[Index("DocumentType", "ReferenceNumber", Name = "idx_doc_type_ref")]
[Index("UserId", Name = "user_id")]
public partial class Document
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("customer_id")]
    public long CustomerId { get; set; }

    [Column("user_id")]
    public long UserId { get; set; }

    [Column("document_type", TypeName = "enum('INVOICE','RECEIPT','PAYMENT','WAREHOUSE_IMPORT')")]
    public string DocumentType { get; set; } = null!;

    [Column("reference_number")]
    [StringLength(50)]
    public string ReferenceNumber { get; set; } = null!;

    [Column("issue_date")]
    public DateOnly IssueDate { get; set; }

    [Column("partner_name")]
    [StringLength(255)]
    public string PartnerName { get; set; } = null!;

    [Column("partner_tax_code")]
    [StringLength(20)]
    public string? PartnerTaxCode { get; set; }

    [Column("total_amount")]
    [Precision(15, 2)]
    public decimal TotalAmount { get; set; }

    [Column("status", TypeName = "enum('PENDING','PROCESSING','PROCESSED','ERROR')")]
    public string? Status { get; set; }

    [Column("file_path")]
    [StringLength(512)]
    public string? FilePath { get; set; }

    [Column("ocr_raw_result", TypeName = "json")]
    public string? OcrRawResult { get; set; }

    [Column("created_at", TypeName = "timestamp")]
    public DateTime? CreatedAt { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("Documents")]
    public virtual Customer Customer { get; set; } = null!;

    [InverseProperty("Document")]
    public virtual ICollection<DocumentBoundingBox> DocumentBoundingBoxes { get; set; } = new List<DocumentBoundingBox>();

    [InverseProperty("Document")]
    public virtual ICollection<DocumentItem> DocumentItems { get; set; } = new List<DocumentItem>();

    [ForeignKey("UserId")]
    [InverseProperty("Documents")]
    public virtual User User { get; set; } = null!;
}
