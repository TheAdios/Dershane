using System;
using System.Collections.Generic;

namespace Dershane.Core.Models;

public partial class Ders
{
    public int DersId { get; set; }

    public string DersAdi { get; set; } = null!;

    public int DersUcret { get; set; }

    public int OgretmenId { get; set; }

    public virtual ICollection<DersUcret> DersUcretNavigation { get; set; } = new List<DersUcret>();

    public virtual ICollection<OgretmenDersSaatleri> OgretmenDersSaatleri { get; set; } = new List<OgretmenDersSaatleri>();
}
