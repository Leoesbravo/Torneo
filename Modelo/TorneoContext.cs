using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Modelo;

public partial class TorneoContext : DbContext
{
    public TorneoContext()
    {
    }

    public TorneoContext(DbContextOptions<TorneoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DetallePartidum> DetallePartida { get; set; }

    public virtual DbSet<Participante> Participantes { get; set; }

    public virtual DbSet<Partidum> Partida { get; set; }

    public virtual DbSet<Rondum> Ronda { get; set; }

    public virtual DbSet<VistaResumenJugadore> VistaResumenJugadores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost; Database= Torneo; TrustServerCertificate=True; Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DetallePartidum>(entity =>
        {
            entity.HasKey(e => e.IdDetalle).HasName("PK__DetalleP__E43646A51A6C3682");

            entity.Property(e => e.Campeon)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Side)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.IdParticipanteNavigation).WithMany(p => p.DetallePartida)
                .HasForeignKey(d => d.IdParticipante)
                .HasConstraintName("FK__DetallePa__IdPar__403A8C7D");

            entity.HasOne(d => d.IdPartidaNavigation).WithMany(p => p.DetallePartida)
                .HasForeignKey(d => d.IdPartida)
                .HasConstraintName("FK__DetallePa__IdPar__3F466844");
        });

        modelBuilder.Entity<Participante>(entity =>
        {
            entity.HasKey(e => e.IdParticipante).HasName("PK__Particip__56139242597B93FD");

            entity.ToTable("Participante");

            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Partidum>(entity =>
        {
            entity.HasKey(e => e.IdPartida).HasName("PK__Partida__6ED660C787B96653");

            entity.Property(e => e.Duracion)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdParticipanteDosNavigation).WithMany(p => p.PartidumIdParticipanteDosNavigations)
                .HasForeignKey(d => d.IdParticipanteDos)
                .HasConstraintName("FK__Partida__IdParti__3C69FB99");

            entity.HasOne(d => d.IdParticipanteUnoNavigation).WithMany(p => p.PartidumIdParticipanteUnoNavigations)
                .HasForeignKey(d => d.IdParticipanteUno)
                .HasConstraintName("FK__Partida__IdParti__3B75D760");
        });

        modelBuilder.Entity<Rondum>(entity =>
        {
            entity.HasKey(e => e.IdRonda).HasName("PK__Ronda__D3E8E37EB8655AD2");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VistaResumenJugadore>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VistaResumenJugadores");

            entity.Property(e => e.NombreJugador)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
