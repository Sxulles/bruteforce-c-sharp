using Bruteforce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bruteforce.Services.PasswordServices
{
    public class PasswordBreaker : IPasswordBreaker
    {
        private static AsciiTableRange[] _characterSets;

        public PasswordBreaker(params AsciiTableRange[] characterSets)
        {
            _characterSets = characterSets;
        }

        public IEnumerable<string> GetCombinations(int passwordLength)
        {
            List<IEnumerable<string>> combinations = new List<IEnumerable<string>>();
            for (int i = 0; i < passwordLength; i++)
            {
                combinations.Add(DecodeAsciiTables(_characterSets));
            }
            return GetAllPossibleCombos(combinations);
        }

        private static IEnumerable<string> DecodeAsciiTables(AsciiTableRange[] charRanges)
        {
            foreach (var charRange in charRanges)
            {
                for (int i = charRange.Start; i <= charRange.End; i++)
                {
                    yield return ((char)i).ToString();
                }
            }
        }

        private static IEnumerable<string> GetAllPossibleCombos(IEnumerable<IEnumerable<string>> strings)
        {
            List<string> combos = new List<string> { "" };

            foreach (var inner in strings)
            {
                List<string> newCombos = new List<string>();
                foreach (var combo in combos)
                {
                    foreach (var str in inner)
                    {
                        newCombos.Add(combo + str);
                    }
                }
                combos.AddRange(newCombos);
            }


            foreach (var combo in combos)
            {
                yield return combo;
            }
        }
    }
}
