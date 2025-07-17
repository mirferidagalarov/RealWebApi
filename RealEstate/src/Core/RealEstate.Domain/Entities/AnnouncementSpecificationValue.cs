using RealEstate.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Domain.Entities
{
    public class AnnouncementSpecificationValue:AuditableEntity
    {
        public int SpecificationId { get; set; }
        public int AnnouncementId { get; set; }
        public string Value {  get; set; }  
    }
}
