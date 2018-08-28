using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomizedTrips.Data;
using Microsoft.AspNetCore.Mvc;

namespace CustomizedTrips.Controllers.Traveler
{
    public class TravelerHomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TravelerHomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string pswrd)
        {
            var PasswordVerification = _context.VacationRequest.SingleOrDefault(i => i.password == pswrd);

            if(PasswordVerification == null)
            {
                return RedirectToAction("Login", "TravlerLoginPortal");
            }

            else
            {
                return View(PasswordVerification);
            }
            
        }
    }
}