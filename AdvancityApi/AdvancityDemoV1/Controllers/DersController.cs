using AdvancityDemoV1.Business.Ders;
using AdvancityDemoV1.Contract.Request;
using AdvancityDemoV1.Contract.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancityDemoV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DersController : ControllerBase
    {
        private readonly IDersBusiness _dersBusiness;

        public DersController(IDersBusiness dersBusiness)
        {
            _dersBusiness = dersBusiness;
        }

        // GET api/v1/ders/{Ad}
        [HttpGet("{ad}")]
        public async Task<DersResponse> Get(string ad)
        {
            return await _dersBusiness.GetAsync(ad);
        }

        // GET api/v1/dersler
        [HttpGet]
        public async Task<DersResponse> Get()
        {
            return await _dersBusiness.GetAllAsync();
        }

        // POST api/v1/dersEkleme
        [ProducesResponseType(201)]
        [HttpPost]
        public async Task Post([FromBody]DersRequest dersRequest)
        {
            await _dersBusiness.AddAsync(dersRequest);
        }

        // PUT api/v1/dersDuzenleme
        [ProducesResponseType(201)]
        [HttpPut("{id}")]
        public async Task PostModified(int id,[FromBody]DersRequest dersRequest)
        {
            await _dersBusiness.ModifiedAsync(dersRequest, id);
        }
    }
}
