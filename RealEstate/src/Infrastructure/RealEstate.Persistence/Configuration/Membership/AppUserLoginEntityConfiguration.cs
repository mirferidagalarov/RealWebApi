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
    public class AppUserLoginEntityConfiguration : IEntityTypeConfiguration<AppUserLogin>
    {
        public void Configure(EntityTypeBuilder<AppUserLogin> builder)
        {
            builder.Property(x => x.UserId).IsRequired().HasColumnType("int");
            builder.Property(x => x.LoginProvider).HasMaxLength(450).HasColumnType("nvarchar");
            builder.Property(x => x.ProviderKey).HasMaxLength(450).HasColumnType("nvarchar");
            builder.Property(x => x.ProviderDisplayName).HasColumnType("nvarchar(max)");

            builder.HasKey(x => new { x.LoginProvider, x.ProviderKey });
            builder.ToTable("UserLogins", "Membership");

            builder.HasOne<AppUser>()
                .WithMany()
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
