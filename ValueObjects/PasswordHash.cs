namespace IbgeApi.ValueObjects;

public class PasswordHash
{
    public PasswordHash(string hash)
    {
        Hash = hash;
    }

    public string Hash { get; }
}