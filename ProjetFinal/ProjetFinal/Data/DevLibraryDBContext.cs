using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProjetFinal.Models;

namespace ProjetFinal.Data
{
    public partial class DevLibraryDBContext : DbContext
    {
        public DevLibraryDBContext()
        {
        }

        public DevLibraryDBContext(DbContextOptions<DevLibraryDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bibliothèque> Bibliothèques { get; set; } = null!;
        public virtual DbSet<Critique> Critiques { get; set; } = null!;
        public virtual DbSet<Fonction> Fonctions { get; set; } = null!;
        public virtual DbSet<MiseÀjour> MiseÀjours { get; set; } = null!;
        public virtual DbSet<RéglageConfig> RéglageConfigs { get; set; } = null!;
        public virtual DbSet<Utilisateur> Utilisateurs { get; set; } = null!;
        public virtual DbSet<UtilisateurBibliothèque> UtilisateurBibliothèques { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=DevLibraryBD");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bibliothèque>(entity =>
            {
                entity.HasKey(e => e.IdBibliothèque)
                    .HasName("PK__Biblioth__F72082DB73E74F75");

                entity.Property(e => e.TotalTelechargements).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Critique>(entity =>
            {
                entity.HasKey(e => e.IdCritique)
                    .HasName("PK__Critique__55055BB9C2622D1C");

                entity.HasOne(d => d.IdBibliothèqueNavigation)
                    .WithMany(p => p.Critiques)
                    .HasForeignKey(d => d.IdBibliothèque)
                    .HasConstraintName("FK__Critique__IdBibl__3F466844");
            });

            modelBuilder.Entity<Fonction>(entity =>
            {
                entity.HasKey(e => e.IdFonction)
                    .HasName("PK__Fonction__94765FBB83E983F7");

                entity.HasOne(d => d.IdBibliothèqueNavigation)
                    .WithMany(p => p.Fonctions)
                    .HasForeignKey(d => d.IdBibliothèque)
                    .HasConstraintName("FK__Fonction__IdBibl__4222D4EF");
            });

            modelBuilder.Entity<MiseÀjour>(entity =>
            {
                entity.HasKey(e => e.IdMiseÀjour)
                    .HasName("PK__MiseÀJou__F33E08CD5A31FC0B");

                entity.HasOne(d => d.IdBibliothèqueNavigation)
                    .WithMany(p => p.MiseÀjours)
                    .HasForeignKey(d => d.IdBibliothèque)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__MiseÀJour__IdBib__3B75D760");
            });

            modelBuilder.Entity<RéglageConfig>(entity =>
            {
                entity.HasKey(e => e.IdConfig)
                    .HasName("PK__RéglageC__79F21764E335B3C2");

                entity.Property(e => e.NotificationAct).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Utilisateur>(entity =>
            {
                entity.HasKey(e => e.IdUtilisateur)
                    .HasName("PK__Utilisat__45A4C1575F59770B");

                entity.HasIndex(e => e.Email, "UX_Utilisateur_Email")
                    .IsUnique()
                    .HasFilter("([Email] IS NOT NULL)");
            });

            modelBuilder.Entity<UtilisateurBibliothèque>(entity =>
            {
                entity.HasKey(e => new { e.IdUtilisateur, e.IdBibliothèque })
                    .HasName("PK__Utilisat__EAD6C97A78ACC11A");

                entity.HasOne(d => d.IdBibliothèqueNavigation)
                    .WithMany(p => p.UtilisateurBibliothèques)
                    .HasForeignKey(d => d.IdBibliothèque)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Utilisate__IdBib__47DBAE45");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
