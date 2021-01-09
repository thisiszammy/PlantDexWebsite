using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlantDex.Application.DTO.UserManagement;

namespace PlantDex.Api.Controllers
{
    public class UsersController : Controller
    {
        [HttpGet]
        [Route("/management/admins")]
        public IActionResult Admins()
        {
            return View();
        }

        [HttpGet]
        [Route("/management/admins/add")]
        public IActionResult AddAdmin()
        {

            return View("AddAdmin");
        }

        [HttpPost]
        [Route("/management/admins/add")]
        public IActionResult AddAdmin(RegisterViewModel registerViewModel)
        {


            return View();
        }


    }
}
