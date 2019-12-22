using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancityDemoV1.Data.Sinif
{
    public interface ISinifRepository
    {
        Task<Models.Sinif> GetAsync(int id);
        Task<IEnumerable<Models.Sinif>> GetAllAsync();
        Task AddAsync(Models.Sinif sinif);
        Task ModifiedAsync(Models.Sinif sinif);
    }
}
