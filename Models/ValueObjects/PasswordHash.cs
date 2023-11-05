namespace IbgeApi.Models.ValueObjects;

public class PasswordHash
{
    public PasswordHash()
    {
    }

    public PasswordHash(string hash)
    {
        Hash = hash;
    }

    public string Hash { get; }
}