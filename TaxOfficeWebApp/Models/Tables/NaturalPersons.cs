using System;
using System.Collections.Generic;

namespace TaxOfficeWebApp
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
        public string Address { get; set; }
        public string Telephone { get; set; }

        public virtual ICollection<Persons> Persons { get; set; }
    }
}
