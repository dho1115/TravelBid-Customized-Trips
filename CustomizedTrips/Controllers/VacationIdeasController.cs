using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CustomizedTrips.Data;
using CustomizedTrips.Models.VacationSuggestions;

namespace CustomizedTrips.Controllers
{
    public class VacationIdeasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VacationIdeasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VacationIdeas
        public async Task<IActionResult> Index()
        {
            return View(await _context.VacationIdeas.ToListAsync());
        }

        // GET: VacationIdeas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacationIdeas = await _context.VacationIdeas
                .SingleOrDefaultAsync(m => m.ID == id);
            if (vacationIdeas == null)
            {
                return NotFound();
            }

            return View(vacationIdeas);
        }

        // GET: VacationIdeas/Create
        public IActionResult Create() //This initial Create sends us to the FORM in the view.
        {
            return View();
        }

        // POST: VacationIdeas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        //This SECOND Create takes the information from the FORM and adds it to the database using the _context.Add and _context.SaveChanges.

        public async Task<IActionResult> Create([Bind("ID,Name,ImagePath,Description")] VacationIdeas vacationIdeas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vacationIdeas); //THIS is where the vacation ideas are added.
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vacationIdeas);
        }

        // GET: VacationIdeas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacationIdeas = await _context.VacationIdeas.SingleOrDefaultAsync(m => m.ID == id);
            if (vacationIdeas == null)
            {
                return NotFound();
            }
            return View(vacationIdeas);
        }

        // POST: VacationIdeas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,ImagePath,Description")] VacationIdeas vacationIdeas)
        {
            if (id != vacationIdeas.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacationIdeas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacationIdeasExists(vacationIdeas.ID))
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
            return View(vacationIdeas);
        }

        // GET: VacationIdeas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacationIdeas = await _context.VacationIdeas
                .SingleOrDefaultAsync(m => m.ID == id);
            if (vacationIdeas == null)
            {
                return NotFound();
            }

            return View(vacationIdeas);
        }

        // POST: VacationIdeas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vacationIdeas = await _context.VacationIdeas.SingleOrDefaultAsync(m => m.ID == id);
            _context.VacationIdeas.Remove(vacationIdeas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VacationIdeasExists(int id)
        {
            return _context.VacationIdeas.Any(e => e.ID == id);
        }
    }
}
