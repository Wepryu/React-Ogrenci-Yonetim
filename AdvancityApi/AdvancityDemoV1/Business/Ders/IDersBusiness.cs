using AdvancityDemoV1.Contract.Request;
using AdvancityDemoV1.Contract.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancityDemoV1.Business.Ders
{
    public interface IDersBusiness
    {
        Task<DersResponse> GetAsync(string ad);
        Task<DersResponse> GetAllAsync();
        Task AddAsync(DersRequest dersRequest);
        Task ModifiedAsync(DersRequest dersRequest, int dersId);
    }
}
