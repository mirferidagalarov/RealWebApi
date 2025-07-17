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
    internal class AnnouncementSpecificationValueEntityConfiguration : IEntityTypeConfiguration<AnnouncementSpecificationValue>
    {
        public void Configure(EntityTypeBuilder<AnnouncementSpecificationValue> builder)
        {
            builder.Property(x => x.SpecificationId).HasColumnType("int");
            builder.Property(x => x.AnnouncementId).HasColumnType("int");
            builder.Property(x => x.Value).HasColumnType("nvarchar").HasMaxLength(200).IsRequired();

            builder.ConfigureAuidtable();

            builder.HasKey(x => new { x.AnnouncementId, x.SpecificationId });
            builder.ToTable("AnnouncementSpecificationValues");


            builder.HasOne<Announcement>()
               .WithMany()
               .HasPrincipalKey(x => x.Id)
               .HasForeignKey(x => x.AnnouncementId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<AnnouncementSpecification>()
               .WithMany()
               .HasPrincipalKey(x => x.Id)
               .HasForeignKey(x => x.SpecificationId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
