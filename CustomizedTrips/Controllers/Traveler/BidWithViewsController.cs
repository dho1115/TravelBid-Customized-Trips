using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CustomizedTrips.Data;
using CustomizedTrips.Models.TravelAgents;

namespace CustomizedTrips.Controllers.Traveler
{
    public class BidWithViewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BidWithViewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        TravelAgentInfo agent1 = new TravelAgentInfo()
        {
            FirstName = "Jay",
            LastName = "Smithe",
            email = "FarAwayJay@email.com",
            YearsExperience = 7.ToString(),
            FavoriteDestinations = "Colorado, Seattle, Amsterdam"
        };

        TravelAgentInfo agent2 = new TravelAgentInfo()
        {
            FirstName = "Marc",
            LastName = "Jones",
            email = "MJTravelAgency@email.com",
            YearsExperience = 5.ToString(),
            FavoriteDestinations = "New York, Seattle, Norway"
        };

        TravelAgentInfo agent3 = new TravelAgentInfo()
        {
            FirstName = "Charlie",
            LastName = "Rogers",
            email = "CharlieRogersTravel@email.com",
            YearsExperience = 15.ToString(),
            FavoriteDestinations = "Italy,Japan,Texas"
        };
        
        // GET: BidWithViews      
        public async Task<IActionResult> Index()
        {
            var addAgent1 = _context.TravelAgentInfo.Add(agent1);
            var addAgent2 = _context.TravelAgentInfo.Add(agent2);
            var addAgent3 = _context.TravelAgentInfo.Add(agent3);

            Bid bid1 = new Bid()
            {
                DateEntered = DateTime.Now,
                agent = agent1,
                BidAmount = 700,
                comments = "Hello... I saw your post and I am willing to negotiate and adjust to your price."
            };

            Bid bid2 = new Bid()
            {
                DateEntered = DateTime.Now,
                agent = agent2,
                BidAmount = 1500,
                comments = "Would love to help you plan your trip"
            };

            Bid bid3 = new Bid()
            {
                DateEntered = DateTime.Now,
                agent = agent3,
                BidAmount = 900,
                comments = "Hello... my name is " + agent3.FirstName + " and I would love to help you plan your trip. My bid is negotiable... to a point."
            };

            _context.Bid.Add(bid1);
            _context.Bid.Add(bid2);
            _context.Bid.Add(bid3);

            //_context.SaveChanges();

            return View(await _context.Bid.Include(i => i.agent).ToListAsync());
        }

        // GET: BidWithViews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bid = await _context.Bid.Include(i => i.agent)
                .SingleOrDefaultAsync(m => m.id == id);
            if (bid == null)
            {
                return NotFound();
            }

            return View(bid);
        }

        // GET: BidWithViews/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BidWithViews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,DateEntered,BidAmount,comments")] Bid bid)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bid);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bid);
        }

        // GET: BidWithViews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bid = await _context.Bid.SingleOrDefaultAsync(m => m.id == id);
            if (bid == null)
            {
                return NotFound();
            }
            return View(bid);
        }

        // POST: BidWithViews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,DateEntered,BidAmount,comments")] Bid bid)
        {
            if (id != bid.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bid);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BidExists(bid.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bid);
        }

        // GET: BidWithViews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bid = await _context.Bid
                .SingleOrDefaultAsync(m => m.id == id);
            if (bid == null)
            {
                return NotFound();
            }

            return View(bid);
        }

        // POST: BidWithViews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bid = await _context.Bid.SingleOrDefaultAsync(m => m.id == id);
            _context.Bid.Remove(bid);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BidExists(int id)
        {
            return _context.Bid.Any(e => e.id == id);
        }
    }
}
