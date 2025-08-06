namespace TestConditionalDependencyInjection;

public interface ISqlDataAccessFactory
{
    ISqlDataAccess GetSqlDataAccess(SqlAccessType accessType);
}
