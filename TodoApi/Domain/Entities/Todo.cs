namespace TodoApi.Domain.Entity;

public class Todo
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public bool Completed { get; set; }
}
