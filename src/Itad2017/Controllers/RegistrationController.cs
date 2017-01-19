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
    public class RegistrationController : Controller
    {
        public RegistrationController()
        {

        }

        public ActionResult Index() // page for registration
        {
            return View();
        }

        public ActionResult Success() // landing after registration
        {
            return View();
        }

        public ActionResult Confirm() // page for email confirm
        {
            return View();
        }

        public ActionResult Finish() // landing after email confirmation
        {
            return View();
        }
    }
}
