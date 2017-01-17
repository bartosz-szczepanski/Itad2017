using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itad2017.Controllers
{
    public class RegistrationController
    {
        public RegistrationController()
        {

        }

        public IActionResult Index() // page for registration
        {
            return View();
        }

        public IActionResult Success() // landing after registration
        {
            return View();
        }

        public IActionResult Confirm() // page for email confirm
        {
            return View();
        }

        public IActionResult Finish() // landing after email confirmation
        {
            return View();
        }
    }
}
