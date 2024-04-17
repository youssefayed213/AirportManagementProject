using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public static class PassengerExtension
    {
        public static String UpperFullName(this Passenger passenger)
        {
            return passenger.FullName.FirstName[0].ToString().ToUpperInvariant() + passenger.FullName.FirstName.Substring(1) + " " +
                   passenger.FullName.LastName[0].ToString().ToUpperInvariant() + passenger.FullName.LastName.Substring(1);
        }
    }
}
