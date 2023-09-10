using AdminAPI.Interfaces;
using AdminAPI.Models;
using Microsoft.Extensions.Hosting;
using Repositories.Interfaces;
using Repositories.Models;

namespace AdminAPI
{
    public class Routes
    {
        private readonly IAuthorization _authentication;


        public Routes(WebApplication app)
        {
            var scope = app.Services.CreateScope();
            var _authentication = scope.ServiceProvider.GetService<IAuthorization>();

            //_authentication = app.Services.GetRequiredService<IAuthorization>();

            var summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            app.MapGet("/weatherforecast", () =>
            {
                var forecast = Enumerable.Range(1, 5).Select(index =>
                    new WeatherForecast
                    (
                        DateTime.Now.AddDays(index),
                        Random.Shared.Next(-20, 55),
                        summaries[Random.Shared.Next(summaries.Length)]
                    ))
                    .ToArray();
                return forecast;
            })
            .WithName("GetWeatherForecast");

            app.MapPost("/registration", async (UserRegistration user) =>
            {
                var login = await _authentication.Registration(user);

                if (login != null)
                {
                    return Results.Ok(login);
                }
                else
                {
                    return Results.BadRequest();
                }
            }).WithName("Registration");

            app.MapPost("/authentication", async (UserAuth auth) =>
            {
                var login = await _authentication.Authentication(auth);

                if (login != null)
                {
                    return Results.Ok(login);
                }
                else
                {
                    return Results.BadRequest();
                }
            }).WithName("Authentication");
        }

            internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
        {
            public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        }
    }
}
