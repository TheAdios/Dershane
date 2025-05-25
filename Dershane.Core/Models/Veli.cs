using System;
using System.Collections.Generic;

namespace Dershane.Core.Models;

public partial class Veli
{
    public int VeliId { get; set; }

    public string VeliAdi { get; set; } = null!;

    public string VeliSoyadi { get; set; } = null!;

    public string VeliTc { get; set; } = null!;

    public string? VeliTel { get; set; }

    public string? VeliMail { get; set; }
}
