using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Todos;

public sealed class TodoService(AppDbContext dbContext) : ITodoService
{
    public async Task<IReadOnlyList<TodoItemView>> GetAll()
        => await dbContext.Items
                          .Select(item => new TodoItemView(item))
                          .ToListAsync();

    public async Task<TodoItemView> Add(TodoItemCreateDto dto)
    {
       ArgumentOutOfRangeException.ThrowIfGreaterThan(dto.Content.Length, 500, nameof(dto.Content));

        var item = new TodoItem
        {
            Content = dto.Content,
            IsDone = false,
            CreatedAt = DateTime.UtcNow
        };
        dbContext.Items.Add(item);

        await dbContext.SaveChangesAsync();

        return new(item);
    }

    public async Task SetIsDoneStatus(int id, bool isDone)
    {
        var item = await dbContext.Items.FindAsync(id)
            ?? throw new ArgumentException("Can't find an item with the id " + id);
        
        item.IsDone = isDone;
        await dbContext.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var item = await dbContext.Items.FindAsync(id);
        if (item is null)
            return;

        dbContext.Items.Remove(item);
        await dbContext.SaveChangesAsync();
    }
}
