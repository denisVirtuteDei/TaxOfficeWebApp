using System;
using System.Collections.Generic;

namespace TaxOfficeWebApp
{
    public partial class Employees
    {
        public Employees()
        {
            Executors = new HashSet<Executors>();
        }

        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string PersonalNumber { get; set; }

        public virtual ICollection<Executors> Executors { get; set; }
    }
}
