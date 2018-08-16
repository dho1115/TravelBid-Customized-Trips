using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CustomizedTrips.Data;
using CustomizedTrips.Models.TravelAgents;

namespace CustomizedTrips.Controllers.TravelAgents
{
    public class TravelAgentProfileController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TravelAgentProfileController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TravelAgentProfile
        public async Task<IActionResult> Index()
        {
            return View(await _context.TravelAgentInfo.ToListAsync());
        }

        // GET: TravelAgentProfile/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelAgentInfo = await _context.TravelAgentInfo
                .SingleOrDefaultAsync(m => m.id == id);
            if (travelAgentInfo == null)
            {
                return NotFound();
            }

            return View(travelAgentInfo);
        }

        // GET: TravelAgentProfile/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TravelAgentProfile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,FirstName,LastName,email,phoneNumber,YearsExperience,FavoriteDestinations")] TravelAgentInfo travelAgentInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(travelAgentInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(travelAgentInfo);
        }

        // GET: TravelAgentProfile/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelAgentInfo = await _context.TravelAgentInfo.SingleOrDefaultAsync(m => m.id == id);
            if (travelAgentInfo == null)
            {
                return NotFound();
            }
            return View(travelAgentInfo);
        }

        // POST: TravelAgentProfile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,FirstName,LastName,email,phoneNumber,YearsExperience,FavoriteDestinations")] TravelAgentInfo travelAgentInfo)
        {
            if (id != travelAgentInfo.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(travelAgentInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TravelAgentInfoExists(travelAgentInfo.id))
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
            return View(travelAgentInfo);
        }

        // GET: TravelAgentProfile/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelAgentInfo = await _context.TravelAgentInfo
                .SingleOrDefaultAsync(m => m.id == id);
            if (travelAgentInfo == null)
            {
                return NotFound();
            }

            return View(travelAgentInfo);
        }

        // POST: TravelAgentProfile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var travelAgentInfo = await _context.TravelAgentInfo.SingleOrDefaultAsync(m => m.id == id);
            _context.TravelAgentInfo.Remove(travelAgentInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TravelAgentInfoExists(int id)
        {
            return _context.TravelAgentInfo.Any(e => e.id == id);
        }
    }
}
