using System;
using System.Collections.Generic;

namespace TaxOfficeWebApp.Models
{
    public partial class Users
    {
        public Users()
        {
            Executors = new HashSet<Executors>();
        }

        public int Id { get; set; }
        public string UserLogin { get; set; }
        public byte[] UserPassword { get; set; }
        public int FkPriority { get; set; }

        public virtual Priorities FkPriorityNavigation { get; set; }
        public virtual Persons Persons { get; set; }
        public virtual ICollection<Executors> Executors { get; set; }
    }
}
