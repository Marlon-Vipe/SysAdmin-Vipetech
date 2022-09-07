using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace empleados.Models
{
    public partial class projectContext : DbContext
    {
        public projectContext()
        {
        }

        public projectContext(DbContextOptions<projectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ciudad> Ciudads { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Direccion> Direccions { get; set; } = null!;
        public virtual DbSet<Tiendum> Tienda { get; set; } = null!;
        public virtual DbSet<TipoCliente> TipoClientes { get; set; } = null!;
        public virtual DbSet<TipoDeVentum> TipoDeVenta { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=IAMVILLALONA\\IAMVILLALONA; Database=project; Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.ToTable("ciudad");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cliente");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cedula");

                entity.Property(e => e.IdCiudad).HasColumnName("idCiudad");

                entity.Property(e => e.IdDireccion).HasColumnName("idDireccion");

                entity.Property(e => e.IdTienda).HasColumnName("idTienda");

                entity.Property(e => e.IdTipoVenta).HasColumnName("idTipoVenta");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.Property(e => e.TipoCliente).HasColumnName("tipoCliente");

                entity.HasOne(d => d.IdCiudadNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdCiudad)
                    .HasConstraintName("FK__cliente__idCiuda__0D7A0286");

                entity.HasOne(d => d.IdDireccionNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdDireccion)
                    .HasConstraintName("FK__cliente__idDirec__0E6E26BF");

                entity.HasOne(d => d.IdTiendaNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdTienda)
                    .HasConstraintName("FK__cliente__idTiend__0F624AF8");

                entity.HasOne(d => d.IdTipoVentaNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdTipoVenta)
                    .HasConstraintName("FK__cliente__idTipoV__10566F31");

                entity.HasOne(d => d.TipoClienteNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.TipoCliente)
                    .HasConstraintName("FK__cliente__tipoCli__114A936A");
            });

            modelBuilder.Entity<Direccion>(entity =>
            {
                entity.ToTable("direccion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Tiendum>(entity =>
            {
                entity.ToTable("tienda");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<TipoCliente>(entity =>
            {
                entity.ToTable("tipoCliente");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<TipoDeVentum>(entity =>
            {
                entity.ToTable("tipoDeVenta");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
