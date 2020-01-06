using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Data.Models
{
   public class Route
    {
        [Required(ErrorMessage ="Zadej misto odkud chces jet")]
        public string startDest { get; set; }
        [Required(ErrorMessage = "Zadej misto kam chces jet")]
        public string finalDestination { get; set; }
        [Required(ErrorMessage = "Zadej datum")]
        public string date { get; set; }
        [Required(ErrorMessage = "Zadej cas")]
        public string time { get; set; }
        [Required(ErrorMessage = "Zadej pocet osob")]
        public int Seats { get; set; }
     
        public double price { get; set; }
    }
}
