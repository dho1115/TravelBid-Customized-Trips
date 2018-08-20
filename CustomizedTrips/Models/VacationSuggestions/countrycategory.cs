using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomizedTrips.Models.VacationSuggestions
{
    public class countrycategory
    {
        public string country { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }

        public ICollection<VacationIdeas> VacationIdeasss { get; set; }
        public countrycategory()
        {
            this.VacationIdeasss = new HashSet<VacationIdeas>();
        }
    }
}
