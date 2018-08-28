using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomizedTrips.Data;
using Microsoft.AspNetCore.Mvc;

namespace CustomizedTrips.Controllers.Traveler
{
    public class TravlerLoginPortalController : Controller
    {

        private readonly ApplicationDbContext _context;

        public TravlerLoginPortalController(ApplicationDbContext context)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PasswordVerification(string pswrd)
        {

            var PasswordCheck = _context.VacationRequest.SingleOrDefault(i => i.password == pswrd);

            if (PasswordCheck == null)
            {
                return RedirectToAction("Login", "TravlerLoginPortal");
            }

            else
            {
                return RedirectToAction("Index", "TravelerHome", new { id=PasswordCheck.id });
            }
            
        }
    }
}