namespace WebApi.Entities;

public sealed class Expense
{
    public int Id { get; set; }

    /// <summary>
    /// Positive (income) or negative (expense) 
    /// </summary>
    public decimal Amount { get; set; }

    public string Description { get; set; } = string.Empty;

    public DateTime? Date { get; set; }
}
