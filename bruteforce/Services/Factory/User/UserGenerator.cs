using Bruteforce.Services.Factory.Password;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bruteforce.Services.Factory.User
{
    public class UserGenerator : IUserGenerator
    {
        private readonly List<IPasswordGenerator> _passwordGenerators;

        private int _userCount;

        public UserGenerator(IEnumerable<IPasswordGenerator> passwordGenerators)
        {
            _passwordGenerators = passwordGenerators.ToList();
        }

        public IEnumerable<(string userName, string password)> Generate(int count, int maxPasswordLength)
        {
            for (int i = 0; i < count; i++)
            {
                yield return ($"user{i}", GetRandomPasswordGenerator().Generate(GetRandomPasswordLength(maxPasswordLength)));
            }
        }

        private IPasswordGenerator GetRandomPasswordGenerator()
        {
            return _passwordGenerators[new Random().Next(_passwordGenerators.Count)];
        }

        private static int GetRandomPasswordLength(int maxPasswordLength)
        {
            return new Random().Next(
                maxPasswordLength / 2 == 0 ? maxPasswordLength / 2 + 1 : maxPasswordLength / 2,
                maxPasswordLength + 1);
        }
    }
}
