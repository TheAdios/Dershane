using System;
using System.Collections.Generic;

namespace Dershane.Core.Models;

public partial class Sinif
{
    public int SinifId { get; set; }

    public string SinifSeviyesi { get; set; } = null!;

    public virtual ICollection<DersUcret> DersUcret { get; set; } = new List<DersUcret>();

    public virtual ICollection<OgrenciDers> OgrenciDers { get; set; } = new List<OgrenciDers>();

    public virtual ICollection<OgretmenDersSaatleri> OgretmenDersSaatleri { get; set; } = new List<OgretmenDersSaatleri>();
}
