using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvancityDemoV1.Business.Ogrenci;
using AdvancityDemoV1.Contract.Request;
using AdvancityDemoV1.Contract.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdvancityDemoV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OgrenciController : ControllerBase
    {
        private readonly IOgrenciBusiness _ogrenciBusiness;

        public OgrenciController(IOgrenciBusiness ogrenciBusiness)
        {
            _ogrenciBusiness = ogrenciBusiness;
        }

        // GET api/v1/ogrenci/{id}
        [HttpGet("{id}")]
        public async Task<OgrenciResponse> Get(int id)
        {
            return await _ogrenciBusiness.GetAsync(id);
        }

        // GET api/v1/ogrenciler
        [HttpGet]
        public async Task<OgrenciResponse> Get()
        {
            return await _ogrenciBusiness.GetAllAsync();
        }

        // POST api/v1/ogrenciEkleme
        [ProducesResponseType(201)]
        [HttpPost]
        public async Task Post([FromBody]OgrenciRequest ogrenciRequest)
        {
            await _ogrenciBusiness.AddAsync(ogrenciRequest);
        }

        // PUT api/v1/ogrenciDuzenleme
        [ProducesResponseType(201)]
        [HttpPut]
        public async Task PostModified(int ogrId, [FromBody]OgrenciRequest ogrenciRequest)
        {
            await _ogrenciBusiness.ModifiedAsync(ogrenciRequest, ogrId);
        }
    }
}