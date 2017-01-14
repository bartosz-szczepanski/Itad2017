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
    public class ParticipantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParticipantsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Participants
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Participant.ToListAsync());
        }

        [Authorize]
        // GET: Participants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participant = await _context.Participant.SingleOrDefaultAsync(m => m.ID == id);
            if (participant == null)
            {
                return NotFound();
            }

            return View(participant);
        }

        // GET: Participants/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Participants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("ID,Email,FirstName,SecondName")] Participant participant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(participant);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(participant);
        }

        // GET: Participants/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participant = await _context.Participant.SingleOrDefaultAsync(m => m.ID == id);
            if (participant == null)
            {
                return NotFound();
            }
            return View(participant);
        }

        // POST: Participants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Email,FirstName,SecondName")] Participant participant)
        {
            if (id != participant.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(participant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParticipantExists(participant.ID))
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
            return View(participant);
        }

        // GET: Participants/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participant = await _context.Participant.SingleOrDefaultAsync(m => m.ID == id);
            if (participant == null)
            {
                return NotFound();
            }

            return View(participant);
        }

        // POST: Participants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var participant = await _context.Participant.SingleOrDefaultAsync(m => m.ID == id);
            _context.Participant.Remove(participant);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ParticipantExists(int id)
        {
            return _context.Participant.Any(e => e.ID == id);
        }
    }
}
