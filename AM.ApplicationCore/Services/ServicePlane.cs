using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServicePlane : Service<Plane>, IServicePlane
    {
        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void DeletePlanes()
        {
            Delete( p => (DateTime.Now - p.ManufactureDate ).TotalDays > 3650 );
        }

        public IEnumerable<Flight> GetFlights(int n)
        {
            return GetMany().OrderByDescending(p => p.PlaneId)
                 .Take(n)
                 .SelectMany(f => f.Flights)
                 .OrderBy(f => f.FlightDate);
                
        }

        public IEnumerable<Traveller> GetPassengers(Plane plane)
        {
            return plane.Flights.SelectMany(f => f.Tickets)
                                .Select(t => t.Passenger)
                                .OfType<Traveller>();
        }

        public bool IsAvailablePlane(int n, Flight f)
        {
            return f.Plane.Capacity >= f.Tickets.Count + n;
        }
    }
}
