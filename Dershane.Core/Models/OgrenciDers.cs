using System;
using System.Collections.Generic;

namespace Dershane.Core.Models;

public partial class OgrenciDers
{
    public int OgrenciDersId { get; set; }

    public int OgretmenId { get; set; }

    public int OgrenciId { get; set; }

    public int SinifId { get; set; }

    public DateOnly BaslangicTarihi { get; set; }

    public DateOnly BitisTarihi { get; set; }

    public int GirilecekDersSaati { get; set; }

    public bool Aktif { get; set; }

    public bool OgrenciIptali { get; set; }

    public string? OgretmenNotu { get; set; }

    public DateTime? OlusturmaTarihi { get; set; }

    public virtual Ogrenci Ogrenci { get; set; } = null!;

    public virtual Ogretmen Ogretmen { get; set; } = null!;

    public virtual Sinif Sinif { get; set; } = null!;
}
