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
    internal class BlogPostTagEntityConfiguration : IEntityTypeConfiguration<BlogPostTag>
    {
        public void Configure(EntityTypeBuilder<BlogPostTag> builder)
        {
            builder.Property(x => x.BlogPostId).HasColumnType("int");
            builder.Property(x => x.TagId).HasColumnType("int");
            builder.ConfigureAuidtable();

            builder.HasKey(x => new { x.BlogPostId, x.TagId });
            builder.ToTable("BlogPostTags");

            builder.HasOne<BlogPost>()
                .WithMany()
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.BlogPostId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<Tag>()
                .WithMany()
                 .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.TagId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
