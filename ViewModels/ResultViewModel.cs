namespace IbgeApi.ViewModels;

public class ResultViewModel<T>
{
    public string? Message { get; set; }
    public T Data { get; set; }
    public string Errors { get; set; }
}