using IbgeApi.Data;
using IbgeApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IbgeApi.Repository;

public abstract class GenericRepository<T>(IbgeDbContext context) : IGenericRepository<T>
    where T : class
{
    public async Task Create(T entity)
    {
        await context.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task<IList<T>> GetAll(int skip = 0, int take = 15)
    {
        return await context.Set<T>()
            .AsNoTracking()
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }

    public async Task Update(T entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task Remove(T entity)
    {
        context.Remove(entity);
        await context.SaveChangesAsync();
    }
}