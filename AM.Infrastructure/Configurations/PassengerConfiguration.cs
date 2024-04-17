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
    public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.OwnsOne(p => p.FullName, fullName =>
            {
                fullName.Property(fn => fn.FirstName)
                        .HasMaxLength(30)
                        .HasColumnName("PassFirstName"); // Map FirstName to PassFirstName column
                fullName.Property(fn => fn.LastName)
                .IsRequired()
                .HasColumnName("PassLastName"); // Map LastName to PassLastName column and make it required
            });
        }
    }
}
