using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Itad2017.Data;
using Itad2017.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Itad2017.Models;

namespace Itad2017.Controllers
{
    public class RegistrationConfrimController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _emailSender;

        public RegistrationConfrimController(ApplicationDbContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int? id)
        {
            //var user = _context.Participant.Select(n => n).Where(n => n.ID == 2003).First();
            //var detail2 = new Detail();
            //detail2.IsConfirmed = false;
            //detail2.IsPresent = false;
            //detail2.Code = "AAA";
            //detail2.RegisterTime = DateTime.Now;
            //user.Details = detail2;

            //_context.Add(detail2);
            //_context.Update(user);

            if (id == null)
            {
                return NotFound();
            }

            var participant = await _context.Participant.Include(n=>n.Details).SingleOrDefaultAsync(m => m.ID == id);
            if (participant == null)
            {
                return NotFound();
            }

            var detail = await _context.Detail.SingleOrDefaultAsync(m => m == participant.Details);
            detail.IsConfirmed = true;
            _context.Update(participant.Details);
            ViewBag.Workshops = await _context.Workshop.ToListAsync();
            await _context.SaveChangesAsync();
            return View(participant.Details);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string TshirtSize, int WorkShop, int ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            var participant = await _context.Participant.Include(n => n.Details).SingleOrDefaultAsync(m => m.ID == ID);
            var workshop = _context.Workshop.FirstOrDefault(n => n.ID == WorkShop);
            if (participant.Details != null)
            {
                participant.Details.TshirtSize = TshirtSize;
                _context.Update(participant.Details);
                if (workshop!=null)
                {
                    var partic = new Participation() { Workshop = workshop, Who = participant };
                    _context.Add(partic);
                }                    

                await _context.SaveChangesAsync();
                return RedirectToAction("Success");
            }

            return Redirect("/RegistrationConfrim?id="+ ID);
        }

        [HttpGet]
        public IActionResult Success()
        {
            return View();
        }
    }
}