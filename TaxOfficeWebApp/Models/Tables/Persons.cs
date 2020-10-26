using System;
using System.Collections.Generic;

namespace TaxOfficeWebApp
{
    public partial class Persons
    {
        public Persons()
        {
            Declarations = new HashSet<Declarations>();
            Registrations = new HashSet<Registrations>();
            ToVisit = new HashSet<ToVisit>();
        }

        public int Id { get; set; }
        public int PersonType { get; set; }
        public string FkUnp { get; set; }
        public int FkPriorities { get; set; }

        public virtual Priorities FkPrioritiesNavigation { get; set; }
        public virtual NaturalPersons FkUnp1 { get; set; }
        public virtual SelfEmployed FkUnp2 { get; set; }
        public virtual Entity FkUnpNavigation { get; set; }
        public virtual ICollection<Declarations> Declarations { get; set; }
        public virtual ICollection<Registrations> Registrations { get; set; }
        public virtual ICollection<ToVisit> ToVisit { get; set; }
    }
}
