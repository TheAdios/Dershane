using System;
using System.Collections.Generic;

namespace Dershane.Core.Models;

public partial class MuhasebeKayitlari
{
    public int KayitId { get; set; }

    public int? OgretmenId { get; set; }

    public int DonemAy { get; set; }

    public int DonemYil { get; set; }

    public decimal ToplamSaat { get; set; }

    public decimal ToplamTutar { get; set; }

    public DateTime? HesaplananTarih { get; set; }

    public virtual Ogretmen? Ogretmen { get; set; }
}
