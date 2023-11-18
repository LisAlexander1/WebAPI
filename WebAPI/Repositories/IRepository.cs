using WebAPI.Models;

namespace WebAPI.Repositories;

public interface IRepository<T> where T : class, IEntity
{
    Task<List<T>> GetAll();
    Task<T?> Get(Guid id);
    Task<T?> Add(T entity);
    Task<T> Update(T entity);
    Task<T> Delete(Guid id);
}