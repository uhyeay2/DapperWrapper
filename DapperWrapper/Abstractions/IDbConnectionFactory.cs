namespace DapperWrapper.Abstractions
{
    public interface IDbConnectionFactory
    {
        System.Data.IDbConnection NewConnection();
    }
}
