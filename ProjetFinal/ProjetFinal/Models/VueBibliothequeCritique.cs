using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal.Models
{
    [Keyless]
    public partial class VueBibliothequeCritique
    {
        [StringLength(255)]
        public string Nom { get; set; } = null!;
        public int? NombreCritiques { get; set; }
        public int? MoyenneNotation { get; set; }
    }
}
