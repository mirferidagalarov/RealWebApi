using RealEstate.Domain.Commons;

namespace RealEstate.Domain.Entities
{
    public class BlogPostLike:AuditableEntity
    {
        public int BlogPostId {  get; set; }
    }
}
