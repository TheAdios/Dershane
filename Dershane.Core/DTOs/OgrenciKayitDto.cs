using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dershane.Core.DTOs
{
    public class OgrenciKayitDto
    {
        public string OgrenciAdi { get; set; } = null!;

        public string? OgrenciSoyadi { get; set; }

        public string? OgrenciTel { get; set; }

        public string OgrenciTc { get; set; }
    }
}
