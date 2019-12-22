using AdvancityDemoV1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancityDemoV1.Contract.Response
{
    public class DersResponse
    {
        public DersResponse()
        {
            Entities = new List<Ders>();
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        public List<Ders> Entities { get; set; }
    }
}
