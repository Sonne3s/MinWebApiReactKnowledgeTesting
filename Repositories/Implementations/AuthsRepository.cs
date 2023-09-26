using Repositories.Interfaces;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementations
{
    public class AuthsRepository : IAuthsRepository
    {
        public Guid GetUserId(string login, string password)
        {
            using (var db = new Context()) { return db.Auths.SingleOrDefault(a => a.Login == login && a.Password == password).UserId; }
        }

        public async Task<Auth?> CreateAsync(string login, string password, User user)
        {
            using (var db = new Context())
            {
                try
                {
                    var auth = new Auth
                    {
                        Login = login,
                        Password = password,
                        UserId = user.Id
                    };

                    await db.Auths.AddAsync(auth);

                    return await db.SaveChangesAsync() >= 1 ? auth : null;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}
