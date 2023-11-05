namespace IbgeApi.Models.ValueObjects;

public class Email
{
    public Email()
    {
    }

    public Email(string emailAddress)
    {
        EmailAddress = emailAddress;
    }

    public string EmailAddress { get; }
}