

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportNet.Core.Application.Interfaces.Repositories;
using SportNet.Infrastructure.Persistence.Context;
using SportNet.Infrastructure.Persistence.Repositories;

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

            #region Repositories
            service.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            service.AddTransient<IUserRepository, UserRepository>();
            service.AddTransient<IEventRepository, EventRepository>();
            #endregion

            return service;
        }
    }
}
