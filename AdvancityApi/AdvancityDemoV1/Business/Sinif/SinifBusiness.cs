using AdvancityDemoV1.Contract.Request;
using AdvancityDemoV1.Contract.Response;
using AdvancityDemoV1.Data.Sinif;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancityDemoV1.Business.Sinif
{
    public class SinifBusiness : ISinifBusiness
    {
        private readonly ISinifRepository _sinifRepository;

        public SinifBusiness(ISinifRepository sinifRepository)
        {
            _sinifRepository = sinifRepository;
        }

        public async Task<SinifResponse> GetAsync(int id)
        {
            SinifResponse sinifResponse = new SinifResponse();
            var sinif = await _sinifRepository.GetAsync(id);

            if (sinif == null)
            {
                sinifResponse.Message = "Product not found.";
            }
            else
            {
                sinifResponse.Entities.Add(sinif);
            }

            return sinifResponse;
        }

        public async Task<SinifResponse> GetAllAsync()
        {
            //TODO: Paging...

            SinifResponse sinifResponse = new SinifResponse();
            IEnumerable<Models.Sinif> siniflar = await _sinifRepository.GetAllAsync();

            if (siniflar.ToList().Count == 0)
            {
                sinifResponse.Message = "Products not found.";
            }
            else
            {
                sinifResponse.Entities.AddRange(siniflar);
            }

            return sinifResponse;
        }

        public async Task AddAsync(SinifRequest sinifRequest)
        {
            Models.Sinif sinif = new Models.Sinif()
            {
                Ad = sinifRequest.Ad,
                Kontenjan = sinifRequest.Kontenjan,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            await _sinifRepository.AddAsync(sinif);
        }
        public async Task ModifiedAsync(SinifRequest sinifRequest, int sinifId)
        {
            var sinif = await _sinifRepository.GetAsync(sinifId);

            sinif.Ad = sinifRequest.Ad;
            sinif.Kontenjan = sinifRequest.Kontenjan;
            sinif.ModifiedDate = DateTime.Now;
            await _sinifRepository.ModifiedAsync(sinif);
        }
    }
}
