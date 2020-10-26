using System;
using System.Collections.Generic;

namespace TaxOfficeWebApp
{
    public partial class Registrations
    {
        public int Id { get; set; }
        public int FkEmployee { get; set; }
        public int FkPerson { get; set; }
        public int FkNcea { get; set; }
        public DateTime RegDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? Bankrupt { get; set; }

        public virtual Executors FkEmployeeNavigation { get; set; }
        public virtual EconomicActivityTypes FkNceaNavigation { get; set; }
        public virtual Persons FkPersonNavigation { get; set; }
    }
}
