using RealEstate.Infrastructure.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Domain.Commons
{
    public class AuditableEntity : IAuditableEntity
    {
  
        public DateTime CreateAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? DeleteAt { get; set; }
        public DateTime? DeletedBy { get; set; }    
    }
}
