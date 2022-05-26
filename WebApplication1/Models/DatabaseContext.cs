using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class DatabaseContext : IdentityDbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AreaDoCandidato> AreaDoCandidatos { get; set; } = null!;
        public virtual DbSet<Computadores> Computadores { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<Vaga> Vagas { get; set; } = null!;
        public virtual DbSet<FileModel> FileModels { get; set; } = null!;
        public virtual DbSet<FileOnDatabaseModel> FilesOnDatabase { get; set; } = null!;

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
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AreaDoCandidato>(entity =>
            {
                entity.HasKey(e => e.IdCandidato)
                    .HasName("PK__AreaDoCa__D55989051E22106C");

                entity.ToTable("AreaDoCandidato");

                entity.Property(e => e.CpfCandidato)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EmailCandidato)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.NomeCandidato)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TelefoneCandidato)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });


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

                entity.Property(e => e.UserSector)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);
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
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__5B65BF97C7325C8E");

                entity.HasIndex(e => e.ComputadorId, "IX_Usuarios_ComputadorId");

                entity.Property(e => e.NomeUsuario)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.SetorUsuario)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Computador)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.ComputadorId)
                    .HasConstraintName("FK__Usuarios__Comput__02FC7413");
            });

            modelBuilder.Entity<Vaga>(entity =>
            {
                entity.HasKey(e => e.IdVaga)
                    .HasName("PK__Vagas__A848DC3E3CDFF396");

                entity.Property(e => e.DescricaoVaga)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.NomeVaga)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.RequisitosVaga)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
