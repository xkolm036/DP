using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarPool.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace CarPool.Controllers.Tests
{
    [TestClass()]
    public class GeographyControllerTests
    {
        private IMemoryCache _cache;
        private List<CarPool.Models.City> cities;
        private List<CarPool.Models.City> streets;

        [TestInitialize]
        public void SetUp()
        {
            //build cache
            var services = new ServiceCollection();
            services.AddMemoryCache();
            var serviceProvider = services.BuildServiceProvider();
            _cache = serviceProvider.GetService<IMemoryCache>();

            cities = new List<Models.City>();
            streets = new List<Models.City>();
            List<CarPool.Models.School> schools = new List<Models.School>();

            //set testing data
            cities.Add(new Models.City() { cityName = "Jílové u Prahy", regionName = "Praha-západ", streetName = null });
            cities.Add(new Models.City() { cityName = "Praha", regionName = "Hlavní město Praha", streetName = null });
            streets.Add(new Models.City() { cityName = "Praha", regionName = "Hlavní město Praha", streetName = "Nad Prahou" });
            schools.Add(new Models.School() { name = "czu", shortName = "czu" });

            //add data to cache
            _cache.Set("CityList", cities);
            _cache.Set("StreetList", streets);
            _cache.Set("SchoolList", schools);
        }


        [TestMethod()]
        public void dropDownItemsTest()
        {
            GeographyController geographyController = new GeographyController(_cache);
            var result = geographyController.dropDownItems("Prah") as PartialViewResult;

            ViewDataDictionary viewData = result.ViewData;
            foreach (CarPool.Models.City c in cities)
            {
                Assert.IsTrue((viewData["City"] as List<CarPool.Models.City>).Contains(c));
            }

            foreach (CarPool.Models.City s in streets)
            {
                Assert.IsTrue((viewData["Street"] as List<CarPool.Models.City>).Contains(s));
            }
            Assert.IsTrue((viewData["School"] as List<CarPool.Models.School>).Count == 0);

        }


    }
}