using System;
using System.Collections.Generic;
using System.Linq;
using CarPool.Data;
using CarPool.Models;
using Microsoft.AspNetCore.Authorization;
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


        [Route("/Car/My")]
        public IActionResult ShowMyCars()
        {    
            ViewData["Cars"] = _db.cars.ToList();
            return View("ShowMyCars");
        }

        [Route("/Car/Add")]
        [HttpPost]
        public IActionResult AddCar()
        {
            List<Car> cars = new List<Car>();
            cars.Add(new Car());
            ViewData["Cars"] = cars;
            return PartialView("_PartialGenerateCards");
        }

        



    }
}