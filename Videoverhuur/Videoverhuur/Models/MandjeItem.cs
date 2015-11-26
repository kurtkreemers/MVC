﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Videoverhuur.Models
{
    public class MandjeItem
    {
        public int BandNr { get; set; }
        public string Titel { get; set; }
        [DisplayFormat(DataFormatString = "{0:€ #,##0.00}")]
        public decimal Prijs { get; set; } public short Plaatsen { get; set; }       
        public MandjeItem(int nr, string titel, decimal prijs)
        {
            BandNr = nr;
            Titel = titel;
            Prijs = prijs;          
        }
    }
}