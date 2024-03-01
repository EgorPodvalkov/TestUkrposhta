using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using TestUkrposhta.DTOs;

namespace TestUkrposhta.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseDTO
    {
        protected readonly string _tableName;
        protected IDbConnection _dbConnection => new SqlConnection(_connectionString);

        private string _connectionString;
        protected BaseRepository(string tableName, string connectionString)
        {
            _tableName = tableName;
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var sql = $"SELECT * FROM [{_tableName}]";

            using var db = _dbConnection;
            return await db.QueryAsync<T>(sql);
        }

        public async Task<T?> GetItemAsync(int id)
        {
            var sql = $"SELECT * FROM [{_tableName}] WHERE ID = @id";

            using var db = _dbConnection;
            return await db.QuerySingleOrDefaultAsync<T>(sql, new { id });
        }

        public async Task<IEnumerable<T>> GetOrderedItemsAsync(string orderStatement = "ID", int? take = null, int? skip = null)
        {
            var mainSegment = $"SELECT * FROM [{_tableName}] ORDER BY {orderStatement} ";
            var skipSegment = skip.HasValue ? $"OFFSET {skip} ROWS " : string.Empty;
            var takeSegment = take.HasValue ? $"FETCH NEXT {take} ROWS ONLY " : string.Empty;

            var sql = mainSegment + skipSegment + takeSegment;

            using var db = _dbConnection;
            return await db.QueryAsync<T>(sql);
        }

        public async Task<bool> Delete(int id)
        {
            var sql = $"DELETE FROM [{_tableName}] WHERE [ID] = @id";

            using var db = _dbConnection;
            var affectedRows = await db.ExecuteAsync(sql, new { id });

            return affectedRows > 0;
        }
    }
}
