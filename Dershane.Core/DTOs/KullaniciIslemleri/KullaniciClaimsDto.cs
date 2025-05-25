using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dershane.Core.DTOs.KullaniciIslemleri
{
    public class KullaniciClaimsDto
    {
        public Guid KullaniciId { get; set; }
        public string AdSoyad { get; set; }
        public string PersonelNo { get; set; }
        public string? EPosta { get; set; }
        public string Brans { get; set; } = null!;
    }
}
