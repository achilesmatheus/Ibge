using IbgeApi.Models;
using IbgeApi.Repository;
using IbgeApi.Repository.Interfaces;
using IbgeApi.Services;
using IbgeApi.Services.Interfaces;
using IbgeApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IbgeApi.ApiHandlers;

public class AccountHandler
{
    public static Task<IResult> SignUp(IUserService service, CreateUserViewModel model)
    {
        return service.Signup(model);
    }

    public static Task<IResult> Login(IUserService service, LoginViewModel model)
    {
        return service.Login(model);
    }
}