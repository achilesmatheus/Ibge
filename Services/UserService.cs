using IbgeApi.Models;
using IbgeApi.Repository.Interfaces;
using IbgeApi.Services.Interfaces;
using IbgeApi.ValueObjects;
using IbgeApi.ViewModels;

namespace IbgeApi.Services;

public class UserService : IUserService
{
    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    private readonly IUserRepository _repository;

    public async Task<IResult> Signup(CreateUserViewModel _model)
    {

        _model.Validate();
        if (_model.IsValid == false) return Results.BadRequest(_model.Notifications);

        try
        {
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(_model.Password);
            var user = new UserModel
            {
                Name = new Name(_model.Name),
                Email = new Email(_model.Email),
                PasswordHash = new PasswordHash(passwordHash)
            };

            await _repository.Create(user);

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

    public Task<IResult> Login(LoginViewModel model)
    {
        throw new NotImplementedException();
    }
}