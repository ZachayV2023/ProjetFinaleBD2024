using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinalV2.Models;

[Table("Critique")]
public partial class Critique
{
    [Key]
    public int IdCritique { get; set; }

    public DateOnly? Date { get; set; }

    public string? Message { get; set; }

    public int? Rating { get; set; }

    [StringLength(255)]
    public string? NomUtilisateur { get; set; }

    public string? ReplyCritique { get; set; }

    public int? IdBibliotheque { get; set; }

    [ForeignKey("IdBibliotheque")]
    [InverseProperty("Critiques")]
    public virtual Bibliotheque? IdBibliothequeNavigation { get; set; }
}
