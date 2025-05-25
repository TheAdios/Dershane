using System;
using System.Collections.Generic;

namespace Dershane.Core.Models;

public partial class OgretmenSinif
{
    public int OgretmenSinifId { get; set; }

    public int OgretmenId { get; set; }

    public int SinifId { get; set; }

    public decimal Ucret { get; set; }
}
