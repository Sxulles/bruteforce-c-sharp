using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bruteforce.Services.PasswordServices
{
    public interface IPasswordBreaker
    {
        IEnumerable<string> GetCombinations(int passwordLength);
    }
}
