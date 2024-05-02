using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal.Models
{
    [Table("Critique")]
    public partial class Critique
    {
        [Key]
        public int IdCritique { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }
        public string? Message { get; set; }
        public int? Rating { get; set; }
        [StringLength(255)]
        public string? NomUtilisateur { get; set; }
        public string? ReplyCritique { get; set; }
        public int? IdBibliothèque { get; set; }

        [ForeignKey("IdBibliothèque")]
        [InverseProperty("Critiques")]
        public virtual Bibliothèque? IdBibliothèqueNavigation { get; set; }
    }
}
