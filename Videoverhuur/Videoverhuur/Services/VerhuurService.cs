﻿using System;
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
            Int32 pstcode = 0;
            Int32.TryParse(postcode, out pstcode);
            using (var db = new VideoVerhuurEntities())
            {
                return (from klant in db.Klanten
                        where klant.Naam == naam && klant.PostCode == pstcode
                        select klant).FirstOrDefault();
            }
        }
        public List<Genre> GetAllGenres()
        {
            using (var db = new VideoVerhuurEntities())
            {
                return db.Genres.OrderBy(m => m.GenreSoort).ToList();
            }
        }
        public Genre GetGenre(int? id)
        {
            using (var db = new VideoVerhuurEntities())
            {
                return db.Genres.Find(id);
            }
        }
        public List<Film> GetAlleFilmsVanGenre(int id)
        {
            using (var db = new VideoVerhuurEntities())
            {
                var query = from film in db.Films.Include("Genre")
                            where film.GenreNr == id
                            orderby film.Titel
                            select film;
                return query.ToList();
            }

        }
        public Film GetFilm(int? id)
        {
            using (var db = new VideoVerhuurEntities())
            { return db.Films.Find(id); }
        }
        public void Bewaar(List<Film> films, List<Verhuur> verhuringen)
        {
            using (var db = new VideoVerhuurEntities())
            {
                foreach (var verhuring in verhuringen)
                {
                    db.Verhuur.Add(verhuring);
                }

                foreach (var eenfilm in films)
                {
                    var film = db.Films.Find(eenfilm.BandNr);
                    film.InVoorraad = eenfilm.InVoorraad;
                    film.UitVoorraad = eenfilm.UitVoorraad;
                }
                db.SaveChanges();
            }
        }
    }
}