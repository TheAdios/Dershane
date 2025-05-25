using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dershane.Core.Models
{
    public class JsonResultModel
    {
        public bool Basarili { get; set; }
        public string Mesaj { get; set; }
        public object NewObject { get; set; }
    }
}
