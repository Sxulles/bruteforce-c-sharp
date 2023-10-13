using Bruteforce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bruteforce.Services.Factory.Password
{
    public class PasswordGenerator : IPasswordGenerator
    {
        private readonly AsciiTableRange[] _characterSets;

        public PasswordGenerator(params AsciiTableRange[] characterSets)
        {
            _characterSets = characterSets;
        }

        public string Generate(int length)
        {

            StringBuilder randomPassword = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                randomPassword.Append(GetRandomCharacter(GetRandomCharacterSet()));
            }

            return randomPassword.ToString();
        }

        private AsciiTableRange GetRandomCharacterSet()
        {
            return _characterSets[new Random().Next(_characterSets.Length)];
        }

        private static char GetRandomCharacter(AsciiTableRange characterSet)
        {
            return (char)new Random().Next(characterSet.Start, characterSet.End + 1);
        }
    }
}
