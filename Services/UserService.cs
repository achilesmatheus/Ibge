using IbgeApi.Models;
using IbgeApi.Models.ValueObjects;
using IbgeApi.Repository.Interfaces;
using IbgeApi.Services.Interfaces;
using IbgeApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IbgeApi.Services;

public class UserService(IUserRepository repository, ITokenService tokenService) : IUserService
{
    public async Task<IResult> Signup(UserViewModel model)
    {
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

            var result = new ResultViewModel()
            {
                Message = "User created successfully",
                Data = new
                {
                    Name = user.Name.FirstName,
                    Email = user.Email.EmailAddress
                }
            };

            return Results.Created("/signup", result);
        }
        catch (Exception e)
        {
            var result = new ResultViewModel()
            {
                Errors = e.Message
            };

            return Results.BadRequest(result);
        }
    }

    public async Task<IResult> Login(LoginViewModel loginViewModel)
    {
        loginViewModel.Validate();
        if (loginViewModel.IsValid == false)
            return Results.BadRequest(loginViewModel.Notifications);

        try
        {
            var user = await repository.GetByEmail(loginViewModel.Email);
            var passwordsAreNotEquals = !BCrypt.Net.BCrypt.Verify(loginViewModel.Password, user.PasswordHash.Hash);

            if (user is null || passwordsAreNotEquals)
                throw new Exception("Usuário ou senha incorretos");

            var token = tokenService.GenerateToken(user);

            var result = new ResultViewModel()
            {
                Message = $"Token gerado para o usuário: {user.Name.FirstName}",
                Data = token
            };

            return Results.Ok(result);
        }
        catch (Exception e)
        {
            var result = new ResultViewModel() { Errors = e.Message };
            return Results.BadRequest(result);
        }
    }
}