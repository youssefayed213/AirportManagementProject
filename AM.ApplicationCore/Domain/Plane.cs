using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public enum PlaneType
    {
        Airbus,
        Boeing
    }
    public class Plane
    {

        public int PlaneId { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "La capacité doit être un entier positif.")]
        public int Capacity {  get; set; }
        
        public DateTime ManufactureDate { get; set; }

        public PlaneType PlaneType { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }

        public override string ToString()
        {
            return " Capacity: "+Capacity+" ManufactureDate: "+ManufactureDate+" PlaneType: "+PlaneType;
        }
    }
}
