using IbgeApi.Models.ValueObjects;

namespace IbgeApi.Models;

public class UserModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Name Name { get; set; } = new();
    public Email Email { get; set; } = new();
    public PasswordHash PasswordHash { get; set; } = new();
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; }
}