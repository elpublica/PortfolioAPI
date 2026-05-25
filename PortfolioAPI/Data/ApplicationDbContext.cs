using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PortfolioAPI.Models;

namespace PortfolioAPI.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Conocimientos> Conocimientos { get; set; }

    public virtual DbSet<Estudios> Estudios { get; set; }

    public virtual DbSet<ExperienciaLaboral> ExperienciaLaborals { get; set; }

    public virtual DbSet<HabilidadesBlandas> HabilidadesBlandas { get; set; }

    public virtual DbSet<MisIdiomas> MisIdiomas { get; set; }

    public virtual DbSet<PerfilPersonal> PerfilPersonals { get; set; }

    public virtual DbSet<Proyectos> Proyectos { get; set; }

    public virtual DbSet<ProyectoImagenes> ProyectoImagenes { get; set; }

    public virtual DbSet<RedesSociales> RedesSociales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=. \\SQLEXPRESS;Database=PortafolioDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Conocimientos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Conocimi__3214EC07BFC152F3");

            entity.Property(e => e.Categoria).HasMaxLength(50);
            entity.Property(e => e.IconoClass).HasMaxLength(50);
            entity.Property(e => e.Nivel).HasMaxLength(20);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Estudios>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Estudios__3214EC079328A735");

            entity.Property(e => e.EsCertificacion).HasDefaultValue(false);
            entity.Property(e => e.FechaPeriodo).HasMaxLength(100);
            entity.Property(e => e.Grado).HasMaxLength(150);
            entity.Property(e => e.Idioma)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValue("es")
                .IsFixedLength();
            entity.Property(e => e.Institucion).HasMaxLength(150);
        });

        modelBuilder.Entity<ExperienciaLaboral>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Experien__3214EC071DC0766A");

            entity.ToTable("ExperienciaLaboral");

            entity.HasIndex(e => e.Idioma, "IX_Experiencia_Idioma");

            entity.Property(e => e.Empresa).HasMaxLength(150);
            entity.Property(e => e.FechaFin).HasMaxLength(50);
            entity.Property(e => e.FechaInicio).HasMaxLength(50);
            entity.Property(e => e.Idioma)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValue("es")
                .IsFixedLength();
            entity.Property(e => e.Puesto).HasMaxLength(150);
        });

        modelBuilder.Entity<HabilidadesBlandas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Habilida__3214EC07457DE36F");

            entity.Property(e => e.Habilidad).HasMaxLength(100);
            entity.Property(e => e.Idioma)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValue("es")
                .IsFixedLength();
        });

        modelBuilder.Entity<MisIdiomas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MisIdiom__3214EC07ADCEBD88");

            entity.Property(e => e.Certificacion).HasMaxLength(100);
            entity.Property(e => e.Nivel).HasMaxLength(50);
            entity.Property(e => e.NombreIdioma).HasMaxLength(50);
            entity.Property(e => e.PorcentajeDominio).HasDefaultValue(0);
        });

        modelBuilder.Entity<PerfilPersonal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PerfilPe__3214EC077EB96967");

            entity.ToTable("PerfilPersonal");

            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.FotoPerfilUrl).HasColumnName("FotoPerfilURL");
            entity.Property(e => e.Idioma)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValue("es")
                .IsFixedLength();
            entity.Property(e => e.NombreCompleto).HasMaxLength(150);
            entity.Property(e => e.Telefono).HasMaxLength(20);
            entity.Property(e => e.TituloProfesional).HasMaxLength(100);
            entity.Property(e => e.Ubicacion).HasMaxLength(100);
            entity.Property(e => e.UrlCv).HasColumnName("URL_CV");
        });

        modelBuilder.Entity<Proyectos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proyecto__3214EC078DC0978E");

            entity.ToTable(tb => tb.HasTrigger("TR_Proyectos_Update"));

            entity.HasIndex(e => e.ExperienciaId, "IX_Proyectos_Experiencia");

            entity.HasIndex(e => e.Idioma, "IX_Proyectos_Idioma");

            entity.Property(e => e.Area).HasMaxLength(100);
            entity.Property(e => e.FechaActualizacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Idioma)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValue("es")
                .IsFixedLength();
            entity.Property(e => e.Nombre).HasMaxLength(150);
            entity.Property(e => e.ResumenCorto).HasMaxLength(255);

            entity.HasOne(d => d.Experiencia).WithMany(p => p.Proyectos)
                .HasForeignKey(d => d.ExperienciaId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Proyectos_Experiencia");
        });

        modelBuilder.Entity<ProyectoImagenes>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proyecto__3214EC07B047A3AF");

            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.Orden).HasDefaultValue(0);
            entity.Property(e => e.Url).HasColumnName("URL");

            entity.HasOne(d => d.Proyecto).WithMany(p => p.ProyectoImagenes)
                .HasForeignKey(d => d.ProyectoId)
                .HasConstraintName("FK_Proyecto_Imagenes");
        });

        modelBuilder.Entity<RedesSociales>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RedesSoc__3214EC071C790248");

            entity.Property(e => e.IconoClass).HasMaxLength(50);
            entity.Property(e => e.Plataforma).HasMaxLength(50);
            entity.Property(e => e.Url).HasColumnName("URL");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
