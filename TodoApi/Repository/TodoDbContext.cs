using Microsoft.EntityFrameworkCore;
using TodoApi.Domain.Entity;

namespace TodoApi.Repository;

public class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Todo> Todos { get; set; }
}
