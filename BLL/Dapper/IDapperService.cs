using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dapper
{
    public interface IDapperService : IDisposable
    {
        DbConnection GetDbconnection();
        T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        Task<int> Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        T Insert<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        T Update<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);

        IEnumerable<TResult> GetNested<T1, T2, T3, TResult>(string sp, Func<T1, T2, T3, TResult> p, string s, CommandType commandType);
        IEnumerable<TResult> GetNested<T1, T2, TResult>(string sp, Func<T1, T2, TResult> p, string s, CommandType commandType);
    }
}
