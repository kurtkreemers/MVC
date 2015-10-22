using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBierenApplication.Models
{
    public class Bier
    {
        [DisplayFormat(DataFormatString = "{0:000}")]
        public int ID { get; set; }
        [Required]
        [StringLength(20)]
        public string Naam { get; set; }

        [UIHint("Percentage")]
        [AlcoholValueControl(ErrorMessage="Percentage moet tss 0 en 15 liggen")]
        public float Alcohol { get; set; }
    }
}