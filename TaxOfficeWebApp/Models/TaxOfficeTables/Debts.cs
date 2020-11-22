using System;
using System.Collections.Generic;

namespace TaxOfficeWebApp.Models
{
    public partial class Debts
    {
        public int Id { get; set; }
        public int FkBankCheck { get; set; }
        public decimal DebtSum { get; set; }
        public DateTime? DebtPayedDate { get; set; }
        public DateTime DebtBillingDate { get; set; }
        public bool IsPayed { get; set; }

        public virtual BankChecks FkBankCheckNavigation { get; set; }
    }
}
