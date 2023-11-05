namespace IbgeApi.Models.ValueObjects;

public class Name
{
    public Name()
    {
    }

    public Name(string firstName)
    {
        FirstName = firstName;
    }

    public string FirstName { get; }
}