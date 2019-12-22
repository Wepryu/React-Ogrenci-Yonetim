using AdvancityDemoV1.Contract.Request;
using AdvancityDemoV1.Contract.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancityDemoV1.Business.Sinif
{
    public interface ISinifBusiness
    {
        Task<SinifResponse> GetAsync(int id);
        Task<SinifResponse> GetAllAsync();
        Task AddAsync(SinifRequest sinifRequest);
        Task ModifiedAsync(SinifRequest sinifRequest, int sinifId);
    }
}
