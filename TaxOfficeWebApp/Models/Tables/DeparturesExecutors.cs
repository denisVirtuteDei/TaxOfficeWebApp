using System;
using System.Collections.Generic;

namespace TaxOfficeWebApp
{
    public partial class DeparturesExecutors
    {
        public int Id { get; set; }
        public int FkExecutor { get; set; }
        public int FkDeparture { get; set; }

        public virtual Departures FkDepartureNavigation { get; set; }
        public virtual Executors FkExecutorNavigation { get; set; }
    }
}
