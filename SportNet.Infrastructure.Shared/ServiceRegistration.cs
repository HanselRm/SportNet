using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportNet.Core.Application.Services;
using SportNet.Core.Domain.Settings;
using SportNet.Infrastructure.Shared.Services;

namespace SportNet.Infrastructure.Shared
{
    public static class ServiceRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection service, IConfiguration configuracion)
        {
            service.Configure<MailSettings>(configuracion.GetSection("MailSettings"));
            service.AddTransient<IEmailServices, EmailServices>();

        }
    }
}