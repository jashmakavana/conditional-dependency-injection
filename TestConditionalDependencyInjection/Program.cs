using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestConditionalDependencyInjection;

class Program
{
    static async Task Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection, configuration);
        var serviceProvider = serviceCollection.BuildServiceProvider();

        var class1 = serviceProvider.GetRequiredService<Class1>();

        // var factory = serviceProvider.GetRequiredService<ISqlDataAccessFactory>();

        ////var defaultDb = serviceProvider.GetRequiredService<ISqlDataAccess>();
        ////var defaultDbNew = serviceProvider.GetRequiredKeyedService<Func<SqlAccessType, ISqlDataAccess>>(SqlAccessType.Default);
        ////var paymentDb = serviceProvider.GetRequiredKeyedService<Func<SqlAccessType, ISqlDataAccess>>(SqlAccessType.Payment);
        // var paymentDb = factory.GetSqlDataAccess(SqlAccessType.Payment);
    }

    private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IConfiguration>(configuration);

        services.AddSingleton<Class1>();

        services.AddScoped<SqlDataAccess>();
        services.AddScoped<PaymentSqlDataAccess>();
        services.AddScoped<ISqlDataAccess, SqlDataAccess>();
        services.AddScoped<Func<SqlAccessType, ISqlDataAccess>>(provider => sqlAccessType =>
        {
            return sqlAccessType switch
            {
                SqlAccessType.Payment => provider.GetRequiredService<PaymentSqlDataAccess>(),
                SqlAccessType.Default => provider.GetRequiredService<SqlDataAccess>(),
                _ => throw new NotSupportedException()
            };
        });

        // services.AddScoped<ISqlDataAccessFactory, SqlDataAccessFactory>();
    }
}
