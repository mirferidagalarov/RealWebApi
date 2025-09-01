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
    public class AppRoleEntityConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            var x = new AppRole();
            builder.Property(m => m.Id).HasColumnType("int");
            builder.Property(m => m.Name).HasMaxLength(256).IsRequired().HasColumnType("varchar");
            builder.Property(m => m.NormalizedName).HasMaxLength(256).IsRequired().HasColumnType("varchar");
            builder.Property(m => m.ConcurrencyStamp).HasMaxLength(256).IsRequired().HasColumnType("varchar");
            builder.Property(m => m.Rank).IsRequired().HasColumnType("tinyint");
            builder.HasKey(m => m.Id);
            builder.ToTable("Roles", "Membership");
        }
    }
}
