namespace TodoApi.Dtos;

public class UpdateTodoDto
{
    public string? Title { get; set; } = String.Empty;
    public bool Completed { get; set; }
}
