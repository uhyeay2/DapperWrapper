using DapperWrapper.Abstractions;
using Dapper;

namespace DapperWrapper
{
    public class DataHandler : IDataHandler
    {
        public DataHandler(IDbConnectionFactory connectionFactory) => _connectionFactory = connectionFactory;

        private readonly IDbConnectionFactory _connectionFactory;

        public async Task<int> ExecuteAsync(IRequestObject request)
        {
            using var connection = _connectionFactory.NewConnection();

            return await connection.ExecuteAsync(request.GenerateSql(), request.GenerateParameters());
        }

        public async Task<TOutput?> FetchAsync<TOutput>(IRequestObject request)
        {
            using var connection = _connectionFactory.NewConnection();

            return (await connection.QueryAsync<TOutput>(request.GenerateSql(), request.GenerateParameters())).FirstOrDefault();
        }

        public async Task<IEnumerable<TOutput>> FetchListAsync<TOutput>(IRequestObject request)
        {
            using var connection = _connectionFactory.NewConnection();

            return await connection.QueryAsync<TOutput>(request.GenerateSql(), request.GenerateParameters());
        }
    }
}
