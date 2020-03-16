using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarPool.Data;
using CarPool.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarPool.Controllers
{
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CarsController(ApplicationDbContext db)
        {
            _db = db;
        }


        [Route("/myCars")]
        public IActionResult ShowMyCars()
        {    
            ViewData["Cars"] = _db.cars.ToList();
            return View("ShowMyCars");
        }
    }
}