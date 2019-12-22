using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancityDemoV1.Data.Ders
{
    public class DersRepository : IDersRepository
    {
        private readonly string _connectionString;
        private IDbConnection _connection { get { return new SqlConnection(_connectionString); } }

        public DersRepository()
        {
            // TODO: It will be refactored...
            _connectionString = "Data Source=.;Initial Catalog=EgitimSistemiDemo;Integrated Security=True";
        
        }

        public async Task<Models.Ders> GetAsync(string ad)
        {
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"SELECT [Id] ,[Ad]
                                ,[CreatedDate]
                                ,[ModifiedDate]
                                FROM [dbo].[Ders]
                                WHERE [Ad] = @Ad";

                var ders = await dbConnection.QueryFirstOrDefaultAsync<Models.Ders>(query, new { @Ad = ad });

                return ders;
            }
        }

        public async Task<Models.Ders> GetAsync(int id)
        {
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"SELECT [Id] ,[Ad]
                                ,[CreatedDate]
                                ,[ModifiedDate]
                                FROM [dbo].[Ders]
                                WHERE [Id] = @Id";

                var ders = await dbConnection.QueryFirstOrDefaultAsync<Models.Ders>(query, new { @Id = id });

                return ders;
            }
        }
        public async Task<IEnumerable<Models.Ders>> GetAllAsync()
        {
            //TODO: Paging...
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"SELECT [Id] ,[Ad]
                                ,[CreatedDate]
                                ,[ModifiedDate]
                                FROM [dbo].[Ders]";

                var ders = await dbConnection.QueryAsync<Models.Ders>(query);

                return ders;
            }
        }

        public async Task AddAsync(Models.Ders ders)
        {
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"INSERT INTO [dbo].[Ders] (
                                [Ad],
                                [CreatedDate],
                                [ModifiedDate]
                                ) VALUES (
                                @Ad,
                                @CreatedDate,
                                @ModifiedDate
                                )";

                await dbConnection.ExecuteAsync(query, ders);
            }
        }
        public async Task ModifiedAsync(Models.Ders ders)
        {
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"UPDATE [dbo].[Ders] SET Ad = @Ad, ModifiedDate = @ModifiedDate WHERE Id =@Id";
                await dbConnection.ExecuteAsync(query, ders);
            }

        }
    }
}
