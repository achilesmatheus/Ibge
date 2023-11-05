using Flunt.Notifications;
using Flunt.Validations;

namespace IbgeApi.ViewModels;

public class LoginViewModel : Notifiable<Notification>
{
    public string Email { get; set; }
    public string Password { get; set; }

    public void Validate()
    {
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsNotNullOrEmpty(Email, "Email", "Preencha o campo email")
            .IsEmail(Email, "Email", "O email digitado não é válido")
            .IsNotNullOrEmpty(Password, "Password", "Preencha o campo password"));
    }
}