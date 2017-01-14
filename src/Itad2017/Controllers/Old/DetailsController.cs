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
    public class DetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DetailsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Details
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Detail.ToListAsync());
        }

        // GET: Details/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detail = await _context.Detail.SingleOrDefaultAsync(m => m.ID == id);
            if (detail == null)
            {
                return NotFound();
            }

            return View(detail);
        }

        // GET: Details/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("ID,Code,IsConfirmed,IsPresent,RegisterTime,TshirtSize")] Detail detail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detail);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(detail);
        }

        // GET: Details/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detail = await _context.Detail.SingleOrDefaultAsync(m => m.ID == id);
            if (detail == null)
            {
                return NotFound();
            }
            return View(detail);
        }

        // POST: Details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Code,IsConfirmed,IsPresent,RegisterTime,TshirtSize")] Detail detail)
        {
            if (id != detail.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetailExists(detail.ID))
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
            return View(detail);
        }

        // GET: Details/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detail = await _context.Detail.SingleOrDefaultAsync(m => m.ID == id);
            if (detail == null)
            {
                return NotFound();
            }

            return View(detail);
        }

        // POST: Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detail = await _context.Detail.SingleOrDefaultAsync(m => m.ID == id);
            _context.Detail.Remove(detail);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool DetailExists(int id)
        {
            return _context.Detail.Any(e => e.ID == id);
        }
    }
}
