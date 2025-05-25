using System;
using System.Collections.Generic;

namespace Dershane.Core.Models;

public partial class KullaniciRol
{
    public int KullaniciRolId { get; set; }

    public Guid KullaniciId { get; set; }

    public Guid RolId { get; set; }

    public DateTime KayitTarihi { get; set; }

    public Guid KayitKullaniciId { get; set; }
}
