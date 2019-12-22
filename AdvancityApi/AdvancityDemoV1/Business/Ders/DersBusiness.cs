using AdvancityDemoV1.Contract.Request;
using AdvancityDemoV1.Contract.Response;
using AdvancityDemoV1.Data.Ders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancityDemoV1.Business.Ders
{
    public class DersBusiness : IDersBusiness
    {
        private readonly IDersRepository _dersRepository;

        public DersBusiness(IDersRepository dersRepository)
        {
            _dersRepository = dersRepository;
        }

        public async Task<DersResponse> GetAsync(string ad)
        {
            DersResponse dersResponse = new DersResponse();
            var ders = await _dersRepository.GetAsync(ad);

            if (ders == null)
            {
                dersResponse.Message = "Aranan isimde Ders Bulunamadı.";
            }
            else
            {
                dersResponse.Entities.Add(ders);
            }

            return dersResponse;
        }

        public async Task<DersResponse> GetAllAsync()
        {
            //TODO: Paging...

            DersResponse dersResponse = new DersResponse();
            IEnumerable<Models.Ders> dersler = await _dersRepository.GetAllAsync();

            if (dersler.ToList().Count == 0)
            {
                dersResponse.Message = "İlgili Derler Bulunumadı.";
            }
            else
            {
                dersResponse.Entities.AddRange(dersler);
            }

            return dersResponse;
        }

        public async Task AddAsync(DersRequest dersRequest)
        {
            Models.Ders ders = new Models.Ders()
            {
                Ad = dersRequest.Ad,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            await _dersRepository.AddAsync(ders);
        }
        public async Task ModifiedAsync(DersRequest dersRequest, int dersId)
        {
            var ders = await _dersRepository.GetAsync(dersId);

            ders.Ad = dersRequest.Ad;
            ders.ModifiedDate = DateTime.Now;
            await _dersRepository.ModifiedAsync(ders);
        }
    }
}
