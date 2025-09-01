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
    internal class AppUserTokenEntityConfiguration : IEntityTypeConfiguration<AppUserToken>
    {
        public void Configure(EntityTypeBuilder<AppUserToken> builder)
        {
            builder.Property(x => x.UserId).HasColumnOrder("int");
            builder.Property(x => x.LoginProvider).HasMaxLength(450).HasColumnOrder("nvarchar");
            builder.Property(x => x.Name).HasMaxLength(450).HasColumnOrder("nvarchar");
            builder.Property(x => x.Value).HasMaxLength(500).HasColumnOrder("nvarchar");
            builder.Property(x => x.Type).IsRequired().HasColumnOrder("tinyinit");
            builder.Property(x => x.ExpirationTime).HasColumnOrder("datetime");


            builder.HasKey(x => new { x.LoginProvider, x.UserId, x.Type, x.Value });
            builder.ToTable("UserTokens", "Membership");

            builder.HasOne<AppUser>()
             .WithMany()
             .HasPrincipalKey(x => x.Id)
             .HasForeignKey(x => x.UserId)
             .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
