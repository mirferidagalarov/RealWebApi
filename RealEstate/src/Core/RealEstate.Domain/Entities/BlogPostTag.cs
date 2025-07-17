using RealEstate.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Domain.Entities
{
    public class BlogPostTag:AuditableEntity
    {
        public int BlogPostId {  get; set; }    
        public int TagId {  get; set; } 
    }
}
