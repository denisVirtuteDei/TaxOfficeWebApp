using System;
using System.Collections.Generic;

namespace TaxOfficeWebApp.Models
{
    public partial class NaturalPersons
    {
        public NaturalPersons()
        {
            Persons = new HashSet<Persons>();
        }

        public string Unp { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public string PassportCode { get; set; }
        public string PersonalNumber { get; set; }
        public string PersonalAddress { get; set; }
        public string Telephone { get; set; }

        public virtual ICollection<Persons> Persons { get; set; }
    }
}
