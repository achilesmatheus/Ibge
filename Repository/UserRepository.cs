using IbgeApi.Data;
using IbgeApi.Models;
using IbgeApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IbgeApi.Repository;

public class UserRepository : IUserRepository
{
    private readonly IbgeDbContext _context;

    public async Task<UserModel> GetById(Guid id)
    {
        return await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Create(UserModel entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(UserModel entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Remove(UserModel entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }
}