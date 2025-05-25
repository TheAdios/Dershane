using System;
using System.Collections.Generic;

namespace Dershane.Core.Models;

public partial class Ogretmen
{
    public int OgretmenId { get; set; }

    public string OgretmenAdi { get; set; } = null!;

    public string OgretmenSoyadi { get; set; } = null!;

    public string? OgretmenMail { get; set; }

    public string OgretmenTc { get; set; }

    public int OgretmenDuzey { get; set; }

    public int BransId { get; set; }

    public virtual ICollection<DersSaat> DersSaat { get; set; } = new List<DersSaat>();

    public virtual ICollection<DersUcret> DersUcret { get; set; } = new List<DersUcret>();

    public virtual ICollection<MuhasebeKayitlari> MuhasebeKayitlari { get; set; } = new List<MuhasebeKayitlari>();

    public virtual ICollection<OgrenciDers> OgrenciDers { get; set; } = new List<OgrenciDers>();

    public virtual ICollection<OgretmenDersSaatleri> OgretmenDersSaatleri { get; set; } = new List<OgretmenDersSaatleri>();
}
