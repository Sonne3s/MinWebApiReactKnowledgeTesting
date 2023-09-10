using AdminAPI.Implementations;
using AdminAPI.Interfaces;
using Repositories.Implementations;
using Repositories.Interfaces;

namespace AdminAPI
{
    public static class DependencyInjections
    {
        public static void AddScoped(IServiceCollection collection)
        {
            collection.AddScoped<IAuthorization, Authorization>();
            collection.AddScoped<IAuthsRepository, AuthsRepository>();
            collection.AddScoped<IUsersRepository, UsersRepository>();
        }
    }
}
