using Scalar.AspNetCore;
using WebApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

AddServices(builder.Services);

var app = builder.Build();

ConfigurePipeline(app);

app.Run();

static void AddServices(IServiceCollection services)
{
    services.AddOpenApi();
}

static void ConfigurePipeline(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
        app.MapScalarApiReference();
    }

    AdminEndpoints.Map(app);
}



