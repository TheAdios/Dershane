using System;
using System.Collections.Generic;

namespace Dershane.Core.Models;

public partial class Rol
{
    public Guid RolId { get; set; }

    public int RolNo { get; set; }

    public string Tanim { get; set; } = null!;

    public string? Aciklama { get; set; }
}
