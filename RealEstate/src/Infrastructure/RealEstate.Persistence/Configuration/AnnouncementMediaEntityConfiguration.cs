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
    internal class AnnouncementMediaEntityConfiguration : IEntityTypeConfiguration<AnnouncementMedia>
    {
        public void Configure(EntityTypeBuilder<AnnouncementMedia> builder)
        {
            builder.Property(x => x.Id).HasColumnType("int").UseIdentityColumn(1, 1);
            builder.Property(x => x.AnnouncementId).HasColumnType("int").IsRequired();
            builder.Property(x => x.Type).HasColumnType("int").IsRequired();
            builder.Property(x => x.Path).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(x => x.IsMain).HasColumnType("bit").IsRequired();


            builder.ConfigureAuidtable();

            builder.HasKey(x => x.Id);
            builder.ToTable("AnnouncementMedias");


            builder.HasOne<Announcement>()
                .WithMany()
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.AnnouncementId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
