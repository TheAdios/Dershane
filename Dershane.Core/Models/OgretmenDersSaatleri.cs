using System;
using System.Collections.Generic;

namespace Dershane.Core.Models;

public partial class OgretmenDersSaatleri
{
    public int KayitId { get; set; }

    public int? OgretmenId { get; set; }

    public int? SinifId { get; set; }

    public int? DersId { get; set; }

    public DateOnly DersTarihi { get; set; }

    public decimal ToplamSaat { get; set; }

    public decimal SaatlikUcret { get; set; }

    public decimal? ToplamTutar { get; set; }

    public virtual Ders? Ders { get; set; }

    public virtual Ogretmen? Ogretmen { get; set; }

    public virtual Sinif? Sinif { get; set; }
}
