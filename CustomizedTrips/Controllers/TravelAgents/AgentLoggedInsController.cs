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
    public class AgentLoggedInsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AgentLoggedInsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AgentLoggedIns
        public async Task<IActionResult> Index()
        {
            return View(await _context.AgentLoggedIn.ToListAsync());
        }

        // GET: AgentLoggedIns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agentLoggedIn = await _context.AgentLoggedIn
                .SingleOrDefaultAsync(m => m.id == id);
            if (agentLoggedIn == null)
            {
                return NotFound();
            }

            return View(agentLoggedIn);
        }

        // GET: AgentLoggedIns/Create
        public IActionResult Create()
        {
            var LoggedInAgent = _context.AgentLoggedIn.LastOrDefault();
            return View(LoggedInAgent);
        }

        // POST: AgentLoggedIns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,DateLogged,LoggedInName,LoggedInPhone,LoggedInEmail")] AgentLoggedIn agentLoggedIn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agentLoggedIn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agentLoggedIn);
        }

        // GET: AgentLoggedIns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agentLoggedIn = await _context.AgentLoggedIn.SingleOrDefaultAsync(m => m.id == id);
            if (agentLoggedIn == null)
            {
                return NotFound();
            }
            return View(agentLoggedIn);
        }

        // POST: AgentLoggedIns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,DateLogged,LoggedInName,LoggedInPhone,LoggedInEmail")] AgentLoggedIn agentLoggedIn)
        {
            if (id != agentLoggedIn.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agentLoggedIn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgentLoggedInExists(agentLoggedIn.id))
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
            return View(agentLoggedIn);
        }

        // GET: AgentLoggedIns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agentLoggedIn = await _context.AgentLoggedIn
                .SingleOrDefaultAsync(m => m.id == id);
            if (agentLoggedIn == null)
            {
                return NotFound();
            }

            return View(agentLoggedIn);
        }

        // POST: AgentLoggedIns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agentLoggedIn = await _context.AgentLoggedIn.SingleOrDefaultAsync(m => m.id == id);
            _context.AgentLoggedIn.Remove(agentLoggedIn);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgentLoggedInExists(int id)
        {
            return _context.AgentLoggedIn.Any(e => e.id == id);
        }
    }
}
