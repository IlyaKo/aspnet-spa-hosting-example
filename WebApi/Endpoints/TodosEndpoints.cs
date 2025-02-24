using Application.Todos;

namespace WebApi.Endpoints;

public static class TodosEndpoints
{
    public static void Map(IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("api/todos");

        group.MapGet(string.Empty, 
            async (ITodoService service) => await service.GetAll());

        group.MapPost(string.Empty,
            async (ITodoService service, TodoItemCreateDto dto) => await service.Add(dto));

        group.MapPut("{id}/status",
           async (ITodoService service, int id, bool isDone) => await service.SetIsDoneStatus(id, isDone));
        
        group.MapDelete("{id}",
            async (ITodoService service, int id) => await service.Delete(id));
    }
}
