using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjetFinalV2.Models;

namespace ProjetFinalV2.Data;

public partial class DevLibraryDbContext : DbContext
{
    public DevLibraryDbContext()
    {
    }

    public DevLibraryDbContext(DbContextOptions<DevLibraryDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bibliotheque> Bibliotheques { get; set; }

    public virtual DbSet<Changelog> Changelogs { get; set; }

    public virtual DbSet<Critique> Critiques { get; set; }

    public virtual DbSet<Fonction> Fonctions { get; set; }

    public virtual DbSet<MiseAjour> MiseAjours { get; set; }

    public virtual DbSet<ReglageConfig> ReglageConfigs { get; set; }

    public virtual DbSet<Utilisateur> Utilisateurs { get; set; }

    public virtual DbSet<UtilisateurBibliotheque> UtilisateurBibliotheques { get; set; }

    public virtual DbSet<VueBibliothequeCritique> VueBibliothequeCritiques { get; set; }

    public virtual DbSet<VueEmailsChiffre> VueEmailsChiffres { get; set; }

    public virtual DbSet<VueEmailsDechiffre> VueEmailsDechiffres { get; set; }

    public virtual DbSet<VueUserDownload> VueUserDownloads { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DevLibraryBD");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bibliotheque>(entity =>
        {
            entity.HasKey(e => e.IdBibliotheque).HasName("PK__Biblioth__142260526F801385");

            entity.Property(e => e.TotalTelechargements).HasDefaultValue(0);
        });

        modelBuilder.Entity<Changelog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__changelo__3213E83F72BBDEEC");

            entity.Property(e => e.InstalledOn).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Critique>(entity =>
        {
            entity.HasKey(e => e.IdCritique).HasName("PK__Critique__55055BB91882BEA8");

            entity.HasOne(d => d.IdBibliothequeNavigation).WithMany(p => p.Critiques).HasConstraintName("FK__Critique__IdBibl__4316F928");
        });

        modelBuilder.Entity<Fonction>(entity =>
        {
            entity.HasKey(e => e.IdFonction).HasName("PK__Fonction__94765FBBBFA1F333");

            entity.HasOne(d => d.IdBibliothequeNavigation).WithMany(p => p.Fonctions).HasConstraintName("FK__Fonction__IdBibl__45F365D3");
        });

        modelBuilder.Entity<MiseAjour>(entity =>
        {
            entity.HasKey(e => e.IdMiseAjour).HasName("PK__MiseAJou__E261F1B01A930BF5");

            entity.HasOne(d => d.IdBibliothequeNavigation).WithMany(p => p.MiseAjours)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__MiseAJour__IdBib__3F466844");
        });

        modelBuilder.Entity<ReglageConfig>(entity =>
        {
            entity.HasKey(e => e.IdConfig).HasName("PK__ReglageC__79F2176463F5733F");

            entity.Property(e => e.NotificationAct).HasDefaultValue(false);
        });

        modelBuilder.Entity<Utilisateur>(entity =>
        {
            entity.HasKey(e => e.IdUtilisateur).HasName("PK__Utilisat__45A4C1570E085DAE");

            entity.HasIndex(e => e.Email, "UX_Utilisateur_Email")
                .IsUnique()
                .HasFilter("([Email] IS NOT NULL)");
        });

        modelBuilder.Entity<UtilisateurBibliotheque>(entity =>
        {
            entity.HasKey(e => new { e.IdUtilisateur, e.IdBibliotheque }).HasName("PK__Utilisat__74E6E75295DCE567");

            entity.HasOne(d => d.IdBibliothequeNavigation).WithMany(p => p.UtilisateurBibliotheques)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Utilisate__IdBib__4BAC3F29");
        });

        modelBuilder.Entity<VueBibliothequeCritique>(entity =>
        {
            entity.ToView("VueBibliothequeCritiques");
            entity.HasKey(e => e.Nom); //<-- Rajouter la ligne suivante
        });

        modelBuilder.Entity<VueEmailsChiffre>(entity =>
        {
            entity.ToView("VueEmailsChiffres");
            entity.HasKey(e => e.IdUtilisateur); //<-- Rajouter la ligne suivante
            entity.Property(e => e.IdUtilisateur).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<VueEmailsDechiffre>(entity =>
        {
            entity.ToView("VueEmailsDechiffres");
            entity.HasKey(e => e.IdUtilisateur); //<-- Rajouter la ligne suivante
            entity.Property(e => e.IdUtilisateur).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<VueUserDownload>(entity =>
        {
            entity.ToView("VueUserDownloads");
            entity.HasKey(e => e.IdUtilisateur); //<-- Rajouter la ligne suivante
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
