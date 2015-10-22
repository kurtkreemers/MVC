using MVCBierenApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBierenApplication.Services
{
    public class BierService
    {
        private static Dictionary<int, Bier> bierenDictionary = new Dictionary<int, Bier>();

        static BierService()
        {
            bierenDictionary[1] = new Bier { ID = 1, Naam = "Jupiler", Alcohol = 0.8f };
            bierenDictionary[2] = new Bier { ID = 2, Naam = "Leffe", Alcohol = 2.2f };
            bierenDictionary[3] = new Bier { ID = 3, Naam = "Hoegaarden", Alcohol = 5.3f };
            bierenDictionary[4] = new Bier { ID = 4, Naam = "Stella Artois", Alcohol = 8.3f };
        }
        public Bier Read(int id)
        {
            return bierenDictionary[id];
        }

        public void Delete(int id)
        {
            bierenDictionary.Remove(id);
        }
        public List<Bier> FindAll()
        {
            return bierenDictionary.Values.ToList();
        }
        public void Add(Bier b)
        {
            b.ID = bierenDictionary.Keys.Max() + 1;
            bierenDictionary.Add(b.ID, b);
        }
    }

}