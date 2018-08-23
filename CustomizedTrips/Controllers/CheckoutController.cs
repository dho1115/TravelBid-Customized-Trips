using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Braintree;
using Microsoft.AspNetCore.Identity;
using CustomizedTrips.Models;
using CustomizedTrips.Services;
using CustomizedTrips.Data;

namespace CustomizedTrips.Controllers
{  
    public class CheckoutController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext _context;
        private IEmailSender _emailSender;

        private IBraintreeGateway _braintreeGateway;
        //private Client _client;

        public CheckoutController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IEmailSender emailSender, IBraintreeGateway braintreeGateway /*Client client*/)
        {
            _userManager = userManager;
            _context = context;
            _emailSender = emailSender;
            _braintreeGateway = braintreeGateway;
            //_client = client;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}