using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementations
{
    public class UsersRepository : IUsersRepository
    {
        public async Task<User?> CreateAsync(string login, string firstName, string middleName, string lastName)
        {
            using (var db = new Context())
            {
                try
                {
                    var user = new User
                    {
                        FirstName = firstName,
                        MiddleName = middleName,
                        LastName = lastName,
                        Login = login
                    };

                    await db.Users.AddAsync(user);

                    return await db.SaveChangesAsync() >= 1 ? user : null;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public async Task<User?> Get(Guid id)
        {
            using (var db = new Context())
            {
                return await db.Users.SingleOrDefaultAsync(u => u.Id == id);
            }
        }
    }
}
