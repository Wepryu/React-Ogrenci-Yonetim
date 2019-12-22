using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancityDemoV1.Data.Ders
{
    public interface IDersRepository
    {
        Task<Models.Ders> GetAsync(string ad);
        Task<Models.Ders> GetAsync(int id);
        Task<IEnumerable<Models.Ders>> GetAllAsync();
        Task AddAsync(Models.Ders ders);
        Task ModifiedAsync(Models.Ders ders);
    }
}
