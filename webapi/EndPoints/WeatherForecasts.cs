using Application.WeatherForecasts.Queries.GetWeatherForecasts;

using webapi.Infrastructure;

namespace webapi.EndPoints;

public class WeatherForecasts : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            // .RequireAuthorization()
            .MapGet(GetWeatherForecasts);
    }

    public async Task<IEnumerable<WeatherForecast>> GetWeatherForecasts(ISender sender)
    {
        return await sender.Send(new GetWeatherForecastsQuery());
    }
}