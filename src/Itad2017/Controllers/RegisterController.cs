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

        public RegisterController(ApplicationDbContext context, IEmailSender emailSender, IDataObjectValidation validationService)
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
        public async Task<IActionResult> Index([Bind("Email,FirstName,SecondName")] Models.Participant participant)
        {
            try
            {
                if (_validationService.ValidateNewParticipant(participant))
                {                
                    _context.SaveNewParticipant(participant);
                    await _context.SaveChangesAsync();
                    //_emailSender.SendEmailAsync("do kogo", "temat", "wiadomosc");
                    return RedirectToAction("Succes");
                }
            }
            catch (ArgumentException exception)
            {
                ViewBag.error = exception.Message;
            }
            
            return View(participant);
        }

        [HttpGet]
        public IActionResult Succes()
        {
            return View();
        }
    }
}