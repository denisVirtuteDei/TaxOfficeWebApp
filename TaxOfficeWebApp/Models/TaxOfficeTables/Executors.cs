using System;
using System.Collections.Generic;

namespace TaxOfficeWebApp.Models
{
    public partial class Executors
    {
        public Executors()
        {
            DeparturesExecutors = new HashSet<DeparturesExecutors>();
            PersonRegistrations = new HashSet<PersonRegistrations>();
        }

        public int Id { get; set; }
        public int FkUser { get; set; }
        public int FkEmployee { get; set; }
        public int FkPosition { get; set; }
        public DateTime StartWorkDate { get; set; }
        public DateTime LastWorkDate { get; set; }

        public virtual Employees FkEmployeeNavigation { get; set; }
        public virtual Positions FkPositionNavigation { get; set; }
        public virtual Users FkUserNavigation { get; set; }
        public virtual ICollection<DeparturesExecutors> DeparturesExecutors { get; set; }
        public virtual ICollection<PersonRegistrations> PersonRegistrations { get; set; }
    }
}
