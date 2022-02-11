using hotelApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotelApplication.Controllers
{
    
    public class MainController : Controller
    {
        ApplicationContext context;
        public MainController(ApplicationContext application)
        {
            context = application;
        }
        
        public IActionResult Example()
        {
            return View();
        }

        public IActionResult house()
        {
            return View();
        }

        public IActionResult provider()
        {
            return View();
        }

        public IActionResult events()
        {
            return View();
        }

        public IActionResult rent()
        {
            return View();
        }


        public IActionResult brone()
        {
            return View();
        }


        [Authorize(Roles = "admin")]
        public IActionResult AdminPage()
        {
            return View();
        }


    }
}
