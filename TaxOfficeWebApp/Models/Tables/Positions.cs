using System;
using System.Collections.Generic;

namespace TaxOfficeWebApp
{
    public partial class Positions
    {
        public Positions()
        {
            Executors = new HashSet<Executors>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string FkUnitStructure { get; set; }
        public int FkPriority { get; set; }

        public virtual Priorities FkPriorityNavigation { get; set; }
        public virtual Units FkUnitStructureNavigation { get; set; }
        public virtual ICollection<Executors> Executors { get; set; }
    }
}
