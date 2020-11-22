using System;
using System.Collections.Generic;

namespace TaxOfficeWebApp.Models
{
    public partial class Departures
    {
        public Departures()
        {
            DeparturesExecutors = new HashSet<DeparturesExecutors>();
            ToVisit = new HashSet<ToVisit>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string DepartureAddress { get; set; }
        public DateTime DepartureDate { get; set; }

        public virtual ICollection<DeparturesExecutors> DeparturesExecutors { get; set; }
        public virtual ICollection<ToVisit> ToVisit { get; set; }
    }
}
