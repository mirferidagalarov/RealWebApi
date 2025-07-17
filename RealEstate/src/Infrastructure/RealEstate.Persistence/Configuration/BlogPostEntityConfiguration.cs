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
    internal class BlogPostEntityConfiguration : IEntityTypeConfiguration<BlogPost>
    {
        public void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            builder.Property(x => x.Id).HasColumnType("int");
            builder.Property(x => x.Title).HasColumnType("nvarchar").HasMaxLength(500).IsRequired();
            builder.Property(x => x.Slug).HasColumnType("varchar").HasMaxLength(500).IsRequired();
            builder.Property(x => x.ImagePath).HasColumnType("varchar").HasMaxLength(500).IsRequired();
            builder.Property(x => x.Body).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(x => x.PublishedAt).HasColumnType("datetime");
            builder.Property(x => x.PublishedBy).HasColumnType("int"); 


            builder.ConfigureAuidtable();
            builder.HasKey(x => x.Id);
            builder.ToTable("BlogPosts");
        }
    }
}
