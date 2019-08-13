using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public enum SigninStatus
    {
        Success = 0,
        Lockout = 1,
        RequiredVerification = 2,
        Failurer = 3,
        SecondFactor = 4,
        Reset = 5,
        Undefine = 6
    }
}
