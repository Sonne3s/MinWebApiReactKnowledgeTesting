using AdminAPI.Interfaces;
using AdminAPI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Repositories;
using Repositories.Interfaces;
using Repositories.Models;
using System.Security.Claims;
using System.Security.Principal;

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

        public async Task<ValueTuple<Guid, string>?> Registration(UserRegistration userData)
        {
            try
            {
                var (login, password, firstName, lastName, middleName) = userData;
                if ((login ?? firstName) != null)
                {
                    var user = await _usersRepository.CreateAsync(login, firstName, middleName, lastName);
                    _ = await _authsRepository.CreateAsync(login, password, user);

                    return (user.Id, user.Login);
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ValueTuple<Guid, string>?> Authentication(UserAuth auth)
        {
            try
            {
                var user = await _usersRepository.Get(_authsRepository.GetUserId(auth.Login, auth.Password));

                if (user == null) return null;

                return (user.Id, auth.Login);
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> Unauthentication(HttpContext context)
        {
            try
            {
                context.SignOutAsync();

                return true;
            }
            catch { return false; }
        }

        public async Task<bool> CreateClaims(string login, HttpContext context)
        {
            try
            {
                var claims = new List<Claim> { new(type: ClaimTypes.Name, login) };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal? claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                return true;
            }
            catch { return false; }
        }

        public async Task<UserMenuData> GetUserData(Guid guid)
        {
            var user = await _usersRepository.Get(guid);

            return new UserMenuData
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
            };
        }
    }
}
