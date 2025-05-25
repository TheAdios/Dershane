using System;
using System.Collections.Generic;

namespace Dershane.Core.Models;

public partial class Odeme
{
    public int OdemeId { get; set; }

    public int OgrenciId { get; set; }

    public int Oran { get; set; }

    public DateOnly Tarih { get; set; }

    public string OdemeTuru { get; set; } = null!;
}
