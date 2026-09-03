using college.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace college.Infrastructure.Persistence
{
    public class DapperRepository : IDapperRepository
    {
        private readonly DapperContext _context;

        public DapperRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sp, object param = null)
        {
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<T>(sp, param, commandType: CommandType.StoredProcedure);
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string sp, object param = null)
        {
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<T>(sp, param, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> ExecuteAsync(string sp, object param = null)
        {
            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(sp, param, commandType: CommandType.StoredProcedure);
        }

        public async Task<T> ExecuteScalarAsync<T>(string sp, object param = null)
        {
            using var connection = _context.CreateConnection();
            return await connection.ExecuteScalarAsync<T>(sp, param, commandType: CommandType.StoredProcedure);
        }
    }
}
