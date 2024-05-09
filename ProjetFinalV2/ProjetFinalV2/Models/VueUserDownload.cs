using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinalV2.Models;

[Keyless]
public partial class VueUserDownload
{
    public int IdUtilisateur { get; set; }

    [StringLength(255)]
    public string LibraryName { get; set; } = null!;

    public DateOnly? DownloadDate { get; set; }
}
