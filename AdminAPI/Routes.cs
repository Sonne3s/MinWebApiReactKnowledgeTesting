using AdminAPI.Interfaces;
using AdminAPI.Models;
using Microsoft.Extensions.Hosting;
using Repositories.Interfaces;
using Repositories.Models;
using System.Security.Claims;

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


            app.MapPost("/registration", async (UserRegistration userRegistration, HttpContext context) =>
            {
                (Guid Id, string Login)? user = await _authentication.Registration(userRegistration);

                if (user.HasValue && await _authentication.CreateClaims(user.Value.Id.ToString(), context))
                {                   
                    return Results.Ok();
                }
                else
                {
                    return Results.BadRequest();
                }
            }).WithName("Registration");

            app.MapPost("/authentication", async (UserAuth auth, HttpContext context) =>
            {
                (Guid Id, string Login)? user = await _authentication.Authentication(auth);

                if (user.HasValue && await _authentication.CreateClaims(user.Value.Id.ToString(), context))
                {
                    return Results.Ok();
                }
                else
                {
                    return Results.BadRequest();
                }
            }).WithName("Authentication");


            app.MapGet("/unauthentication", async (HttpContext context) =>
            {
                var result = await _authentication.Unauthentication(context);
                try
                {
                    if (await _authentication.Unauthentication(context))
                    {
                        return Results.Ok();
                    }

                    return Results.BadRequest();
                }

                catch { return Results.BadRequest(); }
            }).WithName("Unauthentication");

            app.MapGet("/get-user-data", async (HttpContext context) =>
            {
                if (context?.User?.Identity?.IsAuthenticated ?? false && context?.User?.Identity?.Name != null)
                {
                    return Results.Ok(await _authentication.GetUserData(new Guid(context?.User?.Identity?.Name)));
                }
                else
                {
                    return Results.Unauthorized();
                }
            }).WithName("GetUserData");
        }
    }
}
