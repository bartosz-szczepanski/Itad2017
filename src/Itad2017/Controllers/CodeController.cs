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
    public class CodeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _emailSender;

        public CodeController(ApplicationDbContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? id)
        {
            //tutaj musisz wyrenderowac widok z 3 polami
            //imie
            //nazwisko
            // 3 literowy kod
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string TshirtSize, int WorkShop, int ID)
        {
            return Redirect("/Congratulations");
        }

        [HttpGet]
        public async Task<IActionResult> Congratulations()
        {
            //tutaj musisz wyrenderowac widok z informacjami co dalej ma zrobic jak juz potwierdzil ze przyszedl
            return View();
        }
    }
}