using DotLanches.Api.Filters;
using DotLanches.Infra.Extensions;
using System.Reflection;
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
            services.AddScoped<ICheckout, FakeCheckout>();
            services.AddExceptionHandler<ExceptionFilter>();
            services.AddProblemDetails();

            services.ConfigureHealthChecks(configuration);

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

        private static IServiceCollection ConfigureHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection") ??
                throw new Exception("No database connection string found!");

            services.AddHealthChecks()
                .AddNpgSql(connectionString);

            return services;
        }
    }
}