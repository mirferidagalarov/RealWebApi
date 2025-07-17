using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.Domain.Entities;
using RealEstate.Infrastructure.Extensions;

namespace RealEstate.Persistence.Configuration
{
    internal class AgentEntityConfiguration : IEntityTypeConfiguration<Agent>
    {
        public void Configure(EntityTypeBuilder<Agent> builder)
        {
            builder.Property(x => x.Id).HasColumnType("int");
            builder.Property(x => x.Name).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Surname).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Email).HasColumnType("varchar").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Phone).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            builder.Property(x => x.ImagePath).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Rate).HasColumnType("decimal").HasPrecision(3,2).IsRequired();
            builder.ConfigureAuidtable();

            builder.HasKey(x => x.Id);
            builder.ToTable("Agents");
        }
    }
}
