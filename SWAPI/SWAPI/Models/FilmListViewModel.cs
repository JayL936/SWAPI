using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWAPI.Models
{
    public class FilmListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }       
        public string Url { get; set; }       

        public FilmListViewModel(Film film)
        {
            Id = film.EpisodeId;
            Title = film.Title;
            Url = film.Url;
        }
    }
}
