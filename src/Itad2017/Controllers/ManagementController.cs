using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itad2017.Controllers
{
    public class ManagementController
    {
        public ManagementController()
        {

        }

        public IActionResult Index() // login to account
        {
            return View();
        }

        public IActionResult LogOut() // logout from account
        {
            return View();
        }

        public IActionResult Helpers() // list of people assigned to help and prelegents
        {
            return View();
        }

        public IActionResult Participants() // page with list of signed people and managing them
        {
            return View();
        }

        public IActionResult Workshops() // list of all workshops with number of signed people
        {
            return View();
        }

        public IActionResult Workshop() // Details and general informations about one workshop and list of people assigned to this workshop
        {
            return View();
        }
    }
}
