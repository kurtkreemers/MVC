using BierenMVCSecurity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BierenMVCSecurity.Services
{
    public class BierService
    {

        static BierService()
        {
        }
        public Bier Read(int id)
        {
            using (var db = new MVCBierenEntities())
            {
                return db.Bieren.Find(id);
            }
        }

        public void Delete(int id)
        {
            using (var db = new MVCBierenEntities())
            {
                Bier bier = db.Bieren.Find(id);
                db.Bieren.Remove(bier);
                db.SaveChanges();
            }
        }
        public List<Bier> FindAll()
        {
            using (var db = new MVCBierenEntities())
            {
                return db.Bieren.OrderBy(m => m.BierNr).ToList();
            }
        }
        public void Add(Bier b)
        {
            using (var db = new MVCBierenEntities())
            {
                db.Bieren.Add(b);
                db.SaveChanges();
            }
        }
    }

}