using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dershane.Core.DTOs
{
    public class DersKayitDto
    {
        public int OgrenciDersId { get; set; }
        public int OgretmenId { get; set; }
        public int OgrenciId { get; set; }
        public int SinifId { get; set; }
        public DateOnly BaslangicTarihi { get; set; }
        public DateOnly BitisTarihi { get; set; }
        public string? OgretmenNotu { get; set; }
        public int GirilecekDersSaati { get; set; }
    }
}
