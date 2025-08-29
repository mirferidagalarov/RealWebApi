using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Domain.Configurations
{
    public class CryptoServiceOptions
    {
        public string Key { get; set; }
        public string Salt { get; set; }
        public RSA Rsa { get; set; }
    }
}
