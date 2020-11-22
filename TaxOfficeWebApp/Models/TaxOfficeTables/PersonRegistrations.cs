using System;
using System.Collections.Generic;

namespace TaxOfficeWebApp.Models
{
    public partial class PersonRegistrations
    {
        public PersonRegistrations()
        {
            BankChecks = new HashSet<BankChecks>();
        }

        public int Id { get; set; }
        public int FkEmployee { get; set; }
        public int FkPerson { get; set; }
        public int FkInitNcea { get; set; }
        public DateTime RegDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? Bankrupt { get; set; }

        public virtual Executors FkEmployeeNavigation { get; set; }
        public virtual EconomicActivityTypes FkInitNceaNavigation { get; set; }
        public virtual Persons FkPersonNavigation { get; set; }
        public virtual ICollection<BankChecks> BankChecks { get; set; }
    }
}
