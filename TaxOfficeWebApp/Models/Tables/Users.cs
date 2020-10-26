using System;
using System.Collections.Generic;

namespace TaxOfficeWebApp
{
    public partial class Users
    {
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public int FkPriority { get; set; }

        public virtual Priorities FkPriorityNavigation { get; set; }
    }
}
