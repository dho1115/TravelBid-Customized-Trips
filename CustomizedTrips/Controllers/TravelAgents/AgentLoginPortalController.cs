using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomizedTrips.Data;
using CustomizedTrips.Models.TravelAgents;
using Microsoft.AspNetCore.Mvc;

namespace CustomizedTrips.Controllers.TravelAgents
{
    public class AgentLoginPortalController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AgentLoginPortalController(ApplicationDbContext context)
        {
            _context = context;
        } 

        public IActionResult Index()
        {
            return View();
        } 

        public IActionResult Login()
        {
            return View();
        } 

        //NOTE: After the Login, the AgentHomePage will read the Password to determine if it is correct. IF it is, it will direct the agent to his/her home page.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AgentHomePage(string pswrd)
        {          
            var PasswordCheck = _context.TravelAgentInfo.SingleOrDefault(i => i.Password == pswrd);

            if(PasswordCheck == null)
            {
                return RedirectToAction("Login", "AgentLoginPortal");
            }

            else
            {
                AgentLoggedIn AddAgent = new AgentLoggedIn()
                {
                    DateLogged = DateTime.Now,
                    LoggedInName = PasswordCheck.FirstName,
                    LoggedInEmail = PasswordCheck.email,
                    LoggedInPhone = (int)PasswordCheck.phoneNumber
                };

                _context.AgentLoggedIn.Add(AddAgent);
                _context.SaveChanges();

                return View(PasswordCheck);
            }
            
        }
    }
}