using IbgeApi.Models.ValueObjects;

namespace IbgeApi.Models;

public class LocationModel
{
    public int Id { get; set; }
    public State State { get; set; } = new();
    public City City { get; set; } = new();
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; }
}