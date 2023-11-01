using IbgeApi.Repository.Interfaces;
using IbgeApi.ViewModels;

namespace IbgeApi.Services.Interfaces;

public interface IUserService
{
    Task<IResult> Signup(UserViewModel model);
    Task<IResult> Login(LoginViewModel model);
}