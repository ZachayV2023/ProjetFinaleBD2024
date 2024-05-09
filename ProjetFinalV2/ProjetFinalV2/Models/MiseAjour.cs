using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinalV2.Models;

[Table("MiseAJour")]
public partial class MiseAjour
{
    [Key]
    [Column("IdMiseAJour")]
    public int IdMiseAjour { get; set; }

    [StringLength(50)]
    public string? Version { get; set; }

    [Column("DescMiseAJour")]
    public string? DescMiseAjour { get; set; }

    public int? IdBibliotheque { get; set; }

    [ForeignKey("IdBibliotheque")]
    [InverseProperty("MiseAjours")]
    public virtual Bibliotheque? IdBibliothequeNavigation { get; set; }
}
