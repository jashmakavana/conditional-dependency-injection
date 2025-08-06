using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TestConditionalDependencyInjection
{
    public class SqlDataAccessGeneric : ISqlDataAccessGeneric<SqlAccessType.Default>
    {
        public Task<IEnumerable<T>> GetData<T, U>(string queryString, U parameters, CommandType commandType = CommandType.Text, [CallerMemberName] string callerName = "")
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveData<T>(string queryString, T parameters, CommandType commandType = CommandType.Text, [CallerMemberName] string callerName = "")
        {
            throw new NotImplementedException();
        }
    }
}
