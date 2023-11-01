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
    /// <summary>
    /// Cria um novo usuário
    /// </summary>
    /// <param name="service"></param>
    /// <param name="model"></param>
    /// <returns></returns>
    /// <response code="201">Caso o usuário seja cadastrado com sucesso</response>
    /// <response code="400">Caso não seja possível criar um usuário ou o email fornecido já estaja cadastrado</response>
    public static Task<IResult> SignUp(IUserService service, UserViewModel model)
    {
        return service.Signup(model);
    }

    /// <summary>
    /// Verifica se o usuário está cadastrado e retorna um token. 
    /// </summary>
    /// <param name="service"></param>
    /// <param name="model"></param>
    /// <returns></returns>
    /// <response code="200">Caso os dados estejam corretos</response>
    /// <response code="400">Caso o usuário não exista ou os dados fornecidos estejam incorretos</response>
    public static Task<IResult> Login(IUserService service, LoginViewModel model)
    {
        return service.Login(model);
    }
}