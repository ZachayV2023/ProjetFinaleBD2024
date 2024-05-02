using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal.Models
{
    [Table("Fonction")]
    public partial class Fonction
    {
        [Key]
        public int IdFonction { get; set; }
        [StringLength(255)]
        public string Nom { get; set; } = null!;
        public string? Description { get; set; }
        public int? NombreLignesDeCode { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DernierUpdate { get; set; }
        public int? IdBibliotheque { get; set; }

        [ForeignKey("IdBibliotheque")]
        [InverseProperty("Fonctions")]
        public virtual Bibliotheque? IdBibliothequeNavigation { get; set; }
    }
}
