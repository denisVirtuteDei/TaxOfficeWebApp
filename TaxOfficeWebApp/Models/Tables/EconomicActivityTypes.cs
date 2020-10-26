using System;
using System.Collections.Generic;

namespace TaxOfficeWebApp
{
    public partial class EconomicActivityTypes
    {
        public EconomicActivityTypes()
        {
            Registrations = new HashSet<Registrations>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int Ncea { get; set; }

        public virtual ICollection<Registrations> Registrations { get; set; }
    }
}
