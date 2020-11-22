using System;
using System.Collections.Generic;

namespace TaxOfficeWebApp.Models
{
    public partial class Units
    {
        public Units()
        {
            Positions = new HashSet<Positions>();
        }

        public int Id { get; set; }
        public string UnitTitle { get; set; }

        public virtual ICollection<Positions> Positions { get; set; }
    }
}
