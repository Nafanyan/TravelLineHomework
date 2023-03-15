using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Shop.Databases;

public partial class ShopContext : DbContext
{
    public ShopContext()
    {
    }

    public ShopContext(DbContextOptions<ShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Shop");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {

            entity
                //.HasNoKey()
                .ToTable("PRODUCT");

            entity.Property(e => e.CountInStock).HasColumnName("count_in_stock");
            entity.Property(e => e.DescriptionProduct)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description_product");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.NameProduct)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name_product");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 3)")
                .HasColumnName("price");
            entity.Property(e => e.TypeProduct)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("type_product");
            entity.Property(e => e.WeightProduct).HasColumnName("weight_product");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
