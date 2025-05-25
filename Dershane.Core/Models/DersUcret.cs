using System;
using System.Collections.Generic;

namespace Dershane.Core.Models;

public partial class DersUcret
{
    public int DersUcretId { get; set; }

    public int OgretmenId { get; set; }

    public int SinifId { get; set; }

    public int DersId { get; set; }

    public decimal SaatlikUcret { get; set; }

    public DateTime? OlusturmaTarihi { get; set; }

    public virtual Ders Ders { get; set; } = null!;

    public virtual Ogretmen Ogretmen { get; set; } = null!;

    public virtual Sinif Sinif { get; set; } = null!;
}
