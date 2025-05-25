using System;
using System.Collections.Generic;

namespace Dershane.Core.Models;

public partial class Kullanici
{
    public Guid KullaniciId { get; set; }

    public string PersonelNo { get; set; } = null!;

    public string AdSoyad { get; set; } = null!;

    public string? Brans { get; set; }

    public string? CepTel { get; set; }

    public string? EPosta { get; set; }

    public string? Parola { get; set; }

    public bool Aktif { get; set; }
}
