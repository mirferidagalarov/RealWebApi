using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Persistence.Configuration
{
    internal class SubscriberEntityConfiguration : IEntityTypeConfiguration<Subscriber>
    {
        public void Configure(EntityTypeBuilder<Subscriber> builder)
        {
            builder.Property(x => x.Email).HasColumnType("varchar").HasMaxLength(100).IsRequired();
            builder.Property(x => x.CreateAt).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.Approved).HasColumnType("bit").IsRequired();
            builder.Property(x => x.ApprovedAt).HasColumnType("datetime");

            builder.HasKey(x => x.Email);
            builder.ToTable("Subscribers");
        }
    }
}
