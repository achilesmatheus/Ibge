using IbgeApi.Models;

namespace IbgeApi.Repository.Interfaces;

public interface IUserRepository : IGenericRepository<UserModel>
{
    public Task<UserModel> GetByEmail(string email);
    public Task<UserModel> GetByCredentials(string email, string password);
}