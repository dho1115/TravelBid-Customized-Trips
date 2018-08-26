using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomizedTrips.Models.TravelAgents
{
    public class AgentLoggedIn
    {
        [Key]
        public int id { get; set; }
        public DateTime? DateLogged { get; set; }
        public string LoggedInName { get; set; }
        public int? LoggedInPhone { get; set; }
        public string LoggedInEmail { get; set; }
    }
}
