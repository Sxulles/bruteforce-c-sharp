using Bruteforce.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bruteforce.Services.Auth
{
    public class AuthenticationService : IAuthenticationService
    {
        private static IUserRepository _userRepository;
        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Authenticate(string userName, string password)
        {
            var users = _userRepository.GetAll();
            return users.Any(u => u.Username == userName && u.Password == password);
        }
    }
}
