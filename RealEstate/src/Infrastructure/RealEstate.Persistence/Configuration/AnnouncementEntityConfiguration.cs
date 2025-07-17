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
    internal class AnnouncementEntityConfiguration : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            builder.Property(x => x.Id).HasColumnType("int");
            builder.Property(x => x.Title).HasColumnType("nvarchar").HasMaxLength(250).IsRequired();
            builder.Property(x => x.Description).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(x => x.Address).HasColumnType("nvarchar").HasMaxLength(1000).IsRequired();
            builder.Property(x => x.FromAgent).HasColumnType("bit").IsRequired();
            builder.Property(x => x.Type).HasColumnType("int").IsRequired();
            builder.Property(x => x.Email).HasColumnType("varchar").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Phone).HasColumnType("varchar").HasMaxLength(20).IsRequired();
            builder.Property(x => x.Price).HasColumnType("decimal").HasPrecision(18, 2).IsRequired();
            builder.Property(x => x.PriceUnit).HasColumnType("int").IsRequired();
            builder.Property(x => x.CityId).HasColumnType("int").IsRequired();
            builder.Property(x => x.CategoryId).HasColumnType("int").IsRequired();



            builder.ConfigureAuidtable();

            builder.HasKey(x => x.Id);
            builder.ToTable("Announcements");


            builder.HasOne<City>()
                .WithMany()
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.CityId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<Category>()
                .WithMany()
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
