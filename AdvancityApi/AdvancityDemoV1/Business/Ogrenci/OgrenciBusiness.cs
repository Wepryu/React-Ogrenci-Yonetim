using AdvancityDemoV1.Contract.Request;
using AdvancityDemoV1.Contract.Response;
using AdvancityDemoV1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancityDemoV1.Business.Ogrenci
{
    public class OgrenciBusiness: IOgrenciBusiness
    {
        private readonly IOgrenciRepository _ogrenciRepository;

        public OgrenciBusiness(IOgrenciRepository ogrenciRepository)
        {
            _ogrenciRepository = ogrenciRepository;
        }

        public async Task<OgrenciResponse> GetAsync(int id)
        {
            OgrenciResponse ogrenciResponse = new OgrenciResponse();
            var ogrenci = await _ogrenciRepository.GetAsync(id);

            if (ogrenci == null)
            {
                ogrenciResponse.Message = "Product not found.";
            }
            else
            {
                ogrenciResponse.Entities.Add(ogrenci);
            }

            return ogrenciResponse;
        }

        public async Task<OgrenciResponse> GetAllAsync()
        {
            //TODO: Paging...

            OgrenciResponse ogrenciResponse = new OgrenciResponse();
            IEnumerable<Models.Ogrenci> ogrenciler = await _ogrenciRepository.GetAllAsync();

            if (ogrenciler.ToList().Count == 0)
            {
                ogrenciResponse.Message = "Products not found.";
            }
            else
            {
                ogrenciResponse.Entities.AddRange(ogrenciler);
            }

            return ogrenciResponse;
        }

        public async Task AddAsync(OgrenciRequest ogrenciRequest)
        {
            Models.Ogrenci ogrenci = new Models.Ogrenci()
            {
                Ad = ogrenciRequest.Ad,
                No = ogrenciRequest.No,
                Soyad = ogrenciRequest.Soyad,
                CreatedDate = DateTime.Now,
                Gsm = ogrenciRequest.Gsm,
                Eposta = ogrenciRequest.Eposta,
                Durum = ogrenciRequest.Durum,
                ModifiedDate = DateTime.Now
            };

            await _ogrenciRepository.AddAsync(ogrenci);
        }

        public async Task ModifiedAsync(OgrenciRequest ogrenciRequest, int ogrenciId)
        {
            var ogrenci = await _ogrenciRepository.GetAsync(ogrenciId);
          
            ogrenci.Ad = ogrenciRequest.Ad;
            ogrenci.Soyad = ogrenciRequest.Soyad;
            ogrenci.No = ogrenciRequest.No;
            ogrenci.Gsm = ogrenciRequest.Gsm;
            ogrenci.Eposta = ogrenciRequest.Eposta;
            ogrenci.Durum = ogrenciRequest.Durum;
            ogrenci.ModifiedDate = DateTime.Now;
            await _ogrenciRepository.ModifiedAsync(ogrenci);
        }
    }
}
