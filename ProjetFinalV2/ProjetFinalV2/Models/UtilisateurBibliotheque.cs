using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinalV2.Models;

[PrimaryKey("IdUtilisateur", "IdBibliotheque")]
[Table("UtilisateurBibliotheque")]
public partial class UtilisateurBibliotheque
{
    [Key]
    public int IdUtilisateur { get; set; }

    [Key]
    public int IdBibliotheque { get; set; }

    public DateOnly? DateTelechargement { get; set; }

    [ForeignKey("IdBibliotheque")]
    [InverseProperty("UtilisateurBibliotheques")]
    public virtual Bibliotheque IdBibliothequeNavigation { get; set; } = null!;
}
