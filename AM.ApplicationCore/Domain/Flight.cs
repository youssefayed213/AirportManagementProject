using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public int FlightId { get; set; }

        public string Destination { get; set; }

        public string Departure { get; set; }

        public DateTime FlightDate { get; set; }

        public DateTime EffectiveArrival { get; set; }

        public int EstimatedDuration { get; set; }

        public string AirlineLogo { get; set; }

        //[ForeignKey("Plane")] 
        public int PlaneFK { get; set; } // This property is the foreign key corresponding to the Plane entity

        public virtual Plane Plane { get; set; }

        //public ICollection<Passenger> Passenengers { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

        public override string ToString()
        {
            return "[ Destination: "+Destination+" ,date: "+FlightDate+" ,durée: "+EstimatedDuration+"]";
        }
    }
}
