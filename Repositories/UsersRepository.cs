using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UsersRepository
    {
        private Context? _db;

        public User? Get(Guid id)
        {
            using (var db = new Context()) { return db.Users.FirstOrDefault(u => u.Id == id); }
        }

        //public User? Get1(Guid id) => Context.Execute(() => _db.Users.FirstOrDefault(u => u.Id == id), out _db);
    }
}
