using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CustomizedTrips.Models;
using CustomizedTrips.Models.Traveler;
using CustomizedTrips.Models.TravelAgents;
using CustomizedTrips.Models.VacationSuggestions;

namespace CustomizedTrips.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<countrycategory>().HasKey(x => x.country);
        }

        public DbSet<CustomizedTrips.Models.Traveler.VacationRequest> VacationRequest { get; set; }

        public DbSet<CustomizedTrips.Models.TravelAgents.TravelAgentInfo2> TravelAgentInfo { get; set; }

        public DbSet<CustomizedTrips.Models.VacationSuggestions.VacationIdeas> VacationIdeas { get; set; }

        public DbSet<CustomizedTrips.Models.TravelAgents.Bid> Bid { get; set; }

        public DbSet<CustomizedTrips.Models.TravelAgents.BidII> BidII { get; set; }

        public DbSet<CustomizedTrips.Models.TravelAgents.AgentLoggedIn> AgentLoggedIn { get; set; }
    }
}
