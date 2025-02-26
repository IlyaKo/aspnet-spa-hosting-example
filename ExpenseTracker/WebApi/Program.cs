using WebApi.Data;

var builder = WebApplication.CreateBuilder(args);

var clientPolicyKey = "Frontend";

builder.Services.AddCors(options =>
{
    options.AddPolicy(clientPolicyKey, policy =>
    {
        var allowedOrigins = builder.Configuration.GetRequiredSection("CorsOrigins").Get<string[]>();
        if (allowedOrigins is null || allowedOrigins.Length == 0)
            throw new ArgumentException("Please set up allowed origins");

        policy.WithOrigins(allowedOrigins)
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("/api/expenses", () => Seed.Expenses);
app.UseCors(clientPolicyKey);
app.Run();
