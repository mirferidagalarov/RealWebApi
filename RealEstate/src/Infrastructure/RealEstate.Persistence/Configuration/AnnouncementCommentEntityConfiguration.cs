using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Entities;
using RealEstate.Infrastructure.Extensions;

namespace RealEstate.Persistence.Configuration
{
    internal class AnnouncementCommentEntityConfiguration : IEntityTypeConfiguration<AnnouncementComment>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<AnnouncementComment> builder)
        {
            builder.Property(x => x.Id).HasColumnType("int").UseIdentityColumn(1, 1);
            builder.Property(x => x.AnnouncementId).HasColumnType("int").IsRequired();
            builder.Property(x => x.ParentId).HasColumnType("int");
            builder.Property(x => x.Text).HasColumnType("nvarchar").HasMaxLength(300).IsRequired();

            builder.ConfigureAuidtable();

            builder.HasKey(x => x.Id);
            builder.ToTable("AnnouncementComments");

            builder.HasOne<Announcement>()
               .WithMany()
               .HasPrincipalKey(x => x.Id)
               .HasForeignKey(x => x.AnnouncementId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<AnnouncementComment>()
                .WithMany()
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
