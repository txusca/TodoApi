using TodoApi.Domain.Entity;

namespace TodoApi.Repository;

public class TodoRepository : IRepository<Todo>
{
    private readonly TodoDbContext _context;
    public TodoRepository(TodoDbContext context)
    {
        this._context = context;
    }
    public Task Create(Todo todo)
    {
        var entity = new Todo { Id = Guid.NewGuid(), Title = todo.Title, Completed = false };
        _context.Todos.Add(entity);


        return Task.Run(() => _context.SaveChanges());
    }

    public Task Delete(Guid guid)
    {
        var finded = _context.Todos.FirstOrDefault(t => t.Id == guid);
        if (finded == null)
        {
            throw new Exception();
        }
        _context.Todos.Remove(finded);
        return Task.Run(() => _context.SaveChanges());
    }

    public Task<Todo?> Get(Guid id)
    {
        return Task.Run(() => _context.Todos.FirstOrDefault(t => t.Id == id));
    }

    public Task<IEnumerable<Todo>> GetAll()
    {
        return Task.Run<IEnumerable<Todo>>(() => _context.Todos.ToList<Todo>());
    }

    public Task Update(Guid id, Todo todo)
    {
        var todoFinded = _context.Todos.FirstOrDefault(t => t.Id == id);
        if (todoFinded == null)
        {
            throw new Exception("Todo não encontrado.");
        }

        todoFinded.Title = todo.Title;
        todoFinded.Completed = false;
        return Task.Run(() => _context.SaveChanges());
    }
}
