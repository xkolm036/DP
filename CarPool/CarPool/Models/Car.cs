using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarPool.Models
{
    public class Car
    {
        [Key]
        public int id { get; set; }
        public AppUser AppUser { get; set; }
        public string color { get; set; }
        public string spz { get; set; }
        public int seats { get; set; }
        public string model { get; set; }
        public string brand { get; set; }
        public string image { get; set; }
        public string description { get; set; }


    }
}
