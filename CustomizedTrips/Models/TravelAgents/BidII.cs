using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomizedTrips.Models.TravelAgents
{
    public class BidII
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string AgentName { get; set; }
        public string email { get; set; }
        public double phone { get; set; }
        public double bid { get; set; }
        public string comments { get; set; }
    }
}
