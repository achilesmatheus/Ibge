using IbgeApi.ValueObjects;

namespace IbgeApi.Models;

public class UserModel
{
    public Guid Id { get; set; }
    public Name Name { get; set; }
    public Email Email { get; set; }
    public PasswordHash PasswordHash { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; }
}