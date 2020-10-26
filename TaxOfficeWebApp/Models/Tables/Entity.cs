using System;
using System.Collections.Generic;

namespace TaxOfficeWebApp
{
    public partial class Entity
    {
        public Entity()
        {
            Persons = new HashSet<Persons>();
        }

        public string Unp { get; set; }
        public string ShortOrgTitle { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public string PassportNumber { get; set; }
        public string OrgAddress { get; set; }
        public string Telephone { get; set; }

        public virtual ICollection<Persons> Persons { get; set; }
    }
}
