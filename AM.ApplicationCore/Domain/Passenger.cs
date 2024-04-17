using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        //public int Id { get; set; }

        [Key]
        [StringLength(7)]
        public string PassportNumber { get; set; }

        [Display(Name = "Date of Birth")]

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "L'adresse e-mail n'est pas valide.")]
        public string EmailAddress { get; set; }

        public FullName FullName { get; set; }

        [RegularExpression(@"^\d{8}$", ErrorMessage = "Le numéro de téléphone doit contenir exactement 8 chiffres.")]
        public int TelNumber { get; set; }

        //public ICollection<Flight> Flights { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

        /*public  bool CheckProfile(string nom, string prenom, string email)
        {
            return LastName.Equals(nom) && FirstName.Equals(prenom) && EmailAddress.Equals(email);
        }*/

        /* public bool CheckProfile(string nom, string prenom, string email)
         {
             if (email!=null) {
                 return LastName.Equals(nom) && FirstName.Equals(prenom) && EmailAddress.Equals(email);
             }
             else { return LastName.Equals(nom) && LastName.Equals(prenom); }
         }*/

        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger");
        }

    }
}
