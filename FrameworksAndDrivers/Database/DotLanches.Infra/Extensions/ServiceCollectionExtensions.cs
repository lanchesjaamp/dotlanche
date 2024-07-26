using DotLanches.Database.Repositories;
using DotLanches.Domain.Interfaces.Repositories;
using DotLanches.Infra.Data;
using DotLanches.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotLanches.Infra.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DotLanchesDbContext>(
                opt => opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            bool.TryParse(configuration.GetSection("RunMigrationsOnStartup").Value, out var shouldRunMigrations);

            if (shouldRunMigrations)
                services.MigrateDatabase();

            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IPagamentoRepository, PagamentoRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();

            return services;
        }

        private static void MigrateDatabase(this IServiceCollection services)
        {
            using (var serviceScope = services.BuildServiceProvider().GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DotLanchesDbContext>() ??
                    throw new ApplicationException("Failed to migrate database!");

                context.Database.Migrate();
            }
        }
    }
}