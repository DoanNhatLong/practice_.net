using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace project_ocr.entity;

public partial class AccountingDbContext : DbContext
{
    public AccountingDbContext()
    {
    }

    public AccountingDbContext(DbContextOptions<AccountingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AuditLog> AuditLogs { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<DocumentBoundingBox> DocumentBoundingBoxes { get; set; }

    public virtual DbSet<DocumentItem> DocumentItems { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserCustomer> UserCustomers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=accounting;user=root;password=ad1412", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.4.7-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("audit_log");

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Action)
                .HasMaxLength(100)
                .HasColumnName("action");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("tinytext")
                .HasColumnName("description");
            entity.Property(e => e.IpAddress)
                .HasMaxLength(45)
                .HasColumnName("ip_address");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.AuditLogs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("audit_log_ibfk_1");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("customer");

            entity.HasIndex(e => e.TaxCode, "idx_customer_tax").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(255)
                .HasColumnName("company_name");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Status)
                .HasColumnType("enum('ACTIVE','INACTIVE')")
                .HasColumnName("status");
            entity.Property(e => e.TaxCode)
                .HasMaxLength(20)
                .HasColumnName("tax_code");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("document");

            entity.HasIndex(e => e.CustomerId, "customer_id");

            entity.HasIndex(e => new { e.DocumentType, e.ReferenceNumber }, "idx_doc_type_ref");

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.DocumentType)
                .HasColumnType("enum('INVOICE','RECEIPT','PAYMENT','WAREHOUSE_IMPORT')")
                .HasColumnName("document_type");
            entity.Property(e => e.FilePath)
                .HasMaxLength(512)
                .HasColumnName("file_path");
            entity.Property(e => e.IssueDate).HasColumnName("issue_date");
            entity.Property(e => e.OcrRawResult)
                .HasColumnType("json")
                .HasColumnName("ocr_raw_result");
            entity.Property(e => e.PartnerName)
                .HasMaxLength(255)
                .HasColumnName("partner_name");
            entity.Property(e => e.PartnerTaxCode)
                .HasMaxLength(20)
                .HasColumnName("partner_tax_code");
            entity.Property(e => e.ReferenceNumber)
                .HasMaxLength(50)
                .HasColumnName("reference_number");
            entity.Property(e => e.Status)
                .HasColumnType("enum('PENDING','PROCESSING','PROCESSED','ERROR')")
                .HasColumnName("status");
            entity.Property(e => e.TotalAmount)
                .HasPrecision(15, 2)
                .HasColumnName("total_amount");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.Documents)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("document_ibfk_1");

            entity.HasOne(d => d.User).WithMany(p => p.Documents)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("document_ibfk_2");
        });

        modelBuilder.Entity<DocumentBoundingBox>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("document_bounding_box");

            entity.HasIndex(e => e.DocumentId, "document_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DocumentId).HasColumnName("document_id");
            entity.Property(e => e.FieldName)
                .HasMaxLength(100)
                .HasColumnName("field_name");
            entity.Property(e => e.Height).HasColumnName("height");
            entity.Property(e => e.PageNumber)
                .HasDefaultValueSql("'1'")
                .HasColumnName("page_number");
            entity.Property(e => e.Width).HasColumnName("width");
            entity.Property(e => e.XCoord).HasColumnName("x_coord");
            entity.Property(e => e.YCoord).HasColumnName("y_coord");

            entity.HasOne(d => d.Document).WithMany(p => p.DocumentBoundingBoxes)
                .HasForeignKey(d => d.DocumentId)
                .HasConstraintName("document_bounding_box_ibfk_1");
        });

        modelBuilder.Entity<DocumentItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("document_item");

            entity.HasIndex(e => e.DocumentId, "document_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasPrecision(15, 2)
                .HasColumnName("amount");
            entity.Property(e => e.DocumentId).HasColumnName("document_id");
            entity.Property(e => e.ItemName)
                .HasMaxLength(255)
                .HasColumnName("item_name");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.UnitPrice)
                .HasPrecision(15, 2)
                .HasColumnName("unit_price");
            entity.Property(e => e.VatRate)
                .HasColumnType("enum('TAX_0','TAX_5','TAX_8','TAX_10','NONE')")
                .HasColumnName("vat_rate");

            entity.HasOne(d => d.Document).WithMany(p => p.DocumentItems)
                .HasForeignKey(d => d.DocumentId)
                .HasConstraintName("document_item_ibfk_1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user");

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.HasIndex(e => e.GoogleId, "google_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .HasColumnName("full_name");
            entity.Property(e => e.GoogleId).HasColumnName("google_id");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");
            entity.Property(e => e.Role)
                .HasColumnType("enum('ADMIN','USER')")
                .HasColumnName("role");
            entity.Property(e => e.Status)
                .HasColumnType("enum('ACTIVE','INACTIVE')")
                .HasColumnName("status");
        });

        modelBuilder.Entity<UserCustomer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user_customer");

            entity.HasIndex(e => e.CustomerId, "customer_id");

            entity.HasIndex(e => new { e.UserId, e.CustomerId }, "uq_user_customer").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AssignedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("assigned_at");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.UserCustomers)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("user_customer_ibfk_2");

            entity.HasOne(d => d.User).WithMany(p => p.UserCustomers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("user_customer_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
