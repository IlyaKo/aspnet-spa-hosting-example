namespace Application.Todos;

public interface ITodoService
{
    Task<IReadOnlyList<TodoItemView>> GetAll();

    Task<TodoItemView> Add(TodoItemCreateDto dto);

    Task SetIsDoneStatus(int id, bool isDone);

    Task Delete(int id);
}