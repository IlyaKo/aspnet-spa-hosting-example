using Data.Entities;

namespace Application.Todos;

public sealed class TodoItemView(TodoItem source)
{
    public int Id { get; } = source.Id;

    public string Content { get; } = source.Content;

    public bool IsDone { get; } = source.IsDone;

    public DateTime CreatedAt { get; } = source.CreatedAt;
}
