using DotLanches.Application.Services;
using DotLanches.Infra.Extensions;

var builder = WebApplication.CreateBuilder(args);
AddServices(builder);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

static WebApplicationBuilder AddServices(WebApplicationBuilder builder)
{
    builder.Services.AddControllers();
    builder.Services.ConfigureDatabase(builder.Configuration);
    builder.Services.AddScoped<IProdutoService, ProdutoService>();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    return builder;
}