using AdminAPI.Models;

namespace AdminAPI.Interfaces
{
    public interface IAuthorization
    {
        Task<string?> Registration(UserRegistration userData);

        Task<string?> Authentication(UserAuth auth);
    }
}
