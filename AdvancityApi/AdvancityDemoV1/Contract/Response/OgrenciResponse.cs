using AdvancityDemoV1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancityDemoV1.Contract.Response
{
    public class OgrenciResponse
    {
        public OgrenciResponse()
        {
            Entities = new List<Ogrenci>();
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        public List<Ogrenci> Entities { get; set; }
    }
}
