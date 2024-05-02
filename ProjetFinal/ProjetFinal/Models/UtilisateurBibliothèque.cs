using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal.Models
{
    [Table("UtilisateurBibliothèque")]
    public partial class UtilisateurBibliothèque
    {
        [Key]
        public int IdUtilisateur { get; set; }
        [Key]
        public int IdBibliothèque { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateTelechargement { get; set; }

        [ForeignKey("IdBibliothèque")]
        [InverseProperty("UtilisateurBibliothèques")]
        public virtual Bibliothèque IdBibliothèqueNavigation { get; set; } = null!;
    }
}
