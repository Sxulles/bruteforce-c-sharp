using Bruteforce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bruteforce.Services.Repositories
{
    public interface IUserRepository
    {
        void Add(string userName, string password);
        void Update(int id, string userName, string password);
        void Delete(int id);
        void DeleteAll();

        User Get(int id);
        IEnumerable<User> GetAll();
    }
}
