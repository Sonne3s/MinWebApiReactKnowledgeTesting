using AdminAPI.Interfaces;
using AdminAPI.Models;
using Repositories.Interfaces;

namespace AdminAPI.Implementations
{
    public class Authorization : IAuthorization
    {
        private readonly IAuthsRepository _authsRepository;
        private readonly IUsersRepository _usersRepository;

        public Authorization(IAuthsRepository authsRepository, IUsersRepository usersRepository)
        {
            _authsRepository = authsRepository;
            _usersRepository = usersRepository;
        }

        public async Task<string?> Registration(UserRegistration userData)
        {
            try
            {
                var (login, password, firstName, lastName, middleName) = userData;
                if ((login ?? firstName) != null)
                {
                    return (await _authsRepository.CreateAsync(login, password, await _usersRepository.CreateAsync(login, firstName, middleName, lastName))).Login;
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<string?> Authentication(UserAuth auth)
        {
            try
            {
                return _authsRepository.СheckEquivalence(auth.Login, auth.Password) ? auth.Login : null;
            }
            catch
            {
                return null;
            }
        }
    }
}
