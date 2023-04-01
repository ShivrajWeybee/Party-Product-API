using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PartyProductAPI.Data
{
    public partial class InvoiceAppContext : DbContext
    {
        public InvoiceAppContext()
        {
        }

        public InvoiceAppContext(DbContextOptions<InvoiceAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AssignedPartyProduct> AssignedPartyProducts { get; set; }
        public virtual DbSet<GetAllInvoice> GetAllInvoices { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Party> Parties { get; set; }
        public virtual DbSet<PartyProduct> PartyProducts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductRate> ProductRates { get; set; }
        public virtual DbSet<ProductWithRate> ProductWithRates { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AssignedPartyProduct>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("AssignedPartyProduct");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PartyName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GetAllInvoice>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GetAllInvoice");

                entity.Property(e => e.PartyName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoice");

                entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");

                entity.Property(e => e.PartyId).HasColumnName("PartyID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Party)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.PartyId);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.ProductId);
            });

            modelBuilder.Entity<Party>(entity =>
            {
                entity.ToTable("Party");

                entity.Property(e => e.PartyId).HasColumnName("PartyID");

                entity.Property(e => e.PartyName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PartyProduct>(entity =>
            {
                entity.ToTable("Party_Product");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PartyId).HasColumnName("PartyID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Party)
                    .WithMany(p => p.PartyProducts)
                    .HasForeignKey(d => d.PartyId)
                    .HasConstraintName("FK_PartyProduct_Party_PartyID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PartyProducts)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_PartyProduct_Product_ProductID");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Rate).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<ProductRate>(entity =>
            {
                entity.HasKey(e => e.PrtId)
                    .HasName("PK_ProductRate_PrtID");

                entity.ToTable("ProductRate");

                entity.Property(e => e.PrtId).HasColumnName("PrtID");

                entity.Property(e => e.DateOfRate).HasColumnType("date");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Rate).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductRates)
                    .HasForeignKey(d => d.ProductId);
            });

            modelBuilder.Entity<ProductWithRate>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ProductWithRate");

                entity.Property(e => e.DateOfRate).HasColumnType("date");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PrtId).HasColumnName("PrtID");

                entity.Property(e => e.Rate).HasColumnType("decimal(10, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
