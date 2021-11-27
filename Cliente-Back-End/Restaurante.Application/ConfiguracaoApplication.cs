using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Restaurante.Clientes.Application.Comum;
using System.Text;
using Restaurante.Clientes.Domain.Comum.Modelos.Intefaces;
using Restaurante.Clientes.Application.Hubs.Services;
using Restaurante.Clientes.Application.Hubs.Services.Intefaces;
using System;

[assembly: InternalsVisibleTo("Restaurante.Clientes.Test")]
namespace Restaurante.Application
{
    public static class ConfiguracaoApplication
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddHubService()
                .AddTokenService(configuration);


        internal static IServiceCollection AddHubService(this IServiceCollection services) =>
            services.AddSingleton<IInvoiceHubService, InvoiceHubService>();

        internal static IServiceCollection AddTokenService(this IServiceCollection services, IConfiguration configuration)
        {
            var tokenConfiguration = configuration.GetSection(nameof(TokenConfiguration)).Get<TokenConfiguration>();

            services.AddSingleton(tokenConfiguration);

            var key = Encoding.UTF8.GetBytes(tokenConfiguration.SecretKey);

            services.AddAuthentication(auth =>
                {
                    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero,
                        ValidateLifetime = true
                    };
                });

            services.AddTransient<ITokenService, TokenService>();

            return services;
        }
    }
}
