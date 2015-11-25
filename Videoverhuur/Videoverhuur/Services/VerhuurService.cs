using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Videoverhuur.Models;

namespace Videoverhuur.Services
{
    public class VerhuurService
    {
        public Klant GetKlant(string naam, string postcode)
        {
            Int32 pstcode=0;
            Int32.TryParse(postcode,out pstcode);
            using (var db = new VideoVerhuurEntities())
            {
                return (from klant in db.Klanten
                        where klant.Naam == naam && klant.PostCode == pstcode
                        select klant).FirstOrDefault();
            }
        }
    }
}