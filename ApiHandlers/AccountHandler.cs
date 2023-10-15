using IbgeApi.Models;
using IbgeApi.Repository;
using IbgeApi.Repository.Interfaces;
using IbgeApi.Services;
using IbgeApi.ValueObjects;
using IbgeApi.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace IbgeApi.ApiHandlers;

public class AccountHandler
{
    public static async Task<IResult> SignIn(CreateUser model, IUserRepository repository)
    {
        var user = new UserModel();
        user.Name = new Name(model.Name);
        user.Email = new Email(model.Email);
        user.PasswordHash = new PasswordHash(model.Password);

        await repository.Create(user);
        return Results.Ok("Created");
    }
}