using Application.Todos;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Scalar.AspNetCore;
using WebApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var rootPath = builder.Environment.ContentRootPath;

AddServices(builder.Services);

var app = builder.Build();

UpdateDatabase(app.Services);
ConfigurePipeline(app);

app.Run();

void AddServices(IServiceCollection services)
{
    services.AddOpenApi();
    services.AddDbContext<AppDbContext>(options =>
    {
        var databasePath = Path.Combine(rootPath, "..", "Data", "Database", "sqlite.db"); 
        options.UseSqlite("Data Source=" + databasePath);
    });
    services.AddScoped<ITodoService, TodoService>();
}

void ConfigurePipeline(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
        app.MapScalarApiReference();
    }

   TodosEndpoints.Map(app);

    // Serve the frontend static files
    var frontendPath = Path.Combine(rootPath, "..", "client", "dist");
    var frontendStaticFiles = new StaticFileOptions()
    {
        FileProvider = new PhysicalFileProvider(frontendPath)
    };
    app.UseStaticFiles(frontendStaticFiles);
    app.UseSpa(spa =>
    {
        spa.Options.DefaultPageStaticFileOptions = frontendStaticFiles;
    });
}

static void UpdateDatabase(IServiceProvider services)
{
    var scope = services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}


