using DotLanches.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureApplicationServices(builder.Configuration);

var app = builder.Build();

app.MapHealthChecks("/health");

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.UseExceptionHandler();

app.Run();