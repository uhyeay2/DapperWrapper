namespace DapperWrapper.Abstractions
{
    public interface IRequestObject
    {
        public object? GenerateParameters();

        public string GenerateSql();
    }
}
