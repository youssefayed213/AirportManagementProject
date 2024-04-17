using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class FlightMethode: IFlightMethode
    {
        public List<Flight> Flights { get; set; } = new List<Flight>();

        public IEnumerable<DateTime> GetFlightDates(string dest) {
            IEnumerable<DateTime> result = new List<DateTime>();
          /*  foreach (var flight in Flights)
            {
                if (flight.Destination == dest)
                {
                    result.Add(flight.FlightDate);
                    Console.WriteLine(flight.FlightDate);
                }
            }*/
            result = from flight in Flights
                     where flight.Destination == dest
                     select flight.FlightDate;
            return result;
        }

        public List<Flight> GetFlights(string filterType, string filterValue)
        {
            List<Flight> result = new List<Flight>();

            switch (filterType)
            {
                case "Destination":
                    {
                        foreach (var flight in Flights)
                        {
                            if (flight.Destination.Equals(filterValue))
                            {
                                result.Add(flight);
                            }
                        }
                        break;
                    }
                case "Departure":
                    {
                        foreach (var flight in Flights)
                        {
                            if (flight.Departure.Equals(filterValue))
                            { result.Add(flight); }
                        }
                        break;
                    }
                case "FlightDate":
                    {
                        foreach (var flight in Flights)
                        {
                            if (flight.FlightDate.Equals(DateTime.Parse(filterValue)))
                                result.Add(flight);
                        }
                        break;
                    }
                case "EffectiveArrival":
                    {
                        foreach (var flight in Flights)
                        {
                            if (flight.EffectiveArrival.Equals(DateTime.Parse(filterValue)))
                                result.Add(flight);
                        }
                        break;
                    }
                case "EstimatedDuration":
                    {
                        foreach (var flight in Flights)
                        {
                            if (flight.EstimatedDuration.Equals(int.Parse(filterValue)))
                                result.Add(flight);
                        }
                        break;
                    }
            }
            return result;
        }
    }
}
