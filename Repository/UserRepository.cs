using IbgeApi.Data;
using IbgeApi.Models;
using IbgeApi.Repository.Interfaces;
using IbgeApi.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace IbgeApi.Repository;

public class UserRepository : IUserRepository
{
    public UserRepository(IbgeDbContext context)
    {
        _context = context;
    }

    private readonly IbgeDbContext _context;

    public async Task<UserModel> GetByEmail(string email)
    {
        return await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Email.EmailAddress == email);
    }

    public async Task<UserModel> GetByCredentials(string email, string password)
    {
        return await _context.Users
            .AsNoTracking()
            .Where(x => x.Email.EmailAddress == email && x.PasswordHash.Hash == password)
            .FirstOrDefaultAsync();
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