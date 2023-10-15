namespace IbgeApi.ValueObjects;

public class Email
{
    public Email(string emailAddress)
    {
        EmailAddress = emailAddress;
    }

    public string EmailAddress { get; set; }
}