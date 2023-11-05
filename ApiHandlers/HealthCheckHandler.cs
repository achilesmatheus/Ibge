namespace IbgeApi.ApiHandlers;

/// <summary>
/// 
/// </summary>
public static class HealthCheckHandler
{
    /// <summary>
    /// Retorna o status da api. 
    /// </summary>
    /// <returns></returns>
    public static IResult Get()
    {
        return Results.Ok(new
        {
            Title = "Api heath check",
            Online = true
        });
    }
}