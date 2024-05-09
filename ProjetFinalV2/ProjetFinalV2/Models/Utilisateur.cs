using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinalV2.Models;

[Table("Utilisateur")]
[Index("Ville", Name = "IX_Utilisateur_City")]
public partial class Utilisateur
{
    [Key]
    public int IdUtilisateur { get; set; }

    [StringLength(255)]
    public string Nom { get; set; } = null!;

    [StringLength(255)]
    public string Email { get; set; } = null!;

    public DateOnly DateInscription { get; set; }

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

    public byte[]? EmailEncrypted { get; set; }

    public byte[]? ProfileImage { get; set; }
}
