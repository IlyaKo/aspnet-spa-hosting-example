namespace WebApi.Endpoints;

public static class AdminEndpoints
{
    public static void Map(IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("api/admin");

        group.MapGet("ping", () => "pong");
    }
}
