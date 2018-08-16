using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomizedTrips.Models.Traveler
{
    public class VacationRequest
    {
        [Key]
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Destination { get; set; }
        public string DestinationDescription { get; set; }
        public double Budget { get; set; }
        public string DestinationDetails { get; set; }
        public int? PhoneNumber { get; set; }
        public string email { get; set; }
    }
}
