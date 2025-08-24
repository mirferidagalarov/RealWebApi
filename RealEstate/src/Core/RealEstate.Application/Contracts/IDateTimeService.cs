using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Contracts
{
    public interface IDateTimeService
    {
        DateTime Current {  get; }
    }
}
