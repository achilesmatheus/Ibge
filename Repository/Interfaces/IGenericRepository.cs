using IbgeApi.ValueObjects;

namespace IbgeApi.Repository.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<T> GetByEmail(string email);
    Task<T> GetByCredentials(string email, string password);
    Task Create(T entity);
    Task Update(T entity);
    Task Remove(T entity);
}