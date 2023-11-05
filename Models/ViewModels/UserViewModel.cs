using Flunt.Notifications;
using Flunt.Validations;

namespace IbgeApi.ViewModels;

public class UserViewModel : Notifiable<Notification>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public void Validate()
    {
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsNotNullOrEmpty(Name, "Name", "Informe um nome")
            .IsNotNullOrEmpty(Email, "Email", "Informe o email")
            .IsEmail(Email, "Email", "Email inválido")
            .IsNotNullOrEmpty(Password, "Password", "Informe uma senha")
            .IsGreaterOrEqualsThan(Password, 4, "Password", "A senha deve conter pelo menos 4 caracteres"));
    }
}