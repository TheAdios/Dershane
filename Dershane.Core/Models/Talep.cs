using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dershane.Core.Models
{
    public class Talep
    {
        public int Id { get; set; }

        [Required]
        public string AdSoyad { get; set; }

        [Required]
        public string Konu { get; set; }

        [Required]
        public string Aciklama { get; set; }

        public DateTime TalepTarihi { get; set; }
    }
}
