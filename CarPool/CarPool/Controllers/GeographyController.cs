using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarPool.Models;
using CarPool.GeoDbProvider;
using Microsoft.Extensions.Caching.Memory;
using System.Text;
using System.Globalization;
using MoreLinq;

namespace CarPool.Controllers
{
    public class GeographyController : Controller
    {
        private IMemoryCache _cache;
        private List<City> AllCities()
        {
            MSSQL DB = new MSSQL();
            List<City> allCities = new List<City>();
            allCities = DB.GetAllCity();
            DB.CloseConnection();
            return allCities;

        }

        private List<City> AllStreets()
        {
            MSSQL DB = new MSSQL();
            List<City> allStreets = new List<City>();
            allStreets = DB.GetAllStreets();
            DB.CloseConnection();
            return allStreets;

        }
        private List<School> AllSchools()
        {
            List<School> allSchools = new List<School>();
            MSSQL DB = new MSSQL();
            allSchools = DB.FindAllSchools();
            DB.CloseConnection();
            return allSchools;

        }
        [Route("/geo/allcity")]

        private static string RemoveDiacritics(String s)
        {
            String normalizedString = s.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < normalizedString.Length; i++)
            {
                Char c = normalizedString[i];
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    stringBuilder.Append(c);
            }

            return stringBuilder.ToString();
        }

        public List<City> GetAllCities()
        {
            List<City> cities;
            if (!_cache.TryGetValue("CityList", out cities))
            {

                if (cities == null)
                {
                    cities = AllCities();
                }
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetPriority(CacheItemPriority.NeverRemove);
                _cache.Set("CityList", cities, cacheEntryOptions);



            }
            return cities;
        }

        [Route("/geo/AllStreets")]
        public List<City> GetAllStreets()
        {
            List<City> streets;
            if (!_cache.TryGetValue("StreetList", out streets))
            {

                if (streets == null)
                {
                    streets = AllStreets();
                }
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                  .SetPriority(CacheItemPriority.NeverRemove);
                _cache.Set("StreetList", streets, cacheEntryOptions);

            }
            return streets;
        }

        [Route("/geo/allschools")]
        public List<School> GetAllSchools()
        {
            List<School> schools;
            if (!_cache.TryGetValue("SchoolList", out schools))
            {

                if (schools == null)
                {
                    schools = AllSchools();
                }
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                  .SetPriority(CacheItemPriority.NeverRemove);
                _cache.Set("SchoolList", schools, cacheEntryOptions);

            }
            return schools;
        }



        public GeographyController(IMemoryCache cache)
        {
            _cache = cache;

        }




        public IActionResult dropDownItems(string geo)
        {
            geo = geo.Trim();

            //PSSQLControll DB = new PSSQLControll();

            //MSSQL DB = new MSSQL();
            //ViewData["City"] = DB.FindCity(geo);
            //ViewData["Street"] = DB.FindStreet(geo);
            //ViewData["School"] = DB.FindSchool(geo);

            //DB.CloseConnection();

            ViewData["City"] = (from City c in GetAllCities()
                                where RemoveDiacritics(c.cityName.ToUpper()).Contains(RemoveDiacritics(geo.ToUpper()))
                                select c).Distinct().Take(4).ToList();


            ViewData["Street"] = (from City c in GetAllStreets()
                                  where RemoveDiacritics(c.streetName.ToUpper()).Contains(RemoveDiacritics(geo.ToUpper()))
                                  || (geo.Split(" ").Count() > 1 && RemoveDiacritics(c.cityName + " " + c.streetName).ToUpper().Contains(RemoveDiacritics(geo.ToUpper())))
                                  select c).Distinct().Take(4).ToList();

            ViewData["School"] = (from School s in GetAllSchools()
                                  where RemoveDiacritics(s.name.ToUpper()).Contains(RemoveDiacritics(geo.ToUpper())) || RemoveDiacritics(s.shortName.ToUpper()).Contains(RemoveDiacritics(geo.ToUpper()))
                                  select s).Take(2).ToList();



            return PartialView();
        }
    }
}