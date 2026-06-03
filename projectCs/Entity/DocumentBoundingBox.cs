using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace projectCs.Entity;

[Table("document_bounding_box")]
[Index("DocumentId", Name = "document_id")]
public partial class DocumentBoundingBox
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("document_id")]
    public long DocumentId { get; set; }

    [Column("field_name")]
    [StringLength(100)]
    public string FieldName { get; set; } = null!;

    [Column("x_coord")]
    public double XCoord { get; set; }

    [Column("y_coord")]
    public double YCoord { get; set; }

    [Column("width")]
    public double Width { get; set; }

    [Column("height")]
    public double Height { get; set; }

    [Column("page_number")]
    public int? PageNumber { get; set; }

    [ForeignKey("DocumentId")]
    [InverseProperty("DocumentBoundingBoxes")]
    public virtual Document Document { get; set; } = null!;
}
