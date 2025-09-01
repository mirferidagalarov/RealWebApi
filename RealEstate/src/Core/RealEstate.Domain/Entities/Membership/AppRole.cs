using Microsoft.AspNetCore.Identity;

namespace RealEstate.Domain.Entities.Membership
{
    public class AppRole:IdentityRole<int>
    {
        public byte Rank {  get; set; } 
    }
}
