namespace DapperWrapper.Abstractions
{
    public interface IDataHandler
    {
        public Task<IEnumerable<TOutput>> FetchListAsync<TOutput>(IRequestObject request);

        public Task<TOutput?> FetchAsync<TOutput>(IRequestObject request);

        public Task<int> ExecuteAsync(IRequestObject request);
    }
}
