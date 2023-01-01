using DapperWrapper.Abstractions;
using System.Data.SqlClient;
using System.Data;

namespace DapperWrapper
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        public DbConnectionFactory(ISqlConfig sqlConfig) => _sqlConfig = sqlConfig;

        private readonly ISqlConfig _sqlConfig = null!;

        public IDbConnection NewConnection()
        {
            var connection = new SqlConnection(_sqlConfig.GetConnectionString());
            
            connection.Open();

            return connection;
        }
    }
}
