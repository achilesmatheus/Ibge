namespace IbgeApi.ValueObjects;

public class Name
{
    public Name(string firstName)
    {
        FirstName = firstName;
    }

    public string FirstName { get; }
}