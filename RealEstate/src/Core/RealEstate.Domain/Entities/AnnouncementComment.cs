using RealEstate.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Domain.Entities
{
    public class AnnouncementComment : BaseEntity<int>
    {
        public int AnnouncementId { get; set; }
        public int? ParentId { get; set; }
        public string Text { get; set; }
    }
}
