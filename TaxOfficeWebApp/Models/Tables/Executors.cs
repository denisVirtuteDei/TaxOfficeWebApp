using System;
using System.Collections.Generic;

namespace TaxOfficeWebApp
{
    public partial class Executors
    {
        public Executors()
        {
            DeparturesExecutors = new HashSet<DeparturesExecutors>();
            Registrations = new HashSet<Registrations>();
        }

        public int Id { get; set; }
        public int FkEmployee { get; set; }
        public int? FkPosition { get; set; }
        public DateTime StartWorkDate { get; set; }
        public DateTime? LastWorkDate { get; set; }

        public virtual Employees FkEmployeeNavigation { get; set; }
        public virtual Positions FkPositionNavigation { get; set; }
        public virtual ICollection<DeparturesExecutors> DeparturesExecutors { get; set; }
        public virtual ICollection<Registrations> Registrations { get; set; }
    }
}
