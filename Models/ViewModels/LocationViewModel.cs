using Flunt.Notifications;
using Flunt.Validations;
using IbgeApi.Models;
using IbgeApi.Models.ValueObjects;

namespace IbgeApi.ViewModels;

public class LocationViewModel : Notifiable<Notification>
{
    public string State { get; set; }
    public string City { get; set; }

    public void Validate()
    {
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsNotNullOrEmpty(State, "State", "Preencha o campo Estado")
            .IsNotNullOrEmpty(City, "City", "Preencha o campo Cidade")
        );
    }

    public LocationModel ToModel()
    {
        var user = new LocationModel()
        {
            State = new State(State),
            City = new City(City)
        };

        return user;
    }
}