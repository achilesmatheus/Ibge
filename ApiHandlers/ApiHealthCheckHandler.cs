namespace IbgeApi.ApiHandlers;

public static class ApiHealthCheckHandler
{
    public static IResult Get()
    {
        return Results.Ok(new
        {
            Title = "Api heath check",
            Online = true
        });
    }
}