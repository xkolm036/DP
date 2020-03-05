using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExternalData.Models
{
    [Table("tst")]
    public class tst
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Column("startdest")]
        public string startDest { get; set; }
        [Column("finaldest")]
        public string finalDestination { get; set; }
    }
}
