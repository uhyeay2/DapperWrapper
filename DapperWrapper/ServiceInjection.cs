using DapperWrapper.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DapperWrapper
{
    public static class ServiceInjection
    {
        /// <summary>
        /// Inject DbConnectionFactory and DataHandler services. To utilize this service you must inject your own implementation of
        /// ISqlConfig for the DbConnectionFactory to obtain the Sql Connection String.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IServiceCollection InjectDapperWrapper(this IServiceCollection services, ISqlConfig sqlConfig)
        {
            if(services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddSingleton(sqlConfig);
            services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();
            services.AddSingleton<IDataHandler, DataHandler>();

            return services;
        }
    }
}
