using Flunt.Notifications;
using Flunt.Validations;

namespace IbgeApi.ViewModels;

public class CreateUser : Notifiable<Notification>
{
    public CreateUser(string name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
    }

    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    private void Validate()
    {
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsEmail(Email, "Email", "Email inválido"));
    }
}