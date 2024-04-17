using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configurations
{
    public class PlaneConfiguration : IEntityTypeConfiguration<Plane>
    {
        public void Configure(EntityTypeBuilder<Plane> builder)
        {
            // Set PlaneId as the primary key
            builder.HasKey(p => p.PlaneId);

            // Set the table name to "MyPlanes"
            builder.ToTable("MyPlanes");

            // Map the Capacity property to the "PlaneCapacity" column
            builder.Property(p => p.Capacity)
                   .HasColumnName("PlaneCapacity");
        }
    }
}
