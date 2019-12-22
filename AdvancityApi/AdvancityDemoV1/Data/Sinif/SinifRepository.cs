using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancityDemoV1.Data.Sinif
{
    public class SinifRepository : ISinifRepository
    {
        private readonly string _connectionString;
        private IDbConnection _connection { get { return new SqlConnection(_connectionString); } }

        public SinifRepository()
        {
            // TODO: It will be refactored...
            _connectionString = "Data Source=.;Initial Catalog=EgitimSistemiDemo;Integrated Security=True";
        }

        public async Task<Models.Sinif> GetAsync(int id)
        {
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"SELECT [Id] ,[Ad]
                                ,[Kontenjan]
                                ,[CreatedDate]
                                ,[ModifiedDate]
                                FROM [dbo].[Sinif]
                                WHERE [Id] = @Id";

                var sinif = await dbConnection.QueryFirstOrDefaultAsync<Models.Sinif>(query, new { @Id = id });

                return sinif;
            }
        }
        public async Task<IEnumerable<Models.Sinif>> GetAllAsync()
        {
            //TODO: Paging...
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"SELECT [Id]
                                ,[Ad]
                                ,[Kontenjan]
                                ,[CreatedDate]
                                ,[ModifiedDate]
                                FROM [dbo].[Sinif]";

                var sinif = await dbConnection.QueryAsync<Models.Sinif>(query);

                return sinif;
            }
        }

        public async Task AddAsync(Models.Sinif sinif)
        {
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"INSERT INTO [dbo].[Sinif] (
                                [Ad],
                                [Kontenjan],
                                [CreatedDate],
                                [ModifiedDate]) VALUES (
                                @Ad,
                                @Kontenjan,
                                @CreatedDate,
                                @ModifiedDate)";
                await dbConnection.ExecuteAsync(query, sinif);
            }
        }

        public async Task ModifiedAsync(Models.Sinif sinif)
        {
            using (IDbConnection dbConnection = _connection)
            {

                string query = @"UPDATE [dbo].[Sinif] SET
                                Ad = @Ad,
                                Kontenjan = @Kontenjan,
                                ModifiedDate = @ModifiedDate WHERE Id =@Id";
                await dbConnection.ExecuteAsync(query, sinif);
            }


        }
    }
}
