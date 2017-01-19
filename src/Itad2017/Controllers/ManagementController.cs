using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itad2017.Controllers
{
    public class ManagementController : Controller
    {
        public ManagementController()
        {

        }

        public ActionResult Index() // login to account
        {
            return View();
        }

        public ActionResult LogOut() // logout from account
        {
            return View();
        }

        public ActionResult Helpers() // list of people assigned to help and prelegents
        {
            return View();
        }

        public ActionResult Participants() // page with list of signed people and managing them
        {
            return View();
        }

        public ActionResult Workshops() // list of all workshops with number of signed people
        {
            return View();
        }

        public ActionResult Workshop() // Details and general informations about one workshop and list of people assigned to this workshop
        {
            return View();
        }
    }
}
