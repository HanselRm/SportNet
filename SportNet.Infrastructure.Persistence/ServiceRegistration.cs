

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportNet.Infrastructure.Persistence.Context;

namespace SportNet.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceInfrastructure(this IServiceCollection service, IConfiguration configuracion)
        {
            #region Context
            service.AddDbContext<DbContex>(option =>
                option.UseSqlServer(configuracion.GetConnectionString("Default"),
                m => m.MigrationsAssembly(typeof(DbContex).Assembly.FullName)));
            #endregion

            return service;
        }
    }
}
