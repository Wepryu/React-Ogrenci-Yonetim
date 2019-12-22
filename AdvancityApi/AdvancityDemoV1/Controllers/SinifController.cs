using System.Linq;
using System.Threading.Tasks;
using AdvancityDemoV1.Business.Sinif;
using AdvancityDemoV1.Contract.Request;
using AdvancityDemoV1.Contract.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdvancityDemoV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinifController : ControllerBase
    {
        private readonly ISinifBusiness _sinifBusiness;

        public SinifController(ISinifBusiness sinifBusiness)
        {
            _sinifBusiness = sinifBusiness;
        }

        // GET api/v1/sinif/{id}
        [HttpGet("{id}")]
        public async Task<SinifResponse> Get(int id)
        {
            return await _sinifBusiness.GetAsync(id);
        }

        // GET api/v1/siniflar
        [HttpGet]
        public async Task<SinifResponse> Get()
        {
            return await _sinifBusiness.GetAllAsync();
        }

        // POST api/v1/sinifEkleme
        [ProducesResponseType(201)]
        [HttpPost]
        public async Task Post([FromBody]SinifRequest sinifRequest)
        {
            await _sinifBusiness.AddAsync(sinifRequest);
        }

        // PUT api/v1/sinifDuzenleme
        [ProducesResponseType(201)]
        [HttpPut]
        public async Task PostModified([FromBody]SinifRequest sinifRequest, int sinifId)
        {
            await _sinifBusiness.ModifiedAsync(sinifRequest, sinifId);
        }
    }
}
