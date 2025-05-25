using System;
using System.Collections.Generic;

namespace Dershane.Core.Models;

public partial class Ögretmen
{
    public int OgretmenId { get; set; }

    public string? OgretmenAdi { get; set; }

    public string? OgretmenSoyadi { get; set; }

    public string? OgretmenMail { get; set; }

    public string? OgretmenTc { get; set; }

    public int? OgretmenDuzey { get; set; }

    public int? BransId { get; set; }

    public virtual Brans? Brans { get; set; }

    public virtual ICollection<Ders> Ders { get; set; } = new List<Ders>();

    public virtual ICollection<DersUcret> DersUcret { get; set; } = new List<DersUcret>();

    public virtual ICollection<OgrenciDers> OgrenciDers { get; set; } = new List<OgrenciDers>();

    public virtual ICollection<OgretmenSinif> OgretmenSinif { get; set; } = new List<OgretmenSinif>();

    public virtual ICollection<Takvim> Takvim { get; set; } = new List<Takvim>();
}
