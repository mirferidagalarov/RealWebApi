using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Infrastructure.Exceptions
{
    public class BadRequestException : ApiException
    {
        public BadRequestException(string message) : base(message) { }
        public BadRequestException(string message, Exception innerException) : base(message, innerException) { }
        public BadRequestException(string message, IDictionary<string, IEnumerable<string>> errors) : base(message)
        {
            this.Errors = errors;
        }
        public IDictionary<string, IEnumerable<string>> Errors { get; }

    }
}
