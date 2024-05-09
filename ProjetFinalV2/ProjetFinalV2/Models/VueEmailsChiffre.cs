using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinalV2.Models;

[Keyless]
public partial class VueEmailsChiffre
{
    public int IdUtilisateur { get; set; }

    public byte[]? EmailEncrypted { get; set; }
}
