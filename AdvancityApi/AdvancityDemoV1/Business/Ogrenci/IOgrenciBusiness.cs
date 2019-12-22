using AdvancityDemoV1.Contract.Request;
using AdvancityDemoV1.Contract.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancityDemoV1.Business.Ogrenci
{
    public interface IOgrenciBusiness
    {
        Task<OgrenciResponse> GetAsync(int id);
        Task<OgrenciResponse> GetAllAsync();
        Task AddAsync(OgrenciRequest ogrenciRequest);
        Task ModifiedAsync(OgrenciRequest ogrenciRequest, int ogrenciId);
    }
}
