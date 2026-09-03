using System.Collections.Generic;
using System.Threading.Tasks;

namespace college.Application.Interfaces
{
    public interface IDapperRepository
    {
        Task<IEnumerable<T>> QueryAsync<T>(string sp, object param = null);
        Task<T> QueryFirstOrDefaultAsync<T>(string sp, object param = null);
        Task<int> ExecuteAsync(string sp, object param = null);
        Task<T> ExecuteScalarAsync<T>(string sp, object param = null);
    }
}
