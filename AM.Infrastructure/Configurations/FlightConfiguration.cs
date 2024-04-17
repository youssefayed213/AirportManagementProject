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
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {

            // Configure many-to-many relationship with Passenger
          /*  builder
               .HasMany(f => f.Passenengers)
               .WithMany(p => p.Flights)
               .UsingEntity(t => t.ToTable("Reservations")); */

            // Configure one-to-many relationship with Plane
            builder
                .HasOne(f => f.Plane)
                .WithMany(p => p.Flights).HasForeignKey(f => f.PlaneFK).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
