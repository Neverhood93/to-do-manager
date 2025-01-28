using Microsoft.EntityFrameworkCore;
using ToDoManager.Domain.Entities;

namespace ToDoManager.Infrastructure;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options) { }

    public DbSet<ToDo> ToDos { get; set; }
    public DbSet<ToDoStatus> ToDoStatuses { get; set; }
    public DbSet<ToDoFile> Files { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ToDo>()
            .HasOne<ToDoStatus>(t => t.Status)
            .WithMany(s => s.ToDos)
            .HasForeignKey(t => t.StatusId);

        modelBuilder
            .Entity<ToDo>()
            .HasMany<ToDoFile>(t => t.Files)
            .WithOne(f => f.ToDo)
            .HasForeignKey(f => f.ToDoId);
    }
}