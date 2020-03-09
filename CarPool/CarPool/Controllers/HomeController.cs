using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarPool.Models;
using Data;
using Microsoft.AspNetCore.Authorization;
using CarPool.Areas.Identity.Pages.Account;
using CarPool.Data;
using System.ComponentModel.DataAnnotations;

namespace CarPool.Controllers
{
   
    public class HomeController : Controller
    {

     




        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }


    

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
