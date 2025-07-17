using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.Infrastructure.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Infrastructure.Extensions
{
    public static partial class Extension
    {
        public static EntityTypeBuilder<T> ConfigureAuidtable<T>(this EntityTypeBuilder<T> builder)
            where T : class, IAuditableEntity
        {
            builder.Property(x => x.CreateAt).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.CreatedBy).HasColumnType("int");
            builder.Property(x => x.LastModifiedAt).HasColumnType("datetime");
            builder.Property(x => x.LastModifiedBy).HasColumnType("int");
            builder.Property(x => x.DeleteAt).HasColumnType("datetime");
            builder.Property(x => x.DeletedBy).HasColumnType("int");
            return builder;
        }

    }
}
