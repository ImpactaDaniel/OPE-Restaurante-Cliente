using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Restaurante.Application
{
    public static class ConfiguracaoApplication
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) =>
            services.AddMediatR(Assembly.GetExecutingAssembly());
    }
}
