using Microsoft.Extensions.Configuration;
using System.Data;
using System.Runtime.CompilerServices;

namespace TestConditionalDependencyInjection
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly string _connectionString;

        public SqlDataAccess(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("Default");
        }
        public string GetConnectionString()
        {
            return this._connectionString;
        }

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
