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
    public class ParticipationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParticipationsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Participations
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Participation.ToListAsync());
        }

        // GET: Participations/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participation = await _context.Participation.SingleOrDefaultAsync(m => m.ID == id);
            if (participation == null)
            {
                return NotFound();
            }

            return View(participation);
        }

        // GET: Participations/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Participations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID")] Participation participation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(participation);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(participation);
        }

        // GET: Participations/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participation = await _context.Participation.SingleOrDefaultAsync(m => m.ID == id);
            if (participation == null)
            {
                return NotFound();
            }
            return View(participation);
        }

        // POST: Participations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("ID")] Participation participation)
        {
            if (id != participation.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(participation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParticipationExists(participation.ID))
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
            return View(participation);
        }

        // GET: Participations/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participation = await _context.Participation.SingleOrDefaultAsync(m => m.ID == id);
            if (participation == null)
            {
                return NotFound();
            }

            return View(participation);
        }

        // POST: Participations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var participation = await _context.Participation.SingleOrDefaultAsync(m => m.ID == id);
            _context.Participation.Remove(participation);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ParticipationExists(int id)
        {
            return _context.Participation.Any(e => e.ID == id);
        }
    }
}
