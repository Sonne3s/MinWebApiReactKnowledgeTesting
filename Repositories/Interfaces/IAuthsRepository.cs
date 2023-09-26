using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IAuthsRepository
    {
        Guid GetUserId(string login, string password);

        Task<Auth?> CreateAsync(string login, string password, User user);
    }
}
