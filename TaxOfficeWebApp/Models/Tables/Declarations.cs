using System;
using System.Collections.Generic;

namespace TaxOfficeWebApp
{
    public partial class Declarations
    {
        public int Id { get; set; }
        public int FkPerson { get; set; }
        public string Title { get; set; }
        public int FinalAmount { get; set; }
        public bool IsCorrectSum { get; set; }
        public bool IsCorrectFormat { get; set; }
        public DateTime FillingDate { get; set; }

        public virtual Persons FkPersonNavigation { get; set; }
    }
}
