using System;
using System.Collections.Generic;

namespace TaxOfficeWebApp.Models
{
    public partial class EconomicActivityTypes
    {
        public EconomicActivityTypes()
        {
            PayedTaxes = new HashSet<PayedTaxes>();
            PersonRegistrations = new HashSet<PersonRegistrations>();
        }

        public int Id { get; set; }
        public int Ncea { get; set; }
        public string Title { get; set; }

        public virtual ICollection<PayedTaxes> PayedTaxes { get; set; }
        public virtual ICollection<PersonRegistrations> PersonRegistrations { get; set; }
    }
}
