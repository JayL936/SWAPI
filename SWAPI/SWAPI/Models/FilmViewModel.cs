using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWAPI.Models
{
    public class FilmViewModel
    {
        public int EpisodeId { get; set; }
        public string Title { get; set; }
        public int Votes { get; set; }
        public float Score { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public string ReleaseDate { get; set; }

        public FilmViewModel(Film film)
        {
            EpisodeId = film.EpisodeId;
            Title = film.Title;
            Url = film.Url;
            Description = film.Description;
            Director = film.Director;
            Producer = film.Producer;
            ReleaseDate = film.ReleaseDate;
        }
    }
}
