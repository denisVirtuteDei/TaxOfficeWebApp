using System;
using System.Collections.Generic;

namespace TaxOfficeWebApp.Models
{
    public partial class PayedTaxes
    {
        public int Id { get; set; }
        public int FkNcea { get; set; }
        public int FkBankCheck { get; set; }
        public decimal TaxAmount { get; set; }
        public bool IsCorrect { get; set; }

        public virtual BankChecks FkBankCheckNavigation { get; set; }
        public virtual EconomicActivityTypes FkNceaNavigation { get; set; }
    }
}
