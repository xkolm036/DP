using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;



namespace CarPool.Models
{
    [Table("route")]
    public class Route
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Column("startdestination")]
        [Required(ErrorMessage ="Zadej misto odkud chces jet")]
        public string startDestination { get; set; }

        [Column("finaldestination")]
        [Required(ErrorMessage = "Zadej misto kam chces jet")]
        public string finalDestination { get; set; }

        [Column("date")]
        [Required(ErrorMessage = "Zadej datum")]
        public DateTime date { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Zadej cas")]
        public virtual DateTime time { get; set; }

        [Column("seats")]
        [Required(ErrorMessage = "Zadej pocet osob")]
        public int seats { get; set; }

        [Column("price")]
        public double price { get; set; }

        public IList<RouteUser> RouteUser { get; set; }

    }
}
