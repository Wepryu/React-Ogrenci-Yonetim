using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancityDemoV1.Data
{
    public interface IOgrenciRepository
    {
        Task<Models.Ogrenci> GetAsync(int id);
        Task<IEnumerable<Models.Ogrenci>> GetAllAsync();
        Task AddAsync(Models.Ogrenci ogrenci);
        Task ModifiedAsync(Models.Ogrenci ogrenci);
    }
}
