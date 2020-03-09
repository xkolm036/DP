using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarPool.Models;
using CarPool.DbControll;

namespace CarPool.Controllers
{
    public class GeographyController : Controller
    {
        public IActionResult dropDownItems(string geo)
        {
            geo = geo.Trim();
            List<School> school = new List<School>();


            PSSQLControll DB = new PSSQLControll();

            ViewData["City"] = DB.FindCity(geo);
            ViewData["Street"] = DB.FindStreet(geo);
            ViewData["School"] = DB.FindSchool(geo);



            DB.CloseConnection();





            return PartialView();
        }
    }
}