using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class AuthRepository
    {
        public Auth? Get(string login, string password)
        {
            using (var db = new Context()) { return db.Auths.SingleOrDefault(a => a.Login == login && a.Password == password); }
        }
    }
}
