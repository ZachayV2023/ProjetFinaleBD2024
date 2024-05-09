using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinalV2.Models;

[Table("Bibliotheque")]
[Index("Categorie", Name = "IX_Bibliotheque_Category")]
public partial class Bibliotheque
{
    [Key]
    public int IdBibliotheque { get; set; }

    [StringLength(255)]
    public string Nom { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly? DateCreation { get; set; }

    [StringLength(255)]
    public string? Categorie { get; set; }

    public int? TotalTelechargements { get; set; }

    [InverseProperty("IdBibliothequeNavigation")]
    public virtual ICollection<Critique> Critiques { get; set; } = new List<Critique>();

    [InverseProperty("IdBibliothequeNavigation")]
    public virtual ICollection<Fonction> Fonctions { get; set; } = new List<Fonction>();

    [InverseProperty("IdBibliothequeNavigation")]
    public virtual ICollection<MiseAjour> MiseAjours { get; set; } = new List<MiseAjour>();

    [InverseProperty("IdBibliothequeNavigation")]
    public virtual ICollection<UtilisateurBibliotheque> UtilisateurBibliotheques { get; set; } = new List<UtilisateurBibliotheque>();
}
