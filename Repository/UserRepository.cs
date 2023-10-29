using IbgeApi.Data;
using IbgeApi.Models;
using IbgeApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IbgeApi.Repository;

public class UserRepository(IbgeDbContext context) : GenericRepository<UserModel>(context), IUserRepository
{
    public async Task<UserModel> GetByEmail(string email)
    {
        return await context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Email.EmailAddress == email);
    }

    public async Task<UserModel> GetByCredentials(string email, string password)
    {
        return await context.Users
            .AsNoTracking()
            .Where(x => x.Email.EmailAddress == email && x.PasswordHash.Hash == password)
            .FirstOrDefaultAsync();
    }
}