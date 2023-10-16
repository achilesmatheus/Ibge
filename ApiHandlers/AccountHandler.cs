using IbgeApi.Models;
using IbgeApi.Repository.Interfaces;
using IbgeApi.Services;
using IbgeApi.ValueObjects;
using IbgeApi.ViewModels;

namespace IbgeApi.ApiHandlers;

public abstract class AccountHandler
{
    public static async Task<IResult> SignIn(CreateUserViewModel model, IUserRepository repository)
    {
        // Fail fast validation
        model.Validate();
        if (model.IsValid == false) return Results.BadRequest(model.Notifications);

        try
        {
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);
            var user = new UserModel
            {
                Name = new Name(model.Name),
                Email = new Email(model.Email),
                PasswordHash = new PasswordHash(passwordHash)
            };

            await repository.Create(user);

            var result = new ResultViewModel<object>()
            {
                Message = "User created successfully",
                Data = new
                {
                    Name = user.Name.FirstName,
                    Email = user.Email.EmailAddress
                }
            };

            return Results.Ok(result);
        }
        catch (Exception e)
        {
            var result = new ResultViewModel<string>()
            {
                Errors = e.Message
            };

            return Results.BadRequest(result);
        }
    }

    public static async Task<IResult> Login(LoginViewModel model, IUserRepository repository, TokenService tokenService)
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