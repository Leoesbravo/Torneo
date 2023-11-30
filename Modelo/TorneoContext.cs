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

    public virtual DbSet<VistaPartidum> VistaPartida { get; set; }

    public virtual DbSet<VistaResumenJugadore> VistaResumenJugadores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:serverleotorneo.database.windows.net,1433;Initial Catalog=Torneo;Persist Security Info=False;User ID=leonardo;Password=pass@word1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DetallePartidum>(entity =>
        {
            entity.HasKey(e => e.IdDetalle).HasName("PK__DetalleP__E43646A55F267B87");

            entity.Property(e => e.Campeon)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Side)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.IdParticipanteNavigation).WithMany(p => p.DetallePartida)
                .HasForeignKey(d => d.IdParticipante)
                .HasConstraintName("FK__DetallePa__IdPar__22AA2996");

            entity.HasOne(d => d.IdPartidaNavigation).WithMany(p => p.DetallePartida)
                .HasForeignKey(d => d.IdPartida)
                .HasConstraintName("FK__DetallePa__IdPar__21B6055D");
        });

        modelBuilder.Entity<Participante>(entity =>
        {
            entity.HasKey(e => e.IdParticipante).HasName("PK__Particip__56139242C6368ADF");

            entity.ToTable("Participante");

            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Partidum>(entity =>
        {
            entity.HasKey(e => e.IdPartida).HasName("PK__Partida__6ED660C716EC946F");

            entity.Property(e => e.Duracion)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdParticipanteDosNavigation).WithMany(p => p.PartidumIdParticipanteDosNavigations)
                .HasForeignKey(d => d.IdParticipanteDos)
                .HasConstraintName("FK__Partida__IdParti__1DE57479");

            entity.HasOne(d => d.IdParticipanteUnoNavigation).WithMany(p => p.PartidumIdParticipanteUnoNavigations)
                .HasForeignKey(d => d.IdParticipanteUno)
                .HasConstraintName("FK__Partida__IdParti__1CF15040");

            entity.HasOne(d => d.IdRondaNavigation).WithMany(p => p.Partida)
                .HasForeignKey(d => d.IdRonda)
                .HasConstraintName("FK__Partida__IdRonda__1ED998B2");
        });

        modelBuilder.Entity<Rondum>(entity =>
        {
            entity.HasKey(e => e.IdRonda).HasName("PK__Ronda__D3E8E37ED12D176E");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VistaPartidum>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VistaPartida");

            entity.Property(e => e.Duracion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UsernameDos)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UsernameUno)
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
            entity.Property(e => e.PromedioDuracionMinutosSegundos)
                .HasMaxLength(61)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
