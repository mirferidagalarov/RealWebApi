using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Domain.Enums
{
    public enum UserTokenType : byte
    {
        None = 0,
        RefreshToken = 1,
        OtpToken = 2,
        ApiKey = 3
    }

}
