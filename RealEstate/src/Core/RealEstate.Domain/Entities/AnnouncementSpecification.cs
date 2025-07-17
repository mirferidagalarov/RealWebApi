using RealEstate.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Domain.Entities
{
    public class AnnouncementSpecification:BaseEntity<int>
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
