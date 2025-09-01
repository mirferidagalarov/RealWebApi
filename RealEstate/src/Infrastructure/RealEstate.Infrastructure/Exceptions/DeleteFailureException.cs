using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Infrastructure.Exceptions
{
    public class DeleteFailureException : ApiException
    {
        public DeleteFailureException(string typeName, object key, string message) :
            base($"Deletion of entity \"{typeName}\"{key}){message}") { }

    }
}
