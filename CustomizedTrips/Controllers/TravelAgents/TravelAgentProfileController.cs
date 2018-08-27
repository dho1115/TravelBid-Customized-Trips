using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomizedTrips.Data;
using CustomizedTrips.Models.TravelAgents;
using Microsoft.AspNetCore.Mvc;

namespace CustomizedTrips.Controllers.TravelAgents
{
    public class TravelAgentProfileController : Controller
    {

        private readonly ApplicationDbContext _context;

        public TravelAgentProfileController(ApplicationDbContext context)
        {
            _context = context;
        }        

        public IActionResult Create() //Gives us the empty form to fill out.
        {
            return View();
        } 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("id,FirstName,LastName,FavoriteDestinations,YearsExperience,phoneNumber,email,Password")] TravelAgentInfo2 TravelAgentInfo2) //Adds data we entered to list.   
        {

            if(ModelState.IsValid)
            {
                _context.TravelAgentInfo.Add(TravelAgentInfo2);
                _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            } 

            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return Content("Agent ID does not exist.");
            }

            var EditAgent = _context.TravelAgentInfo.SingleOrDefault(m => m.id == id);

            if (EditAgent == null)
            {
                return NotFound();
            }

            return View(EditAgent);
        }

        public IActionResult Index()
        {
            return View(_context.TravelAgentInfo.ToList());
        }
    }
}