namespace TodoApi.Repository;

public interface IRepository<T>
{
    Task<IEnumerable<T>> GetAll();
    Task<T?> Get(Guid guid);
    Task Create(T item);
    Task Update(Guid id, T item);
    Task Delete(Guid guid);
}
