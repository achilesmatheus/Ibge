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
    public AccountHandler()
    {
    }

    public AccountHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    private readonly IUserRepository _repository;

    public async Task<IResult> SignIn(CreateUser model)
    {
        var user = new UserModel();
        user.Name = new Name(model.Name);
        user.Email = new Email(model.Email);
        user.PasswordHash = new PasswordHash(model.Password);

        await _repository.Create(user);
        return Results.Ok("Created");
    }
}