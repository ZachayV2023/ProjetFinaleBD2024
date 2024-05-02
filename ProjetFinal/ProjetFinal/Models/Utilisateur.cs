using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal.Models
{
    [Table("Utilisateur")]
    public partial class Utilisateur
    {
        [Key]
        public int IdUtilisateur { get; set; }
        [StringLength(255)]
        public string Nom { get; set; } = null!;
        [StringLength(255)]
        public string Email { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime DateInscription { get; set; }
        public string? LangagesDeProgrammation { get; set; }
        public string? BibliothequesPreferees { get; set; }
        [StringLength(255)]
        public string? Rue { get; set; }
        [StringLength(255)]
        public string? Ville { get; set; }
        [StringLength(255)]
        public string? Pays { get; set; }
        [StringLength(20)]
        public string? CodePostal { get; set; }
    }
}
