using RealEstate.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Domain.Entities
{
    public class BlogPost:BaseEntity<int>
    {
        public string Title {  get; set; }
        public string Slug {  get; set; }   
        public string ImagePath {  get; set; }
        public string Body {  get; set; }
        public DateTime? PublishedAt { get; set; }
        public int? PublishedBy {  get; set; }   
    }
}
