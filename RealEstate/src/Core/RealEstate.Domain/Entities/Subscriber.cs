using RealEstate.Domain.Commons;

namespace RealEstate.Domain.Entities
{
    public class Subscriber
    {
        public string Email { get; set; }
        public DateTime CreateAt { get; set; }
        public bool Approved { get; set; }
        public DateTime ApprovedAt { get; set; }
    }
}
