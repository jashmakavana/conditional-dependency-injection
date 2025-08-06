using Microsoft.Extensions.DependencyInjection;

namespace TestConditionalDependencyInjection;

public class SqlDataAccessFactory : ISqlDataAccessFactory
{
    private readonly IServiceProvider _serviceProvider;

    public SqlDataAccessFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public ISqlDataAccess GetSqlDataAccess(SqlAccessType accessType)
    {
        return accessType switch
        {
            SqlAccessType.Payment => _serviceProvider.GetRequiredService<PaymentSqlDataAccess>(),
            _ => _serviceProvider.GetRequiredService<SqlDataAccess>(),
        };
    }
}
