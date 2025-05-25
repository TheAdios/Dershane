using System;
using System.Collections.Generic;

namespace Dershane.Core.Models;

public partial class Ogrenci
{
    public int OgrenciId { get; set; }

    public string OgrenciAdi { get; set; } = null!;

    public string OgrenciSoyadi { get; set; } = null!;

    public string? OgrenciTel { get; set; }

    public string? OgrenciTc { get; set; }

    public int? VeliId { get; set; }

    public bool Aktif { get; set; }

    public virtual ICollection<OgrenciDers> OgrenciDers { get; set; } = new List<OgrenciDers>();
}
