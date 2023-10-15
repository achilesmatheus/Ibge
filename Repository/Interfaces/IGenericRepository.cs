namespace IbgeApi.Repository.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<T> GetById(Guid id);
    Task Create(T entity);
    Task Update(T entity);
    Task Remove(T entity);
}