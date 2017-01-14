using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Itad2017.Data;
using Itad2017.Services;

namespace Itad2017.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _emailSender;
        private readonly IDataObjectValidation _validationService;

        public RegisterController(ApplicationDbContext context
            , IEmailSender emailSender
            , IDataObjectValidation validationService
            )
        {
            _context = context;
            _emailSender = emailSender;
            _validationService = validationService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("Email,FirstName,LastName")] Models.Participant participant)
        {
            //_validationService.ValidateNewParticipant(participant);
            if (ModelState.IsValid && _context.Participant.Select(n => n).Where(n => n.Email == participant.Email).Count() < 1)
            {                
                _context.Add(participant);
                await _context.SaveChangesAsync();
                //_emailSender.SendEmailAsync("do kogo", "temat", "wiadomosc");
                return RedirectToAction("Succes");
            }

            // cos poszlo nie tak. wracamy na ten sam widok z danymi ktore przyszly ale trzeba jeszcze zadbac o to zeby wyswietlic bleda 
            return View(participant);
        }

        [HttpGet]
        public IActionResult Succes()
        {
            return View();
        }
    }
}