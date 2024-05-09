using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinalV2.Models;

[Keyless]
public partial class VueBibliothequeCritique
{
    public long? VueBibliothequeCritiqueId { get; set; }

    [StringLength(255)]
    public string Nom { get; set; } = null!;

    [StringLength(255)]
    public string? Categorie { get; set; }

    public long? NombreCritiques { get; set; }

    public int? MoyenneNotation { get; set; }

    [Column("NombreMisesAJour")]
    public long? NombreMisesAjour { get; set; }

    [StringLength(50)]
    public string? DerniereVersion { get; set; }

    public int? MoyenneLignesCodeFonctions { get; set; }

    public long? NombreFonctions { get; set; }
}
