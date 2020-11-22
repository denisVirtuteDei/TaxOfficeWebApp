using System;
using System.Collections.Generic;

namespace TaxOfficeWebApp.Models
{
    public partial class Persons
    {
        public Persons()
        {
            PersonRegistrations = new HashSet<PersonRegistrations>();
            ToVisit = new HashSet<ToVisit>();
        }

        public int Id { get; set; }
        public string FkIndividualPersonUnp { get; set; }
        public string FkEntityPersonUnp { get; set; }
        public string FkSelfEmployedPersonUnp { get; set; }
        public int FkUser { get; set; }

        public virtual Entity FkEntityPersonUnpNavigation { get; set; }
        public virtual NaturalPersons FkIndividualPersonUnpNavigation { get; set; }
        public virtual SelfEmployed FkSelfEmployedPersonUnpNavigation { get; set; }
        public virtual Users FkUserNavigation { get; set; }
        public virtual ICollection<PersonRegistrations> PersonRegistrations { get; set; }
        public virtual ICollection<ToVisit> ToVisit { get; set; }
    }
}
