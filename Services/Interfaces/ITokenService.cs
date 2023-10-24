using IbgeApi.Models;

namespace IbgeApi.Services.Interfaces;

public interface ITokenService
{
    string GenerateToken(UserModel model);
}