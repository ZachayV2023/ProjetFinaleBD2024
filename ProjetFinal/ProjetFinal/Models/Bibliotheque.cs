using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal.Models
{
    [Table("Bibliotheque")]
    public partial class Bibliotheque
    {
        public Bibliotheque()
        {
            Critiques = new HashSet<Critique>();
            Fonctions = new HashSet<Fonction>();
            MiseAjours = new HashSet<MiseAjour>();
            UtilisateurBibliotheques = new HashSet<UtilisateurBibliotheque>();
        }

        [Key]
        public int IdBibliotheque { get; set; }
        [StringLength(255)]
        public string Nom { get; set; } = null!;
        public string? Description { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateCreation { get; set; }
        [StringLength(255)]
        public string? Categorie { get; set; }
        public int? TotalTelechargements { get; set; }

        [InverseProperty("IdBibliothequeNavigation")]
        public virtual ICollection<Critique> Critiques { get; set; }
        [InverseProperty("IdBibliothequeNavigation")]
        public virtual ICollection<Fonction> Fonctions { get; set; }
        [InverseProperty("IdBibliothequeNavigation")]
        public virtual ICollection<MiseAjour> MiseAjours { get; set; }
        [InverseProperty("IdBibliothequeNavigation")]
        public virtual ICollection<UtilisateurBibliotheque> UtilisateurBibliotheques { get; set; }
    }
}
