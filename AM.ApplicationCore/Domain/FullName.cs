using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class FullName
    {
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Le prénom doit avoir entre 3 et 25 caractères.")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool CheckProfile(string nom, string prenom)
        {
            return LastName.Equals(nom) && FirstName.Equals(prenom);
        }


    }
}
