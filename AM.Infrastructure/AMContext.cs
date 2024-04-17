using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure
{
    public class AMContext: DbContext
    {
        //DbSet
        public DbSet<Flight> Flights { get; set; }

        public DbSet<Passenger> passengers { get; set; }
        
        public DbSet<Staff> staffs { get; set; }
        
        public DbSet<Traveller> travelers { get; set; }
        
        public DbSet<Plane> planes { get; set; }

        public DbSet<Ticket> tickets { get; set; }

        //Config connexxion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                        Initial Catalog=AirportManagementDB;Integrated Security=true;
                        MultipleActiveResultSets=true");
            optionsBuilder.UseLazyLoadingProxies();
                base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            modelBuilder.Entity<Plane>().HasKey(p => p.PlaneId);
            modelBuilder.Entity<Plane>().ToTable("MyPlanes");
            modelBuilder.Entity<Plane>().Property(p => p.Capacity)
                   .HasColumnName("PlaneCapacity");

            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            //Configure type détenu (owned type)

            modelBuilder.ApplyConfiguration(new PassengerConfiguration());
            // modelBuilder.Entity<Passenger>().OwnsOne(p => p.FullName);

            //Configurer l'héritage Table Per Hierarchy (TPH)
            /* modelBuilder.Entity<Passenger>().HasDiscriminator<int>("IsTraveller")
                                             .HasValue<Passenger>(0)
                                             .HasValue<Staff>(2)
                                             .HasValue<Traveller>(1); */
            //Configurer l'héritage Table Per Type (TPT)
            modelBuilder.Entity<Staff>().ToTable("Staffs");
            modelBuilder.Entity<Traveller>().ToTable("Travellers");

            //Configurer Primary Key de la porteuse de donnnées
            modelBuilder.Entity<Ticket>().HasKey(t => new { t.FlightFk, t.PassengerFk });
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
            base.ConfigureConventions(configurationBuilder);
        }
    }
}
