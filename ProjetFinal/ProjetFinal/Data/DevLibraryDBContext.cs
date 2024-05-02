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

        public virtual DbSet<Bibliotheque> Bibliotheques { get; set; } = null!;
        public virtual DbSet<Changelog> Changelogs { get; set; } = null!;
        public virtual DbSet<Critique> Critiques { get; set; } = null!;
        public virtual DbSet<Fonction> Fonctions { get; set; } = null!;
        public virtual DbSet<MiseAjour> MiseAjours { get; set; } = null!;
        public virtual DbSet<ReglageConfig> ReglageConfigs { get; set; } = null!;
        public virtual DbSet<Utilisateur> Utilisateurs { get; set; } = null!;
        public virtual DbSet<UtilisateurBibliotheque> UtilisateurBibliotheques { get; set; } = null!;
        public virtual DbSet<VueBibliothequeCritique> VueBibliothequeCritiques { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DevLibraryBD");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bibliotheque>(entity =>
            {
                entity.HasKey(e => e.IdBibliotheque)
                    .HasName("PK__Biblioth__142260529207214F");

                entity.Property(e => e.TotalTelechargements).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Changelog>(entity =>
            {
                entity.Property(e => e.InstalledOn).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Critique>(entity =>
            {
                entity.HasKey(e => e.IdCritique)
                    .HasName("PK__Critique__55055BB9712BE472");

                entity.HasOne(d => d.IdBibliothequeNavigation)
                    .WithMany(p => p.Critiques)
                    .HasForeignKey(d => d.IdBibliotheque)
                    .HasConstraintName("FK__Critique__IdBibl__52593CB8");
            });

            modelBuilder.Entity<Fonction>(entity =>
            {
                entity.HasKey(e => e.IdFonction)
                    .HasName("PK__Fonction__94765FBB7ED1ECEC");

                entity.HasOne(d => d.IdBibliothequeNavigation)
                    .WithMany(p => p.Fonctions)
                    .HasForeignKey(d => d.IdBibliotheque)
                    .HasConstraintName("FK__Fonction__IdBibl__5535A963");
            });

            modelBuilder.Entity<MiseAjour>(entity =>
            {
                entity.HasKey(e => e.IdMiseAjour)
                    .HasName("PK__MiseAJou__E261F1B079BF8677");

                entity.HasOne(d => d.IdBibliothequeNavigation)
                    .WithMany(p => p.MiseAjours)
                    .HasForeignKey(d => d.IdBibliotheque)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__MiseAJour__IdBib__4E88ABD4");
            });

            modelBuilder.Entity<ReglageConfig>(entity =>
            {
                entity.HasKey(e => e.IdConfig)
                    .HasName("PK__ReglageC__79F217644E7A2FA3");

                entity.Property(e => e.NotificationAct).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Utilisateur>(entity =>
            {
                entity.HasKey(e => e.IdUtilisateur)
                    .HasName("PK__Utilisat__45A4C15750F8855C");

                entity.HasIndex(e => e.Email, "UX_Utilisateur_Email")
                    .IsUnique()
                    .HasFilter("([Email] IS NOT NULL)");
            });

            modelBuilder.Entity<UtilisateurBibliotheque>(entity =>
            {
                entity.HasKey(e => new { e.IdUtilisateur, e.IdBibliotheque })
                    .HasName("PK__Utilisat__74E6E75293ECA321");

                entity.HasOne(d => d.IdBibliothequeNavigation)
                    .WithMany(p => p.UtilisateurBibliotheques)
                    .HasForeignKey(d => d.IdBibliotheque)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Utilisate__IdBib__5AEE82B9");
            });

            modelBuilder.Entity<VueBibliothequeCritique>(entity =>
            {
                entity.ToView("VueBibliothequeCritiques");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
