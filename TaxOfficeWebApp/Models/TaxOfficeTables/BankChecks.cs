using System;
using System.Collections.Generic;

namespace TaxOfficeWebApp.Models
{
    public partial class BankChecks
    {
        public BankChecks()
        {
            Debts = new HashSet<Debts>();
            PayedTaxes = new HashSet<PayedTaxes>();
        }

        public int Id { get; set; }
        public int FkRegPerson { get; set; }
        public string Title { get; set; }
        public decimal FinalSum { get; set; }
        public DateTime PayedDate { get; set; }
        public bool IsDebtRepayment { get; set; }
        public bool IsCorrect { get; set; }

        public virtual PersonRegistrations FkRegPersonNavigation { get; set; }
        public virtual ICollection<Debts> Debts { get; set; }
        public virtual ICollection<PayedTaxes> PayedTaxes { get; set; }
    }
}
