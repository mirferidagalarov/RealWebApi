using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.Domain.Entities;
using RealEstate.Infrastructure.Extensions;

namespace RealEstate.Persistence.Configuration
{
    internal class ContactPostEntityConfiguration : IEntityTypeConfiguration<ContactPost>
    {
        public void Configure(EntityTypeBuilder<ContactPost> builder)
        {
            builder.Property(x=>x.Id).HasColumnType("int");
            builder.Property(x => x.Fullname).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Email).HasColumnType("varchar").HasMaxLength(70).IsRequired();
            builder.Property(x => x.Message).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(x => x.Answer).HasColumnType("nvarchar(max)");
            builder.Property(x => x.AnsweredAt).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.AnsweredBy).HasColumnType("int");
            builder.ConfigureAuidtable();


            builder.HasKey(x => x.Id);
            builder.ToTable("ContactPosts");
        }
    }
}
