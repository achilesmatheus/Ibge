using Flunt.Notifications;
using Flunt.Validations;

namespace IbgeApi.ViewModels;

public class CreateUserViewModel : Notifiable<Notification>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public void Validate()
    {
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsNotNullOrEmpty(Email, "Email", "Informe o email")
            .IsEmail(Email, "Email", "Email inválido"));
    }
}