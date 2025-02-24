namespace Data.Entities;

public sealed class TodoItem
{
    public int Id { get; set; }

    public required string Content { get; set; }

    public bool IsDone { get; set; }

    public DateTime CreatedAt { get; set; }
}
