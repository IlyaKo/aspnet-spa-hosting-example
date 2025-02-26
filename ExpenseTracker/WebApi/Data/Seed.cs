using WebApi.Entities;

namespace WebApi.Data;

public static class Seed
{
    public static Expense[] Expenses { get; } =
    [
        new() { Amount = 500, Description = "Salary", Date = new(2024, 01, 10) },
        new() { Amount = -20, Description = "Weekend shopping", Date = new(2024, 01, 12) },
        new() { Amount = -50, Description = "Dinner with friends", Date = new(2024, 01, 15) },
        new() { Amount = -30, Description = "Concert tickets", Date = new(2024, 01, 20) },
        new() { Amount = -10, Description = "Lunch", Date = new(2024, 01, 25) },
        new() { Amount = 100, Description = "Gift", Date = new(2024, 01, 30) },
        new() { Amount = -120, Description = "Car spendings", Date = new(2024, 02, 01) },
    ];
}
