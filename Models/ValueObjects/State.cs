namespace IbgeApi.Models.ValueObjects;

public class State
{
    public State()
    {
    }

    public State(string stateName)
    {
        StateName = stateName;
    }

    public string StateName { get; }
}