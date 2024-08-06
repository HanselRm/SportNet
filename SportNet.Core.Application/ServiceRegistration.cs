

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportNet.Core.Application.Interfaces.Services;
using SportNet.Core.Application.Services;
using System.Reflection;

namespace SportNet.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddAplicationLayer(this IServiceCollection service, IConfiguration configuracion)
        {
            service.AddAutoMapper(Assembly.GetExecutingAssembly());
            #region Service Dependency
            service.AddTransient<IUserServices, UserServices>();
            #endregion
        }
    }
}
