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
    public class TravelAgentCRUDController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TravelAgentCRUDController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TravelAgentCRUD
        public async Task<IActionResult> Index()
        {
            return View(await _context.TravelAgentInfo.ToListAsync());
        }

        // GET: TravelAgentCRUD/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelAgentInfo2 = await _context.TravelAgentInfo
                .SingleOrDefaultAsync(m => m.id == id);
            if (travelAgentInfo2 == null)
            {
                return NotFound();
            }

            return View(travelAgentInfo2);
        }

        // GET: TravelAgentCRUD/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TravelAgentCRUD/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,FirstName,LastName,FavoriteDestinations,YearsExperience,phoneNumber,email,Password")] TravelAgentInfo2 travelAgentInfo2)
        {
            if (ModelState.IsValid)
            {
                _context.Add(travelAgentInfo2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(travelAgentInfo2);
        }

        // GET: TravelAgentCRUD/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelAgentInfo2 = await _context.TravelAgentInfo.SingleOrDefaultAsync(m => m.id == id);
            if (travelAgentInfo2 == null)
            {
                return NotFound();
            }
            return View(travelAgentInfo2);
        }

        // POST: TravelAgentCRUD/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,FirstName,LastName,FavoriteDestinations,YearsExperience,phoneNumber,email,Password")] TravelAgentInfo2 travelAgentInfo2)
        {
            if (id != travelAgentInfo2.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(travelAgentInfo2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TravelAgentInfo2Exists(travelAgentInfo2.id))
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
            return View(travelAgentInfo2);
        }

        // GET: TravelAgentCRUD/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelAgentInfo2 = await _context.TravelAgentInfo
                .SingleOrDefaultAsync(m => m.id == id);
            if (travelAgentInfo2 == null)
            {
                return NotFound();
            }

            return View(travelAgentInfo2);
        }

        // POST: TravelAgentCRUD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var travelAgentInfo2 = await _context.TravelAgentInfo.SingleOrDefaultAsync(m => m.id == id);
            _context.TravelAgentInfo.Remove(travelAgentInfo2);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TravelAgentInfo2Exists(int id)
        {
            return _context.TravelAgentInfo.Any(e => e.id == id);
        }
    }
}
