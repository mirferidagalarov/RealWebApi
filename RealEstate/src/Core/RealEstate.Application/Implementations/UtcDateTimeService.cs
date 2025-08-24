using RealEstate.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Implementations
{
    public class UtcDateTimeService : IDateTimeService
    {
        public DateTime Current => DateTime.UtcNow;
    }
}