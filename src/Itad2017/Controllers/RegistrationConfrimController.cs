using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Itad2017.Data;
using Itad2017.Services;
using Microsoft.EntityFrameworkCore;

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
            if (id == null)
            {
                return NotFound();
            }

            var participant = await _context.Participant.SingleOrDefaultAsync(m => m.ID == id);
            if (participant == null)
            {
                return NotFound();
            }

            participant.Details = new Models.Detail() { IsConfirmed = true, RegisterTime = DateTime.Today };
            _context.Participant.Add(participant);
            return View(participant);
        }
    }
}