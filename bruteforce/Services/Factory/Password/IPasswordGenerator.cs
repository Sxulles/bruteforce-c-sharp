using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bruteforce.Services.Factory.Password
{
    public interface IPasswordGenerator
    {
        string Generate(int length);
    }
}
