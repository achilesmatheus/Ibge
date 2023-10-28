namespace IbgeApi.Repository.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task Create(T entity);
    Task<IList<T>> GetAll(int skip, int take);
    Task Update(T entity);
    Task Remove(T entity);
}