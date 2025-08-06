using Microsoft.Extensions.Configuration;
using System.Data;
using System.Runtime.CompilerServices;

namespace TestConditionalDependencyInjection
{
    public class PaymentSqlDataAccess : ISqlDataAccess
    {
        private readonly string _connectionString;

        public PaymentSqlDataAccess(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultPayment");
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
