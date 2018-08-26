using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CustomizedTrips.Models.TravelAgents;
using CustomizedTrips.Models.Traveler;
using CustomizedTrips.Data;
using Microsoft.EntityFrameworkCore;

namespace CustomizedTrips.Controllers.Traveler
{
    public class BidWithEmptyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BidWithEmptyController(ApplicationDbContext context)
        {
            _context = context;
        } 

        public IActionResult Index()
        {           
            return View(_context.Bid.Include(i => i.agent).ToListAsync());
        } 

        public IActionResult DeleteAllData()
        {
            _context.TravelAgentInfo.Where(i => i.id > 6).ToList().ForEach(i => _context.TravelAgentInfo.Remove(i));

            _context.SaveChanges();

            return View();
        }
    }
}