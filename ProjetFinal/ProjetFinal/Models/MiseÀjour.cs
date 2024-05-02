using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal.Models
{
    [Table("MiseÀJour")]
    public partial class MiseÀjour
    {
        [Key]
        [Column("IdMiseÀJour")]
        public int IdMiseÀjour { get; set; }
        [StringLength(50)]
        public string? Version { get; set; }
        [Column("DescMiseÀJour")]
        public string? DescMiseÀjour { get; set; }
        public int? IdBibliothèque { get; set; }

        [ForeignKey("IdBibliothèque")]
        [InverseProperty("MiseÀjours")]
        public virtual Bibliothèque? IdBibliothèqueNavigation { get; set; }
    }
}
