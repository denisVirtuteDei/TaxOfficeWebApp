using System;
using System.Collections.Generic;

namespace TaxOfficeWebApp.Models
{
    public partial class ToVisit
    {
        public int Id { get; set; }
        public int FkDeparture { get; set; }
        public int FkPerson { get; set; }

        public virtual Departures FkDepartureNavigation { get; set; }
        public virtual Persons FkPersonNavigation { get; set; }
    }
}
