using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Videoverhuur.Models
{
    public class VideoVerhuurInfo
    {
        public Genre Genre { get; set; } 
        public List<Genre> Genres { get; set; }
        public List<Film> Films { get; set; } 
    }
}