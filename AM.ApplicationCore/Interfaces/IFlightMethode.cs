﻿using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IFlightMethode
    {
        public IEnumerable<DateTime> GetFlightDates(string destination);

        public List<Flight> GetFlights(string filterType, string filterValue);
    }
}
