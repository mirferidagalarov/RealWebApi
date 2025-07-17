using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.Domain.Entities;
using RealEstate.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Persistence.Configuration
{
    internal class AnnouncementSpecificationEntityConfiguration : IEntityTypeConfiguration<AnnouncementSpecification>
    {
        public void Configure(EntityTypeBuilder<AnnouncementSpecification> builder)
        {
            builder.Property(x => x.Id).HasColumnType("int").UseIdentityColumn(1, 1);
            builder.Property(x => x.Name).HasColumnType("nvarchar").HasMaxLength(100).IsRequired(); 
            builder.Property(x => x.IsActive).HasColumnType("bit").IsRequired();
            builder.ConfigureAuidtable();

            builder.HasKey(x => x.Id);
            builder.ToTable("AnnouncementSpecifications");
        }
    }
}
