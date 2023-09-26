using AdminAPI.Models;
namespace AdminAPI.Interfaces
{
    public interface IAuthorization
    {
        Task<ValueTuple<Guid, string>?> Registration(UserRegistration userData);

        Task<ValueTuple<Guid, string>?> Authentication(UserAuth auth);

        Task<bool> Unauthentication(HttpContext context);

        Task<bool> CreateClaims(string login, HttpContext context);

        Task<UserMenuData> GetUserData(Guid guid);
    }
}
