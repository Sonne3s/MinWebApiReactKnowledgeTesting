using AdminAPI;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy",
        builder =>
        {
            builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                .WithOrigins("http://localhost:3000");
        });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
DependencyInjections.AddScoped(builder.Services);

//builder.Services.AddSession();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
    {
        options.Cookie.Name = "UserLoginCookie";
        options.SlidingExpiration = true;
        options.ExpireTimeSpan = new TimeSpan(1, 0, 0); // Expires in 1 hour  
        options.Events.OnRedirectToLogin = (context) =>
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return Task.CompletedTask;
        };

        options.Cookie.HttpOnly = true;
        // Only use this when the sites are on different domains  
        options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None;
    });
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();

var routes = new Routes(app);

app.UseCors("CORSPolicy");

app.Run();