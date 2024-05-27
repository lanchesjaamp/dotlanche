using DotLanches.Api.Filters;
using DotLanches.Application.Services;
using DotLanches.Domain.Interfaces.Services;
using DotLanches.Infra.Extensions;
using Microsoft.OpenApi.Models;
using System.Reflection;
using DotLanches.Domain.Ports;
using DotLanches.Payment.FakeCheckout;

namespace DotLanches.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.ConfigureSwagger();

            services.ConfigureDatabase(configuration);
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<IPagamentoService, PagamentoService>();
            services.AddScoped<ICheckout, FakeCheckout>();
            services.AddExceptionHandler<ExceptionFilter>();
            services.AddProblemDetails();

            return services;
        }

        private static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "DotLanches API",
                    Description = "Backend de gerenciamento LanchesJaamp"
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            return services;
        }
    }
}