using Data.Entities;

namespace Data.Seed;

public static class TodoItems
{
    public static List<TodoItem> SeedData
        =>
        [
            new() { Id = 1, Content = "Learn C#", IsDone = true, CreatedAt = new(2025, 01, 01) },
            new() { Id = 2, Content = "Learn EF Core", IsDone = false, CreatedAt = new(2025, 01, 02) },
            new() { Id = 3, Content = "Learn ASP.NET Core", IsDone = false, CreatedAt = new(2025, 01, 03) },
            new() { Id = 4, Content = "Learn hosting models", IsDone = false, CreatedAt = new(2025, 02, 01) },
        ];
}
