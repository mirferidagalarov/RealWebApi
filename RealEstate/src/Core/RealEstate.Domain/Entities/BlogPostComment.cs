using RealEstate.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Domain.Entities
{
    public class BlogPostComment:BaseEntity<int>
    {
        public int BlogPostId {  get; set; }    
        public int? ParentId { get; set; }  
        public string Text { get; set; }
    }
}
