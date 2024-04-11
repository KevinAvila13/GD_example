using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GD_example.Models;

public partial class GuatemaladigitalContext : DbContext
{
    public GuatemaladigitalContext()
    {
    }

    public GuatemaladigitalContext(DbContextOptions<GuatemaladigitalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Ventum> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MSI\\SQLEXPRESS; Database=Guatemaladigital; Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.CodigoCategoria).HasName("PK__categori__3CEE2F4C630ED996");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.CodigoProducto).HasName("PK__Producto__785B009E4069245A");

            entity.ToTable("Producto");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.CodigoCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CodigoCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Producto_Categoria");
        });

        modelBuilder.Entity<Ventum>(entity =>
        {
            entity.HasKey(e => e.CodigoVenta).HasName("PK__Venta__F2421464169DCA1E");

            entity.HasOne(d => d.CodigoProductoNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.CodigoProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Venta_Producto");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
