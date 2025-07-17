using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Domain.Commons
{
    public class BaseEntity<T>:AuditableEntity
        where T : unmanaged
    {
        public T Id { get; set; } 
    }
}
