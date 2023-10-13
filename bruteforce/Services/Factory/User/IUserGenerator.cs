using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bruteforce.Services.Factory.User
{
    public interface IUserGenerator
    {
        IEnumerable<(string userName, string password)> Generate(int count, int maxPasswordLength);
    }
}
