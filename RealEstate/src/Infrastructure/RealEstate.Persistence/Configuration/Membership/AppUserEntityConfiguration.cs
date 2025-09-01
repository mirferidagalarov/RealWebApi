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
    internal class AppUserEntityConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.Id).HasColumnType("int");
            builder.Property(x => x.UserName).HasMaxLength(256).IsRequired().HasColumnType("varchar");
            builder.Property(x => x.NormalizedUserName).HasMaxLength(256).IsRequired().HasColumnType("varchar");
            builder.Property(x => x.Email).HasMaxLength(256).HasColumnType("varchar");
            builder.Property(x => x.NormalizedEmail).HasMaxLength(256).IsRequired().HasColumnType("varchar");
            builder.Property(x => x.EmailConfirmed).IsRequired().HasColumnType("bit");
            builder.Property(x => x.PasswordHash).HasMaxLength(400).IsRequired().HasColumnType("varchar");
            builder.Property(x => x.SecurityStamp).HasMaxLength(400).IsRequired().HasColumnType("varchar");
            builder.Property(x => x.ConcurrencyStamp).HasMaxLength(400).IsRequired().HasColumnType("varchar");
            builder.Property(x => x.PhoneNumber).HasMaxLength(40).HasColumnType("varchar");
            builder.Property(x => x.PhoneNumberConfirmed).IsRequired().HasColumnType("bit");
            builder.Property(x => x.TwoFactorEnabled).IsRequired().HasColumnType("bit");
            builder.Property(x => x.LockoutEnd).HasColumnType("datetimeoffset");
            builder.Property(x => x.LockoutEnabled).IsRequired().HasColumnType("bit");
            builder.Property(x => x.AccessFailedCount).HasColumnType("int");

            builder.HasKey(x => x.Id);
            builder.ToTable("Users", "Membership");
        }
    }
}
