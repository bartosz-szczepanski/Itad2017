using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Itad2017.Data;
using Itad2017.Models;
using Microsoft.AspNetCore.Authorization;

namespace Itad2017.Controllers
{
    public class WorkshopsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkshopsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Workshops
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Workshop.ToListAsync());
        }

        // GET: Workshops/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workshop = await _context.Workshop.SingleOrDefaultAsync(m => m.ID == id);
            if (workshop == null)
            {
                return NotFound();
            }

            return View(workshop);
        }

        // GET: Workshops/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Workshops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("ID,Description,Name,Start")] Workshop workshop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workshop);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(workshop);
        }

        // GET: Workshops/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workshop = await _context.Workshop.SingleOrDefaultAsync(m => m.ID == id);
            if (workshop == null)
            {
                return NotFound();
            }
            return View(workshop);
        }

        // POST: Workshops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Description,Name,Start")] Workshop workshop)
        {
            if (id != workshop.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workshop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkshopExists(workshop.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(workshop);
        }

        // GET: Workshops/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workshop = await _context.Workshop.SingleOrDefaultAsync(m => m.ID == id);
            if (workshop == null)
            {
                return NotFound();
            }

            return View(workshop);
        }

        // POST: Workshops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workshop = await _context.Workshop.SingleOrDefaultAsync(m => m.ID == id);
            _context.Workshop.Remove(workshop);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool WorkshopExists(int id)
        {
            return _context.Workshop.Any(e => e.ID == id);
        }
    }
}
