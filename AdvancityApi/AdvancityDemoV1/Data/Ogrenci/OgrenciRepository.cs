using AdvancityDemoV1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
namespace AdvancityDemoV1.Data.Ogrenci
{
    public class OgrenciRepository : IOgrenciRepository
    {
        private readonly string _connectionString;
        private IDbConnection _connection { get { return new SqlConnection(_connectionString); } }

        public OgrenciRepository()
        {
            // TODO: It will be refactored...
            _connectionString = "Data Source=.;Initial Catalog=EgitimSistemiDemo;Integrated Security=True";
        }

        public async Task<Models.Ogrenci> GetAsync(int id)
        {
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"SELECT [Id] ,[No]
                                ,[Ad]
                                ,[Soyad]
                                ,[Gsm]
                                ,[Eposta]
                                ,[Durum]
                                ,[CreatedDate]
                                ,[ModifiedDate]
                                FROM [dbo].[Ogrenci]
                                WHERE [Id] = @Id";

                var ogrenci = await dbConnection.QueryFirstOrDefaultAsync<Models.Ogrenci>(query, new { @Id = id });

                return ogrenci;
            }
        }
        public async Task<IEnumerable<Models.Ogrenci>> GetAllAsync()
        {
            //TODO: Paging...
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"SELECT [Id] ,[No]
                                ,[Ad]
                                ,[Soyad]
                                ,[Gsm] 
                                ,[Eposta]
                                ,[Durum]
                                ,[CreatedDate]
                                ,[ModifiedDate]
                                FROM [dbo].[Ogrenci]";

                var ogrenci = await dbConnection.QueryAsync<Models.Ogrenci>(query);
                
                return ogrenci;
            }
        }

        public async Task AddAsync(Models.Ogrenci ogrenci)
        {
            Random rnd = new Random();
            string fakulteNo = "12";
            string bolumNo = "10";
            ogrenci.No = "G" + DateTime.Now.Year.ToString().Substring(2, 2)+ fakulteNo +bolumNo+ rnd.Next(100,999);
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"INSERT INTO [dbo].[Ogrenci] (
                                [No],
                                [Ad],
                                [Soyad],
                                [Gsm],
                                [Eposta],
                                [Durum],
                                [CreatedDate],
                                [ModifiedDate]) VALUES (
                                @No,
                                @Ad,
                                @Soyad,
                                @Gsm,
                                @Eposta,
                                @Durum,
                                @CreatedDate,
                                @ModifiedDate)";

                await dbConnection.ExecuteAsync(query, ogrenci);
            }
        }
        public async Task ModifiedAsync(Models.Ogrenci ogrenci)
        {
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"UPDATE [dbo].[Ogrenci] SET
                                Ad = @Ad,
                                Soyad = @Soyad,
                                Gsm = @Gsm,
                                Eposta = @Eposta,
                                Durum = @Durum,
                                ModifiedDate = @ModifiedDate WHERE Id =@Id";
                
                 await dbConnection.ExecuteAsync(query, ogrenci);
            }


        }
    }
}
