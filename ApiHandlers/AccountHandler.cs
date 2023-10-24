using IbgeApi.Models;
using IbgeApi.Repository;
using IbgeApi.Repository.Interfaces;
using IbgeApi.Services;
using IbgeApi.Services.Interfaces;
using IbgeApi.ValueObjects;
using IbgeApi.ViewModels;

namespace IbgeApi.ApiHandlers;

public class AccountHandler
{
    public static Task<IResult> SignUp(IUserService service, CreateUserViewModel model)
    {
        return service.Signup(model);
    }

    public static async Task<IResult> Login(LoginViewModel model, IUserRepository repository,
        ITokenService tokenService)
    {
        model.Validate();
        if (model.IsValid == false) return Results.BadRequest(model.Notifications);

        try
        {
            var user = await repository.GetByEmail(model.Email);
            var passwordsAreNotEquals = !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash.Hash);

            if (user is null || passwordsAreNotEquals)
                throw new Exception("Usuário ou senha incorretos");

            var token = tokenService.GenerateToken(user);

            var result = new ResultViewModel<string>()
            {
                Message = $"Token gerado para o usuário: {user.Name.FirstName}",
                Data = token
            };

            return Results.Ok(result);
        }
        catch (Exception e)
        {
            var result = new ResultViewModel<string>() { Errors = e.Message };
            return Results.BadRequest(result);
        }
    }
}