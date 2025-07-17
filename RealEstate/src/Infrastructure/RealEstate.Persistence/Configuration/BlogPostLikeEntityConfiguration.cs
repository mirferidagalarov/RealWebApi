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
    internal class BlogPostLikeEntityConfiguration : IEntityTypeConfiguration<BlogPostLike>
    {
        public void Configure(EntityTypeBuilder<BlogPostLike> builder)
        {
            builder.Property(x => x.BlogPostId).HasColumnType("int");
            builder.ConfigureAuidtable();

            builder.HasKey(x => new { x.BlogPostId, x.CreatedBy });
            builder.ToTable("BlogPostLikes");

            builder.HasOne<BlogPost>()
                .WithMany()
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.BlogPostId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}