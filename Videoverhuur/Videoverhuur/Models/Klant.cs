//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Videoverhuur.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Klant
    {
        public Klant()
        {
            this.Verhuur = new HashSet<Verhuur>();
        }
    
        public int KlantNr { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string Straat_Nr { get; set; }
        public int PostCode { get; set; }
        public string Gemeente { get; set; }
        public string KlantStat { get; set; }
        public int HuurAantal { get; set; }
        public System.DateTime DatumLid { get; set; }
        public bool Lidgeld { get; set; }
    
        public virtual ICollection<Verhuur> Verhuur { get; set; }
    }
}
