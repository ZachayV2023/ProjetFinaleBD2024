using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinalV2.Models;

[Table("ReglageConfig")]
public partial class ReglageConfig
{
    [Key]
    public int IdConfig { get; set; }

    [StringLength(255)]
    public string? Theme { get; set; }

    [Column("nomMembre")]
    [StringLength(255)]
    public string? NomMembre { get; set; }

    [Column("langPref")]
    [StringLength(50)]
    public string? LangPref { get; set; }

    [Column("notificationAct")]
    public bool? NotificationAct { get; set; }
}
