namespace IbgeApi.Models.ValueObjects;

public class City
{
    public City()
    {
    }

    public City(string cityName)
    {
        CityName = cityName;
    }

    public string CityName { get; }
}