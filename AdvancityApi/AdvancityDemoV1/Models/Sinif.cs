using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancityDemoV1.Models
{
    public class Sinif
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public byte Kontenjan { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
