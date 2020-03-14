using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarPool.Models;
using Data;

namespace CarPool.Controllers
{
    public class GeographyController : Controller
    {
        public IActionResult dropDownItems(string geo)
        {
            geo = geo.Trim();

            //PSSQLControll DB = new PSSQLControll();

            MSSQL DB = new MSSQL();
            ViewData["City"] = DB.FindCity(geo);
            ViewData["Street"] = DB.FindStreet(geo);
            ViewData["School"] = DB.FindSchool(geo);

            DB.CloseConnection();





            return PartialView();
        }
    }
}