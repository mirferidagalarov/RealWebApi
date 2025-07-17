using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.Domain.Entities;
using RealEstate.Infrastructure.Extensions;

namespace RealEstate.Persistence.Configuration
{
    internal class BlogPostCommentEntityConfiguration : IEntityTypeConfiguration<BlogPostComment>
    {
        public void Configure(EntityTypeBuilder<BlogPostComment> builder)
        {

            builder.Property(x => x.Id).HasColumnType("int");
            builder.Property(x => x.Text).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(x => x.BlogPostId).HasColumnType("int").IsRequired();
            builder.Property(x => x.ParentId).HasColumnType("int");
            builder.ConfigureAuidtable();

            builder.HasKey(x => x.Id);
            builder.ToTable("BlogPostComments");

            builder.HasOne<BlogPost>()
                   .WithMany()
                   .HasPrincipalKey(x => x.Id)
                   .HasForeignKey(x => x.BlogPostId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<BlogPostComment>()
                .WithMany()
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
