using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.Domain.Entities.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Persistence.Configuration.Membership
{
    internal class AppUserClaimEntityConfiguration : IEntityTypeConfiguration<AppUserClaim>
    {
        public void Configure(EntityTypeBuilder<AppUserClaim> builder)
        {
            builder.Property(x => x.Id).HasColumnType("int");
            builder.Property(x => x.UserId).IsRequired().HasColumnType("int");
            builder.Property(x => x.ClaimType).IsRequired().HasMaxLength(200).HasColumnType("varchar");
            builder.Property(x => x.ClaimValue).IsRequired().HasMaxLength(200).HasColumnType("varchar");


            builder.HasKey(x => x.Id);
            builder.ToTable("UserClaims", "Membership");

            builder.HasOne<AppUser>()
                .WithMany()
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
