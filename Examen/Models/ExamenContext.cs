using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Examen.Models;

public partial class ExamenContext : DbContext
{
    public ExamenContext()
    {
    }

    public ExamenContext(DbContextOptions<ExamenContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Dato> Datos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    => optionsBuilder.UseSqlServer("server=DESKTOP-30VD0R3\\SQLEXPRESS; database=Examen; integrated security=true; Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dato>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Datos__3213E83FA7820DA8");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Altura).HasColumnName("altura");
            entity.Property(e => e.ApeMaterno)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("ape_Materno");
            entity.Property(e => e.ApePaterno)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("ape_Paterno");
            entity.Property(e => e.Correo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("correo");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Sexo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sexo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
