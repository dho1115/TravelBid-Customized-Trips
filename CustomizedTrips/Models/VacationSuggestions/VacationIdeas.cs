using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomizedTrips.Models.VacationSuggestions
{
    public class VacationIdeas
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public countrycategory Country { get; set; }
        public string Description { get; set; }
    }
}
