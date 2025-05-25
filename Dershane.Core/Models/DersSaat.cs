using System;
using System.Collections.Generic;

namespace Dershane.Core.Models;

public partial class DersSaat
{
    public int DersSaatId { get; set; }

    public int OgretmenId { get; set; }

    public DateOnly DersTarihi { get; set; }

    public decimal GirilenSaat { get; set; }

    public virtual Ogretmen Ogretmen { get; set; } = null!;
}
