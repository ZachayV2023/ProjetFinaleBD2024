using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal.Models
{
    [Table("Bibliothèque")]
    public partial class Bibliothèque
    {
        public Bibliothèque()
        {
            Critiques = new HashSet<Critique>();
            Fonctions = new HashSet<Fonction>();
            MiseÀjours = new HashSet<MiseÀjour>();
            UtilisateurBibliothèques = new HashSet<UtilisateurBibliothèque>();
        }

        [Key]
        public int IdBibliothèque { get; set; }
        [StringLength(255)]
        public string Nom { get; set; } = null!;
        public string? Description { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateCreation { get; set; }
        [StringLength(255)]
        public string? Categorie { get; set; }
        public int? TotalTelechargements { get; set; }

        [InverseProperty("IdBibliothèqueNavigation")]
        public virtual ICollection<Critique> Critiques { get; set; }
        [InverseProperty("IdBibliothèqueNavigation")]
        public virtual ICollection<Fonction> Fonctions { get; set; }
        [InverseProperty("IdBibliothèqueNavigation")]
        public virtual ICollection<MiseÀjour> MiseÀjours { get; set; }
        [InverseProperty("IdBibliothèqueNavigation")]
        public virtual ICollection<UtilisateurBibliothèque> UtilisateurBibliothèques { get; set; }
    }
}
