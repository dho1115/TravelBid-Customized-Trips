using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomizedTrips.Models.TravelAgents
{
    public class TravelAgentInfo
    {
        [Key]
        public int id { get; set; }
        public string FavoriteDestinations { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int YearsExperience { get; set; }
        public string email { get; set; }
        public string Password { get; set; }
        public int phoneNumber { get; set; }
    }
}
