using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomizedTrips.Models.TravelAgents
{
    public class Bid
    {
        [Key]
        public int id { get; set; }
        public DateTime? DateEntered { get; set; }
        public TravelAgentInfo agent { get; set; }
        public double BidAmount { get; set; }
        public string comments { get; set; }
    }
}
