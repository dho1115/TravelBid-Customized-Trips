using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CustomizedTrips.Data;
using CustomizedTrips.Models.Traveler;

namespace CustomizedTrips.Controllers.Traveler
{
    public class VacationFormController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VacationFormController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VacationForm
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.VacationRequest.ToListAsync());
        }

        // GET: VacationForm/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacationRequest = await _context.VacationRequest
                .SingleOrDefaultAsync(m => m.id == id);
            if (vacationRequest == null)
            {
                return NotFound();
            }

            return View(vacationRequest);
        }

        // GET: VacationForm/Create
        public IActionResult Create()        
        {
            return View();
        }

        // POST: VacationForm/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,FirstName,LastName,password,Destination,Budget,DestinationDetails,PhoneNumber,email")] VacationRequest vacationRequest)        
        {
            if (ModelState.IsValid)
            {
                _context.Add(vacationRequest);
                await _context.SaveChangesAsync();

                return RedirectToAction("MemberThankYou", "VacationForm");
                //return RedirectToAction(nameof(Index));
            }

            return View(vacationRequest);            
        }

        // GET: VacationForm/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacationRequest = await _context.VacationRequest.SingleOrDefaultAsync(m => m.id == id);
            if (vacationRequest == null)
            {
                return NotFound();
            }
            return View(vacationRequest);
        }

        // POST: VacationForm/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,FirstName,LastName,Destination,Budget,DestinationDetails,PhoneNumber,email")] VacationRequest vacationRequest)
        {
            if (id != vacationRequest.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacationRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacationRequestExists(vacationRequest.id))
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
            return View(vacationRequest);
        }

        // GET: VacationForm/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacationRequest = await _context.VacationRequest
                .SingleOrDefaultAsync(m => m.id == id);

            if (vacationRequest == null)
            {
                return NotFound();
            }

            return View(vacationRequest);
        }

        // POST: VacationForm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vacationRequest = await _context.VacationRequest.SingleOrDefaultAsync(m => m.id == id);

            _context.VacationRequest.Remove(vacationRequest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VacationRequestExists(int id)
        {
            return _context.VacationRequest.Any(e => e.id == id);
        } 

        public IActionResult MemberCreate(int? id)
        {
            var MemberSearch = _context.VacationRequest.SingleOrDefault(i => i.id == id);

            if(MemberSearch == null)
            {
                return Content("Member not found");
            }

            return View(MemberSearch);
        } 
        
        public IActionResult MemberThankYou()
        {
            return View();
        }
       
    }
}
