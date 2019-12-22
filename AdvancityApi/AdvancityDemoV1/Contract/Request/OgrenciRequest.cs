using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancityDemoV1.Contract.Request
{
    public class OgrenciRequest
    {
        public string No { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Gsm { get; set; }
        public string Eposta { get; set; }
        public Boolean Durum { get; set; }
    }
}
