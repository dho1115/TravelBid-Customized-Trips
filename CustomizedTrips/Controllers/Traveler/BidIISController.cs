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
    public class BidIISController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BidIISController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BidIIS
        public async Task<IActionResult> Index()
        {
            return View(await _context.BidII.ToListAsync());
        }

        // GET: BidIIS/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bidII = await _context.BidII
                .SingleOrDefaultAsync(m => m.id == id);
            if (bidII == null)
            {
                return NotFound();
            }

            return View(bidII);
        }

        // GET: BidIIS/Create
        public IActionResult Create() //Generates empty table for user to fill out.
        {
            BidII NewBid = new BidII()
            {
                AgentName = _context.AgentLoggedIn.LastOrDefault().LoggedInName,
                email = _context.AgentLoggedIn.LastOrDefault().LoggedInEmail,
                phone = (int)_context.AgentLoggedIn.LastOrDefault().LoggedInPhone
            }; 

            return View(NewBid);
        }

        // POST: BidIIS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598. 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,AgentName,email,phone,bid,comments")] BidII bidII)  //ADDS data from from to table.
        {
            if (ModelState.IsValid)
            {
                _context.Add(bidII);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bidII);
        }

        // GET: BidIIS/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bidII = await _context.BidII.SingleOrDefaultAsync(m => m.id == id);
            if (bidII == null)
            {
                return NotFound();
            }
            return View(bidII);
        }

        // POST: BidIIS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,AgentName,email,phone,bid,comments")] BidII bidII)
        {
            if (id != bidII.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bidII);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BidIIExists(bidII.id))
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
            return View(bidII);
        }

        // GET: BidIIS/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bidII = await _context.BidII
                .SingleOrDefaultAsync(m => m.id == id);
            if (bidII == null)
            {
                return NotFound();
            }

            //return RedirectToAction("Index", "TravelerHome");
            return View(bidII);
        }

        // POST: BidIIS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bidII = await _context.BidII.SingleOrDefaultAsync(m => m.id == id);
            _context.BidII.Remove(bidII);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
                
        private bool BidIIExists(int id)
        {
            return _context.BidII.Any(e => e.id == id);
        }
    }
}
