using System;
using System.Collections.Generic;

namespace TaxOfficeWebApp
{
    public partial class Priorities
    {
        public Priorities()
        {
            Persons = new HashSet<Persons>();
            Positions = new HashSet<Positions>();
        }

        public int Id { get; set; }
        public string PriorityTitle { get; set; }

        public virtual ICollection<Persons> Persons { get; set; }
        public virtual ICollection<Positions> Positions { get; set; }
    }
}
