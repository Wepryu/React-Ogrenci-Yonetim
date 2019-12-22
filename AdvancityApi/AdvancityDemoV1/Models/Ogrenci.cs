using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancityDemoV1.Models
{
    public class Ogrenci
    {
        public int Id { get; set; }
        public string No { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Gsm { get; set; }
        public string Eposta{ get; set; }
        public Boolean Durum { get; set; }
         public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
