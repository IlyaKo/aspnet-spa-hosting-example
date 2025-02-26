using Data.Entities;
using Data.Seed;
using Microsoft.EntityFrameworkCore;

namespace Data;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options)
    : DbContext(options)
{
    public DbSet<TodoItem> Items => Set<TodoItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TodoItem>(
            entity =>
            {
                entity.HasData(TodoItems.SeedData);
                entity.Property(e => e.Content).HasMaxLength(500);
            }
        );
    }
}
