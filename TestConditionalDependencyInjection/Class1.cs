namespace TestConditionalDependencyInjection
{
    public class Class1
    {
        private readonly ISqlDataAccess paymentSqlDataAccess;
        private readonly ISqlDataAccess defaultSqlDataAccess;
        private readonly ISqlDataAccess sqlDataAccess;

        public Class1(Func<SqlAccessType, ISqlDataAccess> dataAccess, ISqlDataAccess sqlDataAccess)
        {
            this.sqlDataAccess = sqlDataAccess;
            this.paymentSqlDataAccess = dataAccess.Invoke(SqlAccessType.Payment);
            this.defaultSqlDataAccess = dataAccess.Invoke(SqlAccessType.Default);

            Console.WriteLine("sqlDataAccess:" + this.sqlDataAccess.GetConnectionString());
            Console.WriteLine("paymentSqlDataAccess:" + this.paymentSqlDataAccess.GetConnectionString());
            Console.WriteLine("defaultSqlDataAccess:" + this.defaultSqlDataAccess.GetConnectionString());
        }
    }
}
