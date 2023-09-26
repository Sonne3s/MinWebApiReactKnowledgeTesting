using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IUsersRepository
    {
        Task<User?> CreateAsync(string login, string firstName, string middleName, string lastName);

        Task<User?> Get(Guid id);
    }
}
