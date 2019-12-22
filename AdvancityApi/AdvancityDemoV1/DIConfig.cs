using AdvancityDemoV1.Data;
using AdvancityDemoV1.Data.Ders;
using AdvancityDemoV1.Data.Ogrenci;
using AdvancityDemoV1.Data.Sinif;
using Microsoft.Extensions.DependencyInjection;

namespace AdvancityDemoV1
{
    public static class DIConfig
    {
        public static void RegisterDIConfigurations(IServiceCollection services)
        {
            // Add application services.
            services.AddTransient<Business.Ders.IDersBusiness, Business.Ders.DersBusiness>();
            services.AddTransient<Business.Ogrenci.IOgrenciBusiness, Business.Ogrenci.OgrenciBusiness>();
            services.AddTransient<Business.Sinif.ISinifBusiness, Business.Sinif.SinifBusiness>();

            services.AddTransient<ISinifRepository, SinifRepository>();
            services.AddTransient<IOgrenciRepository, OgrenciRepository>();
            services.AddTransient<IDersRepository, DersRepository>();
        }
    }
}
