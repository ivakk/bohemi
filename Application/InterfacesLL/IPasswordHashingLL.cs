using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesLL
{
    public interface IPasswordHashingLL
    {
        public string PassSalt(int length);
        public string PassHash(string password, string salt);
    }
}
