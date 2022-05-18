using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Computadores> Computadores { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=PC3369\\RalphDatabase;Database=Database2;user id=sa; password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Computadores>(entity =>
            {
                entity.HasKey(e => e.IdComputador)
                    .HasName("PK__Computad__F01A97937997213E");

                entity.Property(e => e.IdComputador).HasColumnName("Id_computador");

                entity.Property(e => e.Marca)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("marca");

                entity.Property(e => e.MemoriaRam).HasColumnName("memoria_ram");

                entity.Property(e => e.Modelo)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("modelo");

                entity.Property(e => e.NumPatrimonio).HasColumnName("num_patrimonio");

                entity.Property(e => e.NumSerie).HasColumnName("num_serie");

                entity.Property(e => e.Processador)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("processador");

                entity.Property(e => e.So)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("SO");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.IdComputador).HasColumnName("Id_computador");

                entity.Property(e => e.Nome)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Setor)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("setor");

                entity.HasOne(d => d.IdComputadorNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdComputador)
                    .HasConstraintName("FK__Usuarios__Id_com__5BE2A6F2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
