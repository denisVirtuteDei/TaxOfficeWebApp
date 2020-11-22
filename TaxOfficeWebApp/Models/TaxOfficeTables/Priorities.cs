using System;
using System.Collections.Generic;

namespace TaxOfficeWebApp.Models
{
    public partial class Priorities
    {
        public Priorities()
        {
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string PriorityTitle { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
