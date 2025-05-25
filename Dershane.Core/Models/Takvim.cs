using System;
using System.Collections.Generic;

namespace Dershane.Core.Models;

public partial class Takvim
{
    public int TakvimId { get; set; }

    public int OgretmenId { get; set; }

    public int DersSaatId { get; set; }
}
